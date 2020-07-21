# RideWithGPS
This is a very simple wrapper to the RideWithGPS API.  I did not encasulate all of the functionality of the API and some of the fields may not be mapped to the correct data types, but would love to get contributions from others!

This client library is published on nuget.org below,

https://www.nuget.org/packages/RideWithGPS/

## Registering with RideWithGPS's API
You need to register with RideWithGPS to get a valid API key to be able to use their API.  You can request an API key by going to the link below,

https://ridewithgps.com/api

## Sample .NET Core Console Application

First, add the RideWithGPS nuget package to your dotnet core application,

https://www.nuget.org/packages/RideWithGPS/

Below is a sample console applicaiton using the libary.  Replace the ApiKey, Email and Password with your actual login information.

````
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
````