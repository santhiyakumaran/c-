using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationProcessAssignment
{
    class BeneficiaryInfo
    {
        private static int autoIncrementRegNo = 1000;
        /// <summary>
        /// To get te beneficiary details in properties
        /// </summary>
        public int RegistrationNumber { get; set; }
        public string BeneficiaryName { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; }
        public long PhoneNumber { get; set; }
        public string City { get; set; }

        public List<VaccineInfo> VaccinationDetails
        {
            get;set;
        }

        /// <summary>
        /// field values
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="gender"></param>
        /// <param name="phNumber"></param>
        /// <param name="city"></param>
        public BeneficiaryInfo(string name,int age,Genderr gender,long phNumber,string city)
        {
            this.BeneficiaryName = name;
            this.Age = age;
            this.Gender = Gender;
            this.PhoneNumber = phNumber;
            this.City = city;
            this.RegistrationNumber = autoIncrementRegNo++;
            
        }

       

    }
    /// <summary>
    /// enum is used to choose a choice
    /// </summary>
    public enum Genderr
    {
        Male =1,
        Female,
        Others
    }

   
}
