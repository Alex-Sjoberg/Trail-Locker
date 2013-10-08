using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrailLocker.Models
{
    public class User : TrailLocker.Controllers.LoginModel
    {
        public Guid UserID { get; set; } //primary key in DB
        public Guid TripID { get; set; } //foriegn key. TODO remove

        //public String username { get;  set; }
        //public String password { get; set; }
        public String name { get; set; }
        public String home { get; set; }
        public int maxWeight { get; set; }

        public virtual ICollection<User> friends { get; set; }

        public  Locker locker; //why can't I put virtual??? Do I need to?
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