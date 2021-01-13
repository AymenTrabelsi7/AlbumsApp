using System;
using System.Collections.Generic;
using System.Text;

namespace Albums
{
    public class PisteViewModel : Observable
    {
        private readonly Piste _modelPiste;

        public PisteViewModel(int numero, string titre)
        {
            _modelPiste = new Piste();
            _modelPiste.titre = titre;
            _modelPiste.num = numero;
        }
        public PisteViewModel(int numero) 
        {
            _modelPiste = new Piste();
            _modelPiste.titre = "Nouvelle Piste";
            _modelPiste.num = numero;
        }

        public PisteViewModel(Piste _piste)
        {
            _modelPiste = _piste;
        }

        public int Num
        {
            get => _modelPiste.num;
            set { _modelPiste.num = value; OnPropertyChanged(nameof(Num)); OnPropertyChanged(nameof(TitrePiste)); }
        }

        public string Titre
        {
            get => _modelPiste.titre;
            set { _modelPiste.titre = value; OnPropertyChanged(nameof(Titre)); OnPropertyChanged(nameof(TitrePiste)); }
        }

        public string TitrePiste => $"{_modelPiste.num} - {_modelPiste.titre}";
    }
        public class Piste
        {
            public int num { get; set; }
            public string titre { get; set; }

        }
}
