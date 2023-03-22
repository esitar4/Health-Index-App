using health_index_app.Shared.FatSecret.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace health_index_app.Shared.FatSecret
{
    public interface IFatSecretSetup {
        public IFatSecretClient client { get; set; }
    }
    public class FatSecretSetup : IFatSecretSetup
    {
        public IFatSecretClient client { get; set; } = new FatSecretClient(
                new FatSecretCredentials
                {
                    ClientKey = "44a3ee4ca84b42ebb3234bc6bf66518c",
                    ClientSecret = "29c8029e8f1b4fdcae11abc7d1babfdd"
                },
                new HttpClient()
            );


    }
}
