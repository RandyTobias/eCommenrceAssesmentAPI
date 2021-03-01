using System.Collections.Generic;
using System.Threading.Tasks;
using eCommerceAssessment.Models;
using eCommerceAssessment.Dtos.Order;

namespace eCommerceAssessment.Services.OrderService
{
    public interface IOrderService
    {
        Task<ServiceResponse<List<OrderGetDto>>> GetAllOrders();
        Task<ServiceResponse<OrderGetDto>> GetOrderById(int id);
        Task<ServiceResponse<List<OrderGetDto>>> AddOrder(OrderAddDto newOrder);
        Task<ServiceResponse<OrderGetDto>> UpdateOrder(OrderUpdateDto updatedOrder);
        Task<ServiceResponse<List<OrderGetDto>>> DeleteOrder(int id);
    }
}