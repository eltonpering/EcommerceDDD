﻿using Domain.Interfaces.Generics;
using Entities.Entities;
using Entities.Entities.Enums;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceCompraUsuario
{
    public interface ICompraUsuario : IGeneric<CompraUsuario>
    {
        public Task<int> QuantidadeProdutoCarrinhoUsuario(string userId);

        public Task<CompraUsuario> ProdutosCompradosPorEstado(string userId, EnumEstadoCompra estado);

        public Task<bool> ConfirmaCompraCarrinhoUsuario(string userId);
    }
}
