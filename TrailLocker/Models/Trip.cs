using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrailLocker.Models
{
    public class Trip
    {
        //Instance Variables
        private float current_weight { get; private set; }
        private float total_capacity { get; private set; }

        private User trip_leader {get; private set;}
        private List<User> travellers {get; private set;}

        private List<Item> items {get; private set;}

        private String destination {get; private set;}
        private DateTime start_time { get; private set; }
        private DateTime end_time { get; private set; }
        private String weather { get; private set; }

        private String description { get; private set; }

        //Constructor
        public Trip()
        {
            current_weight = 0;
        }

        //Methods
        public int add_item(Item new_item)
        {
            return 1;
        }

        public int remove_item(int id)
        {
            return 1;
        }

        public float calculate_current_weight()
        {
            return 1.0F;
        }

        public float calculate_total_capacity()
        {
            return 1.0F;

        }

        public int find_weather()
        {
            return 1;
        }

        public int add_traveller(User new_traveller)
        {
            return 1;
        }

        public int remove_traveller(int id)
        {
            return 1;
        }

        public int generate_suggestions()
        {
            return 1;
        }
    }
}

/*
 * Thoughts
 * -User wanting to create a new trip would probably go through interraction with a controller, not Trip class directly
 * -Probably going to have different 'slots' for different item types. E.g. a sleeping bag slot rather than one big list
 *      - This allows for easy suggestions ("Add a sleeping bag")
 *      
 * - Will interract heavily with locker. Will want to be able to look in locker to grab default equiptment; User will need to be able to move things from locker to trip easily
 * 
 * 
 * Things needed from other classes:
 * 

*/