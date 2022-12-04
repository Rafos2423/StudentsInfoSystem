using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAuthorization.Data;
using WebAuthorization.Data.Identity;
using WebAuthorization.Models;

namespace WebAuthorization.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly WebAuthorization.Data.ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateModel(WebAuthorization.Data.ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CreateStudentModel Student { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var student = _mapper.Map<Student>(Student);

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
