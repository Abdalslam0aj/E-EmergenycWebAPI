using EEmergencyWebApi.Models.Const;
using EEmergencyWepApi.Data.module;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;

namespace EEmergencyWepApi.Models
{

    public class Distance
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class Duration
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class Element
    {
        public Distance distance { get; set; }
        public Duration duration { get; set; }
        public string status { get; set; }
    }

    public class Row
    {
        public IList<Element> elements { get; set; }
    }

    public class Matrix
    {
        public IList<string> destination_addresses { get; set; }
        public IList<string> origin_addresses { get; set; }
        public IList<Row> rows { get; set; }
        public string status { get; set; }
    }
    public class GISService
    {
        ConctionDbClass db;

        public GISService(ConctionDbClass db) {
            this.db = db;
        }

        public ParamedicTeam findNearestResponseTeam (Location helpRequestLocation) {

            List<DCD> dcd= db.DCD.ToList();           
            Dictionary<int, DCD> pairs = new Dictionary<int, DCD> { };
            
            foreach (var d in dcd) {
                Location dcdlocation = new Location(d.latitude,d.longitude);
                int dcdToHelpDuration = nearestDuration(helpRequestLocation, dcdlocation);
                pairs.Add(dcdToHelpDuration,d);                
            }
            
            int chosenDCD= pairs.Keys.Min();
            DCD lockedDCD=pairs[chosenDCD];
            ParamedicTeam team = db.ParamedicTeams.First(e => e.deploymentLocation==lockedDCD.id && e.status==TeamStatus.available);
            if (team == null) {
                chosenDCD = pairs.Keys.Min();
                lockedDCD = pairs[chosenDCD++];
                team = db.ParamedicTeams.First(e => e.deploymentLocation == lockedDCD.id && e.status == TeamStatus.available);
            }
            team.status = TeamStatus.onTheWay;
            db.ParamedicTeams.Update(team);
            
            return team;
        }

        private int nearestDuration(Location cvilianLocation,Location paramedicLocation) {

            string origin=paramedicLocation.latitude+", "+paramedicLocation.longitude;
            string destination= cvilianLocation.latitude + ", " + cvilianLocation.longitude;
            string url = "https://maps.googleapis.com/maps/api/distancematrix/json?units=metric&origins="+origin+ "&destinations=" + destination+ "&region=jo&key=AIzaSyDa7ifKIOyGpc4AJugDeoNyxZIXzyjkSEY";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Matrix j=new Matrix();
            int duration;
            using (StreamReader Reader = new StreamReader(response.GetResponseStream())) {
                 j = JsonConvert.DeserializeObject<Matrix>(Reader.ReadToEnd());
            }

            if (j.rows.First().elements.First().status == "OK") {
                Console.WriteLine(j.rows.First().elements.First().duration.text);
                duration = j.rows.First().elements.First().duration.value;
            }
            else {
                duration = 0;
            }
            

            return duration;
        }

        private ParamedicTeam fastestRoute()
        {


            return new ParamedicTeam();
        }

    }
}
