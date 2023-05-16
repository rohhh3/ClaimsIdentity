using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EFDemo.Data;
using EFDemo.Models;

namespace EFDemo.Pages
{
    public class CreateModel : PageModel
    {
        private readonly EFDemo.Data.ApplicationDbContext _context;

        public CreateModel(EFDemo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Person Person { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Person == null || Person == null)
            {
                return Page();
            }
            Person.Created = DateTime.Now;
            if ((Person.Year % 4 == 0 && Person.Year % 100 != 0) || Person.Year % 400 == 0)
                Person.Result = "Rok przestepny";
            else
                Person.Result = "Rok nieprzestepny";

            _context.Person.Add(Person);
            await _context.SaveChangesAsync();
            return Page();
        }
    }
}
