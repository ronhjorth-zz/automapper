using AutoMapper;
using AutoMapper.Configuration.Annotations;
using ConsoleAutoMapper.DTO;

namespace ConsoleAutoMapper.domain
{
    [AutoMap(typeof(product2DTO))]
    public class product
    {
        [SourceMember("productId")]
        public int Id
        {
            get; set;
        }
        [SourceMember("productName")]
        public string Name
        {
            get; set;
        }
        [SourceMember("SKU")]
        public string SKU
        {
            get; set;
        }

        public product(int id, string name, string sku)
        {
            this.Id = id;
            this.Name = name;
            this.SKU = sku;
        }
    }
}