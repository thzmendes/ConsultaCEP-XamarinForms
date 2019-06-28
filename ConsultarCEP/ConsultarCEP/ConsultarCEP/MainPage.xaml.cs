using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ConsultarCEP.Service.Model;
using ConsultarCEP.Service;


namespace ConsultarCEP
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Button.Clicked += SearchCEP;

        }
        public void SearchCEP(object sender, EventArgs args)
        {
            string cep = CEP.Text;
            cep.Trim();
            try
            {
                if (IsValidCEP(cep))
                {

                    Address address = ViaCepService.BuscarEnderecoViaCEP(cep);
                    if (address != null)
                    {
                        Output.Text = string.Format("ENDEREÇO\nEstado: {0} \nCidade: {1}\nLogradouro: {2} \nBairro: {3}"
                        , address.uf, address.localidade, address.logradouro, address.bairro);
                    }
                    DisplayAlert("Erro: ", "CEP Inexistente", "OK");
                }
            }
            catch (Exception e)
            {
                DisplayAlert("Erro Crítico!", e.Message, "OK");
            }
        }
        private bool IsValidCEP(string cep)
        {
            bool valid = true;
            if (cep.Length != 8)
            { //error 
                DisplayAlert("Erro", "CEP Inválido! O CEP deve conter 8 caracteres", "OK");
                valid = false;
            }
            int newCEP = 0;
            if (!int.TryParse(cep, out newCEP))
            {
                DisplayAlert("Erro", "CEP Inválido! O CEP deve conter apenas números", "OK");
                valid = false;
            }
            return valid;
        }
    }
}
