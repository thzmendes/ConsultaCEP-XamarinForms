using ConsultarCEP.Service.Model;
using Newtonsoft.Json;
using System.Net;

namespace ConsultarCEP.Service
{
    public class ViaCepService
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Address BuscarEnderecoViaCEP(string cep)
        {
            string NovaURL = string.Format(EnderecoURL, cep);
            WebClient wc = new WebClient();
            string content = wc.DownloadString(NovaURL);
            Address address = JsonConvert.DeserializeObject<Address>(content);
            return address.cep == null ? null : address;
        }
    }
}