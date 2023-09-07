using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageExampleWithEntityFramework.Entity;

namespace RazorPageExampleWithEntityFramework.Pages.Product
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPageExampleWithEntityFramework.Entity.ProductContextDb _context;

        public DeleteModel(RazorPageExampleWithEntityFramework.Entity.ProductContextDb context)
        {
            _context = context;
        }

        [BindProperty]
      public Entity.Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ProductsEF == null)
            {
                return NotFound();
            }

            var product = await _context.ProductsEF.FirstOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            else 
            {
                Product = product;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ProductsEF == null)
            {
                return NotFound();
            }
            var product = await _context.ProductsEF.FindAsync(id);

            if (product != null)
            {
                Product = product;
                _context.ProductsEF.Remove(Product);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
