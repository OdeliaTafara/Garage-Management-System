using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        public enum eLicenseType
        {
            A = 1,
            B1,
            AA,
            BB
        }

        protected eLicenseType m_LicenseType;
        protected int m_EngineVolume;
        protected const int k_NumOfWheels = 2;

        public Motorcycle(string i_ModelName, string i_LicenseNumber)
        : base(i_ModelName, i_LicenseNumber, k_NumOfWheels)
        { }

        public Motorcycle()
        {

        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }

            set
            {
                m_EngineVolume = value;
            }
        }

        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }

            set
            {
                m_LicenseType = value;
            }
        }

        public override string ToString()
        {
            return $"{(base.ToString())}, license type: {m_LicenseType}, engine volume: {m_EngineVolume}, number of wheels: {k_NumOfWheels}";
        }
    }
}
