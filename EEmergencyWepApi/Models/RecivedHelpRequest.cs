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

namespace EEmergencyWebApi.Models
{
    public class RecivedHelpRequest
    {
        HelpRequest helpRequest;
        ConctionDbClass db;
        public RecivedHelpRequest(HelpRequest helpRequest, ConctionDbClass db) {
            this.helpRequest = helpRequest;
            this.db = db;
        }

        public async Task<HelpRequestAssigned> assigenHelpRequestAsync() {
            GISService gISService=new GISService(db);
            Location location = new Location(helpRequest.latitude,helpRequest.longitude);            
            ParamedicTeam teamAssigned = gISService.findNearestResponseTeam(location);
            HelpRequestAssigned helpRequestAssigned = new HelpRequestAssigned();
            helpRequestAssigned.id = helpRequest.id;
            helpRequestAssigned.teamNumber = teamAssigned.teamNumber;
            List<TeamMembers> teamMembers = db.TeamMembers.Where(e => e.teamNumber == teamAssigned.teamNumber).ToList();
            foreach (var t in teamMembers) {
                Paramedic paramedic= db.Paramedic.Find(t.phoneNumber);
                paramedic.status = "BUSY";
                db.Paramedic.Update(paramedic);
                bool d= await sendNotificatonAsync(paramedic.notificationToken, "", "");              
            }
            return helpRequestAssigned;
        }

        private async Task<bool> sendNotificatonAsync(string token, string title, string body) {

            using (var client = new HttpClient()) {
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
                return result.StatusCode.Equals(HttpStatusCode.OK);
            }




        }
    }
}
