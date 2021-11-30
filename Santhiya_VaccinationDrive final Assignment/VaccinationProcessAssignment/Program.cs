using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationProcessAssignment
{
    class Program
    {
        /// <summary>
        /// creating a beneficiary list
        /// </summary>
        private static List<BeneficiaryInfo> benificiaries = new List<BeneficiaryInfo>();
        static void Main(string[] args)
        {
            

            Program user = new Program();
           
            var data1 = new BeneficiaryInfo("santhiya", 22,(Genderr)2 , 9087678765, "chidambaram");
            var data2 = new BeneficiaryInfo( "Dhiya", 20,(Genderr)2 , 9012345687, "Chennai");
            var data3 = new BeneficiaryInfo("John", 21, (Genderr)1, 9098767876, "coimbatore");
            benificiaries.Add(data1);
            benificiaries.Add(data2);

            string choice;
            Console.WriteLine("****APPLICATION FOR VACCINATION DRIVE****");
            Console.WriteLine("------------------------------------------");

            /// asking user to choose an option
            do
            {
                Console.WriteLine("<<<<<<<<<  MAIN MENU  >>>>>>>>>>>>");
                Console.WriteLine("\n 1.Beneficiary Registration \n 2.Vaccination \n 3.Exit \n");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("<<Select Option>>");
                int option = int.Parse(Console.ReadLine());
                


                switch (option)
                {
                    case 1:
                        user.BenificiaryRegistration();
                        break;
                    case 2:
                        user.Vaccination();
                        break;
                    case 3:
                        Environment.Exit(-1);
                        break;
                    default:
                        Console.WriteLine("Enter Valid Input...!");
                        break;

                }
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Do you want to continue -(Yes/NO)??");
                choice = Console.ReadLine().ToUpper();
            } while (choice == "YES");
            Console.ReadKey();
            
        }

        // Add beneficiary details
        public void BenificiaryRegistration()
        {

                Console.WriteLine("Enter Benificiary Name:");
                string BeneficiaryName = Console.ReadLine();
                Console.WriteLine("Enter Benificiary Age:");
                int Age = int.Parse(Console.ReadLine());
                Console.WriteLine("Choose Your Gender:");
                Console.WriteLine("\n1.Male\n2.Female \n3.Others");
                Genderr Gender = (Genderr)int.Parse(Console.ReadLine());
                Console.WriteLine("Enter PhoneNumber:");
                long PhoneNumber = long.Parse(Console.ReadLine());
                Console.WriteLine("Enter Benificiary City:");
                string city = Console.ReadLine();


                var data3 = new BeneficiaryInfo(BeneficiaryName, Age, (Genderr)Gender, PhoneNumber, city);
                benificiaries.Add(data3);
                Console.WriteLine("***Registration Successfully***");
                Console.WriteLine($"Your Registration Number is: {data3.RegistrationNumber}");
            
        }


        // Vaccination Process
        public void Vaccination()
        { 

            string option;
            Console.WriteLine("--------------------------------");
            Console.WriteLine("--------Vaccine Details---------");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Enter Your Registration Number:");
            int RegNo = int.Parse(Console.ReadLine());
            foreach(BeneficiaryInfo details in benificiaries)
            {
                if(details.RegistrationNumber==RegNo)
                {
                    Console.WriteLine($"Welcome Mr/Ms :{details.BeneficiaryName}");
                    Console.WriteLine("--------------------------------");

                    do
                    {
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("\n 1.Take Vaccination \n 2.Vaccination History\n 3.Next Due Date \n 4.Exit \n");
                        Console.WriteLine("-----------------------------------------------------------");
                        Console.WriteLine("<<Select Option>>");
                        int choice = int.Parse(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("Which Vaccine Do you want ?");
                                Console.WriteLine("1.CoVaccine \n 2.Covishield \n 3.Sputnic\n");
                                Console.WriteLine("--------------------------------");
                                Console.WriteLine("Choose your option: ");
                                VacType VaccineType = (VacType)int.Parse(Console.ReadLine());
                                if (details.RegistrationNumber == RegNo)
                                {
                                    VaccineInfo user = new VaccineInfo(VaccineType, DateTime.Now);

                                    if (details.VaccinationDetails == null)
                                    {

                                        details.VaccinationDetails = new List<VaccineInfo>();
                                    }
                                    details.VaccinationDetails.Add(user);
                                }

                                Console.WriteLine("Successfully vaccinated!...");
                                break;

                            case 2:
                                VaccinationHistory(RegNo);
                                break;
                            case 3:
                                NextDueDate(RegNo);
                                break;
                            case 4:
                                Environment.Exit(-1);
                                break;
                            default:
                                Console.WriteLine("Enter Valid Input");
                                break;
                        }
                        Console.WriteLine("Do you want to continue -(Yes/NO)??");
                        option = Console.ReadLine().ToUpper();

                    } while (option == "YES");
                }
                              
            }
        }
        /// <summary>
        /// vaccination history
        /// </summary>
        /// <param name="registerNumber"></param>
        public void VaccinationHistory(int registerNumber)
        {
            foreach (BeneficiaryInfo history in benificiaries)
            {
                if (history.RegistrationNumber==registerNumber)
                {
                    if(history.VaccinationDetails !=null)
                    {
                        Console.WriteLine($"Registratuion Number:{ history.RegistrationNumber} \n BeneficiaryName:{history.BeneficiaryName}\n Vaccinated Dose: {history.VaccinationDetails.Count}");
                    }    
                    
                }

            }
        }
        /// <summary>
        /// user to get nextdue date
        /// </summary>
        /// <param name="regNo"></param>
        public void NextDueDate(int regNo)
        {
            foreach (BeneficiaryInfo duedate in benificiaries)
            {
                if (duedate.RegistrationNumber == regNo)
                {
                    if (duedate.VaccinationDetails != null)
                    {
                        if (duedate.VaccinationDetails.Count == 1)
                        {

                            Console.WriteLine("You are vaccinated by " + duedate.VaccinationDetails.Count);
                            Console.WriteLine("Your next Due Date is: " + duedate.VaccinationDetails[0].VaccinatedDate.AddDays(30));

                        }
                        else if (duedate.VaccinationDetails.Count == 2)
                        {
                            Console.WriteLine("You have completed the vaccination course. Thanks for your participation in the vaccination drive.");
                        }

                    }
                }

            }

        }

    }
}
