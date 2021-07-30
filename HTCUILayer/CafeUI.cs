using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTCDataAccessLayer;

namespace HTCUILayer
{
    class CafeUI
    {
        int authenticationNumber;
        string customerName;
        string customerNumber;
        string customerAddress;
        int customerVisitCount;
        Customer cusObj = new Customer();

        public void MainMenu()
        {
            Console.WriteLine("Welcome To hashtag Cafe!!\n\n");
            Console.WriteLine("1.Customer\n 2.Manager\n 3.Exit");

            Console.WriteLine("\nPlease select an option:");
            authenticationNumber = Convert.ToInt32(Console.ReadLine());

            
            if(authenticationNumber == 1)
            {
                CustomerAccess();
            }
            else if(authenticationNumber == 2)
            {
                AdminAccess();
            }
            else if(authenticationNumber == 3)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Please select the valid input");
                Console.Clear();
                MainMenu();
            }

        }

        public void CustomerAccess()
        {
            Console.Clear();
            Console.WriteLine("\n1.New Customer \n2.Existing Customer \n3.MainMenu");
            authenticationNumber = Convert.ToInt32(Console.ReadLine());

            if(authenticationNumber == 1)
            {
                Console.Clear();
                Console.WriteLine("Please provide the below details:");

                Console.WriteLine("Please enter your Name:");
                customerName = Console.ReadLine();

                Console.WriteLine("Please enter your Number:");
                customerNumber = Console.ReadLine();

                Console.WriteLine("Please enter your Adress:");
                customerAddress = Console.ReadLine();

                cusObj.AddCustomer(customerName, customerNumber, customerAddress, 1);

                Console.Clear();
                Order();

            }
            else if (authenticationNumber == 2)
            {
                Console.Clear();

                Console.WriteLine("Please Enter your number");
                customerNumber = Console.ReadLine();

                List<string> list = cusObj.GetCustomerDetailUsingNumber(customerNumber);
                int count = Convert.ToInt32(list[3]);
                if(list[1] == customerNumber)
                {
                    cusObj.UpdateCustomer(list[0],list[1],list[2],count+1);
                }

            }
        }

        public void Order()
        {

        }

        public void AdminAccess()
        {

            Console.WriteLine("1.Add Menu\n2.Update Menu\n3.Delete Menu\n4.Main menu");

            authenticationNumber == Convert.ToInt32(Console.ReadLine());

            if(authenticationNumber == 1)
            {
                AddMenu();
            }
            else if (authenticationNumber == 2)
            {
                UpdateMenu();
            }
            else if(authenticationNumber == 3)
            {
                MainMenu();
            }

        }

        public void AddMenu()
        {
            Console.Clear();

            //Console.WriteLine("1.itemId\n2.itemName\n\3.item")
        }
    }
}
