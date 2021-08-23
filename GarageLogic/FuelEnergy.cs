using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelEnergy : EnergySource
    {
        public enum eFuelType
        {
            Soler = 1,
            Octane95,
            Octane96,
            Octane98
        }

        private eFuelType m_FuelType = eFuelType.Soler;
        private float m_CurrentAmountOfFuel = 0;
        private float m_MaxAmountOfFuel = 0;

        public FuelEnergy(eFuelType i_FuelType, float i_CurrentAmountOfFuel, float i_MaxAmountOfFuel)
        {
            m_FuelType = i_FuelType;
            m_CurrentAmountOfFuel = i_CurrentAmountOfFuel;
            m_MaxAmountOfFuel = i_MaxAmountOfFuel;
        }

        public FuelEnergy()
        {
        
        }

        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }

            set
            {
                m_FuelType = value;
            }
        }


        public void Refuel(float i_FuelToRefuel)
        {
            if(i_FuelToRefuel + m_CurrentAmountOfFuel > m_MaxAmountOfFuel)
            {
                throw new ValueOutOfRangeException();
            }

            m_CurrentAmountOfFuel += i_FuelToRefuel;
        }

        public override string ToString()
        {
            return $"fuel type: {m_FuelType}, current amount of fuel: {m_CurrentAmountOfFuel}, maximun amount of fuel: {m_MaxAmountOfFuel}";
        }
    }
}
