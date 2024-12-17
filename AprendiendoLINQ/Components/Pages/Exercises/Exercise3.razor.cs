using AprendiendoLINQ.Dto;
using AprendiendoLINQ.Models;
using Microsoft.EntityFrameworkCore;

namespace AprendiendoLINQ.Components.Pages.Exercises
{
    public partial class Exercise3
    {
        private IEnumerable<ModelEjercicio3>? ListModelEjercicio3 { get; set; }

        protected override async Task OnInitializedAsync()
        {
            IEnumerable<Category>? _categories = await _NortwingContext.TableCategories.AsNoTracking().ToListAsync();
            IEnumerable<Product> _product = await _NortwingContext.TableProducts.AsNoTracking().ToListAsync();
            IEnumerable<OrderDetails> _orderDetails = await _NortwingContext.TableOrderDetails.AsNoTracking().ToListAsync();

            ListModelEjercicio3 = _categories.Join(_product, pkc => pkc.Id, pkp => pkp.CategoryID,
                (category, product) =>
                    new
                    {
                        CategoryId = category.Id,
                        CategoryName = category.Name,
                        ProductId = product.ProductID,
                    }
                )
                .Join(_orderDetails, lst1 => lst1.CategoryId, pkod => pkod.ProductId,
                (ls1, orderdetail) => new {
                    CategoryName = ls1.CategoryName,
                    CategoryId = ls1.CategoryId,
                    TotalByProduct = orderdetail.Quantity * orderdetail.UnitPrice
                })
                .GroupBy(x => new { x.CategoryId, x.CategoryName })
                .Select(y => 
                    new ModelEjercicio3 
                    {
                        CategoryName = y.Key.CategoryName,
                        TotalProductByCategory = y.Count(),
                        TotalRevenueByCategory = y.Sum(trbc => trbc.TotalByProduct)
                    }
                ).OrderByDescending(x => x.TotalRevenueByCategory);


            await base.OnInitializedAsync();
        }
    }
}
