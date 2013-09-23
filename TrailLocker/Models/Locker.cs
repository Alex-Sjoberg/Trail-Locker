using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrailLocker.Models
{
    public class Locker
    {
        public Guid LockerID { get; set; }
        public virtual List<Item> MyItems { get; set; }
        public Guid UserID { get; set; }
        //stub
    }
}