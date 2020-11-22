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
    class distance {
    
     
    
    }
    public class GISService
    {
        ConctionDbClass db;

        public GISService(ConctionDbClass db) {
            this.db = db;
        }

        public ParamedicTeam findNearestResponseTeam (Location helpRequestLocation) {

            List<DCD> a= db.DCD.ToList();
            foreach (DCD i in a) {
             
            }

            return new ParamedicTeam();
        }

        private ParamedicTeam nearestDistence(Location cvilianLocation,Location paramedicLocation) {

            string origin=paramedicLocation.latitude+","+paramedicLocation.longitude;
            string destination= cvilianLocation.latitude + "," + cvilianLocation.longitude;
            
                string url = @"http://maps.googleapis.com/maps/api/distancematrix/json?origins="
                   + origin + "&amp;destinations=" + destination + "&amp;sensor=false&key=AIzaSyAy_3-4Wn5uKqeutmQRq9PsCm-aS5emGdE";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                response.Close();

                DataSet ds = new DataSet();
                 var dd=response.ToString();
                 var j= JsonConvert.DeserializeObject(dd);
               
              // JsonReader(response) ;
                
               
            
            

        
            return new ParamedicTeam();
        }

        private ParamedicTeam fastestRoute()
        {


            return new ParamedicTeam();
        }

    }
}
