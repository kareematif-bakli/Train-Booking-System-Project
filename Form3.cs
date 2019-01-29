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
    public partial class Form3 : Form
    {
        private MySqlConnection conn;
        private string Server;
        private string database;
        private string uid;
        private string password;
        private string user;
        private string password2;
        public Form3()
        {
            Server = "localhost";
            database = "tut";
            uid = "root";
            password = "";
            string connString;
            connString = $"SERVER={Server};DATABASE={database};UID={uid};PASSWORD={3453453459};";
            conn = new MySqlConnection(connString);
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             user = textBox1.Text;
             password2 = textBox2.Text;
            if (textBox1.Text == "" || textBox2.Text == "")
                MessageBox.Show("Unvalid Username or Password");
            bool dupilcate = false;
            if(Islogin2(user))
                {
                dupilcate = true;
                }
            if (!dupilcate)
            {
                if (Register(user, password2) && (textBox1.Text != "" && textBox2.Text != ""))
                {

                    MessageBox.Show($"User {user} Has been Created.");
                }
                else
                {
                    MessageBox.Show($"User {user} Hasn't been Created.");
                }
            }
            else
            {
                MessageBox.Show($"Username {user} Has been already taken.");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
             user = textBox1.Text;
             password2 = textBox2.Text;
            if (Islogin(user,password2))
            {
                MessageBox.Show($"Welcome {user} !");
                Form1 a = new Form1();
                Form3 b = new Form3(); Hide();
                a.Show();
            }
            else
            {
                MessageBox.Show($"{user} doesnot exist or password is incorrect!");
            }

        }

        public bool Register(string user,string pass)
        {
            string query = $"INSERT INTO users (username,password) VALUES ('{user}','{pass}');";
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
        public bool Islogin(string user,string pass)
        {
            string query = $"SELECT * FROM users WHERE username='{user}' AND password='{pass}';";
            try
            {
                if(OpenConnection())
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
            catch(Exception ex)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                string s = "MySqlException: " + ex.ToString();
                MessageBox.Show(s, "Error", buttons);
                conn.Close();
                return false;
            }

        }
        public bool Islogin2(string user)
        {
            string query = $"SELECT * FROM users WHERE username='{user}' ;";
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
    }

    }
