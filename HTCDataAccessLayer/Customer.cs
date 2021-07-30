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

        public string AddCustomer(string customerName, long customerNumber, string customerAddress, int customerVisitCount)

        {
            sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ToString());
            sqlConObj.Open();
            cmdObj = new SqlCommand("[dbo].[uspAddCustomer]", sqlConObj);
            cmdObj.CommandType = CommandType.StoredProcedure;

            cmdObj.Parameters.Add(new SqlParameter("@customerName", SqlDbType.VarChar)).Value = customerName;
            cmdObj.Parameters.Add(new SqlParameter("@customerNumber", SqlDbType.Int)).Value = customerNumber;
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

        public string UpdateCustomer(string customerName, int customerNumber, string customerAddress, int customerVisitCount)
        {
            sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ToString());
            sqlConObj.Open();
            cmdObj = new SqlCommand("[dbo].[uspUpdateCustomer]", sqlConObj);
            cmdObj.CommandType = CommandType.StoredProcedure;

            cmdObj.Parameters.Add(new SqlParameter("@customerName", SqlDbType.VarChar)).Value = customerName;
            cmdObj.Parameters.Add(new SqlParameter("@customerNumber", SqlDbType.Int)).Value = customerNumber;
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

        public string DeleteCustomer(int customerNumber)
        {

            sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ToString());
            sqlConObj.Open();
            cmdObj = new SqlCommand("[dbo].[uspDeleteCustomer]", sqlConObj);
            cmdObj.CommandType = CommandType.StoredProcedure;

            cmdObj.Parameters.Add(new SqlParameter("@itemId", SqlDbType.Int)).Value = customerNumber;

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
    }
}
