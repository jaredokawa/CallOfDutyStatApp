using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;
using RestSharp;
using System.Security.Cryptography.X509Certificates;
using System;

namespace CODStatApp
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the Call of Duty Player Stats App!");

            Console.WriteLine("Please enter the gamer username:");
            string username = Console.ReadLine();

            Console.WriteLine("Please enter the platform (e.g., psn, xbox, battle, etc.):");
            string platform = Console.ReadLine();

            var response = ApiClient.CallOfDuty(platform, username);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var gamer = ApiClient.ParseResponse(response);
                Console.WriteLine("Gamer Statistics:");
                Console.WriteLine($"Wins: {gamer.wins}");
                Console.WriteLine($"Kills: {gamer.kills}");
                Console.WriteLine($"KD Ratio: {gamer.kdRatio}");
                // Add more statistics output as needed
            }
            else
            {
                Console.WriteLine("Error retrieving gamer statistics. Please try again.");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
