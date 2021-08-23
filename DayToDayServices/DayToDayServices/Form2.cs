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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        OrderServicesClass c = new OrderServicesClass();

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //Load data on grid view
            DataTable dt = c.Select();
            dgvOrderList.DataSource = dt;

        }

        private void btnAddNewOrder_Click(object sender, EventArgs e)
        {

            Regex r1 = new Regex(@"[0-9]");
            Regex rphone = new Regex(@"^[0-9]{10}$");

            string OrderName = cmbOrderName.Text;
            string Material = txtOMeterial.Text;
            string amount = txtOAmount.Text;
            string Size = txtOSize.Text;
            string CustomerName = txtOCusName.Text;
            string CustomerTpNo = txtOCusTp.Text;
            string OrderedDate = dtPickerOrderdDate.Text;
            string HandOverDate = dtPickerHandOverDate.Text;
            string Price = txtOrderPrice.Text;

            //validations

            if (OrderName.Equals(" "))
            {
                MessageBox.Show("Please select Order Name..!");
            }
            else if (Material.Equals(" "))
            {
                MessageBox.Show("Please Enter Material..!");
            }

            else if (amount.Equals(" "))
            {
                MessageBox.Show("Please Enter Amount..!");
            }
            else if (!r1.IsMatch(txtOAmount.Text))
            {
                txtOAmount.BackColor = System.Drawing.Color.LightPink;
                MessageBox.Show("Please Enter Number for Amount..!");
            }
            else if (Size.Equals(" "))
            {
                MessageBox.Show("Please Enter Size..!");
            }
            else if (CustomerName.Equals(" "))
            {
                MessageBox.Show("Please Enter Customer Name..!");
            }
            else if (CustomerTpNo.Equals(" "))
            {
                MessageBox.Show("Please Enter Customer Tp No..!");
            }
            else if (!rphone.IsMatch(txtOCusTp.Text))
            {
                txtOCusTp.BackColor = System.Drawing.Color.LightPink;
                MessageBox.Show("Enter 10digit valid Contact Number..!");
            }
            else if (OrderedDate.Equals(" "))
            {
                MessageBox.Show("Please Enter Ordered Date..!");
            }
            else if (HandOverDate.Equals(" "))
            {
                MessageBox.Show("Please Enter HandOver Date..!");
            }
            else if (Price.Equals(" "))
            {
                MessageBox.Show("Please Enter Price..!");
            }
            else if (!r1.IsMatch(txtOrderPrice.Text))
            {
                txtOrderPrice.BackColor = System.Drawing.Color.LightPink;
                MessageBox.Show("Please Enter Price correctly..!");
            }

            else
            {

                //Get values from the input fields
                c.OrderName = cmbOrderName.Text;
                c.Material = txtOMeterial.Text;
                c.Amount = int.Parse(txtOAmount.Text);
                c.Size = txtOSize.Text;
                c.CustomerName = txtOCusName.Text;
                c.CustomerTpNo = txtOCusTp.Text;
                c.OrderedDate = DateTime.Parse(dtPickerOrderdDate.Text);
                c.HandOverDate = DateTime.Parse(dtPickerHandOverDate.Text);
                c.Price = txtOrderPrice.Text;

                //inserting data into database using created method
                bool success = c.Insert(c);
                if (success == true)
                {
                    //successfully inserted message
                    txtOAmount.BackColor = System.Drawing.Color.White;
                    txtOCusTp.BackColor = System.Drawing.Color.White;
                    txtOrderPrice.BackColor = System.Drawing.Color.White;
                    MessageBox.Show("Successfully added new Order..");

                    //call the clear method
                    Clear();
                }
                else
                {
                    //insertion unsuccessful  message
                    MessageBox.Show("Failed to add new Order..Try again..");
                }

                //Load data on grid view
                DataTable dt = c.Select();
                dgvOrderList.DataSource = dt;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm1 = new Form1();
            frm1.Show();
        }

        //Method to clear textBoxes

        public void Clear()
        {
            txtOrderId.Text = " ";
            cmbOrderName.Text = " ";
            txtOMeterial.Text = " ";
            txtOAmount.Text = " ";
            txtOSize.Text = " ";
            txtOCusName.Text = " ";
            txtOCusTp.Text = " ";
            txtOrderPrice.Text = " ";
            txtOAmount.BackColor = System.Drawing.Color.White;
            txtOCusTp.BackColor = System.Drawing.Color.White;
            txtOrderPrice.BackColor = System.Drawing.Color.White;

        }

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            //Get data from the textboxes
            c.OrderId = int.Parse(txtOrderId.Text);
            c.OrderName = cmbOrderName.Text;
            c.Material = txtOMeterial.Text;
            c.Amount = int.Parse(txtOAmount.Text);
            c.Size = txtOSize.Text;
            c.CustomerName = txtOCusName.Text;
            c.CustomerTpNo = txtOCusTp.Text;
            c.OrderedDate = DateTime.Parse(dtPickerOrderdDate.Text);
            c.HandOverDate = DateTime.Parse(dtPickerHandOverDate.Text);
            c.Price = txtOrderPrice.Text;

            //update data in the data base
            bool success = c.Update(c);

            if (success == true)
            {
                //update successful
                MessageBox.Show("You have successfully Updated");

                //Load data on grid view
                DataTable dt = c.Select();
                dgvOrderList.DataSource = dt;

                //call the clear method
                Clear();
            }
            else
            {
                //fail to update
                MessageBox.Show("Failed to update..Try again..");
            }

        }

        private void btnClearOrder_Click(object sender, EventArgs e)
        {
            //call method to clear data in the textboxes
            Clear();
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            //Get data from the textBox
            c.OrderId = Convert.ToInt32(txtOrderId.Text);

            bool success = c.Delete(c);
            if (success == true)
            {
                //Deleted successfully
                MessageBox.Show("Order Delete Successfully..");

                //Refresh data grid view
                DataTable dt = c.Select();
                dgvOrderList.DataSource = dt;

                //Call clear method
                Clear();

            }
            else
            {
                //Failed to delete
                MessageBox.Show("Failed to Delete..Try again");
            }
        }

        private void dgvOrderList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvOrderList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get data from data grid view and load data to the respective text box
            //identify the row on the which row mouse click
            int rowIndex = e.RowIndex;
            txtOrderId.Text = dgvOrderList.Rows[rowIndex].Cells[0].Value.ToString();
            cmbOrderName.Text = dgvOrderList.Rows[rowIndex].Cells[1].Value.ToString();
            txtOMeterial.Text = dgvOrderList.Rows[rowIndex].Cells[2].Value.ToString();
            txtOAmount.Text = dgvOrderList.Rows[rowIndex].Cells[3].Value.ToString();
            txtOSize.Text = dgvOrderList.Rows[rowIndex].Cells[4].Value.ToString();
            txtOCusName.Text = dgvOrderList.Rows[rowIndex].Cells[5].Value.ToString();
            txtOCusTp.Text = dgvOrderList.Rows[rowIndex].Cells[6].Value.ToString();
            dtPickerOrderdDate.Text = dgvOrderList.Rows[rowIndex].Cells[7].Value.ToString();
            dtPickerHandOverDate.Text = dgvOrderList.Rows[rowIndex].Cells[8].Value.ToString();
            txtOrderPrice.Text = dgvOrderList.Rows[rowIndex].Cells[9].Value.ToString();

        }

        static string myconn = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        private void txtOSearch_TextChanged(object sender, EventArgs e)
        {

            //Get the value from textBox
            string keyword = txtOSearch.Text;


            SqlConnection conn = new SqlConnection(myconn);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblOrderServices WHERE OrderName LIKE '%" + keyword + "%' OR Material LIKE '%" + keyword + "%' OR Amount LIKE '%" + keyword + "%' OR Size LIKE '%" + keyword + "%'  OR CustomerName LIKE '%" + keyword + "%' OR CustomerTpNo LIKE '%" + keyword + "%' OR OrderedDate LIKE '%" + keyword + "%' OR HandOverDate LIKE '%" + keyword + "%' OR Price LIKE '%" + keyword + "%' OR OrderId LIKE '%" + keyword + "%' ", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvOrderList.DataSource = dt;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpcomingOrdersCalender uo = new UpcomingOrdersCalender();
            uo.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormIncome frmIncome = new FormIncome();
            frmIncome.Show();
        }

        private void txtOCusName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void btnOrderDemo_Click(object sender, EventArgs e)
        {
           
            cmbOrderName.Text = "Photo Framing";
            txtOMeterial.Text = "Black wood";
            txtOAmount.Text = "2";
            txtOSize.Text = "18' 18'";
            txtOCusName.Text = "Rajith Silva";
            txtOCusTp.Text = "0777232123";
            txtOrderPrice.Text = "1500.00";

        }
    }
}
