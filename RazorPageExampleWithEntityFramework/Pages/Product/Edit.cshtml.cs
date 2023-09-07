﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPageExampleWithEntityFramework.Entity;

namespace RazorPageExampleWithEntityFramework.Pages.Product
{
    public class EditModel : PageModel
    {
        private readonly RazorPageExampleWithEntityFramework.Entity.ProductContextDb _context;

        public EditModel(RazorPageExampleWithEntityFramework.Entity.ProductContextDb context)
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

            var product =  await _context.ProductsEF.FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            Product = product;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductExists(int id)
        {
          return (_context.ProductsEF?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
