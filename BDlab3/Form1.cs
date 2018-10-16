using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BDlab3
{
    public partial class Form1 : Form
    {
        public static MySqlConnection
                 GetDBConnection(string host, int port, string database, string username, string password)
        {
            // Connection String.
            String connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password + ";SslMode=none";

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MySqlConnection conn = GetDBConnection("127.0.0.1", 3306, "bd_hse", "root", "5962kirill");
                try
                {
                    MySqlCommand mycom = new MySqlCommand(textBox1.Text, conn);
                    conn.Open();
                    MySqlDataAdapter adap = new MySqlDataAdapter(mycom);
                    DataSet ds = new DataSet();
                    adap.Fill(ds);
                    dtgrd.DataSource = ds.Tables[0];
                    conn.Close();
                }
                catch (Exception ex)
                {
                    rtbOut.Text += "Произошла ошибка : ";
                    rtbOut.Text += ex.Message;
                }
            }
        }
    }
}
