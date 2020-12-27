using EEmergencyWepApi.Data.module;
using EEmergencyWepApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EEmergencyWebApi.Models.HelpRequestClasses
{
    public class Mission
    {
        ConctionDbClass db;
        public Mission(ConctionDbClass db)
        {
            this.db = db;
        }
        public HelpRequest getHelpRequest(String phoneNumber) {
            HelpRequest helpRecived;
            Paramedic paramedic = db.Paramedic.Find(phoneNumber);
            if (paramedic != null )
            {
                Console.WriteLine("" + paramedic.fullName);
                Console.WriteLine("" + paramedic.team);
                HelpRequestAssigned paramedicJob = db.HelpRequestAssigned.Find(paramedic.team);
                if (paramedicJob != null)
                {
                    Console.WriteLine("" + paramedicJob.id);
                    helpRecived = db.HelpRequest.Find(paramedicJob.id);
                }
                else {
                    helpRecived = new HelpRequest();
                }
            }
            else {
                helpRecived = new HelpRequest();
                
            }

            return helpRecived;
        }
    }
}
