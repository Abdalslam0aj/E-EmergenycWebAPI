using EEmergencyWebApi.Models.sharedServices;
using EEmergencyWepApi.Data.module;
using EEmergencyWepApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EEmergencyWebApi.Models.HelpRequestClasses
{
    public class RequestAssigner
    {

        public HelpRequestAssigned requestAssigner(ConctionDbClass db, HelpRequest helpRequest)
        {
            GISService gISService = new GISService(db);
            Location location = new Location(helpRequest.latitude, helpRequest.longitude);
            ParamedicTeam teamAssigned = gISService.findNearestResponseTeam(location);
            Console.WriteLine("help request: " + helpRequest.id + " being located By GISServices the nerast response team ");
            HelpRequestAssigned helpRequestAssigned = new HelpRequestAssigned();
            helpRequestAssigned.id = helpRequest.id;
            helpRequestAssigned.teamNumber = teamAssigned.teamNumber;
            Console.WriteLine(helpRequestAssigned.teamNumber + " is the team chosen for help request " + helpRequest.id);
            notifyParamedics(db, teamAssigned.teamNumber);

            return helpRequestAssigned;
        }

        public async void notifyParamedics(ConctionDbClass db, int teamNumber)
        {
            List<TeamMembers> teamMembers = db.TeamMembers.Where(e => e.teamNumber == teamNumber).ToList();

            foreach (var t in teamMembers)
            {
                Paramedic paramedic = db.Paramedic.Find(t.phoneNumber);
                bool d = await Notificationcs.sendNotificatonAsync(paramedic.notificationToken, "Civilian needs help", "you have been assigned to help!");
                paramedic.status = d.ToString();
                Console.WriteLine("notifying team members NT:" + paramedic.notificationToken + " notification sent ? " + d);
                db.Paramedic.Update(paramedic);


            }
        }

        
    }
}
