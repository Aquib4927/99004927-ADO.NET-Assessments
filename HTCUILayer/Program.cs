using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTCDataAccessLayer;
    
namespace HTCUILayer
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            Customer cusObj = new Customer();
            Console.Clear();
            //Console.WriteLine(menu.DeleteItem("F1001"));
            //Console.WriteLine(cusObj.AddCustomer("Aquib Jawed", "7004632163", "Bangalore,India",1));
           
            List<string> list = cusObj.GetCustomerDetailUsingNumber("7004632163");

            foreach(var item in list)
            {
                Console.WriteLine(item);
            }

        }
    }
}
