using System;
using System.Collections.Generic;
using System.Text;

namespace eShopOnContainers.Core.Models.Tisort
{
    public class TisortRoot
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public List<TisortItem> Data { get; set; }
    }
}
