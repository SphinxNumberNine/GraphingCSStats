using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Net;
using System.IO;
using System.Xml;
using Microsoft.VisualBasic;
using OxyPlot;
using OxyPlot.Series;

namespace GraphingApplication
{
    public partial class Form1 : Form
    {

        public struct Stats //structure that allows for the saving of the weapon stats of a single steamId64
        {
            public String playerName;
            public int ak47_kills;
            public int m4a4_kills;
            public int awp_kills;
            public int p2000_kils;
            public int glock18_kills;
            public int desert_eagle_kills;
            public int ump45_kills;
            public int tec9_kills;
            public int five_seven_kills;
            public int total_kills;
        }

        String APIKey = "05A81C3E35BA40B45F2684B4A50DC846"; //Steam API key for use of the Steam Web API

        public Form1()
        {
            InitializeComponent();
            //String vanityUrl = "ashwathk";
            //String steamID64 = getSteamID64(vanityUrl);
            //Stats test = getStats(steamID64);
            var model = new PlotModel { Title = "Test" };
            model.Series.Add(new FunctionSeries(Math.Sin, -10, 10, .1, "sin(x)"));
            //this.plot1.Model = model;
        }

        public String getSteamID64(String vanityUrl) //After the user types in their VanityURL, this method queries the Steam API for the user's SteamID64 for use in other requests
        {
            String url = "http://api.steampowered.com/ISteamUser/ResolveVanityURL/v0001/?key=" + APIKey + "&vanityurl=" + vanityUrl + "&format=xml";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            String data = reader.ReadToEnd();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(data);
            String steamId64 = xmlDoc.ChildNodes[2].ChildNodes[0].InnerText;
            return steamId64;
        }

        public Stats getStats(String steamID64) //After recieving the steamID64, this method queries the Steam API for the actual stats
        {
            Stats stats = new Stats();
            String url = "http://api.steampowered.com/ISteamUserStats/GetUserStatsForGame/v0002/?appid=730&key=" + APIKey + "&steamid=" + steamID64 + "&format=xml";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            String data = reader.ReadToEnd();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(data);
            XmlNode parentNode = xmlDoc.ChildNodes[2];
            XmlNode statsNode = parentNode.ChildNodes[2];
            foreach(XmlNode statNode in statsNode.ChildNodes)
            {
                String statName = statNode.FirstChild.InnerText;
                switch (statName)
                {
                    case "total_kills_ak47":
                        XmlNode valueNode = statNode.ChildNodes[1];
                        Int32.TryParse(valueNode.InnerText, out stats.ak47_kills);
                        break;
                    case "total_kills_m4a1":
                        valueNode = statNode.ChildNodes[1];
                        Int32.TryParse(valueNode.InnerText, out stats.m4a4_kills); //Includes M4A1-S Kills as well as the M4A4
                        break;
                    case "total_kills_awp":
                        valueNode = statNode.ChildNodes[1];
                        Int32.TryParse(valueNode.InnerText, out stats.awp_kills);
                        break;
                    case "total_kills_hkp2000":
                        valueNode = statNode.ChildNodes[1];
                        Int32.TryParse(valueNode.InnerText, out stats.p2000_kils); //Includes USP-S kills as well
                        break;
                    case "total_kills_glock":
                        valueNode = statNode.ChildNodes[1];
                        Int32.TryParse(valueNode.InnerText, out stats.glock18_kills);
                        break;
                    case "total_kills_deagle":
                        valueNode = statNode.ChildNodes[1];
                        Int32.TryParse(valueNode.InnerText, out stats.desert_eagle_kills);
                        break;
                    case "total_kills_ump45":
                        valueNode = statNode.ChildNodes[1];
                        Int32.TryParse(valueNode.InnerText, out stats.ump45_kills);
                        break;
                    case "total_kills_tec9":
                        valueNode = statNode.ChildNodes[1];
                        Int32.TryParse(valueNode.InnerText, out stats.tec9_kills);
                        break;
                    case "total_kills_fiveseven":
                        valueNode = statNode.ChildNodes[1];
                        Int32.TryParse(valueNode.InnerText, out stats.five_seven_kills); //Includes CZ-75 Kills as well as the Five-Seven
                        break;
                    case "total_kills":
                        valueNode = statNode.ChildNodes[1];
                        Int32.TryParse(valueNode.InnerText, out stats.total_kills);
                        break;
                }
            }
            return stats;
        }

        private void getStatsButton_Click(object sender, EventArgs e) //triggers the stat search 
        {
            String vanityUrl = usernameBox.Text;
            String userSteamID64 = getSteamID64(vanityUrl);
            Stats stats = getStats(userSteamID64);
            GraphingForm graph = new GraphingForm(stats);
            graph.Show();
        }

        private void getComparedStatsButton_Click(object sender, EventArgs e)
        {
            String vanityUrl = usernameBox.Text;
            String userSteamID64 = getSteamID64(vanityUrl);
            Stats stats1 = getStats(userSteamID64);
            stats1.playerName = vanityUrl;
            String secondUsername = Microsoft.VisualBasic.Interaction.InputBox("Please enter a second Steam Username to compare.", "Enter Comparison Username");
            String secondUserSteamID64 = getSteamID64(secondUsername);
            Stats stats2 = getStats(secondUserSteamID64);
            stats2.playerName = secondUsername;
            GraphingForm graph = new GraphingForm(stats1, stats2);
            graph.Show();
        }

        private void getWeaponUsePercentagesButton_Click(object sender, EventArgs e)
        {
            String vanityUrl = usernameBox.Text;
            String userSteamID64 = getSteamID64(vanityUrl);
            Stats stats = getStats(userSteamID64);
            GraphingForm graph = new GraphingForm(stats, 0);
            graph.Show();
        }
    }
}
