using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using ConsoleApp;
namespace UserInterface
{
    public partial class Form2 : Form
    {
        BusinessLogic logic = new BusinessLogic();
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Form1 f)
        {
            InitializeComponent(); 
        }
       

        string dateF = "";
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dateF = textBox1.Text;
            
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
       
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Parse(dateF);
            textBox2.Text = logic.NeedToPay(date).ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            double[] volume = logic.VolumeOfDeposits();

            for (int i = 0; i < 12; i++)
            {
                if(!double.IsNaN(volume[i]))
                {
                    textBox3.Text += CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i + 1)
                        + ": " + volume[i].ToString() + Environment.NewLine;
                    continue;
                }
                textBox3.Text += CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i + 1)
                                                 + ": нет выплат в данном месяце \n";
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            List<double> profit = logic.ProductsProfit();
            int i = 0;
            foreach (var client in profit)
            {
                i++;
                textBox4.Text += "Клиент №" + i + ": " + client + Environment.NewLine;
            }
        }

       
    }
}
