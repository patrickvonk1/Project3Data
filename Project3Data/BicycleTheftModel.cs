using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3Data
{
    public class BicycleTheftModel
    {
        //ID For Database
        public int ID { get; set; }

        // kennisname
        public DateTime Date { get; set; }
        //MKbeschrijving
        public string Description { get; set; }
        //werkgebied
        public string Location { get; set; }
        //plaats
        public string City { get; set; }
        //buurt
        public string Neighbourhood { get; set; }
        //straat
        public string Street { get; set; }
        //begindagsoort
        public string DayOfTheWeek { get; set; }
        //trefwoord
        public string Keyword { get; set; }
        //object
        public string Sort { get; set; }
        //merk
        public string Brand { get; set; }
        //type
        public string Type { get; set; }
        //kleur
        public string Color { get; set; }
    }
}
