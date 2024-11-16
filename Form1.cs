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

namespace itemysql
{
    public partial class Form1 : Form
    {
        MySqlConnection conn = new MySqlConnection("Server=localhost;Database=library;Uid=root;Pwd='1905203';");
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt;
        void receiveData()
        {
            dt= new DataTable();
            conn.Open();
            adapter= new MySqlDataAdapter("SELECT *FROM employees",conn);
            adapter.Fill(dt);
            dgwList.DataSource = dt;
            conn.Close();
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            receiveData();  
        }

     
    }
}
