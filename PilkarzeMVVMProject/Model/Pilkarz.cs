namespace Footballers.Model
{
    internal class Pilkarz
    {
        //deklaracja pol i gettery i settery
        #region
        private string imie;
        private string nazwisko;
        private double wiek;
        private double waga;

        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public double Wiek { get => wiek; set => wiek = value; }
        public double Waga { get => waga; set => waga = value; }
        #endregion
        //kostruktory i przeciązone metody
        #region
        public Pilkarz(string imie, string nazwisko, double wiek, double waga)
        {
            this.Imie = imie;
            this.Wiek = wiek;
            this.Nazwisko = nazwisko;
            this.Waga = waga;
        }

        public override string ToString()
        {
            return $"{Imie} {Nazwisko}, Wiek: {Wiek} lat, {Waga}kg";
        }
        public Pilkarz()
        { }
        public void Kopiuj(Pilkarz pilkarz)
        {
            Imie = pilkarz.Imie;
            Nazwisko = pilkarz.Nazwisko;
            Wiek = pilkarz.Wiek;
            Waga = pilkarz.Waga;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Pilkarz footballer = obj as Pilkarz;
            return (this.Wiek == footballer.Wiek && this.Imie == footballer.Imie && this.Nazwisko == footballer.Nazwisko
                && this.Waga == footballer.Waga);
        }
        #endregion
    }
}