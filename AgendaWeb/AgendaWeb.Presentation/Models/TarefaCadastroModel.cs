using System.ComponentModel.DataAnnotations;

namespace AgendaWeb.Presentation.Models
{
    public class TarefaCadastroModel
    {
        [Required(ErrorMessage = "Informe o nome da tarefa.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o data da tarefa.")]
        public string Data { get; set; }

        [Required(ErrorMessage = "Informe a hora da tarefa.")]
        public string Hora { get; set; }

        [Required(ErrorMessage = "Informe a descrição da tarefa.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe a prioridade da tarefa.")]
        public string Prioridade { get; set; }

    }
}
