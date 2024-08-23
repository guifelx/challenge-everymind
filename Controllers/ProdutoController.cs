using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EverymindChallenge.Context;
using EverymindChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EverymindChallenge.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutosContext _context;

        public ProdutoController(ProdutosContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var produtos = _context.Produtos.ToList();
            return View(produtos);
        }

        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Novo(Produto produto)
        {
            if(ModelState.IsValid)
            {
                _context.Produtos.Add(produto); 
                _context.SaveChanges(); 
                return RedirectToAction(nameof(Index));
            }

            return View(produto); 
        }

        public IActionResult Editar(int id)
        {
            var produto = _context.Produtos.Find(id);

            if(produto == null)
            {
                return RedirectToAction(nameof(Index)); 
            }
            return View(produto);
        }

        [HttpPost]
        public IActionResult Editar (Produto produto)
        {
            var produtoBanco = _context.Produtos.Find(produto.Id);

            produtoBanco.Nome = produto.Nome;
            produtoBanco.Codigo = produto.Codigo; 
            produtoBanco.PrecoProduto = produto.PrecoProduto;
            produtoBanco.Descricao = produto.Descricao;

            _context.Produtos.Update(produtoBanco); 
            _context.SaveChanges();
            
            return RedirectToAction(nameof(Index)); 
        }

        public IActionResult Deletar (int id)
        {
            var produto = _context.Produtos.Find(id);

            if(produto == null)
                return RedirectToAction(nameof(Index));

            return View(produto);
        }
        
        [HttpPost]
        public IActionResult Deletar (Produto produto) 
        {
            var produtoBanco = _context.Produtos.Find(produto.Id); 

            _context.Produtos.Remove(produtoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index)); 
        }
    }
}