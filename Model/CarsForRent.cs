using Car_services.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car_services.Model
{
    public class CarsForRent
    {
        public String LicencePlate { get; set; }
  
        public string Color { get; set; }
        public int No_of_cylinders { get; set; }


        public FuelType Fuel_Type { get; private set; }
        public string set_Fuel
        {
            get { return set_Fuel; }
            set => Fuel_Type = setFuel(value);

        }



        public EngineType Engine_type { get; private set; }

        public DateOnly manufactuare_date { get; set; }


        public string Car_Company { get; set; }


        public string Model { get; set; }

        // i will ignore this in the database and use it only for setting the engine type from a string
        public string set_Engine_Type
        {
            get => set_Engine_Type;
            set => Engine_type = setType(value);
        }
        //helper function for setting the engine type from a string
        private EngineType setType(string type)
        {
            if (Enum.TryParse(type, out EngineType engineType))
            {
                Engine_type = engineType;
                return engineType;
            }
            else
            {
                throw new ArgumentException("Invalid engine type.");

            }

        }
        private FuelType setFuel(string fuel)
        {
            if (Enum.TryParse(fuel, out FuelType fuelType))
            {
                Fuel_Type = fuelType;
                return fuelType;
            }
            else
            {
                throw new ArgumentException("Invalid fuel type.");
            }
        }
        public List<RentedCarCustomer> CarsCutomers { get; set; }

    }
}
