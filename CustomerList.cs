public static class CustomerList
{
    private static List<Customer> _customers = [];
    public static void AddCustomer(Customer customer)
    {
        _customers.Add(customer);
    }

    public static void RemoveCustomer(Customer customer)
    {
        _customers.Remove(customer);
    }

    public static void EditCustomer(Customer originalCustomer, Customer newValues)
    {
        Console.WriteLine("original address: " + originalCustomer.Address);
        Console.WriteLine("new address: " + newValues.Address);
        originalCustomer.Name = newValues.Name;
        originalCustomer.Address = newValues.Address;
        originalCustomer.Number = newValues.Number;
        originalCustomer.Email = newValues.Email;
    }

    public static Customer GetCustomer(string name)
    {
        return _customers.Find(c => c.Name == name);
    }

    public static List<Customer> GetCustomers()
    {
        return _customers;
    }
}
