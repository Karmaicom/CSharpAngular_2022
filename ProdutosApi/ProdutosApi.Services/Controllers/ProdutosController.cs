using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApi.Infra.Data.Entities;
using ProdutosApi.Infra.Data.Interfaces;
using ProdutosApi.Services.Requests;

namespace ProdutosApi.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {

        private IProdutoRepository _produtoRepository;

        public ProdutosController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpPost]
        public IActionResult Post(ProdutoPostRequest request)
        {
            try
            {
                var produto = new Produto()
                {
                    IdProduto = Guid.NewGuid(),
                    Nome  = request.Nome,
                    Preco = request.Preco,
                    Quantidade = request.Quantidade,
                    DataCadastro = DateTime.Now
                };

                _produtoRepository.Inserir(produto);

                return StatusCode(201, new { mensagem = "Cadastro realizado com sucesso.", produto });
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(ProdutoPutRequest request)
        {
            try
            {
                var produto = _produtoRepository.ObterPorId(request.IdProduto);

                if (produto != null)
                {
                    produto.Nome = request.Nome;
                    produto.Preco = request.Preco;
                    produto.Quantidade = request.Quantidade;

                    _produtoRepository.Alterar(produto);

                    return StatusCode(200, new { mensagem = "Produto atuaizado.", produto });
                }
                else
                {
                    return StatusCode(400, new { mensagem = "O Produto não está cadastrado no sistema."});
                }
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var produto = _produtoRepository.ObterPorId(id);

                if (produto != null)
                {
                    _produtoRepository.Delete(produto);

                    return StatusCode(200, new { mensagem = "Produto excluído com sucesso.", produto });
                }
                else
                {
                    return StatusCode(400, new { mensagem = "Produto não encontrado.", produto });
                }
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var produtos = _produtoRepository.Consultar();
                return StatusCode(200, produtos);
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var produto = _produtoRepository.ObterPorId(id);

                if (produto == null)
                {
                    return StatusCode(404, new { mensagem = "Produto não encontrado." });
                }

                return StatusCode(200, produto);
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }
    }
}
