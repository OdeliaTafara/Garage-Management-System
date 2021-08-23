using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected readonly string r_ModelName;
        protected readonly string r_LicenseNumber;
        protected float m_RemainingEnergyPercentage = 0f;
        protected List<Wheel> r_Wheels = new List<Wheel>(); 
        protected readonly int r_NumOfWheels;
        protected EnergySource m_EnergySource;

        public Vehicle(string i_ModelName, string i_LicenseNumber, float i_RemainingEnergyPercentage, List<Wheel> i_Wheels)
        {
            r_ModelName = i_ModelName;
            r_LicenseNumber = i_LicenseNumber;
            m_RemainingEnergyPercentage = i_RemainingEnergyPercentage;
            m_Wheels = i_Wheels;
        }

        public Vehicle(string i_ModelName, string i_LicenseNumber, int i_NumOfWheels)
        {
            r_ModelName = i_ModelName;
            r_LicenseNumber = i_LicenseNumber;
            r_NumOfWheels = i_NumOfWheels;
        }

        public Vehicle()
        {

        }

        public string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }

        public float RemainingEnergyPercentage
        {
            set
            {
                 m_RemainingEnergyPercentage = value;
            }
        }

        public EnergySource EnergySource
        {
            get
            {
                return m_EnergySource;
            }
        }

        public override int GetHashCode()
        {
            return r_LicenseNumber.GetHashCode();
        }

        public void InflateTiresToMaximum()
        {
            foreach(Wheel wheel in m_Wheels)
            {
                wheel.InflateToMaximum();
            }
        }

        public void setWheels(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            for(int i = 0; i < r_NumOfWheels; i++)
            {
                r_Wheels.Add(new Wheel(i_ManufacturerName, i_CurrentAirPressure, i_MaxAirPressure));
            }
        }

        public override string ToString()
        {
            return $"License number: {r_LicenseNumber}, model name: {r_ModelName}";
        }
    }
}
