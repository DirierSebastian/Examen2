using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
        int _Latidos;
        bool _Img1;
        bool _Img2;
        bool _R;
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
        public bool R
        {
            get { return _R; }
            set { SetValue(ref _R, value); }
        }
        public bool Img1
        {
            get { return _Img1; }
            set { SetValue(ref _Img1, value); }
        }
        public bool Img2
        {
            get { return _Img2; }
            set { SetValue(ref _Img2, value); }
        }
        public bool Condicion1
        {
            get { return _Condicion1; }
            set { SetValue(ref _Condicion1, value);
                if (_Condicion1 == true)
                {
                    Vimc = true;
                    Vfcn = false;
                }
                else
                {
                    Calcular();
                }
            }
        }
        public bool Condicion2
        {
            get { return _Condicion2; }
            set { SetValue(ref _Condicion2, value);
                if (_Condicion1 == false)
                {
                    Vimc = false;
                    Vfcn = true;
                }
                else
                {
                    Calcular();
                }

            }
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
        public int Latidos
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
                Img1 = false;
                Img2 = false;
                R = false;

            }
            else if (_Condicion2 == true)
            {
                Vimc = false;
                Vfcn = true;
                Img1 = false;
                Img2 = false;
                R = false;
            }
            else
            {
                Vimc = false;
                Vfcn = false;
                Img1 = false;
                Img2 = false;
                R = false;

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
                R = true;
                Img1 = true;
                Img2 = false;
            }
            else if(total >18.5 &&  total <= 24.9)
            {
                await DisplayAlert("IMC", "Peso normal", "OK");
                R = true;
                Img1 = false;
                Img2 = true;
            }
            else if(total >24.9 && total <= 29.9)
            {
                await DisplayAlert("IMC", "Sobrepeso", "OK");
                R = true;
                Img1 = true;
                Img2 = false;
            }
            else
            {
                await DisplayAlert("IMC", "Obesidad", "OK");
                R = true;
                Img1 = true;
                Img2 = false;
            }
        }

        public async Task FCN()
        {
            int latidos = Latidos;
            int resultado = latidos * 4;
            if(resultado < 60)
            {
                await DisplayAlert("FCN", "FC baja", "OK");
                Img1 = true;
                Img2 = false;
                R = true;
            }
            else if (resultado >= 60 && resultado < 100)
            {
                await DisplayAlert("FCN", "FC normal", "OK");
                Img1 = false;
                Img2 = true;
                R = true;
            }
            if (resultado >= 100)
            {
                await DisplayAlert("FCN", "FC alto", "OK");
                Img1 = true;
                Img2 = false;
                R = true;
            }
        }
        
        public void procesoSimple()
        {

        }
        #endregion
        #region COMANDOS

        public ICommand ProcesoAsyncomand => new Command(async () => await ProcesoAsyncrono());
        public ICommand IMCcommand => new Command(async () => await IMC());
        public ICommand FCNcommand => new Command(async () => await FCN());
        public ICommand ProcesoSimpcomand => new Command(procesoSimple);
        #endregion
    }
}
