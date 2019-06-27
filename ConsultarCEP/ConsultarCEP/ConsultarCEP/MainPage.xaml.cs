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
           Address address = ViaCepService.BuscarEnderecoViaCEP(cep);
           Output.Text= string.Format("ENDEREÇO\nEstado: {0} \nCidade: {1}\nLogradouro: {2} \nBairro: {3}"
               , address.uf,address.localidade,address.logradouro, address.bairro);
           
        }
    }
}
