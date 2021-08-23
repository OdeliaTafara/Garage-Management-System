using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricEnergy : EnergySource
    {
        private float m_RemainingTimeOfEngineOperation;
        private float r_MaxTimeOfEngineOperation;

        public ElectricEnergy()
        {

        }

        public void Recharge(float i_TimeToCharge)
        {
            if(i_TimeToCharge + m_RemainingTimeOfEngineOperation > r_MaxTimeOfEngineOperation)
            {
                throw new ValueOutOfRangeException();
            }

            m_RemainingTimeOfEngineOperation += i_TimeToCharge;
        }

        public override string ToString()
        {
            return $"remaining time of engine operation: {m_RemainingTimeOfEngineOperation}, maximum time of engine operation: {r_MaxTimeOfEngineOperation}";
        }
    }
}
