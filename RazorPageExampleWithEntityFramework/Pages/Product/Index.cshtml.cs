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
    public class IndexModel : PageModel
    {
        private readonly RazorPageExampleWithEntityFramework.Entity.ProductContextDb _context;

        public IndexModel(RazorPageExampleWithEntityFramework.Entity.ProductContextDb context)
        {
            _context = context;
        }

        public IList<Entity.Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ProductsEF != null)
            {
                Product = await _context.ProductsEF.ToListAsync();
            }
        }
    }
}
