using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrailLocker.Models
{
    public class User
    {
        public String username { get; private set; }
        public String name { get; private set; }
        public String home { get; private set; }
        public int maxWeight { get; private set; }
        public List<String> friends { get; private set; }

        private Locker locker;
        private List<Trip> trips;

        public User(String name, int maxWeight)
        {
            this.name = name;
            this.maxWeight = maxWeight;
        }
    }
}