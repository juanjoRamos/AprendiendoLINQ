using AprendiendoLINQ.Dto;
using AprendiendoLINQ.Models;
using Microsoft.EntityFrameworkCore;

namespace AprendiendoLINQ.Components.Pages.Exercises
{
    public partial class Exercise2
    {
        private IEnumerable<ModelEjercicio2> ListModelEjercicio2;

        protected override async Task OnInitializedAsync()
        {
            IEnumerable<Product>? ListProducts = await _NortwingContext.TableProducts.AsNoTracking().ToListAsync();
            IEnumerable<OrderDetails>? ListOrderDetails = await _NortwingContext.TableOrderDetails.AsNoTracking().ToListAsync();

            //Es mas lógico calcular primero en el join cada uno de los registros y luego al agrupar hacer la suma de ellos 
            //con los calculos ya realizados

            ListModelEjercicio2 = ListProducts
                .Join(ListOrderDetails, pk => pk.ProductID, odk => odk.ProductId, (product, orderdetail) => new
                {
                    //Esto lo hace registro por registro
                    NameProductRegistry = product.ProductName,
                    SoldProductRegistry = orderdetail.Quantity,
                    TotalRevenueRegistry = orderdetail.Quantity * orderdetail.UnitPrice,
                })
                .GroupBy(x => new { x.NameProductRegistry })
                .Select(result => new ModelEjercicio2
                {
                    ProductName = result.Key.NameProductRegistry,
                    TotalSold = result.Sum(x => x.SoldProductRegistry),
                    Totalrevenue = result.Sum(x => x.TotalRevenueRegistry),
                })
                .OrderByDescending(x => x.Totalrevenue);

            await base.OnInitializedAsync();
        }
    }
}
