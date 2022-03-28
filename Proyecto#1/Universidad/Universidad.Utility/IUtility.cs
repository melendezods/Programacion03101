using System;
using System.Collections.Generic;
using System.Text;

namespace Universidad.Utility
{
    public interface IUtility
    {
        public IRestClient RestClient { get; }

    }

    public interface IRestClient
    {

        public string Post(string url, string json);
    
    }

}
