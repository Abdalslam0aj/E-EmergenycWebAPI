using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EEmergencyWepApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReciveHelpRequestController : ControllerBase
    {        
        [HttpGet]
        public async Task<ActionResult<bool>> sendNotificatonAsync(string token, string title, string body) {
            
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
                    return result.StatusCode.Equals(HttpStatusCode.OK);
                }
           


           
        }
    }
}
