using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace DayToDayServices.DayToDayClasses
{
    class DayToDayClass
    {

        //create setter properties, this act as data carrier in our application
        public int Service_Id { get; set; }
        public string ServiceName { get; set; }
        public string Material { get; set; }
        public int Amount { get; set; }
        public string Size { get; set; }
        public DateTime Date { get; set; }
        public string CusName { get; set; }
        public string CusTpNo { get; set; }
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
                string sql = "SELECT * FROM tblDayToDayServices";

                //creating cmd using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);

                //creating sql dataAdapter using cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                conn.Open();
                adapter.Fill(dt);
            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        //Inserting data into database
        public bool Insert(DayToDayClass c)
        {
            //creating default return type and setting its value to false
            bool isSuccess = false;

            //1. connect database
            SqlConnection conn = new SqlConnection(dayToDayConnString);

            try
            {
                //2.create sql quary for insert data
                string sql = "INSERT INTO tblDayToDayServices (ServiceName,Material,Amount,Size,Date,CusName,CusTpNo,Price) VALUES (@ServiceName,@Material,@Amount,@Size,@Date,@CusName,@CusTpNo,@Price)";
                //create sql command using sql conn
                SqlCommand cmd = new SqlCommand(sql, conn);

                //create parameters to add data
                cmd.Parameters.AddWithValue("@ServiceName",c.ServiceName);
                cmd.Parameters.AddWithValue("@Material", c.Material);
                cmd.Parameters.AddWithValue("@Amount",c.Amount);
                cmd.Parameters.AddWithValue("@Size", c.Size);
                cmd.Parameters.AddWithValue("@Date", c.Date);
                cmd.Parameters.AddWithValue("@CusName", c.CusName);
                cmd.Parameters.AddWithValue("@CusTpNo", c.CusTpNo);
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
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }

        //method to update data

        public bool Update(DayToDayClass c)
        {
            //create a default return type and set its default value to false
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(dayToDayConnString);
            try
            {
                //sql to update data in thye databse
                string sql = "UPDATE tblDayToDayServices SET ServiceName=@ServiceName, Material=@Material,Amount=@Amount, Size=@Size,Date=@Date,CusName=@CusName,CusTpNo=@CusTpNo, Price=@Price WHERE Service_Id=@Service_Id";

                //creating sql command
                SqlCommand cmd = new SqlCommand(sql, conn);

                //create parameters to add value
                cmd.Parameters.AddWithValue("@ServiceName", c.ServiceName);
                cmd.Parameters.AddWithValue("@Material", c.Material);
                cmd.Parameters.AddWithValue("@Amount", c.Amount);
                cmd.Parameters.AddWithValue("@Size", c.Size);
                cmd.Parameters.AddWithValue("@Date", c.Date);
                cmd.Parameters.AddWithValue("@CusName", c.CusName);
                cmd.Parameters.AddWithValue("@CusTpNo", c.CusTpNo);
                cmd.Parameters.AddWithValue("@Price", c.Price);
                cmd.Parameters.AddWithValue("@Service_Id", c.Service_Id);

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
        public bool Delete(DayToDayClass c)
        {
            //create a default return value & set it's value to false
            bool isSuccess = false;

            //create sql connection
            SqlConnection conn = new SqlConnection(dayToDayConnString);

            try
            {
                //Sql to delete data
                string sql = "DELETE FROM tblDayToDayServices WHERE Service_Id=@Service_Id";

                //creating sql command 
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Service_Id", c.Service_Id);

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
            catch(Exception ex)
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
}
