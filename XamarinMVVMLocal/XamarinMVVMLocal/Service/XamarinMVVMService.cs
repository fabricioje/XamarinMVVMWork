using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using XamarinMVVMLocal.Model;

namespace XamarinMVVMLocal.Service
{
    public class XamarinMVVMService
    {
        //endereço da API
        private const string BaseUrl = "http://www.fabwebapi.somee.com/api/";

        public async Task<List<Dados>> GetDadosAsync()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //faz a concatenação da API onde se encontra as informações
            var response = await httpClient.GetAsync($"{BaseUrl}dados").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<List<Dados>>(
                        await new StreamReader(responseStream)
                            .ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return null;
        }
    }
}
