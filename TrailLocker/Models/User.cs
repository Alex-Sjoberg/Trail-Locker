using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrailLocker.Models
{
    public class User
    {
        public Guid UserID { get; set; } //for testing DB stuff
        public Guid TripID { get; set; }
        public Trip myTrip { get; set; }
        //public int ID { get; set; }

        public String username { get;  set; }
        public String password { get; set; }
        public String name { get; set; }
        public String home { get; set; }
        public int maxWeight { get; set; }

        public virtual List<User> friends { get; set; }

        public Locker locker;
        public  virtual ICollection<Trip> trips {get; set;}

        public User(String username, String password, String name, String home, int maxWeight)
        {
            this.username = username;
            this.password = password;
            this.name = name;
            this.home = home;
            this.maxWeight = maxWeight;
        }

        public User()
        {
            this.name = "Unknown";
            this.maxWeight = 0;
            this.trips = new List<Trip>();
			this.friends = new List<User>();
        }
    }
}