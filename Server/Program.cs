using System.Net.Sockets;
using System.Net;

namespace Server
{
    public class ChatServer
    {
        const short port = 4040;
        const string serverAddress = "127.0.0.1";

        TcpListener server = null;
        public ChatServer()
        {
            server = new TcpListener(new IPEndPoint(IPAddress.Parse(serverAddress), port));
        }
        public void Start()
        {
            server.Start();
            Console.WriteLine("Waiting for connection!....");
            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("Connected!!!");
            AnswerDbContext context = new AnswerDbContext();
            NetworkStream ns = client.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            while (true)
            {
                string message = sr.ReadLine();
                var Phrase = context.Answers
                                    .Where(x => x.Phrase == message);
                foreach ( var x in Phrase ) 
                {
                    sw.WriteLine(x.AnswerToPhrase);
                }
                sw.Flush();
            }

            //var Phrase = context.Answers;
            //foreach (var answer in Phrase)
            //{
            //    Console.Write(answer.Phrase);
            //    Console.WriteLine(answer.AnswerToPhrase);
            //}
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                ChatServer server = new ChatServer();
                server.Start();
            }
        }
    }
}
