using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PinewoodExercise.Pages
{
    public class AddModel : PageModel
    {
        private readonly ILogger<AddModel> _logger;

        public AddModel(ILogger<AddModel> logger)
        {
            _logger = logger;
        }

        public void OnPost()
        {
            if (Request.Form["name"] != "")
            {
                // Do something here
                _logger.LogInformation(Request.Form["name"]);

            }
        }
    }
}
