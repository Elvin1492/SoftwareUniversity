
namespace GalscticGPS
{
    using System;

    public struct Location
    {
        // define fields for the struct
        private double latitude;
        private double longitude;
        private Planet planet;

        // define a constructor 
        public Location(double latitude, double longitude, Planet planet) :this()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Planet = planet;
        }

        // define properties for the structure
        public double Latitude
        { 
            get { return this.latitude; }
            set
            {
                if (value < 0 || value > 90)
                {
                    throw new ArgumentOutOfRangeException(Convert.ToString(value), "Latitude should be in the range [0..90]");
                }

                this.latitude = value;
            }
        }

        public double Longitude 
        {
            get { return this.longitude; }
            set
            {
                if (value < 0 || value > 90)
                {
                    throw new ArgumentOutOfRangeException("Longitude", "Longitude should be in the range [0..90]");
                }

                this.longitude = value;
            }
        }

        public Planet Planet
        {
            get { return this.planet; }
            set { this.planet = value; }
        }

        // imlement the ToString() method to print the location on the console
        public override string ToString()
        {
            return String.Format("{0:0.000000}, {1:0.000000} - {2}", this.latitude, this.longitude, this.planet);
        }
    }
}
