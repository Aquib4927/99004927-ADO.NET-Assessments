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
    public class Menu
    {
        SqlConnection sqlConObj;
        SqlCommand cmdObj;
        SqlDataReader drMenu;

        public string AddItem(string itemId, string itemName, string itemDescription,
                              int itemTax, int itemPrice, int itemDiscount)
        {
            sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ToString());
            sqlConObj.Open();
            cmdObj = new SqlCommand("[dbo].[uspAddMenu]", sqlConObj);
            cmdObj.CommandType = CommandType.StoredProcedure;

            cmdObj.Parameters.Add(new SqlParameter("@itemId", SqlDbType.VarChar)).Value = itemId;
            cmdObj.Parameters.Add(new SqlParameter("@itemName", SqlDbType.VarChar)).Value = itemName;
            cmdObj.Parameters.Add(new SqlParameter("@itemDescription", SqlDbType.VarChar)).Value = itemDescription;
            cmdObj.Parameters.Add(new SqlParameter("@itemTax", SqlDbType.Int)).Value = itemTax;
            cmdObj.Parameters.Add(new SqlParameter("@itemPrice", SqlDbType.Int)).Value = itemPrice;
            cmdObj.Parameters.Add(new SqlParameter("@itemDiscount", SqlDbType.Int)).Value = itemDiscount;

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

        public string UpdateItem(string itemName, string itemDescription, int itemTax,
                                  int itemPrice, int itemDiscount, string itemId)
        {
            sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ToString());
            sqlConObj.Open();
            cmdObj = new SqlCommand("[dbo].[uspUpdateMenu]", sqlConObj);
            cmdObj.CommandType = CommandType.StoredProcedure;

            cmdObj.Parameters.Add(new SqlParameter("@itemId", SqlDbType.VarChar)).Value = itemId;
            cmdObj.Parameters.Add(new SqlParameter("@itemName", SqlDbType.VarChar)).Value = itemName;
            cmdObj.Parameters.Add(new SqlParameter("@itemDescription", SqlDbType.VarChar)).Value = itemDescription;
            cmdObj.Parameters.Add(new SqlParameter("@itemTax", SqlDbType.Int)).Value = itemTax;
            cmdObj.Parameters.Add(new SqlParameter("@itemPrice", SqlDbType.Int)).Value = itemPrice;
            cmdObj.Parameters.Add(new SqlParameter("@itemDiscount", SqlDbType.Int)).Value = itemDiscount;

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

        public string DeleteItem(string itemId)
        {

            sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ToString());
            sqlConObj.Open();
            cmdObj = new SqlCommand("[dbo].[uspDeleteMenu]", sqlConObj);
            cmdObj.CommandType = CommandType.StoredProcedure;

            cmdObj.Parameters.Add(new SqlParameter("@itemId", SqlDbType.VarChar)).Value = itemId;

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

        public List<string> GetMenu()
        {
            List<string> lstMenu = new List<string>();

            try
            {
                sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ToString());
                cmdObj = new SqlCommand(@"SELECT itemName,itemPrice FROM MENU", sqlConObj);
                sqlConObj.Open();
                drMenu = cmdObj.ExecuteReader();

                while (drMenu.Read())
                {
                    lstMenu.Add(drMenu["itemName"] + "  " + drMenu["itemPrice"]);
                }

                return lstMenu;
            }
            catch (Exception)
            {
                lstMenu.Add("Something went wrong Error code -99");
                return lstMenu;


            }
            finally
            {
                sqlConObj.Close();
            }

        }
    }
}
