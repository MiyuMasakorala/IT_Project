using DayToDayServices.DayToDayClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayToDayServices
{

    
    public partial class FormIncome : Form
    {
        public FormIncome()
        {
            InitializeComponent();
        }

        IncomeSend n = new IncomeSend();

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Regex r1 = new Regex(@"[0-9]");

            string IncomeCategory = cmbIncomeCategory.Text;
            string IncomeDate = dtIncomeDate.Text;
            string IncomeAmount = txtIncomeAmount.Text;

            if (cmbIncomeCategory.Equals(" "))
            {
                MessageBox.Show("Please select Category..!");
            }
            else if (txtIncomeAmount.Equals(" "))
            {
                MessageBox.Show("Please Enter Amount of income..!");
            }
            else if (!r1.IsMatch(txtIncomeAmount.Text))
            {
            
                MessageBox.Show("Please Enter Amount correctly..!");
            }
            else
            {
                //Get values from the input fields
                n.IncomeCategory = cmbIncomeCategory.Text;
                n.IncomeDate = DateTime.Parse(dtIncomeDate.Text);
                n.IncomeAmount = txtIncomeAmount.Text;

                //inserting data into database using created method
                bool success = n.Insert(n);
                if (success == true)
                {
                    //successfully inserted message

                    MessageBox.Show("Income sent successfully..");
                   
                }
                else
                {
                    //insertion unsuccessful  message
                    MessageBox.Show("Failed to Send Income..Try again..");
                }
            }
        }

        private void btnSendInDemo_Click(object sender, EventArgs e)
        {
            cmbIncomeCategory.Text = "Day To Day Service";
            txtIncomeAmount.Text = "5000.00";
        }
    }
}
