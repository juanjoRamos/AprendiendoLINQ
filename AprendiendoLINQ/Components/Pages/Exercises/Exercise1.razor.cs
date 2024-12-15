using AprendiendoLINQ.Dto;
using AprendiendoLINQ.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AprendiendoLINQ.Components.Pages.Exercises
{
    public partial class Exercise1
    {
        private IEnumerable<ModelEjercicio1> ListModelEjercicio1;
        protected override async Task OnInitializedAsync()
        {
            IEnumerable<Customer>? ListCustomers = await _NortwingContext.TableCustomers.AsNoTracking().ToListAsync();
            IEnumerable<Order>? ListOrder = await _NortwingContext.TableOrders.AsNoTracking().ToListAsync();
            IEnumerable<OrderDetails> ListProduct = await _NortwingContext.TableOrderDetails.AsNoTracking().ToListAsync();

            ListModelEjercicio1 = ListCustomers
                .Join(ListOrder, kc => kc.CustomerID, ko1 => ko1.CustomerID,
                (customer, order) => new
                {
                    CustomerName = customer.ContactName,
                    OrderId = order.OrderID
                })
                .Join(ListProduct, ko => ko.OrderId, kp => kp.OrderId,
                (order, product) => new ModelEjercicio1
                {
                    CustomerName = order.CustomerName,
                    OrderId = order.OrderId,
                    TotalAmount = product.UnitPrice * product.Quantity
                })
                .GroupBy(x => new { x.CustomerName })
                .Select(y => new ModelEjercicio1
                {
                    CustomerName = y.Key.CustomerName,
                    TotalAmount = y.Sum(s => s.TotalAmount)
                })
                .OrderByDescending(obd => obd.TotalAmount);

            await base.OnInitializedAsync();
        }

    }
}
