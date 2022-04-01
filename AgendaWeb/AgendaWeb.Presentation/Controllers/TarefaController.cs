using AgendaWeb.Infra.Data.Entities;
using AgendaWeb.Infra.Data.Repositories;
using AgendaWeb.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaWeb.Presentation.Controllers
{
    public class TarefaController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(TarefaCadastroModel model, [FromServices] ITarefaRepository tarefaRepository)
        {
            // Verifica se todos os campos do Model passaram nas regras de validação
            if (ModelState.IsValid)
            {
                try
                {
                    var tarefa = new Tarefa();

                    tarefa.Id = Guid.NewGuid();
                    tarefa.Nome = model.Nome;
                    tarefa.Data = DateTime.Parse(model.Data);
                    tarefa.Hora = TimeSpan.Parse(model.Hora);
                    tarefa.Descricao = model.Descricao;
                    tarefa.Prioridade = int.Parse(model.Prioridade);

                    tarefaRepository.Create(tarefa);

                    TempData["MensagemSucesso"] = $"Tarefa {tarefa.Nome} foi cadastrada com sucesso!";

                    //limpar os campos do formulário
                    ModelState.Clear();
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = $"Falha ao cadastrar tarefa: {e.Message}";
                }
            }
            else
            {
                TempData["MensagemAlerta"] = $"Ocorreram erros de validação no preenchimento dos dados, por favor verifique!";
            }

            return View();
        }

        public IActionResult Consulta()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Consulta(TarefaConsultaModel model, [FromServices] ITarefaRepository tarefaRepository)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    model.Tarefas = tarefaRepository.FindByDate(DateTime.Parse(model.DataMin), DateTime.Parse(model.DataMax));
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = $"Falha ao consultar tarefas: {e.Message}";
                }
            } 
            else
            {
                TempData["MensagemAlerta"] = $"Ocorreram erros de validação no preenchimento dos dados, por favor verifique!";
            }

            return View(model);
        }

        public IActionResult Exclusao(Guid id, [FromServices] ITarefaRepository tarefaRepository)
        {
            try
            {
                if (id != null)
                {
                    var tarefa = new Tarefa();
                    tarefa.Id = id;

                    tarefaRepository.Delete(tarefa);

                    TempData["MensagemSucesso"] = $"Tarefa excluída com sucesso!";
                }
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Falha ao excluir a tarefa. Erro: {e.Message}";
            }


            return RedirectToAction("Consulta");
        }
    }
}
