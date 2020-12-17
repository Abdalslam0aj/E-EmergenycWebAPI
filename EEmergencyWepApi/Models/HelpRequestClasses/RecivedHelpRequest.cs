using EEmergencyWebApi.Models.Const;
using EEmergencyWebApi.Models.HelpRequestClasses;
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

        public async Task<List<HelpRequestAssigned>> assigenHelpRequestAsync() {
            RequestAssigner assigner = new RequestAssigner();

            var requestsAssigned  = await assigner.requestAssignerAsync(db, helpRequest);
           
            return requestsAssigned;
            
        }

        




        
    }
}
