using MinhasFinancasWebApp.Models;

namespace MinhasFinancasWebApp.Services
{
    public class BuscaCEPService
    {
        private static RegistroCEP _cep = new();
        const string URILink = "https://cdn.apicep.com/file/apicep/";

        public RegistroCEP consultaGetCep(string cep)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = client.GetAsync(URILink + cep + ".json").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = response.Content.ReadAsStringAsync().Result;
                        _cep = System.Text.Json.JsonSerializer.Deserialize<RegistroCEP>(jsonString);
                        return _cep;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao consultar o CEP: " + ex.Message);
            }
            return new RegistroCEP();
        }
    }
}
