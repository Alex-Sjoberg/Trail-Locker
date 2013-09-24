using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrailLocker.Models
{
    public class User
    {
        public Guid UserID { get; set; } //for testing DB stuff
        //public int ID { get; set; }

        public String username { get;  set; }
        public String name { get; set; }
        public String home { get; set; }
        public int maxWeight { get; set; }

        public virtual List<User> friends { get; set; }

        public Locker locker;
        public  ICollection<Trip> trips;

        public User(String name, int maxWeight)
        {
            this.name = name;
            this.maxWeight = maxWeight;
        }

        public User()
        {
            this.name = "Unknown";
            this.maxWeight = 0;
            this.trips = new List<Trip>();
        }
    }
}