using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PinewoodExercise.Pages
{
    public class AddModel : PageModel
    {
        private readonly ILogger<AddModel> _logger;
        public bool _error = false;
        public string _errorMessage = "";

        public AddModel(ILogger<AddModel> logger)
        {
            _logger = logger;
        }

        public void OnPost()
        {
            if (Request.Form["name"] == "")
            {
                _logger.LogError("No customer name given");
                _error = true;
                _errorMessage = "No customer name given";
            }
            else
            {
                Customer newCustomer = new(Request.Form["name"], Request.Form["address"], Request.Form["number"], Request.Form["email"]);
                CustomerList.AddCustomer(newCustomer);
            }
        }
    }
}
