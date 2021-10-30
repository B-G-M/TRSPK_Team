using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleApp;
namespace UserInterface
{
    
    public partial class Form1 : Form
    {
        BusinessLogic logic = new BusinessLogic();
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            int k = 0;
            foreach (var client in logic.Clients)
            {
                DateTime date = client.Date;
                textBox1.Text += "Клиент №: " + k + Environment.NewLine +
                                 "ФИО : " + client.FullName + Environment.NewLine +
                                 "Тип вклада: " + client.TypeContribution + Environment.NewLine +
                                 "Сумма вклада: " + client.Sum + Environment.NewLine +
                                 "Дата вклада: " + date.ToShortDateString() + Environment.NewLine +
                                 "Срок вклада: " + client.Term + Environment.NewLine + Environment.NewLine;
                k++;
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2(this);
            newForm.Show();
        }
        string fio,tc,sum,date,term,str = "";

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            int k = 0;
            int number;
            number = int.Parse(textBox3.Text);
            foreach (var client in logic.Clients)
            {
                DateTime date = client.Date;
                if (k == number)
                {
                    textBox1.Text += "Клиент №: " + k + Environment.NewLine +
                                 "ФИО : " + client.FullName + Environment.NewLine +
                                 "Тип вклада: " + client.TypeContribution + Environment.NewLine +
                                 "Сумма вклада: " + client.Sum + Environment.NewLine +
                                 "Дата вклада: " + date.ToShortDateString() + Environment.NewLine +
                                 "Срок вклада: " + client.Term + Environment.NewLine + Environment.NewLine;
                    break;
                }
                k++;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int num = int.Parse(textBox3.Text);
            logic.DellClient(num);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            client.FullName = textBox2.Text;
            client.TypeContribution = comboBox1.Text;
            client.Sum = double.Parse(textBox4.Text);
            client.Date = DateTime.Parse(textBox5.Text);
            client.Term = int.Parse(textBox6.Text);
            logic.AddClient(client);
        }
    }
    
}
