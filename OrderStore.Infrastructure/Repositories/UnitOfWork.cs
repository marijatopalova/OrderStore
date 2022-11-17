using OrderStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderStore.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        public IProductRepository Products { get; }
        public IOrderRepository Orders { get; }

        public UnitOfWork(ApplicationDbContext context, IProductRepository productRepository, IOrderRepository orderRepository)
        {
            this.context = context;
            Products = productRepository;
            Orders = orderRepository;
        }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
    }
}
