﻿
using AnyBuyStore.Data.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AnyBuyStore.Core.Handlers.ProductHandler.Queries.GetAllByUserId
{
    public class GetAllByUserIdQuery : IRequest<IEnumerable<ProductModel>>
    {
        public int UserId { get; set; }

        public class GetAllByUserIdHandler : IRequestHandler<GetAllByUserIdQuery, IEnumerable<ProductModel>>
        {
            private readonly DatabaseContext _context;
            public GetAllByUserIdHandler(DatabaseContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<ProductModel>> Handle(GetAllByUserIdQuery request, CancellationToken cancellationToken)
            {
                var data = await _context.Product.Where(a => a.UserId == request.UserId).ToListAsync();

                var getData = new List<ProductModel>();

                {

                    foreach (var product in data)
                    {
                        getData.Add(new ProductModel()
                        {
                            Id = product.Id,
                            DiscountId = product.DiscountId,
                            ProductSubcategoryId = product.ProductSubcategoryId,
                            Name = product.Name,
                            Description = product.Description,
                            Price = product.Price,
                            Brand = product.Brand,
                            ImageUrl = product.ImageUrl,
                            Quantity = product.Quantity
                        });
                    }

                }

                return getData;
            }
        }
    }
    public class ProductModel
    {
        public int Id { get; set; }
        public int? DiscountId { get; set; }
        public int ProductSubcategoryId { get; set; }
        public string Name { get; set; } = String.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; } = String.Empty;
        public string ImageUrl { get; set; } = String.Empty;
        public int Quantity { get; set; } = 1;

    }

}



