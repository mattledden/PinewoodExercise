using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PinewoodExercise.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly ILogger<DeleteModel> _logger;

        public Customer _customer;

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
                }
            }
        }

        public void OnPostDelete()
        {
            _logger.LogInformation("Deleting customer {0}", Request.Form["name"]);
            _customer = CustomerList.GetCustomer(Request.Form["name"]);
            CustomerList.RemoveCustomer(_customer);
        }
    }
}
