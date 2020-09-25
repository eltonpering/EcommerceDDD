using Domain.Interfaces.InterfaceProduct;
using Domain.Interfaces.InterfaceServices;
using Domain.Services;
using Entities.Entities;
using Infrastructure.Repository.Repositories;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTestEcommerceDDD
{
    [TestClass]
    public class UnitTestEcomerce
    {
        [TestMethod]
        public async Task AddProductComSucesso()
        {
            try
            {
                IProduct _IProduct = new RepositoryProduct();
                IServiceProduct _IServiceProduct = new ServiceProduct(_IProduct);
                var produto = new Produto
                {
                    Descricao = string.Concat("Descrição Test TDD", DateTime.Now.ToString()),
                    QtdEstoque = 10,
                    Nome = string.Concat("Nome Test TDD", DateTime.Now.ToString()),
                    Valor = 20,
                    UserId = "2355646e-2176-4524-9d8c-9688d4ee556b"
                };
                await _IServiceProduct.AddProduct(produto);

                Assert.IsFalse(produto.Notificacoes.Any());
            }
            catch (Exception)
            {

                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task AddProductComValidacaoCampoObrigatorio()
        {
            try
            {
                IProduct _IProduct = new RepositoryProduct();
                IServiceProduct _IServiceProduct = new ServiceProduct(_IProduct);
                var produto = new Produto
                {

                };
                await _IServiceProduct.AddProduct(produto);

                Assert.IsTrue(produto.Notificacoes.Any());
            }
            catch (Exception)
            {

                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task ListarProdutosUsuario()
        {

            try
            {
                IProduct _IProduct = new RepositoryProduct();

                var listaProdutos = await _IProduct.ListarProdutosUsuario("2355646e-2176-4524-9d8c-9688d4ee556b");

                Assert.IsTrue(listaProdutos.Any());
            }
            catch (Exception)
            {

                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task GetEntityById()
        {
            try
            {
                IProduct _IProduct = new RepositoryProduct();
                var listaProdutos = await _IProduct.ListarProdutosUsuario("2355646e-2176-4524-9d8c-9688d4ee556b");
                var produto = await _IProduct.GetEntityById(listaProdutos.LastOrDefault().Id);

                Assert.IsTrue(produto != null);
            }
            catch (Exception)
            {

                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task Delete()
        {
            try
            {
                IProduct _IProduct = new RepositoryProduct();
                var listaProdutos = await _IProduct.ListarProdutosUsuario("2355646e-2176-4524-9d8c-9688d4ee556b");
                var ultimoProduto = listaProdutos.LastOrDefault();
                await _IProduct.Delete(ultimoProduto);
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }


    }
}
