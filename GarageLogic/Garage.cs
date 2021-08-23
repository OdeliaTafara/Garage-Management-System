using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private static Dictionary<int, VehicleInGarage> s_VehiclesInGarage = null;
        
        public void AddVehicleToGarage(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_Vehicle)
        {
            VehicleInGarage vehicleInGarage = new VehicleInGarage(i_OwnerName, i_OwnerPhoneNumber, i_Vehicle);
            s_VehiclesInGarage.Add(i_Vehicle.GetHashCode(), vehicleInGarage);
        }

        public bool IsVehicleInGarage(string i_LicenseNumber)
        {
            return s_VehiclesInGarage.ContainsKey(i_LicenseNumber.GetHashCode());
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, VehicleInGarage.eVehicleStatus i_NewVehicleStatus)
        {
            s_VehiclesInGarage[i_LicenseNumber.GetHashCode()].VehicleStatus = i_NewVehicleStatus;
        }

        public void RefuelToMaximum(string i_LicenseNumber)
        {
            //ToDo
        }

        public VehicleInGarage GetVehicle(string i_LicenseNumber)
        {
            return s_VehiclesInGarage[i_LicenseNumber.GetHashCode()];
        }

        public List<string> GetLicenseNumbers(VehicleInGarage.eVehicleStatus i_VehicleStatus)
        {
            List<string> vehiclesLicenseNumbers = new List<string>();

            foreach(VehicleInGarage vehicleInGarage in s_VehiclesInGarage.Values)
            {
                if(i_VehicleStatus == vehicleInGarage.VehicleStatus)
                {
                    vehiclesLicenseNumbers.Add(vehicleInGarage.LicenseNumber);
                }
            }

            return vehiclesLicenseNumbers;
        }

        public List<string> GetLicenseNumbers()
        {
            List<string> vehiclesLicenseNumbers = new List<string>();

            foreach(VehicleInGarage vehicleInGarage in s_VehiclesInGarage.Values)
            {
                vehiclesLicenseNumbers.Add(vehicleInGarage.LicenseNumber);
            }

            return vehiclesLicenseNumbers;
        }

        public void InflateTiresToMaximum(string i_LicenseNumber)
        {
            s_VehiclesInGarage[i_LicenseNumber.GetHashCode()].InflateTiresToMaximum();
        }

        public void ChargeElectricBasedVehicle(string i_LicenseNumber, int i_NumberOfMinutesToCharge)
        {
           //TODO
        }
    }
}
