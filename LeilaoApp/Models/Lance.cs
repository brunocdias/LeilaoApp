using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeilaoApp.Models
{
    public class Lance
    {
        [Key]
        public int Id_Lance { get; set; }

        [Required]
        [Display(Name = "Lista de Pessoas")]
        public int Id_Pessoa { get; set; }


        [ForeignKey("Id_Pessoa"), Column(Order = 0)]
        public Pessoa Pessoas { get; set; }


        [Required]
        [Display(Name = "Lista de Produtos")]
        public int Id_Produto { get; set; }


        [ForeignKey("Id_Produto"), Column(Order = 2)]
        public Produto Produtos { get; set; }

        [Required]
        [Display(Name = "Valor do Lance")]
        public double Valor { get; set; }

    }
}