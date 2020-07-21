using RideWithGPS.ResponseModel;
using System;
using System.Collections.Generic;
using System.Net.Http;
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

        public RideWithGPSClient()
        {
            this.Client = new HttpClient();
        }

        public RideWithGPSClient(HttpClient client, RideWithGPSConnectionInfo connectionInfo)
        {
            this.Client = client;

            this.ConnectionInfo = connectionInfo;
        }

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

        public async Task<UserDetails> GetCurrentUserDetails()
        {
            var url = $"{this.ConnectionInfo.BaseUrl}/users/current.json?{this.GetStandardQueryString()}";

            var result = await this.Client.GetAsync(url);

            var response = await result.Content.ReadAsStringAsync();

            var json = JsonSerializer.Deserialize<UserDetailsResponse>(response);

            return json.user;
        }

        public async Task<UserDetails> GetUserDetails(int userId)
        {
            var url = $"{this.ConnectionInfo.BaseUrl}/users/{userId}.json?{this.GetStandardQueryString()}";

            var result = await this.Client.GetAsync(url);

            var response = await result.Content.ReadAsStringAsync();

            var json = JsonSerializer.Deserialize<UserDetailsResponse>(response);

            return json.user;
        }

        public async Task<List<UserTrip>> GetUserTrips(int userId, int offset, int limit)
        {
            var url = $"{this.ConnectionInfo.BaseUrl}/users/{userId}/trips.json?{this.GetOffsetQueryString(offset, limit)}";

            var result = await this.Client.GetAsync(url);

            var response = await result.Content.ReadAsStringAsync();

            var json = JsonSerializer.Deserialize<UserTripsResponse>(response);

            return json.Trips;
        }

        public async Task<TripDetails> GetTripDetails(int tripId)
        {
            var url = $"{this.ConnectionInfo.BaseUrl}/trips/{tripId}.json?{this.GetStandardQueryString()}";

            var result = await this.Client.GetAsync(url);

            var response = await result.Content.ReadAsStringAsync();

            var json = JsonSerializer.Deserialize<TripDetailsResponse>(response);

            return json.trip;
        }

        protected string GetAuthQueryString(RideWithGPSConnectionInfo connection)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);

            query["email"] = connection.Email;
            query["password"] = connection.Password.ConvertToString();
            query["apikey"] = connection.ApiKey;
            query["version"] = connection.Version;

            return query.ToString();
        }

        protected string GetStandardQueryString()
        {
            var query = HttpUtility.ParseQueryString(string.Empty);

            query["apikey"] = this.ConnectionInfo.ApiKey;
            query["version"] = this.ConnectionInfo.Version;
            query["auth_token"] = this.AuthToken;

            return query.ToString();
        }

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