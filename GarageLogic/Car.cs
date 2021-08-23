using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{

    public abstract class Car : Vehicle
    {
        public enum eColor
        {
            Red = 0,
            Silver,
            White,
            Black
        }

        public enum eDoors
        {
            Two = 2,
            Three,
            Four,
            Five
        }

        private eColor m_Color;
        private eDoors m_NumberOfDoors;
        private const int k_NumOfWheels = 4;


        public Car()
        {
           
        }

        public Car(string i_ModelName, string i_LicenseNumber, float i_RemainingEnergyPercentage, List<Wheel> i_Wheels, eColor i_Color, eDoors i_NumberOfDoors)
        : base(i_ModelName, i_LicenseNumber, i_RemainingEnergyPercentage, i_Wheels)
        {
            m_Color = i_Color;
            m_NumberOfDoors = i_NumberOfDoors;
        }

        public Car(string i_ModelName, string i_LicenseNumber)
        : base(i_ModelName, i_LicenseNumber, k_NumOfWheels)
        {}

        public eColor Color 
        {
            get
            {
                return m_Color;
            }
            set
            {
                m_Color = value;
            }
        }

        public eDoors NumberOfDoors
        {
            get
            {
                return m_NumberOfDoors;
            }
            set
            {
                m_NumberOfDoors = value;
            }
        }

        public override string ToString()
        {
            return $"{(base.ToString())}, color: {m_Color}, number of doors: {m_NumberOfDoors}, number of wheels: {k_NumOfWheels}";
        }
    }
}
