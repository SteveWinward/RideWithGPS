using System;
using System.Collections.Generic;
using System.Text;

namespace RideWithGPS.ResponseModel
{
    public class TripDetailsResponse
    {
        public string type { get; set; }
        public TripDetails trip { get; set; }
    }

    public class TripDetails
    {
        public int id { get; set; }
        public int highlighted_photo_id { get; set; }
        public object highlighted_photo_checksum { get; set; }
        public float distance { get; set; }
        public float elevation_gain { get; set; }
        public float elevation_loss { get; set; }
        public string track_id { get; set; }
        public int user_id { get; set; }
        public int visibility { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime departed_at { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public float first_lng { get; set; }
        public float first_lat { get; set; }
        public float last_lat { get; set; }
        public float last_lng { get; set; }
        public Coordinates[] bounding_box { get; set; }
        public object locality { get; set; }
        public object postal_code { get; set; }
        public object administrative_area { get; set; }
        public object country_code { get; set; }
        public bool is_stationary { get; set; }
        public object privacy_code { get; set; }
        public UserDetails user { get; set; }
        public Gear gear { get; set; }
        public Metrics metrics { get; set; }
        public bool live_logging { get; set; }
        public object live_log { get; set; }
        public bool rememberable { get; set; }
        public object[] photos { get; set; }
        public Track_Points[] track_points { get; set; }
    }

    public class Gear
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Metrics
    {
        public int id { get; set; }
        public int parent_id { get; set; }
        public string parent_type { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Ele ele { get; set; }
        public Hr hr { get; set; }
        public Cad cad { get; set; }
        public Speed speed { get; set; }
        public Grade grade { get; set; }
        public bool stationary { get; set; }
        public int duration { get; set; }
        public int firstTime { get; set; }
        public int movingTime { get; set; }
        public int stoppedTime { get; set; }
        public float pace { get; set; }
        public float movingPace { get; set; }
        public int ascentTime { get; set; }
        public int descentTime { get; set; }
        public float vam { get; set; }
        public float distance { get; set; }
        public float endElevation { get; set; }
        public int numPoints { get; set; }
        public float ele_gain { get; set; }
        public float ele_loss { get; set; }
        public int v { get; set; }
        public Watts watts { get; set; }
        public int? calories { get; set; }
    }

    public class Ele
    {
        public float max { get; set; }
        public float min { get; set; }
        public float _min { get; set; }
        public float _max { get; set; }
        public int max_i { get; set; }
        public int min_i { get; set; }
        public float _avg { get; set; }
        public float avg { get; set; }
    }

    public class Hr
    {
        public int max { get; set; }
        public int min { get; set; }
        public int _min { get; set; }
        public int _max { get; set; }
        public int max_i { get; set; }
        public int min_i { get; set; }
        public float _avg { get; set; }
        public float avg { get; set; }
    }

    public class Cad
    {
        public int max { get; set; }
        public int min { get; set; }
        public int _min { get; set; }
        public int _max { get; set; }
        public int max_i { get; set; }
        public int min_i { get; set; }
        public float _avg { get; set; }
        public float avg { get; set; }
    }

    public class Speed
    {
        public float max { get; set; }
        public float min { get; set; }
        public float _min { get; set; }
        public float _max { get; set; }
        public float max_i { get; set; }
        public float min_i { get; set; }
        public float _avg { get; set; }
        public float avg { get; set; }
    }

    public class Grade
    {
        public float max { get; set; }
        public float min { get; set; }
        public float _min { get; set; }
        public float _max { get; set; }
        public int max_i { get; set; }
        public int min_i { get; set; }
        public float _avg { get; set; }
        public float avg { get; set; }
    }

    public class Watts
    {
    }

    public class Track_Points
    {
        public int c { get; set; }
        public int h { get; set; }
        public int t { get; set; }
        public float e { get; set; }
        public float g { get; set; }
        public float s { get; set; }
        public float x { get; set; }
        public float y { get; set; }
    }

}
