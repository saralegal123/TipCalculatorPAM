namespace TipCalculator
{
    public partial class MainPage : ContentPage
    {
        bool arredondarPraCima
        bool arredondarPraBaixo

        public MainPage()
        {
            InitializeComponent();
            //Nesse contexto, o +=
            billInput.TextChanged += (s, e) => CalculateTip(false, false);
            roundDown.Clicked += (s, e) => CalculateTip(false, true);
            roundUp.Clicked += (s, e) => CalculateTip(true, false);

            tipPercentSlider.ValueChanged += (s, e) =>
            {
                double pct = Math.Round(e.NewValue);
                tipPercent.Text = pct + "%";
                CalculatorTip(false, false);
            }
        }

        private void OnNormalTip(object sender, EventArgs e)
        {
            double gorjeta = Convert.ToDouble(billInput.Text);
            double percentualDaGorjeta = TipoPercentSlider.Value;
            double gorjeta = valor * (percentualDaGorjeta / 100);
        }


        private void CalculateTip()
        {
            double valor = Convert.ToDouble(billInput.Text);
            double percentualDaGorjeta = tipPercentSlider.Value;
            double gorjeta = valor * (percentualDaGorjeta / 100);

            if (arredondarPraBaixo)
            {
                Math.Celling(gorjeta);
            }
            if (arredondarPraCima)
            {
                Math.Floor(gorjeta)
            }
            double total = valor + gorjeta;
            tipOutPut.Text = total.ToString(gorjeta);

            totalOutPut = Convert.ToString(total);
        }
        private void OnGenerousTip(object sender, EventArgs e)
        {
            tipPercentSlider.Value = 15;
        }


        void CalculateTip(bool roundUp, bool roundDown)
        {
            double t;
            if (Double.TryParse(billInput.Text, out t) && t > 0)
            {
                double pct = Math.Round(tipPercentSlider.Value);
                double tip = Math.Round(t * (pct / 100.0), 2);

                double final = t + tip;
                if (roundUp)
                {
                    final = Math.Ceiling(final);
                    tip = final - t;
                }
                else if (roundDown)
                {
                    final = Math.floor(final);
                    tip = final - t;
                }

                tipOutput.Text = tip.ToString("C");
                totalOutput.Text = final.ToString("C");
            }
        }