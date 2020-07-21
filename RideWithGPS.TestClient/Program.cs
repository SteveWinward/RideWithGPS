using System;
using System.Threading.Tasks;

namespace RideWithGPS.TestClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // RideWithGPS API connection details
            var connection = new RideWithGPSConnectionInfo()
            {
                ApiKey = "<INSERT_API_KEY_HERE>",
                Email = "<INSERT_EMAIL_HERE>",
                Password = "<INSERT_PASSWORD_HERE>".ConvertToSecureString(),
            };

            // connect to the RideWithGPS API and get an auth token
            var client = await RideWithGPSClient.Connect(connection);

            // get the current user context
            var user = await client.GetCurrentUserDetails();

            // get the last 10 trips for the current user context
            var trips = await client.GetUserTrips(user.id, 0, 10);

            // print the last 10 trips
            foreach(var trip in trips)
            {
                Console.WriteLine($"Name: {trip.name} Date: {trip.created_at}");
            }
        }
    }
}
