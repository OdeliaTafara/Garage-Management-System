using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class ElectricMotorcycle : Motorcycle
    {
        public ElectricMotorcycle()
        {
            m_EnergySource = new ElectricEnergy();
        }

        public override string ToString()
        {

          return $"{(base.ToString())}, {(m_EnergySource as ElectricEnergy).ToString()}";

        }
    }
}
