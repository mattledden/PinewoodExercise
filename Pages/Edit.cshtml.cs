using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PinewoodExercise.Pages
{
    public class EditModel : PageModel
    {
        private readonly ILogger<EditModel> _logger;
        public Customer? _customer;
        public string _name;
        public bool _error = false;
        public string _errorMessage = "";

        public EditModel(ILogger<EditModel> logger)
        {
            _logger = logger;
        }

        public void OnPostSearch()
        {
            _name = Request.Form["name"];
            if (_name != "")
            {
                _customer = CustomerList.GetCustomer(_name);
                if (_customer == null)
                {
                    _logger.LogError("Customer not found");
                    _error = true;
                    _errorMessage = "Customer not found";
                }
            }
        }

        public void OnPostEdit()
        {
            if (Request.Form["name"] == "")
            {
                _logger.LogError("No customer name given");
                _error = true;
                _errorMessage = "No customer name given";
            }
            else
            {
                Customer newValues = new(Request.Form["name"], Request.Form["address"], Request.Form["number"], Request.Form["email"]);
                _logger.LogInformation("new address : " + newValues.Address);
                _logger.LogInformation("name : " + Request.Form["name"]);
                _customer = CustomerList.GetCustomer(Request.Form["name"]);
                _logger.LogInformation("old address : " + _customer.Address);
                CustomerList.EditCustomer(_customer, newValues);
                _customer = null; // set to null to clear the form
            }
        }
    }
}
