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
            menu.AddItem("F1000", "Noodles", "Chinese Food", 0, 200, 0);
            cusObj.AddCustomer("Aquib Jawed", 8757550099,"Bangalore,India",1);
        }
    }
}
