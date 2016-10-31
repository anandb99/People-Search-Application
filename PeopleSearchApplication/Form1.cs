using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace PeopleSearchApplication
{
    public partial class Form1 : Form
    {
        DataSet ds = new DataSet();
        SqlConnection cs = new SqlConnection("Data Source=DESKTOP-MML041V\\SQLEXPRESS; Initial Catalog=peopleSearchApplicationDatabase; Integrated Security=TRUE;");
        SqlDataAdapter da = new SqlDataAdapter();

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            //select * from peopleSearchApplicationTable where firstName like 'anand' or lastName like 'reddy'
            if (inputTextBox.Text != "")
            {
                String query = "Select * from peopleSearchApplicationTable where firstName like '" + inputTextBox.Text
                    + "' or lastName like '" + inputTextBox.Text + "'";
                Console.WriteLine(query);
                da.SelectCommand = new SqlCommand(query, cs);
                ds.Clear();
                da.Fill(ds);
                dataGridView.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Please enter input value");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void displayAllButton_Click(object sender, EventArgs e)
        {
            da.SelectCommand = new SqlCommand("select * from peopleSearchApplicationTable",cs);
            ds.Clear();
            da.Fill(ds);
            dataGridView.DataSource = ds.Tables[0];
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
    
            if (firstNameTextBox.Text == "")
                MessageBox.Show("Please enter first name");
            else if (lastNameTextBox.Text == "")
                MessageBox.Show("Please enter last name");
            else if (dateTimePicker.Text=="")
                MessageBox.Show("Please enter DOB");
            else
            {
                da.InsertCommand = new SqlCommand("insert into peopleSearchApplicationTable values (@firstName, @lastName, @address, @dob, @interests)", cs);

                da.InsertCommand.Parameters.Add("@firstName", SqlDbType.VarChar).Value = firstNameTextBox.Text;
                da.InsertCommand.Parameters.Add("@lastName", SqlDbType.VarChar).Value = lastNameTextBox.Text;
                da.InsertCommand.Parameters.Add("@address", SqlDbType.VarChar).Value = addressTextBox.Text;
                da.InsertCommand.Parameters.Add("@dob", SqlDbType.Date).Value = dateTimePicker.Text;
                da.InsertCommand.Parameters.Add("@interests", SqlDbType.VarChar).Value = interestsTextBox.Text;

                cs.Open();
                da.InsertCommand.ExecuteNonQuery();
                cs.Close();

                displayAllButton_Click(null,null);
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
