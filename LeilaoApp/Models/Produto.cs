using System.ComponentModel.DataAnnotations;

namespace LeilaoApp.Models
{
    public class Produto
    {
        [Key]
        public int Id_Produto { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Valor Inicial")]
        public double Valor_Inicial { get; set; }
    }
}