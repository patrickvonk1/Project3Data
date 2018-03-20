using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3Data
{
    public class ParkingGarageModel
    {
        //The ID
        public int ID { get; set; }

        //Name of the ParkingGarage
        public string Name { get; set; }

        //The date when the data was logged on the server that runs each hour
        public DateTime Date { get; set; }

        //Is the ParkingGarage open
        public bool IsOpen { get; set; }

        //Total number of cars that can fit in this Parking Garage
        public int ParkingCapacity { get; set; }

        //Total of left over places
        public int VacantSpaces { get; set; }
    }
}
