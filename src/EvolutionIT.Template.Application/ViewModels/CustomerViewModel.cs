using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EvolutionIT.Template.Application.ViewModels
{
    public class CustomerViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required.")]
        [MinLength(4)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The e-mail is required.", AllowEmptyStrings = false)]
        [EmailAddress]
        [DisplayName("E-mail")]
        public string Email { get; set; }
    }
}
