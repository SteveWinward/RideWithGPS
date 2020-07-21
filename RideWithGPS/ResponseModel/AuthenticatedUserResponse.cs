using System;
using System.Collections.Generic;
using System.Text;

namespace RideWithGPS.ResponseModel
{
    public class AuthenticatedUserResponse
    {
        public AuthenticatedUser user { get; set; }
        public Labs labs { get; set; }
        public object[] additional_drawer_items { get; set; }
    }

    public class AuthenticatedUser
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public DateTime created_at { get; set; }
        public int self_membership_id { get; set; }
        public object description { get; set; }
        public object interests { get; set; }
        public bool email_visible { get; set; }
        public DateTime last_login_at { get; set; }
        public double total_route_distance { get; set; }
        public bool metric_units { get; set; }
        public object hr_max { get; set; }
        public object hr_rest { get; set; }
        public object hr_zone_1_low { get; set; }
        public object hr_zone_1_high { get; set; }
        public object hr_zone_2_low { get; set; }
        public object hr_zone_2_high { get; set; }
        public object hr_zone_3_low { get; set; }
        public object hr_zone_3_high { get; set; }
        public object hr_zone_4_low { get; set; }
        public object hr_zone_4_high { get; set; }
        public object hr_zone_5_low { get; set; }
        public object hr_zone_5_high { get; set; }
        public object is_male { get; set; }
        public object weight { get; set; }
        public object vo2max { get; set; }
        public int num_unread_messages { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public string display_name { get; set; }
        public object locality { get; set; }
        public object administrative_area { get; set; }
        public object postal_code { get; set; }
        public string country_code { get; set; }
        public bool email_on_message { get; set; }
        public bool email_on_comment { get; set; }
        public bool email_on_update { get; set; }
        public int visibility { get; set; }
        public string time_zone { get; set; }
        public object facebook_id { get; set; }
        public int account_level { get; set; }
        public int weeks_start_on { get; set; }
        public int email_bounce_count { get; set; }
        public int trips_included_in_totals_count { get; set; }
        public int site_id { get; set; }
        public object dob { get; set; }
        public int deactivated { get; set; }
        public DateTime updated_at { get; set; }
        public object deactivated_at { get; set; }
        public string locale { get; set; }
        public string name { get; set; }
        public object age { get; set; }
        public string[] privileges { get; set; }
        public int highlighted_photo_id { get; set; }
        public Preferences preferences { get; set; }
        public object[] gear { get; set; }
        public object[] unseen_updates { get; set; }
        public object[] push_applications { get; set; }
        public object[] relevant_goal_participants { get; set; }
        public object[] club_ids { get; set; }
        public object[] slim_favorites { get; set; }
        public bool has_events { get; set; }
        public bool needs_password_reset { get; set; }
        public bool eligible_for_onetime_trial { get; set; }
        public bool is_shadow_user { get; set; }
        public string auth_token { get; set; }
        public object user_summary { get; set; }
    }

    public class Preferences
    {
        public string planner_overlay { get; set; }
        public bool metric_units { get; set; }
        public bool show_dash_onboarding_overlay { get; set; }
    }

    public class Labs
    {
        public bool fit_export { get; set; }
        public bool rsp_redesign { get; set; }
        public bool homepage_redesign { get; set; }
        public bool pinned_in_searchbar { get; set; }
        public bool smart_export { get; set; }
        public bool mobile_home_redesign { get; set; }
        public bool can_see_homepage_opt_in { get; set; }
        public bool strava_sync { get; set; }
        public bool relive_sync { get; set; }
        public bool trsp_redesign { get; set; }
        public bool varia { get; set; }
        public bool route_planner { get; set; }
    }

}
