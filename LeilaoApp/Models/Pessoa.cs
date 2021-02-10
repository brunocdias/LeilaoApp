using System.ComponentModel.DataAnnotations;

namespace LeilaoApp.Models
{
    public class Pessoa
    {
        [Key]
        public int Id_Pessoa { get; set; }

        [Required]
        [StringLength(45, ErrorMessage = "O nome deve conter até 45 caracteres.")]
        public string Nome { get; set; }

        [Required]

        public int Idade { get; set; }
    }
}