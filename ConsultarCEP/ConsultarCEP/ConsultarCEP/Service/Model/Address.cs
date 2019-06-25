namespace ConsultarCEP.Service.Model
{
    public class Address
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string unidade { get; set; }
        public string ibge { get; set; }
        public string gia { get; set; }

        public Address(string cEP, string lagradouro, string complemento, string bairro, string cidade, string uF, string unidade, string iBGE, string gIA)
        {
            cep = cEP;
            logradouro = lagradouro;
            this.complemento = complemento;
            this.bairro = bairro;
            localidade = cidade;
            uf = uF;
            this.unidade = unidade;
            ibge = iBGE;
            gia = gIA;
        }
    }
}