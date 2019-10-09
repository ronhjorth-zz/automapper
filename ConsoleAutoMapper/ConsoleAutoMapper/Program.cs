using System;
using System.Collections.Generic;
using AutoMapper;
using System.Text.Json;
using System.Text.Json.Serialization;
using ConsoleAutoMapper.core.maps;
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
            
            var newProduct = new product(21, "Blue Barries", "123BB", 3);
            
            /*
             First step create a map between the domain and DTO objects. 
                        
                Simple mapping with the DTO and domain object can be mapped directly.     
                All members within the source and destination are exactly the same.
            */
            var configSameMembers = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<user, userDTO>();
            });
           
            IMapper userSameMembersMapper = configSameMembers.CreateMapper();

            /*                
                More time than not members within the objects do not match so you need to 
                Configure AutoMapper and define the member mapping. dest.productId = src.Id
                Note:
                    this is called "projection"
                    You can do this inline with the the main stream of code OR you could 
                    create a DomainMappingProfile for a clean implementation of the map.  
            */
            var configuration =  new MapperConfiguration(cfg => {
               cfg.CreateMap<product, productDTO>();
               cfg.AddProfile<DomainMappingProfile>();
           });

           var productDifferentMembersMapper = new Mapper(configuration);
           /*
               Final step Perform map the values and out put to screen.
           */
            
            var userDestination = userSameMembersMapper.Map<user, userDTO>(newUser);
            var productDestination  = productDifferentMembersMapper.Map<product, productDTO>(newProduct);
            
            string userMessage = String.Format("New User added name = {0} {1}", userDestination.firstName,
                userDestination.lastName);
            
            string productMessage = String.Format("New product added name:{0} SKU:{1}", productDestination.productName, 
                productDestination.SKU);
            
            Console.WriteLine(userMessage);
            Console.WriteLine(productMessage);
            
            /*
                now lets place an order 
                placing an order uses a more complex object to map.
            */
            List<product> orderedProducts = new List<product>();
            
            orderedProducts.Add(newProduct);
            orderedProducts.Add(new product{Id = 45, Name = "PineApple", SKU = "123PA", quanity = 50});

            var newOrder = new order
            {
                Id = Guid.NewGuid().ToString(),
                createDate = DateTime.Today.ToString(),
                userId = newUser.userId.ToString(),
                products = orderedProducts
            };

            var orderConfig =  new MapperConfiguration(cfg => {
                cfg.CreateMap<order, orderDTO>();
                cfg.AddProfile<DomainMappingProfile>();
            });
            var orderMapper = new Mapper(orderConfig);
            var orderInfo  = orderMapper.Map<order, orderDTO>(newOrder);

            string json = JsonSerializer.Serialize<orderDTO>(orderInfo);
            
            Console.WriteLine(json);
        }
    }
}