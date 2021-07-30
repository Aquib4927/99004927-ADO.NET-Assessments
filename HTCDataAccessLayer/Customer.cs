using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace HTCDataAccessLayer
{
    public class Customer
    {
        SqlConnection sqlConObj;
        SqlCommand cmdObj;
        SqlDataReader drCustomer;

        public string AddCustomer(string customerName, string customerNumber, string customerAddress, int customerVisitCount)
        {
            sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ToString());
            sqlConObj.Open();
            cmdObj = new SqlCommand("[dbo].[uspAddCustomer]", sqlConObj);
            cmdObj.CommandType = CommandType.StoredProcedure;

            cmdObj.Parameters.Add(new SqlParameter("@customerName", SqlDbType.VarChar)).Value = customerName;
            cmdObj.Parameters.Add(new SqlParameter("@customerNumber", SqlDbType.VarChar)).Value = customerNumber;
            cmdObj.Parameters.Add(new SqlParameter("@customerAddress", SqlDbType.VarChar)).Value = customerAddress;
            cmdObj.Parameters.Add(new SqlParameter("@customerVisitCount", SqlDbType.Int)).Value = customerVisitCount;

            try
            {
                cmdObj.ExecuteNonQuery();
                return "One row affected";
            }
            catch (Exception ex)
            {
                return "Something Went Wrong!!";
            }
            finally
            {
                sqlConObj.Close();
            }
        }

        public string UpdateCustomer(string customerName, string customerNumber, string customerAddress, int customerVisitCount)
        {
            sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ToString());
            sqlConObj.Open();
            cmdObj = new SqlCommand("[dbo].[uspUpdateCustomer]", sqlConObj);
            cmdObj.CommandType = CommandType.StoredProcedure;

            cmdObj.Parameters.Add(new SqlParameter("@customerName", SqlDbType.VarChar)).Value = customerName;
            cmdObj.Parameters.Add(new SqlParameter("@customerNumber", SqlDbType.VarChar)).Value = customerNumber;
            cmdObj.Parameters.Add(new SqlParameter("@customerAddress", SqlDbType.VarChar)).Value = customerAddress;
            cmdObj.Parameters.Add(new SqlParameter("@customerVisitCount", SqlDbType.Int)).Value = customerVisitCount;

            try
            {
                cmdObj.ExecuteNonQuery();
                return "Update Successfully\nOne row affected";
            }
            catch (Exception ex)
            {
                //throw ex.Message();
                return "Something Went Wrong!!";

            }
            finally
            {
                sqlConObj.Close();
            }

        }

        public string DeleteCustomer(string customerNumber)
        {

            sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ToString());
            sqlConObj.Open();
            cmdObj = new SqlCommand("[dbo].[uspDeleteCustomer]", sqlConObj);
            cmdObj.CommandType = CommandType.StoredProcedure;

            cmdObj.Parameters.Add(new SqlParameter("@customerNumber", SqlDbType.VarChar)).Value = customerNumber;

            try
            {
                cmdObj.ExecuteNonQuery();
                return "Deleted Successfully\nOne row affected";
            }
            catch (Exception ex)
            {
                //throw ex.Message();
                return "Something Went Wrong!!";

            }
            finally
            {
                sqlConObj.Close();
            }

        }

        public List<string> GetCustomerDetailUsingNumber(string customerNumber)
        {
            List<string> lstCustomer = new List<string>();
            try
            {
                sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ToString());
                cmdObj = new SqlCommand($@"SELECT customerName,customerNumber,customerAddress, customerVisitCount FROM Customer where customerNumber='{customerNumber}'", sqlConObj);
                sqlConObj.Open();
                drCustomer = cmdObj.ExecuteReader();

                drCustomer.Read();

                lstCustomer.Add(drCustomer["customerName"] + "  " + drCustomer["customerNumber"] + "  " + drCustomer["customerAddress"] + " " + drCustomer["customerVisitCount"]);

                return lstCustomer;
            }
            catch (Exception)
            {
                lstCustomer.Add("Something went wrong");
                return lstCustomer;
            }
            finally
            {
                sqlConObj.Close();
            }

        }

    }
}
