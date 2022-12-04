using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAuthorization.Data;
using WebAuthorization.Data.Identity;
using WebAuthorization.Models;

namespace WebAuthorization.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly WebAuthorization.Data.ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EditModel(WebAuthorization.Data.ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [BindProperty]
        public StudentModel Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student =  await _context.Students.FirstOrDefaultAsync(m => m.Id == id);
            Student = _mapper.Map<Student, StudentModel>(student);

            if (student == null)
            {
                return NotFound();
            }
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

            if (Student.Deleted)
            {
                ModelState.AddModelError("Student.Deleted", "Could not be deleted");
                ModelState.AddModelError("", "Could not be deleted");
                return Page();
            }

            var student = _mapper.Map<Student>(Student);
            _context.Attach(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(Student.Id))
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

        private bool StudentExists(int id)
        {
          return _context.Students.Any(e => e.Id == id);
        }
    }
}
