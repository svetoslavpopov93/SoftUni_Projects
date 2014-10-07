using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticGPS
{
    struct Location
    {
        private double latitude;
        private double longitude;
        public Planet planet;

        public Location(double latitude, double longitude, Planet planet)
        {
            this.latitude = latitude;
            this.longitude = longitude;
            this.planet = planet;
        }

        public double Latitude
        {
            get
            {
                if (this.latitude < 0)
                {
                    throw new ArgumentException("Latitude value must be greater than zero.");
                }
                else
                {
                    return this.latitude;
                }
            }
            set
            {
                latitude = value;
            }
        }

        public double Longitude
        {
            get
            {
                if (longitude < 0)
                {
                    throw new ArgumentException("Longitude value must be greater than zero.");
                }
                return this.longitude;
            }
            set
            {
                longitude = value;
            }
        }
        public Planet Planet
        {
            get
            {
                return this.planet;
            }
            set
            {
                planet = value;
            }
        }

        public override string ToString()
        {
            return this.Latitude + ", " + this.Longitude + " - " + this.Planet;
        }
    }
}
