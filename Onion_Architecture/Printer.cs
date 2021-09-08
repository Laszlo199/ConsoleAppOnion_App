using System;
using System.Collections.Generic;
using System.ComponentModel;
using CustomerApp.Core.ApplicationService;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;
using CustomerApp.Infrastructure.Static.Data.Repositories;

namespace Onion_Architecture
{
    public class Printer : IPrinter
    {

        private ICustomerService _customerService;
        
        public Printer(ICustomerService customerService)
        {
            _customerService = customerService;

            InitData();
            StartUI();
           
        }

        public void StartUI()
        {
            string[] menuitems =
            {
                "List all customers",
                "Add customer",
                "Delete Customer",
                "Edit customer",
                "Exit",
            };
            var selectedItem = ShowMenu(menuitems);

            while (selectedItem != 5)
            {
                switch (selectedItem)
                {
                    case 1:
                        var customers = _customerService.GetAllCustomers();
                        ListOfCustomer(customers);
                        break;
                    case 2:
                        var firstName = AskQuestions("FirstName: ");
                        var lastName = AskQuestions("LastName: ");
                        var address = AskQuestions("Address: ");
                        var customer = _customerService.NewCustomer(firstName, lastName, address);
                        _customerService.CreateCustomer(customer);
                        
                        break;
                    case 3:
                        var deleteById = PrintFindCustomerById();
                        _customerService.DeleteCustomer(deleteById);
                        break;
                    case 4:
                        var idForEdit = PrintFindCustomerById();
                        var customerToEdit = _customerService.FindCustomerById(idForEdit);
                        Console.WriteLine("Updating "+ customerToEdit.FirstName + customerToEdit.LastName + customerToEdit.Address);
                        var newFirstName = AskQuestions("FirstName: ");
                        var newLastName = AskQuestions("LastName: ");
                        var newAddress = AskQuestions("Address: ");
                        _customerService.UpdateCustomer(new Customer()
                        {
                            Id = idForEdit,
                            FirstName = newFirstName,
                            LastName = newLastName,
                            Address = newAddress
                        });
                        
                        break;
                    case 5:
                        Console.WriteLine("Exit");
                        break;
                }

                selectedItem = ShowMenu(menuitems);
            }

            Console.WriteLine("Bye!!!!!");
            Console.ReadLine();
        }

        private void InitData()
        {
            var cust1 = new Customer()
            {
                FirstName = "Andrea",
                LastName = "Tolnay",
                Address = "Skt.jorgenPuki.22"

            };
            _customerService.CreateCustomer(cust1);
            


            var cust2 = new Customer()
            {
                FirstName = "peeter",
                LastName = "Szamos",
                Address = "Rakopsi ut 21"
            };
            _customerService.CreateCustomer(cust2);
        }

        // Ez a UI:
        private int PrintFindCustomerById()
        {
            Console.WriteLine("Insert customer id: ");
            int id;
            
            while (!int.TryParse(Console.ReadLine(),out id))
            {
                Console.WriteLine("Pls insert a number!!");
            }

            return id;
        }
        
        //Ez a Appilaciton service
         private Customer FindTheCustomer(int id)
         {
             return _customerService.FindCustomerById(id);
         }
         
        void ListOfCustomer(IEnumerable<Customer> customers)
        {
            Console.WriteLine("\nList of Costumers:");
            
            foreach (var customer in customers)
            {
                Console.WriteLine($"ID: {customer.Id} {customer.FirstName} {customer.LastName} {customer.Address}");
                
            }
            Console.WriteLine("\n");    
        }
        
        string AskQuestions(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
       
        private int ShowMenu(string[] menuitems)
        {
            Console.WriteLine("Select a menu item!");
           

            for (int i = 0; i < menuitems.Length; i++)
            {
                Console.WriteLine((i+1)+": "+menuitems[i]);
                
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > 5 )
            {
                Console.WriteLine("Pls select a number between 1-5");
            }
            Console.WriteLine("selected Number: "+ selection);
            return selection;
            
        }
        
    }
}