using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TrailLocker.Models
{
    public class Item
    {
        public Guid ItemID { get; set; }
        public Guid LockerId { get; set; }
        //stub
    }
}