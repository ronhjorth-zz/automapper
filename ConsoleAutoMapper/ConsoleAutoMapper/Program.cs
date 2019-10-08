using System;
using AutoMapper;
using ConsoleAutoMapper.DTO;
using ConsoleAutoMapper.domain;
namespace ConsoleAutoMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("AutoMapper 2000!");
            /*
             First step create a map between the two product objects. 
                        
                Simple mapping with the DTO and domain object can be mapped directly.     
                All members within the source and destination are exactly the same.
            */
            var configSameMembers = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<user, userDTO>();
            });
            /*                
                More time than not members within the objects do not match so you need to 
                Configure AutoMapper and define the member mapping. dest.productId = src.Id
                Note:
                    this is called projections 
            */
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<product, productDTO>()
                    .ForMember(dest => dest.productId, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.productName, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.SKU, opt => opt.MapFrom(src => src.SKU)));

            var configProduct2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<product, product2DTO>();
            });
            configProduct2.AssertConfigurationIsValid();
            
            //var configuration = new MapperConfiguration(cfg => cfg.AddMaps("ConsoleAutoMapper.DTO.product"));

            //var productDifferentMembers2Mapper = new Mapper(configuration);
            
            /*
                Second step create a map                 
            */
            IMapper userSameMembersMapper = configSameMembers.CreateMapper();
            IMapper productDifferentMembersMapper = config.CreateMapper();
            IMapper productDifferentMembers2Mapper = configProduct2.CreateMapper();
            
            
            /*
                Final step Perform mapping
                
                create a new user and new product            

                Note : 
                newUser is initialize a new user type by using object initializers. 
                newProduct is initialize a new product type by a constructor.
            */
            var newUser = new user 
            {
                userId = 22, 
                firstName="Test", 
                lastName = "Dummy"
            };
            
            var newProduct = new product(21, "Blue Barries", "123BB");

            var userDestination = userSameMembersMapper.Map<user, userDTO>(newUser);
            var productDestination  = productDifferentMembersMapper.Map<product, productDTO>(newProduct);
            var productDestination2  = productDifferentMembers2Mapper.Map<product, product2DTO>(newProduct);
            
            string userMessage = String.Format("New User added name = {0} {1}", userDestination.firstName,
                userDestination.lastName);
            
            string productMessage = String.Format("New product added name : {0} SKU : {1}", productDestination.productName,
                productDestination.SKU);
            
            Console.WriteLine(userMessage);
            Console.WriteLine(productMessage);
            
        }
    }
}