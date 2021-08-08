using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACMEFactoryBL;
using ACMEFactoryDTO;

namespace ACMEFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = "FactoryTokyo";
            string passWord = "Tokyo@2021";
            ACMEBL obj = new ACMEBL();
        Start:
            Console.WriteLine("Enter 1 for Manager and 2 for Worker");
            var input = Console.ReadLine();
            bool successfull = false;
            while (!successfull)
            {
                if (input == "1")
                {
                    Console.WriteLine("Write your username:");
                    var username = Console.ReadLine();
                    Console.WriteLine("Enter your password:");
                    var password = Console.ReadLine();
                    if (username == userName && password == passWord)
                    {
                        Console.WriteLine("You have successfully logged in !!!");
                        Console.ReadLine();
                        successfull = true;
                        break;
                    }
                    if (!successfull)
                    {
                        Console.WriteLine("Your username or password is incorect, try again aftersometime !!!");
                    }
                }
                else
                {
                    Console.WriteLine("Enter your Worker id:");
                    int id = int.Parse(Console.ReadLine());
                }
            }   
            if(successfull==true)
            {
                Console.WriteLine("enter 1 for worker and 2 for machine details ");
                if(Console.ReadLine()=="1")
                {
                    Console.WriteLine("Enter 1 for adding 2 for deleting and 2 for updating and 4 for fetching worker details");
                    switch (Console.ReadLine())
                    {
                        case '1':
                            Console.WriteLine("Enter Worker Name");
                            string name = Console.ReadLine();
                            Console.WriteLine("Enter Worker Type");
                            int type = int.Parse(Console.ReadLine());
                            obj.AddNewWorkerDetails(name, type);
                        case '2':
                            Console.WriteLine("Enter Worker id to delete");
                            int id = int.Parse(Console.ReadLine());
                            obj.DeleteWorkerDetails(id);
                        case '3':

                        case '4':
                            obj.GetAllWorkerDetails();
                    }
                }
            }
            obj.AddNewWorkerDetails();

        }
    }
}
