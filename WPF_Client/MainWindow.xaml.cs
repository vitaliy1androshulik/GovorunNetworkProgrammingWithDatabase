using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IPEndPoint serverPoint;
        TcpClient client;
        ObservableCollection<MessageInfo> messages;
        NetworkStream ns = null;
        StreamReader sr = null;
        StreamWriter sw = null;
        public MainWindow()
        {
            InitializeComponent();
            TextBoxIp.Text = ConfigurationManager.AppSettings["ServerAddress"];
            TextBoxPort.Text = ConfigurationManager.AppSettings["ServerPort"];
            client = new TcpClient();
            string address = ConfigurationManager.AppSettings["ServerAddress"]!;
            short port = short.Parse(ConfigurationManager.AppSettings["ServerPort"]!);
            serverPoint = new IPEndPoint(IPAddress.Parse(address), port);//точка нашого сервера
            messages = new ObservableCollection<MessageInfo>();
            this.DataContext = messages;
            Connect();
        }
        private async void Listen()
        {
            while (true)
            {
                string? message = await sr.ReadLineAsync();
                messages.Add(new MessageInfo(message));
            }
        }
        private void Connect()
        {
            try
            {
                client.Connect(serverPoint);
                ns = client.GetStream();

                sw = new StreamWriter(ns);
                sr = new StreamReader(ns);
                Listen();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }        
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string message = TextBoxText.Text;
            sw.WriteLine(message);
            sw.Flush();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            WPF_AddWindow windows = new WPF_AddWindow();
            windows.Show();
        }
    }

    class MessageInfo
    {
        public string Text { get; set; }
        public DateTime Time { get; set; }
        public MessageInfo(string text)
        {
            this.Text = text??"";
            Time = DateTime.Now;
        }
        public override string ToString()
        {
            return $"{Text,-50} {Time.ToShortTimeString()}";
        }
    }
}