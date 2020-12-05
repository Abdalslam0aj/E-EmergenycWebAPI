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

        public async Task<HelpRequestAssigned> requestAssigner(ConctionDbClass db, HelpRequest helpRequest)
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
                bool d = await sendNotificatonAsync(paramedic.notificationToken, "Civilian needs help", "you have been assigned to help!");
                paramedic.status = d.ToString();
                Console.WriteLine("notifying team members NT:" + paramedic.notificationToken + " notification sent ? " + d);


                db.Paramedic.Update(paramedic);


            }
        }

        private async Task<bool> sendNotificatonAsync(string token, string title, string body)
        {

            using (var client = new HttpClient())
            {
                var firebaseOptionsServerId = "AAAAkD9ch-4:APA91bFLU4H4oLBoKSqQ5N_MGbVi0DBT6zSTMrT4-W6lfwFqGBi82mx49BRYVGtWxGnKUGUIXNxuXM9mdihGOz3-hAeK94UD3h9X4b8Y2mN2LROjr5qgo1d7FX6JrAFrGDcoIGgCSQCK";

                var firebaseOptionsSenderId = "619538319342";
                client.BaseAddress = new Uri("https://fcm.googleapis.com");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization",
                    $"key={firebaseOptionsServerId}");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Sender", $"id={firebaseOptionsSenderId}");
                var data = new
                {
                    to = token,
                    notification = new
                    {
                        body = body,
                        title = title,
                    },
                    priority = "high"
                };
                var json = JsonConvert.SerializeObject(data);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("/fcm/send", httpContent);
                if (result.StatusCode.Equals(HttpStatusCode.OK))
                    return result.StatusCode.Equals(HttpStatusCode.OK);
                else
                    return false;
            }
        }
    }
}
