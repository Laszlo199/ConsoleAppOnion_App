using System;
using System.Collections.Generic;
using CustomerApp.Core.ApplicationService;
using CustomerApp.Core.ApplicationService.Services;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;
using CustomerApp.Infrastructure.Static.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Customer = CustomerApp.Core.Entity.Customer;


namespace Onion_Architecture
{
    class Program
    {

    //static List<Customer> customers = new List<Customer>();

    static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddScoped<ICustomerRepository, CustomerRepositories>();
        serviceCollection.AddScoped<ICustomerService, CustomerService>();
        serviceCollection.AddScoped<IPrinter, Printer>();
        var serviceProvider = serviceCollection.BuildServiceProvider();
        var printer = serviceProvider.GetRequiredService<IPrinter>();
        printer.StartUI();

    }

    }
}