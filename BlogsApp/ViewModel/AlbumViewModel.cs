using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Albums
{
    public class AlbumViewModel : Observable
    {
        private readonly Album _albumModel;

        public AlbumViewModel()
        {
            _albumModel = new Album();
            if(_albumModel.Pistes == null)
            {
                _albumModel.Pistes = new ObservableCollection<PisteViewModel>()
                {
                    new PisteViewModel(1),
                    new PisteViewModel(2),
                    new PisteViewModel(3),
                };
            }
            _selectedPiste = _albumModel.Pistes[0];
        }

        public AlbumViewModel(Album model)
        {
            _albumModel = model;
        }

        public void AddPiste()
        {
            PisteViewModel newPiste = new PisteViewModel(_albumModel.Pistes.Count + 1);
            if (_albumModel.PisteText != null) newPiste.Titre = _albumModel.PisteText;
            _albumModel.Pistes.Add(newPiste);
            _selectedPiste = _albumModel.Pistes[newPiste.Num-1];
        }

        internal void ModifyPiste()
        {
            if (_selectedPiste != null && _albumModel.PisteText != null)
            {
                _selectedPiste.Titre = _albumModel.PisteText;
            }
        }

        private PisteViewModel _selectedPiste;
        public PisteViewModel SelectedPiste
        {
            get => _selectedPiste;
            set => SetProperty(ref _selectedPiste, value);
        }

        public void RemovePiste()
        {
            if (_selectedPiste != null)
            {
                int num = _selectedPiste.Num;
                _albumModel.Pistes.Remove(_selectedPiste);
                _selectedPiste = null;
                foreach (PisteViewModel p in _albumModel.Pistes)
                {
                    if (p.Num > num) p.Num--;
                }
            }
        }

        public override string ToString()
        {
            return TitreArtiste;
        }

        public string Artiste
        {
            get => _albumModel.Artiste;
            set { _albumModel.Artiste = value; OnPropertyChanged(nameof(Artiste)); OnPropertyChanged(nameof(TitreArtiste)); }
        }

        public string Titre
        {
            get => _albumModel.Titre;
            set { _albumModel.Titre = value; OnPropertyChanged(nameof(Titre)); OnPropertyChanged(nameof(TitreArtiste)); }
        }

        public string TitreArtiste => $"{_albumModel.Titre} - {_albumModel.Artiste}";

        public ObservableCollection<PisteViewModel> Pistes
        {
            get => _albumModel.Pistes;
            set { _albumModel.Pistes = value; OnPropertyChanged(nameof(Pistes)); }
        }

        public string PisteText
        {
            get => _albumModel.PisteText;
            set { _albumModel.PisteText = value;OnPropertyChanged(nameof(PisteText)); }
        }
    }

  
    public class Album
    {
        public int Id { get; set; }

        public string Artiste { get; set; }

        public string Titre { get; set; }

        public ObservableCollection<PisteViewModel> Pistes { get; set; }

        public string PisteText { get; set; }
    }
}
