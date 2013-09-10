using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrailLocker.Models
{
    public class Trip
    {
        //Instance Variables
        public float current_weight { get; private set; }

        public Trip()
        {
            current_weight = 0;
        }
    }
}