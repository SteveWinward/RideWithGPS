using System;
using System.Collections.Generic;
using System.Text;

namespace RideWithGPS.ResponseModel
{

    public class UserDetailsResponse
    {
        public UserDetails user { get; set; }
    }

    public class UserDetails
    {
        public int id { get; set; }
        public DateTime created_at { get; set; }
        public string description { get; set; }
        public string interests { get; set; }
        public string locality { get; set; }
        public string administrative_area { get; set; }
        public int account_level { get; set; }
        public float total_trip_distance { get; set; }
        public int total_trip_duration { get; set; }
        public float total_trip_elevation_gain { get; set; }
        public string name { get; set; }
        public int highlighted_photo_id { get; set; }
        public string highlighted_photo_checksum { get; set; }
        public bool friendable { get; set; }
    }

}
