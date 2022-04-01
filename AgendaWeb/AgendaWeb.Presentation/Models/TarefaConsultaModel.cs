using AgendaWeb.Infra.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace AgendaWeb.Presentation.Models
{
    public class TarefaConsultaModel
    {
        [Required(ErrorMessage = "Informa a data de início.")]
        public string DataMin { get; set; }

        [Required(ErrorMessage = "Informe a data de término.")]
        public string DataMax { get; set; }

        public List<Tarefa>? Tarefas { get; set; }
    }
}
