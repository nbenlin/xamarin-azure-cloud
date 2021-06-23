using System;
using System.Collections.Generic;
using System.Text;

namespace projectCdv.Helpers
{
    public class Constants
    {

        // Constants for azure web api
        
        public static string ApplicationURL = "https://xamtravelexpapp.azurewebsites.net";
        public const string VENUE_SEARCH = "https://api.foursquare.com/v2/venues/search?ll={0},{1}&client_id={2}&client_secret={3}&v={4}";
        public const string CLIENT_ID = "TM15W4VPDS1NJ4Y4AUZSDV2K4DXPHWKQGD2P22ZB2MOQ2JA4";
        public const string CLIENT_SECRET = "LC003CMXOVKNNCEGKK2FJCXJW3RITVAWMAUIUHHRQJBMXXTZ";
        

        // Constants for azure function
        public const string AzureFunctionURL = "https://travelappv2.azurewebsites.net/api/HttpTriggerFunc?code=/K2Yl1X6S0pRDsGxNaRPpKkjJnYP/8qtgFrtM/LKJdYdXkESuN100Q==";
        public const string AzureFunctionPostURL = "https://travelappv2.azurewebsites.net/api/user";
    }
}
