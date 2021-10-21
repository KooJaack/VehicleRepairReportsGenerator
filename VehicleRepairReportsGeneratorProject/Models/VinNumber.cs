using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRepairReportsGeneratorProject.Constants;
using VehicleRepairReportsGeneratorProject.Utils;

namespace VehicleRepairReportsGeneratorProject.Models
{
    class VinNumber
    {
        private DbUnitOfWork _dbUnitWork;

        public VinNumber(string vinNumber, DbUnitOfWork dbUnitWork)
        {
            if (vinNumber.Length != 17)
                throw new FormatException("VIN must always 17 characters !");

            InitializeComponents(vinNumber);

        }

        private void InitializeComponents(string vinNumber)
        {
            GetMakeFromString(vinNumber.Substring(0, 3));
            GetModelFromString(vinNumber.Substring(3, 5));
            GetModelYear(vinNumber.ElementAt(9));
            CheckDigit = vinNumber.ElementAt(8);
            VehicleId = vinNumber.Substring(11, 6);
        }


        private void GetMakeFromString(string make)
        {
            Make = _dbUnitWork.Makes.getByVinSymbol(make);
        }
        private void GetModelFromString(string model)
        {
            Model = _dbUnitWork.Models.getByVinSymbol(model);
        }

        private void GetModelYear(char year)
        {
            ModelYear = ConvertCharToModelYear(year);
        }

        private int ConvertCharToModelYear(char year)
        {
            var yearCode = CheckCharIsInYearCodes(year);
            var carYear = VinConstants.FIRST_YEAR_DECODE + yearCode;

            return VerifyCarYear(carYear);

        }

        private int CheckCharIsInYearCodes(char year)
        {
            foreach (char ch in VinConstants.YEAR_CODES)
            {
                if (ch == year)
                    return VinConstants.YEAR_CODES.IndexOf(ch);
            }

            throw new ArgumentOutOfRangeException();
        }

        private int VerifyCarYear(int carYear)
        {
            var currentYear = DateTime.Now.Year;

            while (carYear < currentYear - VinConstants.YEAR_CODES.Length)
            {
                carYear = carYear + VinConstants.YEAR_CODES.Length;
            }

            return carYear;
        }

        public Make Make { get; private set; }
        public Model Model { get; private set; }
        public char CheckDigit { get; private set; }
        public int ModelYear { get; private set; }
        public string AssemblyPlant { get; private set; }
        public string VehicleId { get; private set; }

    }
}
