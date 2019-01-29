using MySql.Data.MySqlClient;
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
    public partial class Form1 : Form
    {
        private MySqlConnection conn;
        private string Server;
        private string database;
        private string uid;
        private string password;
        private string Star;
        private string Endi;
        private int train_Nu;
        private string train_Na;
        private string datte;
        private int seat;

        public Form1()
        {
            Server = "localhost";
            database = "train";
            uid = "root";
            password = "";

            string connString;
            connString = $"SERVER={Server};DATABASE={database};UID={uid};PASSWORD={3453453459};";
            DateTime date = DateTime.Now.Date;
            DateTime.Now.ToLongDateString();
            conn = new MySqlConnection(connString);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (comboBox1.Text== "Assuit ")
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add('1');
                comboBox3.Items.Add('4');

            }
            else
                if(comboBox1.Text == "Cairo")
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add('2');
                comboBox3.Items.Add('4');
            }
            else
                if(comboBox1.Text == "Alexandria")
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add('1');
                comboBox3.Items.Add('2');
            }
            else
                if(comboBox1.Text == "Beni Suef")
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add('1');
                comboBox3.Items.Add('3');
            }
            else
                if(comboBox1.Text == "Red Sea")
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add('2');
                comboBox3.Items.Add('3');
            }
            else
                if(comboBox1.Text == "South Sinai")
            {
                comboBox3.Items.Clear();
                comboBox3.Items.Add('3');
                comboBox3.Items.Add('4');
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox4.Text;
            seat = int.Parse(textBox1.Text);
            comboBox4.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Star = comboBox1.Text;
            Endi = comboBox2.Text;
            train_Nu = int.Parse(comboBox3.Text);
            train_Na = textBox10.Text;
            datte = textBox9.Text;
            // seat = int.Parse(textBox1.Text);
            comboBox4.Items.Clear();
            for (int i = 1; i <= 60; i++)
            {
                if (!Islogin(train_Nu, train_Na, i, datte, Star, Endi))
                {
                    comboBox4.Items.Add(i);
                }

            }

        }
        public bool Islogin(int train_Nu, string train_Na, int seat, string datte, string Star, string Endi)
        {
              string query = $"SELECT * FROM trai WHERE train_number='{train_Nu}' AND train_name='{train_Na}' AND seat='{seat}' AND start_place='{Star}' AND end_place='{Endi}' AND date='{datte}';";
            try
            {
                   if (OpenConnection())
                   {
                       MySqlCommand cmd = new MySqlCommand(query, conn);
                       MySqlDataReader reader = cmd.ExecuteReader();

                       if (reader.Read())
                       {
                           reader.Close();
                           conn.Close();
                           return true;
                       }
                       else
                       {
                           reader.Close();
                           conn.Close();
                           return false;
                       }
                   }
                   else
                   {
                       conn.Close();
                       return false;
                   }
               }
               catch (Exception ex)
               {
                   conn.Close();
                   return false;
               }

           }
           private bool OpenConnection()
           {
               try
               {
                   conn.Open();
                   return true;
               }
               catch (MySqlException ex)
               {
                   switch (ex.Number)
                   {
                       case 0:
                           MessageBox.Show("Connection to the server Failed!");
                           break;
                       case 1045:
                           MessageBox.Show("Sever Username or Password is in Correct");
                           break;
                   }
                   return false;
               }
               
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "1")
            {
                textBox10.Text = "Armada";
            }
            else
                 if (comboBox3.Text == "2")
            {
                textBox10.Text = "Atlantic Coast Express";
            }
            else
                 if (comboBox3.Text == "3")
            {
                textBox10.Text = "Golden Arrow";
            }
            else
                 if (comboBox3.Text == "4")
            {
                textBox10.Text = "Bullet Train";
            }


            if (comboBox3.Text == "1")
            {
                textBox6.Text = "150$";
            }
            else
               if (comboBox3.Text == "2")
            {
                textBox6.Text = "75$";
            }
            else
               if (comboBox3.Text == "3")
            {
                textBox6.Text = "100$";
            }
            else
               if (comboBox3.Text == "4")
            {
                textBox6.Text = "125$";
            }

        }
        public bool Register(int train_Nu, string train_Na, int seat, string datte, string Star, string Endi)
        {
   string query = $"INSERT INTO trai (id, train_number, train_name, seat, start_place, end_place, date) VALUES ('','{train_Nu}','{ train_Na}','{seat}','{ Star}','{Endi}','{datte}');";
            //  string query = $"INSERT INTO users (id, username, password) VALUES ('','{user}','{pass}');";
            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        string s = "MySqlException: " + ex.ToString();
                        MessageBox.Show(s, "Error", buttons);
                        return false;
                    }
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                return false;
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(Register(train_Nu, train_Na, seat, datte, Star, Endi) && seat!=0)
            {
                MessageBox.Show($"Ticket of train_Number: {train_Nu} ," + Environment.NewLine +
                                   $"train_Name is :{train_Na}, seat is :{seat}" + Environment.NewLine +
                                   $"on date :{datte},"+ Environment.NewLine +$"starting place is:{Star}," + Environment.NewLine+
                                   $"ending place is:{Endi} Is Reserved");
                Form2 a = new Form2(Star, Endi, datte, train_Na, train_Nu, seat);
                Form1 b = new Form1(); Hide();
                a.Show();
            }
           else
            {
                MessageBox.Show($"Ticket doen't Reserved");
            }
                   // public Form2(string St, string En, string Da, string T_NA, int T_NU, int Seatt)
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

      

        private void button1_Click_1(object sender, EventArgs e)
        {
          
        }
       
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.Text==comboBox1.Text)
                MessageBox.Show(" Start Place can't be The End Place" + Environment.NewLine + ", Plese Check your Destination again");
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
    
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Form4 a = new Form4();
            Form1 b = new Form1();Hide();
            a.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
