﻿using Catalogo.Domain.Entities;
using Catalogo.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Domain.Service
{
    public class ProdutoService : IProdutoService
    {
        IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }


        public List<Produto> GetProdutos()
        {
            return _produtoRepository.GetProdutos();
        }


        public Produto SalvarProduto(Produto produto)
        {
            if (produto != null)
            {
                return _produtoRepository.Salvar(produto);
            }
            return null;
        }

        public bool DeleteProduto(int id)
        {
            var retorno = _produtoRepository.Delete(id);

            if (retorno)
            {
                return true;
            }
            return false;

        }

        public Produto AtualizarProduto(int id, Produto produto)
        {
           return _produtoRepository.Atualizar(id, produto);
        }

    }
}
