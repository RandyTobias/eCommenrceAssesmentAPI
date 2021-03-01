using AutoMapper;
using eCommerceAssessment.Models;
using eCommerceAssessment.Dtos.Address;
using eCommerceAssessment.Dtos.User;
using eCommerceAssessment.Dtos.UserType;
using eCommerceAssessment.Dtos.ShippingProvider;
using eCommerceAssessment.Dtos.Product;
using eCommerceAssessment.Dtos.Order;
using eCommerceAssessment.Dtos.Transaction;

namespace eCommerceAssessment
{
    public class AutoMapperProfile : Profile    
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserGetDto>();
            CreateMap<UserRegisterDto, User>();
            CreateMap<Address, AddressGetDto>();
            CreateMap<AddressAddDto, Address>();
            CreateMap<UserType, UserTypeGetDto>();
            CreateMap<UserTypeAddDto, UserType>();
            CreateMap<ShippingProvider, ShippingProviderGetDto>();
            CreateMap<ShippingProviderAddDto, ShippingProvider>();
            CreateMap<Product, ProductGetDto>();
            CreateMap<ProductAddDto, Product>();
            CreateMap<Order, OrderGetDto>();
            CreateMap<OrderAddDto, Order>();
            CreateMap<Transaction, TransactionGetDto>();
            CreateMap<TransactionAddDto, Transaction>();
        }
    }
}