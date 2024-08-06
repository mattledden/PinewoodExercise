using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PinewoodExercise.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly ILogger<DeleteModel> _logger;

        public Customer? _customer;
        public bool _error = false;
        public string _errorMessage = "";

        public DeleteModel(ILogger<DeleteModel> logger)
        {
            _logger = logger;
        }

        public void OnPostSearch()
        {
            if (Request.Form["name"] != "")
            {
                _customer = CustomerList.GetCustomer(Request.Form["name"]);
                if (_customer == null)
                {
                    _logger.LogError("Customer not found");
                    _error = true;
                    _errorMessage = "Customer not found";
                }
            }
        }

        public void OnPostDelete()
        {
            _logger.LogInformation("Deleting customer {0}", Request.Form["name"]);
            // sometimes _customer was being reset to null so getting the customer name again
            // not an ideal solution as now there's a risk the user enters a different name and deletes a different customer
            _customer = CustomerList.GetCustomer(Request.Form["name"]);
            if (_customer == null)
            {
                _logger.LogError("Customer not found");
                _error = true;
                _errorMessage = "Customer not found";
            }
            else
            {
                CustomerList.RemoveCustomer(_customer);
                _customer = null; // set to null to clear the form
            }
        }
    }
}
