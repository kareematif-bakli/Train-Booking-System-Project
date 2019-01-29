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

    public partial class Form4 : Form
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
        public Form4()
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

        private void Form4_Load(object sender, EventArgs e)
        {

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
        private void button1_Click(object sender, EventArgs e)
        {
            int seat2;
            string Start = comboBox6.Text;
            string Endl = comboBox5.Text;
            string train_Nam = comboBox7.Text;
            string daatte = textBox5.Text;
            if (textBox2.Text != "")
            {
                seat2 = int.Parse(textBox2.Text);
            }
            else
                seat2 = 0;
            if (Islogin2(Start, Endl, train_Nam, daatte, seat2) && seat2!=0)
            {
                Delete(Start, Endl, train_Nam, daatte, seat2);
                MessageBox.Show("Ticket Deleted Successfully");
            }
            else
            {
                MessageBox.Show("Enetr Rigth Information of Ticket" + Environment.NewLine + "That You Want To Delete.");
            }
        }
        public bool Delete(string Start, string Endl, string train_Nam, string daatte, int seat2)
        {
            string query = $"DELETE FROM trai WHERE train_name='{train_Nam}' AND seat='{seat2}' AND start_place='{Start}' AND end_place='{Endl}';";
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
        public bool Islogin2(string Start, string Endl, string train_Nam, string daatte, int seat2)
        {
            string query = $"SELECT * FROM trai WHERE train_name='{train_Nam}' AND seat='{seat2}' AND start_place='{Start}' AND end_place='{Endl}' AND date='{daatte}';";
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
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.Text == comboBox6.Text)
                MessageBox.Show(" Start Place can't be The End Place" + Environment.NewLine + ", Plese Check your Destination again");
        }
        

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox6.Text == "Assuit ")
            {
                comboBox7.Items.Clear();
                comboBox7.Items.Add("Armada");
                comboBox7.Items.Add("Bullet Train");

            }
            else
             if (comboBox6.Text == "Cairo")
            {
                comboBox7.Items.Clear();
                comboBox7.Items.Add("Atlantic Coast Express");
                comboBox7.Items.Add("Bullet Train");
            }
            else
             if (comboBox6.Text == "Alexandria")
            {
                comboBox7.Items.Clear();
                comboBox7.Items.Add("Armada");
                comboBox7.Items.Add("Atlantic Coast Express");
            }
            else
             if (comboBox6.Text == "Beni Suef")
            {
                comboBox7.Items.Clear();
                comboBox7.Items.Add("Armada");
                comboBox7.Items.Add("Golden Arrow");
            }
            else
             if (comboBox6.Text == "Red Sea")
            {
                comboBox7.Items.Clear();
                comboBox7.Items.Add("Atlantic Coast Express");
                comboBox7.Items.Add("Golden Arrow");
            }
            else
             if (comboBox6.Text == "South Sinai")
            {
                comboBox7.Items.Clear();
                comboBox7.Items.Add("Golden Arrow");
                comboBox7.Items.Add("Bullet Train");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            Form4 b = new Form4();Hide();
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
