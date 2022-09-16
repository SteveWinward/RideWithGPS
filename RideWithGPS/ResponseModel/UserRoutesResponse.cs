using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RideWithGPS.ResponseModel
{
    public class UserRoutesResponse
    {
        [JsonPropertyName("results")]
        public List<UserRoute> Routes { get; set; }
        public int results_count { get; set; }
    }

    public class UserRoute
    {
#nullable enable
        public int id { get; set; }
        public int group_membership_id { get; set; }
        public string name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public DateTime created_at { get; set; }
        public float? distance { get; set; }
        public float elevation_gain { get; set; }
        public float elevation_loss { get; set; }
        public int visibility { get; set; }
        public float first_lat { get; set; }
        public float first_lng { get; set; }
        public float last_lat { get; set; }
        public float last_lng { get; set; }
        public bool is_trip { get; set; }
        public string postal_code { get; set; } = string.Empty ;
        public string locality { get; set; } = string.Empty;
        public string administrative_area { get; set; } = string.Empty;
        public int? pavement_type_id { get; set; }
        public string country_code { get; set; } = string.Empty;
        public bool has_course_points { get; set; }
        public DateTime updated_at { get; set; }
        public int? best_for_id { get; set; }
        public int? planner_options { get; set; }
        public int user_id { get; set; }
        public DateTime? deleted_at { get; set; }
        public float sw_lng { get; set; }
        public float sw_lat { get; set; }
        public float ne_lng { get; set; }
        public float ne_lat { get; set; }
        public string track_id { get; set; } = string.Empty;
        public DateTime? archived_at { get; set; }
        public int likes_count { get; set; }
        public string track_type { get; set; } = string.Empty;
        public string terrain { get; set; } = string.Empty;
        public string difficulty { get; set; } = string.Empty;
        public int unpaved_pct { get; set; }
        public int highlighted_photo_id { get; set; }
        public string? highlighted_photo_checksum { get; set; }
    }
}
