using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ProyectoWeb.Client.Repositorios
{
    public class RepositorioOC : IRepositorioOC
    {

        private readonly HttpClient httpClient;

        public RepositorioOC(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        private static JsonSerializerOptions defaultJson => new() { PropertyNameCaseInsensitive = true }; 

        public async Task<HttpResponseWrapper<T>> Get<T>(string url) {
        
            var httpResponse = await httpClient.GetAsync(url);

            if (httpResponse.IsSuccessStatusCode)
            {

                var response = await Deserializar<T>(httpResponse, defaultJson);
                return new HttpResponseWrapper<T>(response, false, httpResponse);


            }
            else {

                return new HttpResponseWrapper<T>(default, true, httpResponse);

            }

        
        }

        public async Task<HttpResponseWrapper<object>> Post<T>(string url , T enviar) {

            var enviarJSON = JsonSerializer.Serialize(enviar); 
            var enviarContent = new StringContent(enviarJSON, Encoding.UTF8, "application/json" );
            var responseHttp = await httpClient.PostAsync(url, enviarContent);
            return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp);

        }



        private async Task<T> Deserializar<T>(HttpResponseMessage httpResponse, JsonSerializerOptions jsonSerializerOptions) {
            
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseString, jsonSerializerOptions);

        }
        
    }
}
