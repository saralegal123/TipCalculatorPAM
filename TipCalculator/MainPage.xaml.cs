using Microsoft.Maui.Graphics.Text;
using System.Reflection.Metadata.Ecma335;

namespace TipCalculator
{
    public partial class MainPage : ContentPage
    {
        bool arrendondaPraCima;
        bool arrendondaPraBaixo;

        public MainPage()
        {
            InitializeComponent();
            tipPercentSlider.ValueChanged += (s, e) => CalculateTip();
        }



        private void OnNormalTip(object sender, EventArgs e)
        {
            tipPercentSlider.Value = 15;
        }


        private void CalculateTip()
        {
            double valor = Convert.ToDouble(billInput.Text);
            double percentualDaGorjeta = tipPercentSlider.Value;
            double gorjeta = valor * (percentualDaGorjeta / 100);
            if (arrendondaPraCima)
            {
                gorjeta = Math.Ceiling(gorjeta);
            }
            if (arrendondaPraBaixo)
            {
                gorjeta = Math.Floor(gorjeta);
            }
            double total = valor + gorjeta;
            //Currency
            tipOutput.Text = gorjeta.ToString("C");
            totalOutput.Text = total.ToString("C");
            tipPercent.Text = tipPercentSlider.Value.ToString();
        }


        private void OnGenerousTip(object sender, EventArgs e)
        {
            tipPercentSlider.Value = 20;
        }

        private void roundUp_Clicked(object sender, EventArgs e)
        {
            arrendondaPraCima = true;
            arrendondaPraBaixo = false;
        }

        private void roundDown_Clicked(object sender, EventArgs e)
        {
            arrendondaPraCima = false;
            arrendondaPraBaixo = true;
        }
    }

}
