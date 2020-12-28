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
        public bool EndHelpRequest(String phoneNumber)
        {
            HelpRequest helpRecived;
            Paramedic paramedic = db.Paramedic.Find(phoneNumber);
            if (paramedic != null)
            {
                Console.WriteLine("" + paramedic.fullName);
                Console.WriteLine("" + paramedic.team);
                HelpRequestAssigned paramedicJob = db.HelpRequestAssigned.Find(paramedic.team);
                if (paramedicJob != null)
                {
                    Console.WriteLine("" + paramedicJob.id);
                    db.HelpRequestAssigned.Remove(paramedicJob);
                    ParamedicTeam relesedTeam= db.ParamedicTeams.Find(paramedic.team);
                    db.ParamedicTeams.Update(relesedTeam);
                    db.SaveChanges();
                    var teams=  db.HelpRequestAssigned.Where(e => e.id == paramedicJob.id);
                    if (teams.Count() == 0)
                    {
                        helpRecived = db.HelpRequest.Find(paramedicJob.id);
                        RequestLog requestLog = new RequestLog();
                        requestLog.civilianPhoneNumber = helpRecived.civilianPhoneNumber;
                        requestLog.description = helpRecived.description;
                        requestLog.id = helpRecived.id;
                        requestLog.latitude = requestLog.longitude;
                        requestLog.longitude = requestLog.longitude;
                        requestLog.timeOfArrivel = helpRecived.timeOfArrivel;
                        requestLog.timeOfEnd = requestLog.timeOfEnd;
                        db.RequestLog.Add(requestLog);
                        db.HelpRequest.Remove(helpRecived);
                        return true;
                    }

                    return false;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;

            }

            
        }
    }
}
