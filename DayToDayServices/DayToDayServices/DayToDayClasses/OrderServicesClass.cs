using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayToDayServices.DayToDayClasses
{
    class OrderServicesClass
    {
        //create setter properties
        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public string Material { get; set; }
        public int Amount { get; set; }
        public string Size { get; set; }
        public string CustomerName { get; set; }
        public string CustomerTpNo { get; set; }
        public DateTime OrderedDate { get; set; }
        public DateTime HandOverDate { get; set; }
        public string Price { get; set; }


        static string dayToDayConnString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        //selecting data from database
        public DataTable Select()
        {
            //database connection
            SqlConnection conn = new SqlConnection(dayToDayConnString);
            DataTable dt = new DataTable();

            try
            {
                //writting sql query
                string sql = "SELECT * FROM tblOrderServices";

                //creating cmd using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);

                //creating sql dataAdapter using cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        //Inserting data into database
        public bool Insert(OrderServicesClass c)
        {
            //creating default return type and setting its value to false
            bool isSuccess = false;

            //1. connect database
            SqlConnection conn = new SqlConnection(dayToDayConnString);

            try
            {
                //2.create sql quary for insert data
                string sql = "INSERT INTO tblOrderServices (OrderName,Material,Amount,Size,CustomerName,CustomerTpNo,OrderedDate,HandOverDate,Price) VALUES (@OrderName,@Material,@Amount,@Size,@CustomerName,@CustomerTpNo,@OrderedDate,@HandOverDate,@Price)";
                //create sql command using sql conn
                SqlCommand cmd = new SqlCommand(sql, conn);

                //create parameters to add data
                cmd.Parameters.AddWithValue("@OrderName", c.OrderName);
                cmd.Parameters.AddWithValue("@Material", c.Material);
                cmd.Parameters.AddWithValue("@Amount", c.Amount);
                cmd.Parameters.AddWithValue("@Size", c.Size);
                cmd.Parameters.AddWithValue("@CustomerName", c.CustomerName);
                cmd.Parameters.AddWithValue("@CustomerTpNo", c.CustomerTpNo);
                cmd.Parameters.AddWithValue("@OrderedDate", c.OrderedDate);
                cmd.Parameters.AddWithValue("@HandOverDate", c.HandOverDate);
                cmd.Parameters.AddWithValue("@Price", c.Price);

                //connection opens here
                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                //if the query runs successfully then, the value of the rows will be greater than zero..else value will be zero
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }


            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }


        //method to update data

        public bool Update(OrderServicesClass c)
        {
            //create a default return type and set its default value to false
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(dayToDayConnString);
            try
            {
                //sql to update data in thye databse
                string sql = "UPDATE tblOrderServices SET OrderName=@OrderName,Material=@Material,Amount=@Amount,Size=@Size,CustomerName=@CustomerName,CustomerTpNo=@CustomerTpNo,OrderedDate=@OrderedDate,HandOverDate=@HandOverDate,Price=@Price WHERE OrderId=@OrderId";

                //creating sql command
                SqlCommand cmd = new SqlCommand(sql, conn);

                //create parameters to add value
                cmd.Parameters.AddWithValue("@OrderName", c.OrderName);
                cmd.Parameters.AddWithValue("@Material", c.Material);
                cmd.Parameters.AddWithValue("@Amount", c.Amount);
                cmd.Parameters.AddWithValue("@Size", c.Size);
                cmd.Parameters.AddWithValue("@CustomerName", c.CustomerName);
                cmd.Parameters.AddWithValue("@CustomerTpNo", c.CustomerTpNo);
                cmd.Parameters.AddWithValue("@OrderedDate", c.OrderedDate);
                cmd.Parameters.AddWithValue("@HandOverDate", c.HandOverDate);
                cmd.Parameters.AddWithValue("@Price", c.Price);
                cmd.Parameters.AddWithValue("@OrderId", c.OrderId);

                //open databse connection
                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                //if the query runs successfully then the value of rows will be greater than zero else its value will be zero
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }

        //create method to delete data from the databse
        public bool Delete(OrderServicesClass c)
        {
            //create a default return value & set it's value to false
            bool isSuccess = false;

            //create sql connection
            SqlConnection conn = new SqlConnection(dayToDayConnString);

            try
            {
                //Sql to delete data
                string sql = "DELETE FROM tblOrderServices WHERE OrderId=@OrderId";

                //creating sql command 
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@OrderId", c.OrderId);

                //open connection
                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                //if the query runs successfully then the value of rows will be greater than zero else its value will be zero
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                //close connection
                conn.Close();
            }
            return isSuccess;
        }



    }

    //class for send Income 

    class IncomeSend
    {
        //create setter and getter properties
        public string IncomeCategory { get; set; }

        public DateTime IncomeDate { get; set; }

        public string IncomeAmount { get; set; }

        static string IncomeSendConnString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        //Inserting data into database
        public bool Insert(IncomeSend n)
        {
            //creating default return type and setting its value to false
            bool isSuccess = false;

            //1. connect database
            SqlConnection conn = new SqlConnection(IncomeSendConnString);

            try
            {
                //2.create sql quary for insert data
                string sql = "INSERT INTO tblincomeSend (IncomeCategory,IncomeDate,IncomeAmount) VALUES (@IncomeCategory,@IncomeDate,@IncomeAmount)";
                //create sql command using sql conn
                SqlCommand cmd = new SqlCommand(sql, conn);

                //create parameters to add data
                cmd.Parameters.AddWithValue("@IncomeCategory", n.IncomeCategory);
                cmd.Parameters.AddWithValue("@IncomeDate", n.IncomeDate);
                cmd.Parameters.AddWithValue("@IncomeAmount", n.IncomeAmount);
             

                //connection opens here
                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                //if the query runs successfully then, the value of the rows will be greater than zero..else value will be zero
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }


            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
    }
}
