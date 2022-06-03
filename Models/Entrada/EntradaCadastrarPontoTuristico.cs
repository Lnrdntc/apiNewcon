using System.ComponentModel.DataAnnotations;

namespace TesteNewcon.Models.Entrada
{
    public class EntradaCadastrarPontoTuristico
    {

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Local { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Este campo deve conter menos que 100 catacteres")]
        public string Descricao { get; set; }
    }
}
