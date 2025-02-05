using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Address address2 = new Address("456 Arab Road", "Kubwa", "Abuja", "Nigeria");
        Address address3 = new Address("3 Dekka Road", "Calabar", "Cross RIver", "Nigeria");
        Address address4 = new Address("2 Redemption Close - Omachi", "Port Harcourt", "Rivers State", "Nigeria");

        // Create customers
        Customer customer1 = new Customer("Ekanachita Oyama", address1);
        Customer customer2 = new Customer("Adams Oyama", address2);
        Customer customer3 = new Customer("Coolmyne Inyang", address3);
        Customer customer4 = new Customer("Smart Abamson", address4);

        // Create products
        Product product1 = new Product("Laptop", 101, 999.99m, 1);
        Product product2 = new Product("Smartphone", 102, 499.99m, 2);
        Product product3 = new Product("Headphones", 103, 149.99m, 3);
        Product product4 = new Product("Monitor", 104, 199.99m, 2);
        Product product5 = new Product("Keyboard", 105, 49.99m, 1);
        Product product6 = new Product("Mouse", 106, 24.99m, 2);
        Product product7 = new Product("Tablet", 107, 299.99m, 1);
        Product product8 = new Product("Printer", 108, 199.99m, 1);
        Product product9 = new Product("External Hard Drive", 109, 89.99m, 1);
        Product product10 = new Product("Webcam", 110, 79.99m, 2);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);
        order1.AddProduct(product4);
        order1.AddProduct(product5);

        Order order2 = new Order(customer2);
        order2.AddProduct(product6);
        order2.AddProduct(product7);
        order2.AddProduct(product8);
        order2.AddProduct(product9);
        order2.AddProduct(product10);

        Order order3 = new Order(customer3);
        order3.AddProduct(product1);
        order3.AddProduct(product3);
        order3.AddProduct(product5);
        order3.AddProduct(product7);
        order3.AddProduct(product9);

        Order order4 = new Order(customer4);
        order4.AddProduct(product2);
        order4.AddProduct(product4);
        order4.AddProduct(product6);
        order4.AddProduct(product8);
        order4.AddProduct(product10);

        // Display order details
        DisplayOrderDetails(order1);
        DisplayOrderDetails(order2);
        DisplayOrderDetails(order3);
        DisplayOrderDetails(order4);
    }

    static void DisplayOrderDetails(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order.GetTotalCost()}\n");
    }
}
