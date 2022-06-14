using System;
using System.Collections.Generic;
using System.Text;

namespace eShopOnContainers.Core.Models.Tisort
{
    public class Marka
    {
        public int Id { get; set; }
        public string Brand{ get; set; }

        public override string ToString()
        {
            return Brand;
        }
    }
}
