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

        public List<ParamedicTeam> findNearestResponseTeam (Location helpRequestLocation,int numberOfPatient) {
            numberOfPatient = 1;
            List<DCD> dcd= db.DCD.ToList();
            Dictionary<int, DCD> pairs = new Dictionary<int, DCD> { };
            
            foreach (var d in dcd) {
                Location dcdlocation = new Location(d.latitude,d.longitude);
                int dcdToHelpDuration = nearestDuration(helpRequestLocation, dcdlocation);
                try
                {
                    pairs.Add(dcdToHelpDuration, d);
                }
                catch (Exception e) { Console.WriteLine("same duration"); }
            }
            Console.WriteLine("all available DCD trafic and shortest route is located ");

            int chosenDCD= pairs.Keys.Min();
            DCD lockedDCD=pairs[chosenDCD];
            Console.WriteLine("the fastest duration DCD is chosen: "+lockedDCD.name+" with arivel duration "+ pairs.Keys.Min());
            var team = db.ParamedicTeams.Where(e => e.deploymentLocation==lockedDCD.id && e.status==TeamStatus.available);

            int c = 0;
            if (team == null)
            {
                var newDcd = dcd.Where(e => e.id != lockedDCD.id).ToArray();
                while (team == null)
                {

                    team = db.ParamedicTeams.Where(e => e.deploymentLocation == newDcd[c].id && e.status == TeamStatus.available);
                    c++;
                }
            }
            
                List<ParamedicTeam> teams = team.ToList();


            
            for(int i=1;i<=numberOfPatient;i++) {
                if (i <= teams.Count )
                {
                    teams[i].status = TeamStatus.onTheWay;
                    Console.WriteLine("found the response team:  " +teams.Count);
                }
            }
            foreach (var paramedicTeam in teams)
            {
                db.ParamedicTeams.Update(paramedicTeam);
                db.SaveChanges();
                Console.WriteLine("found the response team:  " + paramedicTeam.teamNumber);
            }
            return teams;
        }

        private int nearestDuration(Location cvilianLocation,Location paramedicLocation) {

            string origin=paramedicLocation.latitude+", "+paramedicLocation.longitude;
            string destination= cvilianLocation.latitude + ", " + cvilianLocation.longitude;
            string url = "https://maps.googleapis.com/maps/api/distancematrix/json?units=metric&origins="+origin+ "&destinations=" + destination+ "&key=AIzaSyDa7ifKIOyGpc4AJugDeoNyxZIXzyjkSEY";
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
                Console.WriteLine(j.rows.First().elements.First().status);
                duration = 0;
            }
            

            return duration;
        }

        public static bool isThere(Location cvilianLocation, Location paramedicLocation)
        {

            string origin = paramedicLocation.latitude + ", " + paramedicLocation.longitude;
            string destination = cvilianLocation.latitude + ", " + cvilianLocation.longitude;
            string url = "https://maps.googleapis.com/maps/api/distancematrix/json?units=metric&origins=" + origin + "&destinations=" + destination + "&region=jo&key=AIzaSyDa7ifKIOyGpc4AJugDeoNyxZIXzyjkSEY";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Matrix j = new Matrix();
            int distance;
            using (StreamReader Reader = new StreamReader(response.GetResponseStream()))
            {
                j = JsonConvert.DeserializeObject<Matrix>(Reader.ReadToEnd());
            }
            Console.WriteLine(j.rows.First().elements.First().status);
            if (j.rows.First().elements.First().status == "OK")
            {
                Console.WriteLine(j.rows.First().elements.First().distance.text);
                distance = j.rows.First().elements.First().distance.value;
                if (distance < 100)
                    return true;
            }
            else
            {
                return false;
            }


            return false;
        }

        private ParamedicTeam fastestRoute()
        {


            return new ParamedicTeam();
        }

    }
}
