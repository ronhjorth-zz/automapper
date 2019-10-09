using AutoMapper;
using AutoMapper.Configuration.Annotations;
using ConsoleAutoMapper.DTO;

namespace ConsoleAutoMapper.domain
{
    [AutoMap(typeof(productDTO))]
    public class product
    {
        [SourceMember("productId")]
        public int Id
        {
            get; set;
        }
        
        public int quanity
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

        public product()
        {
        }

        public product(int id, string name, string sku, int quantity)
        {
            this.Id = id;
            this.Name = name;
            this.SKU = sku;
            this.quanity = quantity;
        }
    }
}