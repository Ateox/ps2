using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace FizzBuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public FizzBuzzForm FizzBuzz { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
            
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                Name = "User";
            }
        }
        public string Information;
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid){
                return Page();
            }
            if (FizzBuzz.Number%3 == 0 && FizzBuzz.Number%5 == 0)
            {
                Information = "FizzBuzz";
            }else if (FizzBuzz.Number%5 == 0)
            {
                Information = "Buzz";
            }else if (FizzBuzz.Number%3 == 0)
            {
                Information = "Fizz";
            }else
            {
                Information = "Liczba "+FizzBuzz.Number+" nie spełnia kryteriów FizzBuzz";
            }
            return Page();
        }
    }
}