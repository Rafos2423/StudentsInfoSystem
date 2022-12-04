using System.ComponentModel.DataAnnotations;
using WebAuthorization.Models.Validators;

namespace WebAuthorization.Models
{
    public class StudentModel
    {
        public int Id { get; set; }

        [NameExists]
        [FirstCapital(ErrorMessage = "Must be first capital")]
        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public bool Deleted { get; set; }

        [Required(ErrorMessage = "Enter Price")]
        public decimal Price { get; set; }

        public string FullName { get; set; }
    }
}