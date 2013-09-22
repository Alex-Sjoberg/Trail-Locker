using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrailLocker.Models
{
    public class User
    {
        private String username { get; set; }
        private String password { get; set; }
        private String name { get; set; }
        private String home { get; set; }
        private int maxWeight { get; set; }
        public List<String> friends { get; set; }

        private Locker locker;
        private List<Trip> trips;

        public User(String username, String password, String name, String home, int maxWeight)
        {
            this.username = username;
            this.password = password;
            this.name = name;
            this.home = home;
            this.maxWeight = maxWeight;

            this.friends = new List<string>();
            this.trips = new List<Trip>();
        }
    }
}