using Microsoft.EntityFrameworkCore;
using OrderStore.Domain.Interfaces;
using OrderStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderStore.Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext context;

        public OrderRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Order>> GetOrdersByOrderName(string orderName)
        {
            return await context.Orders.Where(x => x.OrderDetails.Contains(orderName)).ToListAsync();
        }
    }
}
