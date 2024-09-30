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

            Console.WriteLine("Trips");
            // print the last 10 trips
            foreach (var trip in trips)
            {
                Console.WriteLine($"Name: {trip.name} Date: {trip.created_at}");
            }

            Console.WriteLine();
            Console.WriteLine("Routes");
            // get the user routes and display some information about them
            var routes = client.GetUserRoutes(user.id, 0, 10).Result;
            Console.WriteLine($"{routes.Count} routes found");

            for (int i = 0; i < routes.Count; i++)
            {
                var routeDetails = client.GetRouteDetails(routes[i].id).Result;
                Console.WriteLine(
                    $"[{i.ToString("D3")}] {routeDetails.name}: {routeDetails.track_points.Count} track points and {routeDetails.points_of_interest.Count} POIs");
            }

            // The detailed_route_id config entry holds the id of a route for which to output details
            if (int.TryParse(config["detailed_route_id"], out var detailedRouteId))
            {
                var routeDetails = client.GetRouteDetails(detailedRouteId).Result;
                if (routeDetails != null)
                {
                    Console.WriteLine($"Route name:{routeDetails.name}");
                    
                    if (routeDetails.points_of_interest.Count > 0)
                    {
                        foreach (var poi in routeDetails.points_of_interest)
                        {
                            Console.WriteLine("POI");
                            Console.WriteLine($"Name:{poi.name}");
                            Console.WriteLine($"Type:{poi.poi_type}");
                            Console.WriteLine($"Description:{poi.description}");
                            Console.WriteLine($"Url:{poi.url}");
                            Console.WriteLine($"Latitude:{poi.lat}");
                            Console.WriteLine($"Longitude:{poi.lng}");
                            Console.WriteLine($"Visibility:{poi.visibility}");
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No points of interest found");
                    }
                    
                    Console.WriteLine();
                    Console.WriteLine("Track points:");
                    var pointNumber = 0;
                    const int maxPointsToOutput = 10;
                    foreach (var trackPoint in routeDetails.track_points)
                    {
                        Console.WriteLine($"Distance:{trackPoint.d}");
                        Console.WriteLine($"X:{trackPoint.x}");
                        Console.WriteLine($"Y:{trackPoint.y}");
                        Console.WriteLine($"Elevation:{trackPoint.e}");
                        Console.WriteLine();
                        pointNumber++;
                        if (pointNumber > maxPointsToOutput)
                        {
                            break;
                        }
                    }
                    
                }
            }

            // get the user events and print their name and number of routes
            (await client.GetUserEvents(user.id)).ForEach(userEvent =>
            {
                var eventDetails = client.GetEventDetails(userEvent.Id).Result;
                Console.Out.WriteLine(
                    $"Event {eventDetails.name} (Id: {eventDetails.id}) contains {eventDetails.routes.Count} route(s)");
            });
        }
    }
}