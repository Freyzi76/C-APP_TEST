using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Services
{
    class RequestApi
    {

        public Task<string> GetDataTrim(string ServiceUrl, string FirstVar, string SecondVar)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();

            clientHandler.ServerCertificateCustomValidationCallback = (sr, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)
            HttpClient client = new HttpClient(clientHandler);

            if(ServiceUrl != null)
            {

                if(FirstVar != null)
                {

                    if (FirstVar != null && SecondVar == null)
                    {

                        return client.GetStringAsync(App.API_BASE_URL + ServiceUrl + FirstVar.Trim());

                    }
                    else if (FirstVar != null && SecondVar != null)
                    {

                        return client.GetStringAsync(App.API_BASE_URL + ServiceUrl + FirstVar.Trim() + "/" + SecondVar.Trim());

                    }

                }
                else
                {
                    return client.GetStringAsync(App.API_BASE_URL + ServiceUrl);
                }

            }
            else
            {
                return Task.Run(() => string.Empty);
            }

            return Task.Run(() => string.Empty);

        }

    }
}
