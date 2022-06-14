using System;
using System.Collections.Generic;
using System.Text;

namespace eShopOnContainers.Core.Models.Tisort
{
    public class TisortType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return Type;
        }
    }
}
