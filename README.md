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

Below is a sample console applicaiton using the libary.  Modify the user secret keys "apikey", "email" and "password" with your actual login information.

````csharp
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace RideWithGPS.TestClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                            .AddUserSecrets<Program>()
                            .Build();

            // RideWithGPS API connection details
            var connection = new RideWithGPSConnectionInfo()
            {
                ApiKey = config["apikey"],
                Email = config["email"],
                Password = config["password"].ConvertToSecureString(),
            };

            // connect to the RideWithGPS API and get an auth token
            var client = await RideWithGPSClient.Connect(connection);

            // get the current user context
            var user = await client.GetCurrentUserDetails();

            // get the last 10 trips for the current user context
            var trips = await client.GetUserTrips(user.id, 0, 10);

            // print the last 10 trips
            foreach (var trip in trips)
            {
                Console.WriteLine($"Name: {trip.name} Date: {trip.created_at}");
            }

            // get the user routes and display some information about them
            var routes = client.GetUserRoutes(user.id, 0, 1000).Result;
            Console.WriteLine($"{routes.Count} routes found");

            for (int i = 0; i < routes.Count; i++)
            {
                var routeDetails = client.GetRouteDetails(routes[i].id).Result;
                Console.WriteLine($"[{i.ToString("D3")}] {routeDetails.name}: {routeDetails.track_points.Count} track points and {routeDetails.points_of_interest.Count} POIs");
            }

            // get the user events and print their name and number of routes
            (await client.GetUserEvents(user.id)).ForEach(userEvent =>
            {
                var eventDetails = client.GetEventDetails(userEvent.Id).Result;
                Console.Out.WriteLine($"Event {eventDetails.name} (Id: {eventDetails.id}) contains {eventDetails.routes.Count} route(s)");
            });
        }
    }
}
````
