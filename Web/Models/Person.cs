using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Person
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El nombre debe de ser menor a 50 digitoss")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Debe de ser una direccion de correo valido.")]
        public string Email { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }

    }
}