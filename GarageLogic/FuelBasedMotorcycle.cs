using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelBasedMotorcycle : Motorcycle
    {
        public FuelBasedMotorcycle()
        {
            m_EnergySource = new FuelEnergy();
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {(m_EnergySource as FuelEnergy).ToString()}";
        }
    }

   
}
