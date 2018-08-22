using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication6.Pages.Phrase
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public PhraseInput PhraseInput { get; set; }
        [BindProperty]
        public List<PhraseInput> PhraseInputs { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            return Page();
        }
    }

    public class PhraseInput
    {
        public int Id { get; set; }
        public string Statement { get; set; }
        public string Translation { get; set; }
        public string Sentences { get; set; }
    }
}