using System;
using System.Collections.Generic;
using System.Text;

namespace eShopOnContainers.Core.Models.Tisort
{
    public class TisortItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUri { get; set; }
        public int TisortBrandId { get; set; }
        public string TisortBrand { get; set; }
        public int TisortTypeId { get; set; }
        public string TisortType { get; set; }
    }
}
