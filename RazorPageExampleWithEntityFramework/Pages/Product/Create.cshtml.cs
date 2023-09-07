using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPageExampleWithEntityFramework.Entity;

namespace RazorPageExampleWithEntityFramework.Pages.Product
{
    public class CreateModel : PageModel
    {
        private readonly RazorPageExampleWithEntityFramework.Entity.ProductContextDb _context;

        public CreateModel(RazorPageExampleWithEntityFramework.Entity.ProductContextDb context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Entity.Product Product { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ProductsEF == null || Product == null)
            {
                return Page();
            }

            _context.ProductsEF.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
