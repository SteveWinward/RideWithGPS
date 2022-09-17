using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RideWithGPS.ResponseModel
{
    public class EventDetailsResponse
    {
        [JsonPropertyName("event")]
        public EventDetails eventDetails { get; set; }
    }
#nullable enable

    public class EventDetails
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string? desc { get; set; }
        public int group_id { get; set; }
        public int group_membership_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public bool official { get; set; }
        public DateTime? starts_on { get; set; }
        public string custom_tabs { get; set; } = string.Empty;
        public string? location { get; set; }
        public string slug { get; set; } = string.Empty;
        public DateTime? ends_on { get; set; }
        public int? cost_in_cents   { get; set; }
        public int visibility { get; set; }
        public DateTime? starts_at { get; set; }
        public DateTime? ends_at { get; set; }

        public bool request_age_and_gender { get; set; }
        public bool filter_gender{get; set; }
        public bool filter_age { get; set; }
        public string age_splits { get; set; } = string.Empty;
        public string? participant_duration { get; set; }
        public bool request_email { get; set; }
        public List<string> organizer_ids { get; set; } = new();
        public int? event_series_id { get; set; }
        public DateTime? archived_at { get; set; }
        public List<int> photo_ids { get; set; } = new();
        public int highlighted_photo_id { get; set; }
        public string? highlighted_photo_checksum { get; set; }

        public List<string> photos { get; set; } = new();
        public string thumb_url { get; set; } = string.Empty;
        public bool all_day { get; set; }
        public bool is_participant { get; set; }
        public List<UserRoute> routes { get; set; } = new();
     }
}
