using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class Job
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El titulo debe de ser menor a 50 caracteres")]
        public string Title { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy}")]
        public DateTime Date { get; set; }

        public string Description { get; set; }

        public int PersonID { get; set; }

        [ForeignKey("PersonID")]
        public virtual Person person { get; set; }

    }

}