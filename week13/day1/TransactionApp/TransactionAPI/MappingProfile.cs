using AutoMapper;
using TransactionAPI.DTOs;
using TransactionAPI.Models;

namespace TransactionAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Transaction, TransactionDto>();
        }
    }
}