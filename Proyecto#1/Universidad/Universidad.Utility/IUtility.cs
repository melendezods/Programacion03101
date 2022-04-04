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
        public string Put(string url, string json);
        public string Delete(string url, string json);

        public string Get(string url);


    }

   

}
