using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eCommerceAssessment.Models;
using eCommerceAssessment.Dtos.Order;
using eCommerceAssessment.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace eCommerceAssessment.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public OrderService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<OrderGetDto>>> AddOrder(OrderAddDto newOrder)
        {
            ServiceResponse<List<OrderGetDto>> serviceResponse = new ServiceResponse<List<OrderGetDto>>(); 
            // Order order = _mapper.Map<Order>(newOrder);
            /*
                I'm not actually quite sure why the above didn't work for order like it did for the 
                rest of the entities. I am definitely not the most certain about AutoMapper.
            */
            Order order = new Order();
            try
            {
                order.transactionid = newOrder.transaction;
                order.productid = newOrder.product;
                order.quantity = newOrder.quantity;
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
                serviceResponse.Data = (_context.Orders.Select(u => _mapper.Map<OrderGetDto>(u))).ToList();
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<OrderGetDto>>> GetAllOrders()
        {
            ServiceResponse<List<OrderGetDto>> serviceResponse = new ServiceResponse<List<OrderGetDto>>();
            try
            {
                List<Order> dbOrders = await _context.Orders.ToListAsync();
                serviceResponse.Data = dbOrders.Select(u => _mapper.Map<OrderGetDto>(u)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<OrderGetDto>> GetOrderById(int id)
        {
            ServiceResponse<OrderGetDto> serviceResponse = new ServiceResponse<OrderGetDto>();
            try
            {
                Order dbOrder = await _context.Orders.FirstOrDefaultAsync(u => u.id == id);
                serviceResponse.Data = _mapper.Map<OrderGetDto>(dbOrder); 
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<OrderGetDto>> UpdateOrder(OrderUpdateDto updatedOrder)
        {
            ServiceResponse<OrderGetDto> serviceResponse = new ServiceResponse<OrderGetDto>();
            try{
                Order order = await _context.Orders.FirstOrDefaultAsync(u => u.id == updatedOrder.id);

                order.id = updatedOrder.id;
                order.transactionid = updatedOrder.transaction;
                order.productid = updatedOrder.product;
                order.quantity = updatedOrder.quantity;

                _context.Orders.Update(order);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<OrderGetDto>(order);
            }
            catch (Exception ex) {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<OrderGetDto>>> DeleteOrder(int id)
        {
            ServiceResponse<List<OrderGetDto>> serviceResponse = new ServiceResponse<List<OrderGetDto>>();
            try{
                Order order = await _context.Orders.FirstAsync(u => u.id == id);
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
                
                serviceResponse.Data = (_context.Orders.Select(u => _mapper.Map<OrderGetDto>(u))).ToList();
            }
            catch (Exception ex) {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}