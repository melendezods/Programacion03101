using System;
using System.Collections.Generic;
using System.Text;
using Universidad.Utility.RestClient;

namespace Universidad.Utility
{
    public class UtilityHelper : IUtility
    {
        
        public RestFullClient restClient;

        public UtilityHelper()
        {
            restClient = new RestFullClient();
        }

        public IRestClient RestClient => restClient;


    }
}
