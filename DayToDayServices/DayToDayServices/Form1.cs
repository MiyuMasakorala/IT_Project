using DayToDayServices.DayToDayClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayToDayServices
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DayToDayClass c = new DayToDayClass();

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        static string myconn = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //Get the value from textBox
            string keyword = txtSearch.Text;


            SqlConnection conn = new SqlConnection(myconn);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblDayToDayServices WHERE ServiceName LIKE '%"+keyword+"%' OR Material LIKE '%" +keyword+ "%' OR Amount LIKE '%" + keyword + "%' OR Size LIKE '%" + keyword + "%'  OR Date LIKE '%" + keyword + "%' OR CusName LIKE '%" + keyword + "%' OR CusTpNo LIKE '%" + keyword + "%' OR Price LIKE '%" + keyword + "%' OR Service_Id LIKE '%" + keyword + "%' ", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dvgServicesData.DataSource = dt;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //get the data from textboxes
            c.Service_Id = int.Parse(txtSid.Text);
            c.ServiceName = txtServiceName.Text;
            c.Material = txtMaterial.Text;
            c.Amount = int.Parse(txtAmount.Text);
            c.Size = txtSize.Text;
            c.Date = DateTime.Parse(dateTimePicker1.Text);
            c.CusName = txtCusName.Text;
            c.CusTpNo = txtCusTpNo.Text;
            c.Price = txtPrice.Text;

            //update data in the data base
            bool success = c.Update(c);

            if (success == true)
            {
                //update successful
                MessageBox.Show("You have successfully Updated");

                //Load data on grid view
                DataTable dt = c.Select();
                dvgServicesData.DataSource = dt;

                //call the clear method
                clear();
            }
            else
            {
                //fail to update
                MessageBox.Show("Failed to update..Try again..");
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Regex r1 = new Regex(@"[0-9]");
            Regex rphone = new Regex(@"^[0-9]{10}$");

            string serviceName = txtServiceName.Text;
            string Material = txtMaterial.Text;
            string Size = txtSize.Text;
            string ammount = txtAmount.Text;
            string date = dateTimePicker1.Text;
            string Price = txtPrice.Text;
            string CusName = txtCusName.Text;
            string custpNo = txtCusTpNo.Text;

            //validations

            if (serviceName.Equals(" "))
            {
                MessageBox.Show("Please select Service Name..!");
            }
            else if (Material.Equals(" "))
            {
                MessageBox.Show("Please enter Material..!");
            }
            else if (ammount.Equals(" "))
            {
                MessageBox.Show("Please enter Amount..!");
            }
            else if (!r1.IsMatch(txtAmount.Text))
            {
                txtAmount.BackColor = System.Drawing.Color.LightPink;
                MessageBox.Show("Please Enter Number for Amount..!");
            }
            else if (Size.Equals(" "))
            {
                MessageBox.Show("Please enter Size..!");
            }
            else if (date.Equals(" "))
            {
                MessageBox.Show("Please enter Date..!");
            }
            else if (CusName.Equals(" "))
            {
                MessageBox.Show("Please enter Customer Name..!");
            }
            else if (custpNo.Equals(" "))
            {
                MessageBox.Show("Please enter Customer Tp No..!");
            }
            else if (!rphone.IsMatch(txtCusTpNo.Text))
            {
                txtCusTpNo.BackColor = System.Drawing.Color.LightPink;
                MessageBox.Show("Enter 10digit valid Contact Number..!");
            }
            else if (Price.Equals(" "))
            {
                MessageBox.Show("Please enter Price..!");
            }
            else if (!r1.IsMatch(txtPrice.Text))
            {
                txtPrice.BackColor = System.Drawing.Color.LightPink;
                MessageBox.Show("Please Enter Price correctly..!");
            }

            else
            {
                //Get the value from the input fields
                c.ServiceName = txtServiceName.Text;
                c.Material = txtMaterial.Text;
                c.Size = txtSize.Text;
                c.CusName = txtCusName.Text;
                c.CusTpNo = txtCusTpNo.Text;
                c.Price = txtPrice.Text;
                c.Amount = Convert.ToInt32(txtAmount.Text);
                c.Date = DateTime.Parse(dateTimePicker1.Text);


                //inserting data into database using created method
                bool success = c.Insert(c);
                if (success == true)
                {
                    //successfully inserted message
                    txtAmount.BackColor = System.Drawing.Color.White;
                    txtCusTpNo.BackColor = System.Drawing.Color.White;
                    txtPrice.BackColor = System.Drawing.Color.White;
                    MessageBox.Show("Successfully added new Service..");

                    //call the clear method
                    clear();
                }
                else
                {
                    //insertion unsuccessful  message
                    MessageBox.Show("Failed to add new service..Try again..");
                }

                //Load data on grid view
                DataTable dt = c.Select();
                dvgServicesData.DataSource = dt;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Load data on grid view
            DataTable dt = c.Select();
            dvgServicesData.DataSource = dt;

        }

        //Method to clear text boxes
        public void clear()
        {
            txtServiceName.Text = " ";
            txtMaterial.Text = " ";
            txtAmount.Text = " ";
            txtSize.Text =" ";
            txtCusName.Text = " ";
            txtCusTpNo.Text = " ";
            txtPrice.Text = " ";
            txtSid.Text = " ";
            txtAmount.BackColor = System.Drawing.Color.White;
            txtCusTpNo.BackColor = System.Drawing.Color.White;
            txtPrice.BackColor = System.Drawing.Color.White;


        }

        private void dvgServicesData_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get data from data grid view and load data to the respective text box
            //identify the row on the which row mouse click
            int rowIndex = e.RowIndex;
            txtSid.Text = dvgServicesData.Rows[rowIndex].Cells[0].Value.ToString();
            txtServiceName.Text = dvgServicesData.Rows[rowIndex].Cells[1].Value.ToString();
            txtMaterial.Text = dvgServicesData.Rows[rowIndex].Cells[2].Value.ToString();
            txtAmount.Text = dvgServicesData.Rows[rowIndex].Cells[3].Value.ToString();
            txtSize.Text = dvgServicesData.Rows[rowIndex].Cells[4].Value.ToString();
            dateTimePicker1.Text = dvgServicesData.Rows[rowIndex].Cells[5].Value.ToString();
            txtCusName.Text = dvgServicesData.Rows[rowIndex].Cells[6].Value.ToString();
            txtCusTpNo.Text = dvgServicesData.Rows[rowIndex].Cells[7].Value.ToString();
            txtPrice.Text = dvgServicesData.Rows[rowIndex].Cells[8].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Call clear method
            clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Get data from the textBox
            c.Service_Id = Convert.ToInt32(txtSid.Text);

            bool success = c.Delete(c);
            if (success==true)
            {
                //Deleted successfully
                MessageBox.Show("Successfully Delete the Service");

                //Refresh data grid view
                DataTable dt = c.Select();
                dvgServicesData.DataSource = dt;

                //Call clear method
                clear();

            }
            else
            {
                //Failed to delete
                MessageBox.Show("Failed to Delete..Try again");
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 frm2 = new Form2();
            frm2.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            FormIncome frIn = new FormIncome();
            frIn.Show();
        }

        private void txtCusName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void DemoDay_Click(object sender, EventArgs e)
        {
            txtServiceName.Text = "Taking Photoes";
            txtMaterial.Text = "Mat Paper";
            txtAmount.Text = "3";
            txtSize.Text = "8' 8'";
            txtCusName.Text = "Sarath Silva";
            txtCusTpNo.Text = "0777654321";
            txtPrice.Text = "3000.00";
          
        }
    }
}
