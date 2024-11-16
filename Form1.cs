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

        private void dgwList_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtNo.Text= dgwList.CurrentRow.Cells[0].Value.ToString();
                txtSurname.Text = dgwList.CurrentRow.Cells[1].Value.ToString();
                txtName.Text = dgwList.CurrentRow.Cells[2].Value.ToString();
                txtAge.Text = dgwList.CurrentRow.Cells[3].Value.ToString();
                txtSalary.Text= dgwList.CurrentRow.Cells[4].Value.ToString();
            }
            catch 
            {

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string sqlQuery = "INSERT INTO employees(last_name,first_name,age,employee_salary)" +
                "VALUES (@surname,@name,@age,@employeeSalary)";
            cmd=new MySqlCommand(sqlQuery,conn);
            cmd.Parameters.AddWithValue("@surname",txtSurname.Text);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@age", txtAge.Text);
            cmd.Parameters.AddWithValue("@employeeSalary", txtSalary.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            receiveData();
            MessageBox.Show("New employee added");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sqlQuery = "DELETE FROM employees WHERE id=@no";
            cmd=new MySqlCommand(sqlQuery,conn);    
            cmd.Parameters.AddWithValue("@no",txtNo.Text);  
            conn.Open();   
            cmd.ExecuteNonQuery();
            conn.Close(); 
            receiveData();
            MessageBox.Show("Employee deleted");

        }
    }
}
