using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationProcessAssignment
{
    class VaccineInfo
    {
        /// <summary>
        /// to know about vaccination details
        /// </summary>
        public VacType VaccineType { get; set; }
        public string Dosage { get; set; }
        public DateTime VaccinatedDate { get; set; }

        public VaccineInfo(VacType vaccineType,DateTime vaccinatedDate)
        {
            this.VaccineType = VaccineType; 
            this.VaccinatedDate = vaccinatedDate;


        }

       
           

    }
    /// <summary>
    /// chose the vaccination
    /// </summary>
    public enum VacType
    {
        Co_vaccine =1,
        Covishield,
        Sputnic
    }
}
