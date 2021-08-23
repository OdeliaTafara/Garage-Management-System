using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleInGarage
    {
        public enum eVehicleStatus
        {
            InRepair,
            Repaired,
            Payed
        }

        private readonly string r_OwnerName;
        private readonly string r_OwnerPhoneNumber;
        private eVehicleStatus m_VehicleStatus;
        private Vehicle m_Vehicle;

        public VehicleInGarage(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_Vehicle)
        {
            r_OwnerName = i_OwnerName;
            r_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_Vehicle = i_Vehicle;
            m_VehicleStatus = eVehicleStatus.InRepair;
        }

        public override int GetHashCode()
        {
            return m_Vehicle.GetHashCode();
        }

        public eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }

            set
            {
                m_VehicleStatus = value;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return m_Vehicle.LicenseNumber;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }
        }

        public void InflateTiresToMaximum()
        {
            m_Vehicle.InflateTiresToMaximum();
        }

        public override string ToString()
        {
            return $"{m_Vehicle.ToString()}, owner name: {r_OwnerName}, owner name: {r_OwnerPhoneNumber},status in garage: {1}";
        }
    }
}
