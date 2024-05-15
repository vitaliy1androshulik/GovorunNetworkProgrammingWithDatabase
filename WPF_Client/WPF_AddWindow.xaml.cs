using Server;
using Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_Client
{
    /// <summary>
    /// Interaction logic for WPF_AddWindow.xaml
    /// </summary>
    public partial class WPF_AddWindow : Window
    {
        AnswerDbContext context;
        public WPF_AddWindow()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Answer answer = new Answer();
            Answer AnswerForDB = context.Answers.FirstOrDefault(u => u.Phrase == answer.Phrase);
            answer.AnswerToPhrase = TextBoxAnswer.Text;
            answer.Phrase= TextBoxPhrase.Text;
            if(AnswerForDB!=null && AnswerForDB.Phrase == TextBoxPhrase.Text)
            {
                MessageBox.Show("This phrase already exists");
            }
            else
            {
                context.Answers.Add(answer);
                context.SaveChanges();
                MessageBox.Show("Phrase and answer added!");
                this.Close();
            }
            
        }
    }
}
