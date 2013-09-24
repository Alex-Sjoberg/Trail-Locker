using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrailLocker.Models.Items
{
    public class Food : Item
    {
        public int servings { get; set; }
        public Boolean requireWater { get; set; }
    }
}