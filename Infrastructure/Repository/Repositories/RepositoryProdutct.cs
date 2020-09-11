using Domain.Interfaces.InterfaceProduct;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryProdutct : RepositoryGenerics<Produto>, IProduct
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;


        public RepositoryProdutct()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Produto>> ListarProdutosUsuario(string userId)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await banco.Produto.Where(p => p.UserId == userId).AsNoTracking().ToListAsync();
            }
        }
    }
}
