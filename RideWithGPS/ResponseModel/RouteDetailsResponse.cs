using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideWithGPS.ResponseModel
{
    public class RouteDetailsResponse
    {
        public string type { get; set; }
        public RouteDetails route { get; set; }
    }

    public class RouteDetails
    {
#nullable enable
        public int id { get; set; }
        public int highlighted_photo_id { get; set; }
        public string? highlighted_photo_checksum { get; set; }
        public float? distance { get; set; }
        public float elevation_gain { get; set; }
        public float elevation_loss { get; set; }
        public string track_id { get; set; } = string.Empty;

        public int user_id { get; set; }
        public string? pavement_type { get; set; }
        public int? pavement_type_id { get; set; }
        public List<int> recreation_type_ids { get; set; } = new();
        public int visibility { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public float first_lng { get; set; }
        public float first_lat { get; set; }
        public float last_lat { get; set; }
        public float last_lng { get; set; }
        public List<Coordinates> bounding_box { get; set; } = new();
        public string locality { get; set; } = string.Empty;
        public string postal_code { get; set; } = string.Empty;
        public string administrative_area { get; set; } = string.Empty;
        public string country_code { get; set; } = string.Empty;
        public string? privacy_code { get; set; }
        public UserDetails? user { get; set; }
        public bool has_course_points { get; set; }
        public List<string> tag_names { get; set; } = new();
        public string track_type { get; set; } = string.Empty;
        public string terrain { get; set; } = string.Empty;
        public string difficulty { get; set; } = string.Empty;
        public int unpaved_pct { get; set; }
        public string surface { get; set; } = string.Empty;
        public List<int> photo_ids { get; set; } = new();
        public List<PointOfInterest> points_of_interest { get; set; } = new();
        public List<CoursePoint> course_points { get; set; } = new();
        public List<RouteTrackPoint> track_points { get; set; } = new();
    }

    public class PointOfInterest
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int visibility { get; set; }
        public int poi_type { get; set; }
        public float lng {get; set;}
        public float lat { get; set; }
        public string name { get; set; } = string.Empty;
        public string? url { get; set; }
        public string description { get; set; } = string.Empty;
        public string? mongo_id { get; set; }
        public int parent_id { get; set; }
        public string parent_type { get; set; } = string.Empty;
        public DateTime created_at{ get; set; }
        public DateTime updated_at{ get; set; }
        public List<int> photo_ids { get; set; } = new();
    }
#nullable disable

    public class CoursePoint
    {
        public float d { get; set; }
        public int i { get; set; }
        public string n { get; set; }       // Course point detailed instruction
        public string t { get; set; }       // t: turn direction
        public float x { get; set; }
        public float y { get; set; }
    }

    public class RouteTrackPoint
    {
        public int R { get; set; }          // Road type ??
        public int S { get; set; }          // Surface type ??
        public float d { get; set; }        // Distance to this point
        public float e { get; set; }        // Point elevation
        public float x { get; set; }
        public float y { get; set; }
    }




}