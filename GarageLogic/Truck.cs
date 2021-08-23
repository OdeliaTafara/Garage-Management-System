using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private readonly bool r_ContainDangerousMaterials;
        private readonly float r_MaxCargoWeight;

        public Truck(string i_ModelName, string i_LicenseNumber, float i_RemainingEnergyPercentage, List<Wheel> i_Wheels, bool i_ContainDangerousMaterials, float i_MaxCargoWeight)
        : base(i_ModelName, i_LicenseNumber, i_RemainingEnergyPercentage, i_Wheels)
        {
            r_ContainDangerousMaterials = i_ContainDangerousMaterials;
            r_MaxCargoWeight = i_MaxCargoWeight;
        }

        public Truck() { }

        public override string ToString()
        {
            return $"{(base.ToString())}, Does contain dangerous materials: {r_ContainDangerousMaterials}, max cargo weight: {r_MaxCargoWeight}";
        }


    }
}
