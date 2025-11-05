//using Org.Apache.Http.Authentication;

namespace AutaMAUI
{
    public partial class MainPage : ContentPage
    {
        Auto auto1 = new Auto();
        string msg = "";
        class Auto
        {
            public double CENA_LAKIER { get; set; }
            public double CENA_FELGI { get; set; }
            public double CENA_CZUJNIKI { get; set; }
            public double CENA_CLIMATRONIC { get; set; }
            public double CENA_NAWIGACJA { get; set; }   
            public string Color { get; set; }
            public string Felgs { get; set; }
            public bool[] Extras { get; set; }
            public double BasePrice { get; set; }
            public Auto(string Color, string Felgs, bool[] Extras)
            {
                this.Extras = [false, false, false];
                this.Color = Color;  
                this.Felgs = Felgs;
                this.BasePrice = 75000;
                this.CENA_LAKIER = 0;
                this.CENA_FELGI = 0;
                this.CENA_CZUJNIKI = 6500;
                this.CENA_CLIMATRONIC = 8500;
                this.CENA_NAWIGACJA = 5000;

            }

            public Auto()
            {
                this.Extras = [false, false, false];
                this.Color = "Szary";
                this.Felgs = "Stalowe";
                this.BasePrice = 75000;
                this.BasePrice = 75000;
                this.CENA_LAKIER = 0;
                this.CENA_FELGI = 0;
                this.CENA_CZUJNIKI = 6500;
                this.CENA_CLIMATRONIC = 8500;
                this.CENA_NAWIGACJA = 5000;

            }
        }
        void handleChange(object sender, EventArgs e)
        {
            imgCar.Source = pckColor.Items[pckColor.SelectedIndex].ToLower() + ".png";
            if (pckColor.SelectedIndex == 3) { imgCar.Source = "zolty.png"; }
            auto1.Color = pckColor.Items[pckColor.SelectedIndex];
            if (sender is RadioButton) { auto1.Felgs = ((RadioButton)sender).Content.ToString(); }
            auto1.Extras[0] = chkParking.IsChecked;
            auto1.Extras[1] = chkClima.IsChecked;
            auto1.Extras[2] = chkNav.IsChecked;
            msg = "";
            msg += "Cena bazowa: " + auto1.BasePrice + " PLN\n";
            if (auto1.Color == "Szary") { auto1.CENA_LAKIER = 0; }
            else { auto1.CENA_LAKIER = 9000; msg += "Lakier: " + auto1.Color + " " + auto1.CENA_LAKIER + " PLN\n";  }
            if (auto1.Felgs == "Aluminiowe") { auto1.CENA_FELGI = 7000; msg += "Felgi: " + auto1.Felgs + " " + auto1.CENA_FELGI + " PLN\n"; }
            else auto1.CENA_FELGI = 0;
            if (auto1.Extras[0]) { 
                auto1.CENA_CZUJNIKI = 6500; 
                msg += "Czujniki parkowania: " + auto1.CENA_CZUJNIKI + " PLN\n";
            } 
            else {
                auto1.CENA_CZUJNIKI = 0;
            }
            if (auto1.Extras[1]) {
                auto1.CENA_CLIMATRONIC = 8500;
                msg += "Climatronic: " + auto1.CENA_CLIMATRONIC + " PLN\n";
            } 
            else {
                auto1.CENA_CLIMATRONIC = 0;
            }
            if (auto1.Extras[2]) {
                auto1.CENA_NAWIGACJA = 5000; 
                msg += "Nawigacja: " + auto1.CENA_NAWIGACJA + " PLN\n";
            } 
            else {
                auto1.CENA_NAWIGACJA = 0;
            }
            double temp = auto1.BasePrice + auto1.CENA_LAKIER + auto1.CENA_FELGI + auto1.CENA_CZUJNIKI + auto1.CENA_CLIMATRONIC + auto1.CENA_NAWIGACJA;
            msg += "\nRazem: " + temp.ToString() + " PLN";
            lblDisplay.Text = msg;
        }
        public MainPage()
        {
            InitializeComponent();
            pckColor.SelectedIndex = 0;
        }

       
    }

}
