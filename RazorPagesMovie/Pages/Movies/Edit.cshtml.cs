using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;
namespace RazorPagesMovie.Pages.Movies{
    public class EditModel:PageModel{
        private readonly MovieContext _context;
        public EditModel(MovieContext context){
            _context=context;
        }
        [BindProperty]
        public Movie Movie{get;set;}
       public async Task<IActionResult>OnGetAsync(int?id){
           if(id==null){
               return NotFound();
           }
           Movie=await _context.Movie.SingleOrDefaultAsync(m=>m.ID==id);
           if(Movie==null){
               return NotFound();
           }
           return Page();

       }
    }
}