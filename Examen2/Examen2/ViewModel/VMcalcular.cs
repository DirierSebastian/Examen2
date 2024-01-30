using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Examen2.ViewModel
{
    public class VMcalcular : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        bool _Condicion1;
        bool _Condicion2;
        bool _Vimc;
        bool _Vfcn;
        double _Peso;
        double _Altura;
        double _Latidos;
        #endregion
        #region CONSTRUCTOR
        public VMcalcular(INavigation navigation)
        {
            Navigation = navigation;
            
        }
        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        public bool Condicion1
        {
            get { return _Condicion1; }
            set { SetValue(ref _Condicion1, value); }
        }
        public bool Condicion2
        {
            get { return _Condicion2; }
            set { SetValue(ref _Condicion2, value); }
        }
        public bool Vimc
        {
            get { return _Vimc; }
            set { SetValue(ref _Vimc, value); }
        }
        public bool Vfcn
        {
            get { return _Vfcn; }
            set { SetValue(ref _Vfcn, value); }
        }
        public double Peso
        {
            get { return _Peso; }
            set { SetValue(ref _Peso, value); }
        }
        public double Altura
        {
            get { return _Altura; }
            set { SetValue(ref _Altura, value); }
        }
        public double Latidos
        {
            get { return _Latidos; }
            set { SetValue(ref _Latidos, value); }
        }
        #endregion
        #region PROCESOS
        public async Task ProcesoAsyncrono()
        {

        }

        public void Calcular()
        {
            if (_Condicion1 == true)
            {
                Vimc = true;
                Vfcn = false;
            }
            else if (_Condicion2 == true)
            {
                Vimc = false;
                Vfcn = true;
            }
            else
            {
                Vimc = false;
                Vfcn = false;
            }
        }

        public async Task IMC()
        {
            double peso = Peso;
            double altura = Altura;
            double total = peso / (altura * altura);
            if(total <= 18.5)
            {
                await DisplayAlert("IMC", "Peso insuficiente", "OK");
            }
            else if(total >18.5 &&  total <= 24.9)
            {
                await DisplayAlert("IMC", "Peso normal", "OK");
            }
            else if(total >24.9 && total <= 29.9)
            {
                await DisplayAlert("IMC", "Sobrepeso", "OK");
            }
            else
            {
                await DisplayAlert("IMC", "Obesidad", "OK");
            }
        }



        public void procesoSimple()
        {

        }
        #endregion
        #region COMANDOS
        public ICommand ProcesoAsyncomand => new Command(async () => await ProcesoAsyncrono());
        public ICommand IMCcommand => new Command(async () => await IMC());
        public ICommand ProcesoSimpcomand => new Command(procesoSimple);
        #endregion
    }
}
