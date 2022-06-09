﻿//inocmplete here


using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.OrderHandler.Queries.GetAllOrders
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<OrderModel>> { }

    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderModel>>
    {
        private readonly DatabaseContext _context;
        public GetAllOrdersHandler(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<OrderModel>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.Order.ToListAsync();

            var ModelList = new List<OrderModel>();

            {
                if (data.Any() == true)
                {
                    foreach (var vals in data)
                    {
                        ModelList.Add(new OrderModel()
                        {
                            Id = vals.Id,
                            UserId = vals.UserId,
                            TotalAmount = vals.TotalAmount,
                            TotalDiscount = vals.TotalDiscount
                        });
                    }
                }

            }


            return ModelList;
        }
       
    }
    public class OrderModel
    {
      
        public int Id { get; set; }

        public  int UserId { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal? TotalDiscount { get; set; }
    }

}
