using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFinanceiro.Models
{
    public class Requisicao
    {
        public int Id { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }

        [Required]
        public DateTime Data { get; set; } = DateTime.Now;

        public string? Status { get; set; } = "Pendente";
    }
}