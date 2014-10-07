using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticGPS
{
    class Program
    {
        static void Main()
        {
            Planet myPlanet = Planet.Earth;

            Location myLocation = new Location(18.037986, 28.870097, myPlanet);

            Console.WriteLine(myLocation);
        }
    }
}
