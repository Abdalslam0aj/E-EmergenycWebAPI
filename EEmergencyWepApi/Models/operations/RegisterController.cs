using EEmergencyWepApi.Data.module;
using EEmergencyWepApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EEmergencyWebApi.Models.operations
{
    public class RegisterController
    {
        ConctionDbClass db;
        public RegisterController(ConctionDbClass db)
        {
            this.db = db;
        }
        public  bool RegisterCivilan(Civilian civilian) {

            if (checkNumber(civilian.NIDN) && checkNumber(civilian.phoneNumber) && checkPassword(civilian.password) && civilian.bloodType != null &&
                civilian.birthDate != null && civilian.FullName != null)
            {
                User user = new User();
                user.phoneNumber = civilian.phoneNumber;
                user.userType = "civilian";
                try
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    db.Civilian.Add(civilian);
                    db.SaveChanges();
                }
                catch (Exception ex) {

                    return false;
                }
                return true;
            }
            else {
               return false;
            
            
            }
        
        
        }

       

        bool checkNumber(string  Number) {

            if (Number == null)
            {
                return false;
            }
            else if (Number.Length == 10)
            {
                bool isNumber = true;
                var numbersList =Number.ToCharArray();
                foreach (var charToTest in numbersList) {
                    if (!Char.IsNumber(charToTest))
                        isNumber = false;
                }
                return isNumber;
            }
            else {

                return false;
            
            }
        
        
        }

        bool checkPassword(string password) {
            bool hasUpper = false;
            bool hasLower = false;
            if (password != null)
            {
                if (password.Length > 8)
                {
                    var charArray = password.ToCharArray();

                    foreach (var charToCheck in charArray)
                    {
                        if (Char.IsUpper(charToCheck))
                            hasUpper = true;
                        if (Char.IsLower(charToCheck))
                            hasLower = true;
                    }

                    return hasLower && hasUpper;
                }
                else {

                    return false;
                
                }

            }
            else {

                return false;
            }
        
        
        }
    }
}
