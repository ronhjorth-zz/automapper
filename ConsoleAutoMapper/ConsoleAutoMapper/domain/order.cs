using System.Collections.Generic;

namespace ConsoleAutoMapper.domain
{
    public class order
    {
        public string Id
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

        public List<product> products { get; set; }
    }
}