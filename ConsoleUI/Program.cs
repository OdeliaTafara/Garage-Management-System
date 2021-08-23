using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        private enum eUserProgramChoiceInput
        {
            Exit,
            InsertNewVehicleToGarage,
            DisplayLicenseNumbers,
            ChangeVehicleStutus,
            InflateTiresToMaximum,
            RefuelFuelBasedVehicle,
            ChargeElectricBasedVehicle,
            DisplayVehicleInformation,
            BadInput
        }

        private static void runUserChoiseProgram(eUserProgramChoiceInput i_UserChoice, Garage i_Garage)
        {
            switch(i_UserChoice)
            {
                case eUserProgramChoiceInput.InsertNewVehicleToGarage:
                    insertNewVehicleToGarage(i_Garage);
                    break;
                case eUserProgramChoiceInput.DisplayLicenseNumbers:
                    displayLicenseNumbers(i_Garage);
                    break;
                case eUserProgramChoiceInput.ChangeVehicleStutus:
                    changeVehicleStutus(i_Garage);
                    break;
                case eUserProgramChoiceInput.InflateTiresToMaximum:
                    inflateTiresToMaximum(i_Garage);
                    break;
                case eUserProgramChoiceInput.RefuelFuelBasedVehicle:
                    refuelFuelBasedVehicle(i_Garage);
                    break;
                case eUserProgramChoiceInput.ChargeElectricBasedVehicle:
                    chargeElectricBasedVehicle(i_Garage);
                    break;
                case eUserProgramChoiceInput.DisplayVehicleInformation:
                    displayVehicleInformation();
                    break;
            }
        }
       
        private static string getValidLicenseNumberFromUser(Garage i_Garage)
        {
            Console.WriteLine("Please enter license number");
            string licenseNumber = Console.ReadLine();

            while(!i_Garage.IsVehicleInGarage(licenseNumber))
            {
                Console.WriteLine("No such vehicle in the garage. Please enter again.");
                licenseNumber = Console.ReadLine();
            }

            return licenseNumber;
        }

        private static VehiclesProduction.eVehicleType getVehiclesTypeFromUser()
        {
            string vehicleTypeStr = Console.ReadLine();
            int vehicleType;

            bool goodInput = int.TryParse(vehicleTypeStr, out vehicleType);

            return (VehiclesProduction.eVehicleType)vehicleType;
        }

        private static float getRemainingEnergyPercentageFromUser()
        {
            string remainingEnergyPercentageStr = Console.ReadLine();
            int remainingEnergyPercentage;

            bool goodInput = int.TryParse(remainingEnergyPercentageStr, out remainingEnergyPercentage);

            return (float)remainingEnergyPercentage/100;
        }

        private static Car.eDoors getNumberOfDoorsFromUser()
        {
            string numberOfDoorsStr = Console.ReadLine();
            int numberOfDoors;

            bool goodInput = int.TryParse(numberOfDoorsStr, out numberOfDoors);

            return (Car.eDoors)numberOfDoors;
        }

        private static Car.eColor getCarColorFromUser()
        {
            string carColorStr = Console.ReadLine();
            int carColor;

            bool goodInput = int.TryParse(carColorStr, out carColor);

            return (Car.eColor)carColor;
        }

        private static Motorcycle.eLicenseType getMotocycleLicenseTypeFromUser()
        {
            string licenseTypeStr = Console.ReadLine();
            int licenseType;

            bool goodInput = int.TryParse(licenseTypeStr, out licenseType);

            return (Motorcycle.eLicenseType)licenseType;
        }

        private static FuelEnergy.eFuelType getFuelTypeFromUser()
        {
            string fuelTypeStr = Console.ReadLine();
            int fuelType;

            bool goodInput = int.TryParse(fuelTypeStr, out fuelType);

            return (FuelEnergy.eFuelType)fuelType;
        }

        private static void setCarPropsFromUser(Car i_Car)
        {
            Console.WriteLine("Please the number of doors");
            Car.eDoors numberOfDoors = getNumberOfDoorsFromUser();
            i_Car.NumberOfDoors = numberOfDoors;

            displayCarColors();
            Car.eColor carColor = getCarColorFromUser();
            i_Car.Color = carColor;
        }

        private static void setMotorcyclePropsFromUser(Motorcycle i_Motorcycle)
        {
            displayLicenseType();
            Console.WriteLine("Please the license type of the motorcycle");
            Motorcycle.eLicenseType licenseType = getMotocycleLicenseTypeFromUser();
            i_Motorcycle.LicenseType = licenseType;

            int engineVolume = 0; //TODO
            i_Motorcycle.EngineVolume = engineVolume;
        }

        private static void setTruckPropsFromUser(Truck i_Turck)
        {
            Console.WriteLine("Please the number of doors");
            Car.eDoors numberOfDoors = getNumberOfDoorsFromUser();
            i_Turck.NumberOfDoors = numberOfDoors;


            displayCarColors();
            Car.eColor carColor = getCarColorFromUser();
            i_Turck.Color = carColor;
        }

        private static void setFuelEnergyPropsFromUser(FuelEnergy i_FuelEnergy)
        {
            displayFuelTypes();
            FuelEnergy.eFuelType fuelType = getFuelTypeFromUser();
            i_FuelEnergy.FuelType = fuelType;
        }

        private static Vehicle getVehicleFromUser(string i_LicenseNumber)
        {

            Console.WriteLine("Please enter the vehicle model name");
            string modelName = Console.ReadLine();

            displayVehiclesTypes();
            VehiclesProduction.eVehicleType vehicleType = getVehiclesTypeFromUser();

            Vehicle newVehicle = VehiclesProduction.CreateVehicle(vehicleType, modelName, i_LicenseNumber);

            Console.WriteLine("Please enter the remaining energy percentage (number between 0-100");
            float remainingEnergyPercentage = getRemainingEnergyPercentageFromUser();
            newVehicle.RemainingEnergyPercentage = remainingEnergyPercentage;

            Console.WriteLine("Please enter the wheels model name ");
            string wheelsModelName = Console.ReadLine();
            Console.WriteLine("Please enter the current air pressure");
            int currentAirPressure = 0;
            Console.WriteLine("Please enter the max air pressure");
            int maxAirPressure = 0;

            newVehicle.setWheels(wheelsModelName, currentAirPressure, maxAirPressure);

            if(newVehicle is Car)
            {
                setCarPropsFromUser(newVehicle as Car);
            }
            if(newVehicle is Motorcycle)
            {
                setMotorcyclePropsFromUser(newVehicle as Motorcycle);
            }
            if(newVehicle is Truck)
            {
                setTruckPropsFromUser(newVehicle as Truck);
            }

            if(newVehicle.EnergySource is FuelEnergy)
            {
                setFuelEnergyPropsFromUser(newVehicle.EnergySource as FuelEnergy);
            }

            if(newVehicle.EnergySource is ElectricEnergy)
            {

            }

            return newVehicle;
        }

        private static void insertNewVehicleToGarage(Garage i_Garage)
        {
            Console.WriteLine("Please enter license number");
            string licenseNumber = Console.ReadLine();

            if(i_Garage.IsVehicleInGarage(licenseNumber))
            {
                i_Garage.ChangeVehicleStatus(licenseNumber, VehicleInGarage.eVehicleStatus.InRepair);
            }
            else
            {
                Vehicle newVehicle = getVehicleFromUser(licenseNumber);

                Console.WriteLine("Please enter your name");
                string ownerName = Console.ReadLine();
                Console.WriteLine("Please enter your phone-number");
                string ownerPhoneNumber = Console.ReadLine();

                i_Garage.AddVehicleToGarage(ownerName, ownerPhoneNumber, newVehicle);
            }
        }

        private static void displayFuelTypes()
        {
            Console.WriteLine("Please enter the license type:");

            StringBuilder optionsDisplay = new StringBuilder();
            optionsDisplay.AppendLine("1. Soler");
            optionsDisplay.AppendLine("2. Octane95");
            optionsDisplay.AppendLine("3. Octane96");
            optionsDisplay.AppendLine("4. Octane98");

            Console.WriteLine(optionsDisplay.ToString());
        }

        private static void displayLicenseTypes()
        {
            Console.WriteLine("Please enter the license type:");

            StringBuilder optionsDisplay = new StringBuilder();
            optionsDisplay.AppendLine("1. A");
            optionsDisplay.AppendLine("2. B1");
            optionsDisplay.AppendLine("3. AA");
            optionsDisplay.AppendLine("4. BB");

            Console.WriteLine(optionsDisplay.ToString());
        }

        private static void displayVehiclesTypes()
        {
            Console.WriteLine("Please enter the vehicle type:");

            StringBuilder optionsDisplay = new StringBuilder();
            optionsDisplay.AppendLine("1. fuel based motorcycle");
            optionsDisplay.AppendLine("2. electric based motorcycle");
            optionsDisplay.AppendLine("3. fuel based car");
            optionsDisplay.AppendLine("4. electric car");
            optionsDisplay.AppendLine("5. fuel based truck");

            Console.WriteLine(optionsDisplay.ToString());

        }

        private static void displayLicenseNumbersOfVehiclesInGarage(Garage i_Garage, VehicleInGarage.eVehicleStatus i_VehicleStatus)
        {
            List<string> licenseNumbersList = i_Garage.GetLicenseNumbers(i_VehicleStatus);
            StringBuilder licenseNumbers = new StringBuilder();

            foreach(string licenseNumber in licenseNumbersList)
            {
                licenseNumbers.AppendLine(licenseNumber);
            }

            Console.WriteLine(licenseNumbers);
        }

        private static void displayLicenseNumbersOfVehiclesInGarage(Garage i_Garage)
        {
            List<string> licenseNumbersList = i_Garage.GetLicenseNumbers();
            StringBuilder licenseNumbers = new StringBuilder();

            foreach(string licenseNumber in licenseNumbersList)
            {
                licenseNumbers.AppendLine(licenseNumber);
            }

            Console.WriteLine(licenseNumbers);
        }

        public static void displayLicenseNumbers(Garage i_Garage)
        {
            Console.WriteLine("Please enter the vehicle type:");

            StringBuilder optionsDisplay = new StringBuilder();
            optionsDisplay.AppendLine("1. fuel based motorcycle");
            optionsDisplay.AppendLine("2. electric based motorcycle");
            optionsDisplay.AppendLine("3. fuel based car");
            optionsDisplay.AppendLine("4. electric car");
            optionsDisplay.AppendLine("5. fuel based truck");

            Console.WriteLine(optionsDisplay.ToString());
        }

        public static void displayCarColors()
        {
            StringBuilder optionsDisplay = new StringBuilder();

            optionsDisplay.AppendLine("Please choose the color of the car");
            optionsDisplay.AppendLine("1. Red");
            optionsDisplay.AppendLine("2. Silver");
            optionsDisplay.AppendLine("3. White");
            optionsDisplay.AppendLine("4. Black");

            Console.WriteLine(optionsDisplay.ToString());
        }

        private static void changeVehicleStutus(Garage i_Garage)
        {
            string licenseNumber = getValidLicenseNumberFromUser(i_Garage);
            VehicleInGarage.eVehicleStatus newVehicleStatus = getVehicleStatusFromUser();
            
            i_Garage.ChangeVehicleStatus(licenseNumber, newVehicleStatus);
        }

        private static void inflateTiresToMaximum(Garage i_Garage)
        {
            string licenseNumber = getValidLicenseNumberFromUser(i_Garage);
            i_Garage.InflateTiresToMaximum(licenseNumber);
        }

        private static void refuelFuelBasedVehicle(Garage i_Garage)
        {
            string licenseNumber = getValidLicenseNumberFromUser(i_Garage);
            // refuel
        }

        private static void chargeElectricBasedVehicle(Garage i_Garage)
        {
            string licenseNumber = getValidLicenseNumberFromUser(i_Garage);
            int numberOfMinutesToCharge = 0; //TDDO
            Garage.ChargeElectricBasedVehicle(licenseNumber, numberOfMinutesToCharge);
        }

        private static void displayVehicleInformation()
        {
           
        }

        public static void DisplayOptionsToUser()
        {
            StringBuilder optionsStr = new StringBuilder();

            optionsStr.AppendLine("1. Insert new vehicle to the garage");
            optionsStr.AppendLine("2. Display license numbers of vehicles in the garage");
            optionsStr.AppendLine("3. Change vehicle stutus");
            optionsStr.AppendLine("4. Inflate vehicle tires to maximum");
            optionsStr.AppendLine("5. Refuel fuel-based vehicle");
            optionsStr.AppendLine("6. Charge electric-based vehicle");
            optionsStr.AppendLine("7. Display vehicle information");
            optionsStr.AppendLine("0. Exit");

            Console.WriteLine(optionsStr.ToString()); 
        }

        private static eUserProgramChoiceInput getChoiceInputType(string i_ChoiceStr)
        {
            int userChoice;
            eUserProgramChoiceInput userChoiceInput = eUserProgramChoiceInput.BadInput;
            bool goodinput = int.TryParse(i_ChoiceStr, out userChoice) && userChoice >= 0 && userChoice <=7;

            if(goodinput)
            {
                userChoiceInput = (eUserProgramChoiceInput)userChoice;
            }

            return userChoiceInput;
        }

        public static void runProgram()
        {
            Garage garage = new Garage();
            eUserProgramChoiceInput userChoiceInput;

            do
            {   
                DisplayOptionsToUser();
                string choiseStr = Console.ReadLine();
                userChoiceInput = getChoiceInputType(choiseStr);
                runUserChoiseProgram(userChoiceInput, garage);
            }
            while(userChoiceInput != eUserProgramChoiceInput.Exit);
        }

        public static void Main()
        {
            runProgram();
        }
    }
}
