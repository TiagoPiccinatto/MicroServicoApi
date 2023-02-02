using Catalogo.Domain.Entities;
using Catalogo.Domain.Service;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.API.Controllers
{
    [Route("/api/[Controller]")]
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
            var produto = _produtoService.GetProdutos();
            return Ok(produto);
        }
        [HttpPost]
        public ActionResult Salvar([FromBody] Produto produto)
        {
            _produtoService.SalvarProduto(produto);
            return Ok();
        }
    }
}
