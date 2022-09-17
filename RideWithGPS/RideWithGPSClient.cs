using RideWithGPS.ResponseModel;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace RideWithGPS
{
    public class RideWithGPSClient
    {
        protected string AuthToken { get; set; }

        protected RideWithGPSConnectionInfo ConnectionInfo { get; set; }

        protected HttpClient Client { get; set; }

        protected RideWithGPSClient()
        {
            this.Client = new HttpClient();
        }

        protected RideWithGPSClient(HttpClient client, RideWithGPSConnectionInfo connectionInfo)
        {
            this.Client = client;

            this.ConnectionInfo = connectionInfo;
        }

        /// <summary>
        /// Creates a new RideWithGPSClient object from the RideWithGPSConnectionInfo details
        /// </summary>
        /// <param name="connection">The connection details (api key, credentials, etc)</param>
        /// <returns></returns>
        public static async Task<RideWithGPSClient> Connect(RideWithGPSConnectionInfo connection)
        {
            var httpClient = new HttpClient();
            var client = new RideWithGPSClient(httpClient, connection);

            var url = $"{connection.BaseUrl}/users/current.json?{client.GetAuthQueryString(connection)}";

            var result = await httpClient.GetAsync(url);

            var response = await result.Content.ReadAsStringAsync();

            var json = JsonSerializer.Deserialize<AuthenticatedUserResponse>(response);

            client.AuthToken = json.user.auth_token;

            return client;
        }

        /// <summary>
        /// Returns the current user context details
        /// </summary>
        /// <returns></returns>
        public async Task<UserDetails> GetCurrentUserDetails()
        {
            var url = $"{this.ConnectionInfo.BaseUrl}/users/current.json?{this.GetStandardQueryString()}";

            var result = await this.Client.GetAsync(url);

            var response = await result.Content.ReadAsStringAsync();

            var json = JsonSerializer.Deserialize<UserDetailsResponse>(response);

            return json.user;
        }

        /// <summary>
        /// Looks up a users details from their unique user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserDetails> GetUserDetails(int userId)
        {
            var url = $"{this.ConnectionInfo.BaseUrl}/users/{userId}.json?{this.GetStandardQueryString()}";

            var result = await this.Client.GetAsync(url);

            var response = await result.Content.ReadAsStringAsync();

            var json = JsonSerializer.Deserialize<UserDetailsResponse>(response);

            return json.user;
        }

        /// <summary>
        /// Returns a list of user trips.
        /// </summary>
        /// <param name="userId">The unique user id</param>
        /// <param name="offset">Where to start the result set</param>
        /// <param name="limit">How many results to return</param>
        /// <returns></returns>
        public async Task<List<UserTrip>> GetUserTrips(int userId, int offset, int limit)
        {
            var url = $"{this.ConnectionInfo.BaseUrl}/users/{userId}/trips.json?{this.GetOffsetQueryString(offset, limit)}";

            var result = await this.Client.GetAsync(url);

            var response = await result.Content.ReadAsStringAsync();

            var json = JsonSerializer.Deserialize<UserTripsResponse>(response);

            return json.Trips;
        }

        /// <summary>
        /// Returns the details for a specific trip id
        /// </summary>
        /// <param name="tripId">The unique trip id</param>
        /// <returns></returns>
        public async Task<TripDetails> GetTripDetails(int tripId)
        {
            var url = $"{this.ConnectionInfo.BaseUrl}/trips/{tripId}.json?{this.GetStandardQueryString()}";

            var result = await this.Client.GetAsync(url);

            var response = await result.Content.ReadAsStringAsync();

            var json = JsonSerializer.Deserialize<TripDetailsResponse>(response);

            return json.trip;
        }

        /// <summary>
        /// Returns a list of user routes.
        /// </summary>
        /// <param name="userId">The unique user id</param>
        /// <param name="offset">Where to start the result set</param>
        /// <param name="limit">How many results to return</param>
        /// <returns></returns>
        public async Task<List<UserRoute>> GetUserRoutes(int userId, int offset, int limit)
        {
            var url = $"{this.ConnectionInfo.BaseUrl}/users/{userId}/routes.json?{this.GetOffsetQueryString(offset, limit)}";

            var result = await this.Client.GetAsync(url);

            var response = await result.Content.ReadAsStringAsync();

            var json = JsonSerializer.Deserialize<UserRoutesResponse>(response);

            return json.Routes;
        }

        /// <summary>
        /// Returns the details for a specific route id
        /// </summary>
        /// <param name="routeId">The unique route id</param>
        /// <returns></returns>
        public async Task<RouteDetails> GetRouteDetails(int routeId)
        {
            var url = $"{this.ConnectionInfo.BaseUrl}/routes/{routeId}.json?{this.GetStandardQueryString()}";

            var result = await this.Client.GetAsync(url);

            var response = await result.Content.ReadAsStringAsync();

            var json = JsonSerializer.Deserialize<RouteDetailsResponse>(response);

            return json.route;
        }

        /// <summary>
        /// Returns a list of user events.
        /// </summary>
        /// <param name="userId">The unique user id</param>
        /// <param name="groupName">Specify the desired event group (past, current, ...) or leave empty to get all events</param>
        /// <returns></returns>
        public async Task<List<UserEvent>> GetUserEvents(int userId, string groupName = null)
        {
            var url = $"{this.ConnectionInfo.BaseUrl}/users/{userId}/events.json?{this.GetStandardQueryString()}";

            var result = await this.Client.GetAsync(url);

            var response = await result.Content.ReadAsStringAsync();

            var json = JsonSerializer.Deserialize<UserEventsResponse>(response);

            return json.Events(groupName);
        }

        /// <summary>
        /// Returns the details for a specific event id
        /// </summary>
        /// <param name="eventId">The unique event id</param>
        /// <returns></returns>
        public async Task<EventDetails> GetEventDetails(int eventId)
        {
            var url = $"{this.ConnectionInfo.BaseUrl}/events/{eventId}.json?{this.GetStandardQueryString()}";

            var result = await this.Client.GetAsync(url);

            var response = await result.Content.ReadAsStringAsync();

            var json = JsonSerializer.Deserialize<EventDetailsResponse>(response);

            return json.eventDetails;
        }

        /// <summary>
        /// Returns the query string for the initial auth connection
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        protected string GetAuthQueryString(RideWithGPSConnectionInfo connection)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);

            query["email"] = connection.Email;
            query["password"] = connection.Password.ConvertToString();
            query["apikey"] = connection.ApiKey;
            query["version"] = connection.Version;

            return query.ToString();
        }

        /// <summary>
        /// Returns the query string for the api calls that already have an auth token value
        /// </summary>
        /// <returns></returns>
        protected string GetStandardQueryString()
        {
            var query = HttpUtility.ParseQueryString(string.Empty);

            query["apikey"] = this.ConnectionInfo.ApiKey;
            query["version"] = this.ConnectionInfo.Version;
            query["auth_token"] = this.AuthToken;

            return query.ToString();
        }

        /// <summary>
        /// Returns a query string that includes the offset and limit details
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        protected string GetOffsetQueryString(int offset, int limit = 100)
        {
            var standardQuery = this.GetStandardQueryString();

            var newQuery = HttpUtility.ParseQueryString(standardQuery);

            newQuery["offset"] = offset.ToString();
            newQuery["limit"] = limit.ToString();

            return newQuery.ToString();
        }
    }
}