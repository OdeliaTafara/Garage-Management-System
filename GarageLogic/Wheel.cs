using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_ManufacturerName = String.Empty;
        private float m_CurrentAirPressure = 0;
        private readonly float r_MaxAirPressure;

        public Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            r_ManufacturerName = i_ManufacturerName;
            m_CurrentAirPressure = i_CurrentAirPressure;
            r_MaxAirPressure = i_MaxAirPressure;
        }

        public Wheel(string i_ManufacturerName, float i_MaxAirPressure) : this(i_ManufacturerName, i_MaxAirPressure, i_MaxAirPressure)
        {

        }

        public void Inflate(float i_AirToInflate)
        {   
            if(i_AirToInflate + m_CurrentAirPressure > r_MaxAirPressure)
            {
                throw new ValueOutOfRangeException();
            }

            m_CurrentAirPressure += i_AirToInflate;
        }

        public void InflateToMaximum()
        {
            m_CurrentAirPressure = r_MaxAirPressure;
        }
    }
}
