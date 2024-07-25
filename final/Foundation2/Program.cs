using System;
class Program
{
    public static void Main(string[] args)
    {
        Address address1 = new Address("1080 Main St", "Motown", "ML", "Botswana");
        Address address2 = new Address("512 Ram St", "Othertown", "ON", "Canada");

        Customer customer1 = new Customer("Mike Epps", address1);
        Customer customer2 = new Customer("James Bond", address2);

        Product product1 = new Product("Laptop", "LPT123", 999.99, 1);
        Product product2 = new Product("Mouse", "MSE456", 25.50, 2);
        Product product3 = new Product("Keyboard", "KBD789", 49.99, 1);
        Product product4 = new Product("Monitor", "MNT101", 199.99, 1);
        Product product5 = new Product("USB Cable", "USB102", 10.99, 3);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: {order1.GetTotalCost():C}");

        Console.WriteLine();

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: {order2.GetTotalCost():C}");
    }
}
