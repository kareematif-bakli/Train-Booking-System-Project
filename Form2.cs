using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SW__Project
{
    public partial class Form2 : Form
    {
        private string St;
        private string En;
        private string Da;
        private string T_NA;
        private int  T_NU;
        private int Seatt;
        public Form2(string St, string En, string Da, string T_NA, int T_NU, int Seatt)
        {
            this.St = St;
            this.En = En;
            this.Da = Da;
            this.T_NA = T_NA;
            this.T_NU = T_NU;
            this.Seatt = Seatt;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text== "Credit Cards")
            {
                label1.Text = "Credit ID";
                label2.Text = "Password";
            }
            if (comboBox1.Text == "PayPal")
            {
                label1.Text = "PayPal ID";
                label2.Text = "Password";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 a = new Form4();
            Form2 b = new Form2("", "", "", "",1, 1); Hide();
            a.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            Form2 b = new Form2("", "", "", "", 1, 1); Hide();
            a.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Customer Name:"+textBox1.Text+Environment.NewLine+$"Mail Id:"+textBox5.Text+Environment.NewLine+$"Ticket Information" + Environment.NewLine + $"Start Place is:{St}" + Environment.NewLine +
                $"Destination is:{En}" + Environment.NewLine + $"On Date:{Da}" + Environment.NewLine +
                $"Train_Name is:{T_NA}" + Environment.NewLine + $"Train_Number is:{T_NU}"+Environment.NewLine+
                $"Seat is:{Seatt}");
        }
    }
}
