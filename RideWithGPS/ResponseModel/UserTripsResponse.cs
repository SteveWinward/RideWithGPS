using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RideWithGPS.ResponseModel
{
    public class UserTripsResponse
    {
        [JsonPropertyName("results")]
        public List<UserTrip> Trips { get; set; }
        public int results_count { get; set; }
    }

    public class UserTrip
    {
        public int id { get; set; }
        public int group_membership_id { get; set; }
        public object route_id { get; set; }
        public DateTime created_at { get; set; }
        public int? gear_id { get; set; }
        public DateTime departed_at { get; set; }
        public int duration { get; set; }
        public float distance { get; set; }
        public float elevation_gain { get; set; }
        public float elevation_loss { get; set; }
        public int visibility { get; set; }
        public string description { get; set; }
        public bool is_gps { get; set; }
        public string name { get; set; }
        public object max_hr { get; set; }
        public object min_hr { get; set; }
        public object avg_hr { get; set; }
        public object max_cad { get; set; }
        public object min_cad { get; set; }
        public object avg_cad { get; set; }
        public float avg_speed { get; set; }
        public float max_speed { get; set; }
        public int moving_time { get; set; }
        public bool processed { get; set; }
        public object avg_watts { get; set; }
        public object max_watts { get; set; }
        public object min_watts { get; set; }
        public bool is_stationary { get; set; }
        public int? calories { get; set; }
        public DateTime updated_at { get; set; }
        public string time_zone { get; set; }
        public float first_lng { get; set; }
        public float first_lat { get; set; }
        public float last_lng { get; set; }
        public float last_lat { get; set; }
        public int user_id { get; set; }
        public object deleted_at { get; set; }
        public float sw_lng { get; set; }
        public float sw_lat { get; set; }
        public float ne_lng { get; set; }
        public float ne_lat { get; set; }
        public string track_id { get; set; }
        public string postal_code { get; set; }
        public string locality { get; set; }
        public string administrative_area { get; set; }
        public string country_code { get; set; }
        public object source_type { get; set; }
        public int highlighted_photo_id { get; set; }
        public string highlighted_photo_checksum { get; set; }
        public int utc_offset { get; set; }
    }

}
