using AutoMapper;
using AutoMapper.Configuration.Annotations;
using ConsoleAutoMapper.domain;

namespace ConsoleAutoMapper.DTO
{
    [AutoMap(typeof(product))]
    public class product2DTO
    {
        [SourceMember("Id")]
        public int productId
        {
            get; set;
        }
     
        [SourceMember("Name")]
        public string productName
        {
            get; set;
        }
        [SourceMember("SKU")]
        public string SKU
        {
            get; set;
        }
    }
}