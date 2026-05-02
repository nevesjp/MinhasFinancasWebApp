using Microsoft.AspNetCore.Mvc;

namespace MinhasFinancasWebApp.Models
{
    public class BuscaCEP
    {
        /*
         ***** Model**********
                     * {
              "code": "58070-402",
              "state": "PB",
              "city": "João Pessoa",
              "district": "Cristo Redentor",
              "address": "Rua Jorge do Espírito Santo",
              "status": 200,
              "ok": true,
              "statusText": "ok"
            } 
         ********************
         */
        public string cepConsultaText { get; set; }

        public string code { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string discrict { get; set; }
        public string address { get; set; }
        public int status { get; set; }
        public bool ok { get; set; }
        public string statusText { get; set; }
    }
}
