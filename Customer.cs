public class Customer
{
    private string _name;
    private string _address;
    private string _number;
    private string _email;
    public Customer(string name, string address, string number, string email)
    {
        _name = name;
        _address = address;
        _number = number;
        _email = email;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetAddress()
    {
        return _address;
    }

    public string GetNumber()
    {
        return _number;
    }

    public string GetEmail()
    {
        return _email;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public void SetAddress(string address)
    {
        _address = address;
    }

    public void SetNumber(string number)
    {
        _number = number;
    }

    public void SetEmail(string email)
    {
        _email = email;
    }
}
