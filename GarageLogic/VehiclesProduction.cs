using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehiclesProduction
    {
        public enum eVehicleType
        {
            FuelBasedMotorcycle = 1,
            ElectricMotorcycle,
            FuelBasedCar,
            ElectricCar,
            FuelBasedTruck
        }

        public static Vehicle CreateVehicle(eVehicleType i_VehicleType, string i_ModelName, string i_LicenseNumber)
        {   
            Vehicle newVehicle;

            switch(i_VehicleType)
            {
                case eVehicleType.FuelBasedMotorcycle:
                    newVehicle = new FuelBasedMotorcycle(i_ModelName, i_LicenseNumber);
                    break;
                case eVehicleType.ElectricMotorcycle:
                    newVehicle = new ElectricMotorcycle(i_ModelName, i_LicenseNumber);
                    break;
                case eVehicleType.FuelBasedCar:
                    newVehicle = new FuelBasedCar(i_ModelName, i_LicenseNumber);
                    break;
                case eVehicleType.ElectricCar:
                    newVehicle = new ElectricCar(i_ModelName, i_LicenseNumber);
                    break;
                default: // i_VehicleType == eVehicleType.FuelBasedTruck
                    newVehicle = new FuelBasedTruck(i_ModelName, i_LicenseNumber);
                    break;
            }

            return newVehicle;
        }
    }
}
