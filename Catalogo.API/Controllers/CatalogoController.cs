using Catalogo.Domain.Entities;
using Catalogo.Domain.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.API.Controllers
{
    [Route("/api/[Controller]")]
    [ApiController]
    [Authorize]
    public class CatalogoController : Controller
    {
        ProdutoService _produtoService;

        public CatalogoController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public ActionResult Obter()
        {
            try
            {
                var produto = _produtoService.GetProdutos();
                return Ok(produto);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        [HttpPost]
        public ActionResult Salvar([FromForm] Produto produto)
        {
            _produtoService.SalvarProduto(produto);
            return Ok();
        }

        [HttpDelete("({id})")]
        public ActionResult Deletar(int id)
        {
            _produtoService.DeleteProduto(id);
            return Ok();
        }

        [HttpPut("({id})")]
        public ActionResult Atualizar(int id, Produto produto)
        {
            _produtoService.AtualizarProduto(id, produto);
            return Ok();
        }
    }
}
