using System.Collections.Generic;

namespace ConsoleAutoMapper.DTO
{
    public class orderDTO
    {
        public string orderId
        {
            get; set;
        }
        public string userId
        {
            get; set;
        }
        public string createDate
        {
            get; set;
        }
        public List<productDTO> orderedProducts
        {
            get; set;
        }
    }
}