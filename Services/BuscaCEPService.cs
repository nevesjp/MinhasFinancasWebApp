using MinhasFinancasWebApp.Models;

namespace MinhasFinancasWebApp.Services
{
    public class BuscaCEPService
    {
        private static RegistroCEP _cep;
        private static List<RegistroCEP> _cepList = new List<RegistroCEP>();
        const string URILink = "https://cdn.apicep.com/file/apicep/";

        public void Adicionar(RegistroCEP cep)
        {
            _cep = cep;
            _cepList.Add(cep);
        }

        public List<RegistroCEP> Listar()
        {
            // Retorna a lista do historico
            return _cepList.ToList();
        }

        public RegistroCEP? SetRegistro()
        {
            // Atualiza o registro consultado
            return _cep;
        }

        public RegistroCEP? consultaGetCep(string cep)
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
                else
                {
                    throw new Exception("Erro na resposta da API: " + response.StatusCode);
                }
            }
        }
    }
}
