using LQiW_Server.Controllers;
using LQiW_Server.UserGroup;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LQiW_Server.Classen
{
    public class GeocodingService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public GeocodingService(HttpClient httpClient, string apiKey)
        {
            _httpClient = httpClient;
            _apiKey = apiKey;
        }

        public async Task<UserLocation> GetLocationDetailsFromAddress(string address)
        {
            var url = $"https://maps.googleapis.com/maps/api/geocode/json?address={Uri.EscapeDataString(address)}&key={_apiKey}";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<GeocodeData>(json);
                if (data.Status == "OK") // Ensure there are results
                {
                    var jobject = JObject.Parse(json);
                    JObject firstItem = (JObject)jobject["results"][0];
                    string formattedAddress = (string)firstItem["formatted_address"];
                    double latitude = (double)firstItem["geometry"]["location"]["lat"];
                    double longitude = (double)firstItem["geometry"]["location"]["lng"];
                    string district = string.Empty;
                    string country = string.Empty;
                    int postcode = 0;
                    JArray addrComp = (JArray)firstItem["address_components"];
                    foreach (var adressComp in addrComp)
                    {
                        if (adressComp["types"][0].ToString()=="political")
                        {
                            district = adressComp["long_name"].ToString();
                        }
                        if (adressComp["types"][0].ToString()=="country")
                        {
                            country = adressComp["short_name"].ToString();
                        }
                        if (adressComp["types"][0].ToString()=="postal_code")
                        {
                            postcode = Convert.ToInt32(adressComp["short_name"]);
                        }
                    }

                    if ((country != "AT") || (postcode < 1000 || postcode > 1230))
                    {
                        throw new Exception("notAT");
                    }
                    
                    var details = new UserLocation()
                    {
                        Latitude = latitude,
                        Longitude = longitude,
                        FormattedAddress = formattedAddress,
                        Country = country,
                        PostalCode = postcode,
                        District = district,
                    };
                    return details;
                }
                throw new Exception($"Geocoding failed with status: {data.Status}");
            }
            throw new Exception("Failed to get response from geocoding API");
        }

        public class GeocodeData
        {
            public string Status { get; set; }
        }
    }
}