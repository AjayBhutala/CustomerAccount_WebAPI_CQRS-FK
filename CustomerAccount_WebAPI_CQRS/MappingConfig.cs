using AutoMapper;
using CustomerAccount_WebAPI_CQRS.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CustomerAccount_WebAPI_CQRS_FK
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Account, AccountDTO>().ReverseMap();

        }
    }
}
