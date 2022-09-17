using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;

namespace RideWithGPS.ResponseModel
{
    public class UserEventsResponse
    {
        public List<UserEventGroup> groups { get; set; }

        public List<UserEvent> Events(string groupName)
        {
            List<UserEvent> retList = new();
            groups.ForEach(group =>
            {
                if (string.IsNullOrEmpty(groupName) || groupName.Equals(group.name))
                {
                    retList.AddRange(group.items);
                }
            });
            return retList;
        }
    }

    public class UserEventGroup
    {
        public string name { get; set; }
        public List<UserEvent> items { get; set; }
    }
    public class UserEvent
    {
#nullable enable
        public string name { get; set; } = string.Empty;
        public string? desc { get; set; }
        public DateTime? starts_on { get; set; }
        public string? location { get; set; }
        public DateTime? ends_on { get; set; }
        public string slug { get; set; } = string.Empty;

        public List<int> photo_ids { get; set; } = new();
        public UserDetails user { get; set; } = new();

        public int Id
        {
            get
            {
                // The slug has the following format: "id-name"
                // To obtain the event id, we will therefore use the first part of the slug, before the "-"
                int id = -1;
                Int32.TryParse(slug.Split('-')[0], out id);
                return id;
            }
        }
    }
}