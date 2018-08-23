using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using WebApplication6.Models;

namespace WebApplication6.Pages.Phrase
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public PhraseInput PhraseInput { get; set; }
        [BindProperty]
        public List<PhraseInput> PhraseInputs { get; set; }

        private readonly ApplicationContext _dbcontext;

        public IndexModel(ApplicationContext applicationContext)
        {
            _dbcontext = applicationContext;
        }

        public IActionResult OnGet()
        {
            var phrases = _dbcontext.Phrases;
            if (phrases != null && phrases.Any())
            {
                PhraseInputs = phrases.Select(x => new PhraseInput() { Id = x.Id, Statement = x.Statement }).ToList();
            }

            return Page();
        }

        public IActionResult OnGetAddForm()
        {
            var partial = new PartialViewResult();
            partial.ViewName = "_AddingPhrase";
            partial.ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
            {
                Model = PhraseInput
            };

            return partial;
        }

        public IActionResult OnPost()
        {
            var phrase = new Models.Phrase()
            {
                Id = 0,
                Statement = PhraseInput.Statement
            };

            _dbcontext.Phrases.Add(phrase);
            _dbcontext.SaveChanges();

            return Redirect("/Phrase/Index");
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