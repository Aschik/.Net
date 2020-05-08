namespace Footballers.ViewModel
{
    using System.ComponentModel;
    using System.IO;
    using System.Text.Json;
    using System.Windows.Input;

    using Footballers.Model;
    using Footballers.ViewModel.BaseClass;

    internal class PilkarzeVM : ViewModelBase
    {
        //deklaracja pól
        #region
        private double? wiek = 25;
        private string imie = null;
        private string nazwisko = null;
        private double? waga = 80;
        private Pilkarz wybrany = null;
        private BindingList<Pilkarz> listaPilkarzy = new BindingList<Pilkarz>();
        private ICommand dodaj, wyczysc, kopiuj, usun, edytuj, wczytajPilkarza, zapiszPilkarzy;
        private string sciezka = "DataFootballers.json";
        #endregion
        ////informujemy o aktualizacji własności-gettery i settery
        #region
        public double? Wiek
        {
            get => wiek; set
            {
                wiek = value;
                OnPropertyChanged(nameof(Wiek));
            }
        }
        public string Imie
        {
            get => imie; set
            {
                imie = value;
                OnPropertyChanged(nameof(Imie));
            }
        }
        public Pilkarz Wybrany
        {
            get => wybrany; set
            {
                wybrany = value;
                OnPropertyChanged(nameof(Wybrany));
                if (KopiujPilkarza.CanExecute(null)) KopiujPilkarza.Execute(null);
            }
        }
        public BindingList<Pilkarz> ListaPilkarzy
        {
            get => listaPilkarzy; set
            {
                listaPilkarzy = value;
                OnPropertyChanged(nameof(ListaPilkarzy));
            }
        }
        public string Nazwisko
        {
            get => nazwisko; set
            {
                nazwisko = value;
                OnPropertyChanged(nameof(Nazwisko));
            }
        }
        public double? Waga
        {
            get => waga; set
            {
                waga = value;
                OnPropertyChanged(nameof(Waga));
            }
        }
        #endregion
        //interfejsy ICommand
        #region
        public ICommand Dodaj
        {
            get
            {
                if (dodaj is null)
                {
                    dodaj = new RelayCommand(
                        execute =>
                        {
                            var footballer = new Pilkarz(Imie, Nazwisko, (double)Wiek, (double)Waga);
                            if (!ListaPilkarzy.Contains(footballer))
                            {
                                ListaPilkarzy.Add(footballer);
                                OnPropertyChanged(nameof(ListaPilkarzy));
                                Wyczysc.Execute(null);

                            }
                        }
                        , canExecute => CzyPoleToNUll
                    );
                }
                return dodaj;
            }
        }

        public ICommand UsunPilkarza
        {
            get
            {
                if (usun is null)
                {
                    usun = new RelayCommand(execute =>
                    {
                        var footballer = new Pilkarz(Imie, Nazwisko, (double)Wiek, (double)Waga);
                        if (ListaPilkarzy.Contains(footballer))
                        {
                            ListaPilkarzy.Remove(footballer);
                            OnPropertyChanged(nameof(ListaPilkarzy));
                        }
                    }, canExecute => CzyPoleToNUll && Wybrany != null);
                }
                return usun;
            }
        }
        public ICommand Wyczysc
        {
            get
            {
                if (wyczysc is null)
                {
                    wyczysc = new RelayCommand(
                        execute =>
                        {
                            Imie = Nazwisko = null;
                            Waga = Wiek = null;
                        }
                        , canExecute => true
                    );
                }
                return wyczysc;
            }
        }

        public ICommand KopiujPilkarza
        {
            get
            {
                if (kopiuj is null)
                {
                    kopiuj = new RelayCommand(
                        execute =>
                        {
                            Imie = Wybrany.Imie;
                            Nazwisko = Wybrany.Nazwisko;
                            Wiek = Wybrany.Wiek;
                            Waga = Wybrany.Waga;
                        }
                        , canExecute => Wybrany != null
                    );
                }
                return kopiuj;
            }
        }
        private bool CzyPoleToNUll { get { return (!string.IsNullOrEmpty(Imie) && !string.IsNullOrEmpty(Nazwisko) && Wiek > 0 && Waga > 0); } }


        public ICommand EdytujPilkarza
        {
            get
            {
                if (edytuj is null)
                {
                    edytuj = new RelayCommand(execute =>
                    {
                        var newFootballer = new Pilkarz(Imie, Nazwisko, (double)Wiek, (double)Waga);
                        if (ListaPilkarzy.Contains(Wybrany))
                        {
                            var index = ListaPilkarzy.IndexOf(wybrany);
                            ListaPilkarzy[index].Kopiuj(newFootballer);
                            ListaPilkarzy.ResetItem(index);
                            Wyczysc.Execute(null);

                        }
                    }, canExecute => CzyPoleToNUll && Wybrany != null);
                }
                return edytuj;
            }
        }
        public ICommand WczytajPilkarzy
        {
            get
            {
                if (wczytajPilkarza is null)
                {
                    wczytajPilkarza = new RelayCommand(execute =>
                    {
                        var jsonFootballers = File.ReadAllText(sciezka);
                        ListaPilkarzy = JsonSerializer.Deserialize<BindingList<Pilkarz>>(jsonFootballers);
                        OnPropertyChanged(nameof(WczytajPilkarzy));
                        ListaPilkarzy.ResetBindings();
                    }, canExecute => File.Exists(sciezka) && (new FileInfo(sciezka).Length > 0));
                }
                return wczytajPilkarza;
            }
        }
        public PilkarzeVM()
        {
        }
        public ICommand ZapiszPilkarzy
        {
            get
            {
                if (zapiszPilkarzy is null)
                {
                    zapiszPilkarzy = new RelayCommand(execute =>
                    {
                        var jsonFootballers = JsonSerializer.Serialize(ListaPilkarzy);
                        File.WriteAllText(sciezka, jsonFootballers);
                        OnPropertyChanged(nameof(ZapiszPilkarzy));
                    }, canExecute => true);
                }
                return zapiszPilkarzy;
            }
        }

        #endregion
    }
}