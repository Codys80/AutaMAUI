//using Org.Apache.Http.Authentication;

namespace AutaMAUI
{
    public partial class MainPage : ContentPage
    {
        static int CENA_BAZOWA = 75000;
        int CENA_LAKIER = 9000;
        int CENA_FELGI = 7000;
        int CENA_CZUJNIKI = 6500;
        int CENA_CLIMATRONIC = 8500;
        int CENA_NAWIGACJA = 5000;
        class Auto
        {
            public string Color { get; set; }
            public string Felgs { get; set; }
            public bool[] Extras { get; set; }
            public double BasePrice { get; set; }
            public Auto(string Color, string Felgs, bool[] Extras)
            {
                Extras = new bool[2];
                for (int i = 0; i < 3; i++)
                {
                    this.Extras[i] = Extras[i];
                }
                this.Color = Color;
                this.Felgs = Felgs;
                this.BasePrice = 75000;
            }


            public Auto()
            {
                Extras = new bool[2];
                for (int i = 0; i < 3; i++)
                {
                    this.Extras[i] = false;
                }
                this.Color = "Szary";
                this.Felgs = "Stalowe";
                this.BasePrice = Convert.ToDouble(CENA_BAZOWA);

            }
        }
        void handleChange(object sender, EventArgs e)
        {
            Auto auto1 = new Auto();
            auto1.Color = pckColor.SelectedItem.ToString();
            if (sender is RadioButton) { auto1.Felgs = ((RadioButton)sender).Content.ToString(); }
            auto1.Extras[0] = chkParking.IsChecked;
            auto1.Extras[1] = chkClima.IsChecked;
            auto1.Extras[2] = chkNav.IsChecked;

            lblBase.Text = "Cena bazowa: " + auto1.Color;
            lblColor.Text = "Lakier: " + auto1.Color;
            lblFelgs.Text = "Felgi: " + auto1.Felgs;
            lblClima.Text = "Climatronic: ";
            lblOverall.Text = "Razem: ";
        }
        public MainPage()
        {
            //new Auto(pckColor.SelectedItem.ToString(), FelgiGroup.SelectedItem.ToString(), 100000, new bool[] { chkClima.IsChecked });
            InitializeComponent();
            Auto auto1 = new Auto();
            pckColor.SelectedIndex = 0;
        }

       
    }

}
