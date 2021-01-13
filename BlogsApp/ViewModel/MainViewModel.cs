using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Albums
{
    public class MainViewModel : Observable
    {
        public MainViewModel()
        {
            _albums = new ObservableCollection<AlbumViewModel>
            {
                new AlbumViewModel() { Artiste = "Nirvana", Titre = "Nevermind (Deluxe)", Pistes = new ObservableCollection<PisteViewModel>(){
                new PisteViewModel(1), new PisteViewModel(2), new PisteViewModel(3),}
                },
                new AlbumViewModel() { Artiste = "Pink Floyd", Titre = "Dark Side of the Moon", Pistes = new ObservableCollection<PisteViewModel>(){
                new PisteViewModel(1), new PisteViewModel(2), new PisteViewModel(3),}
                },
                new AlbumViewModel() { Artiste = "The Beatles", Titre = "Abbey Road", Pistes = new ObservableCollection<PisteViewModel>(){
                new PisteViewModel(1), new PisteViewModel(2), new PisteViewModel(3),}
                }
            };

            _selectedAlbum = _albums[0];
        }



        private readonly ObservableCollection<AlbumViewModel> _albums;



        public ObservableCollection<AlbumViewModel> Albums
        {
            get { return _albums; }
        }

        private AlbumViewModel _selectedAlbum;
        
        public AlbumViewModel SelectedAlbum
        {
            get => _selectedAlbum;
            set => SetProperty(ref _selectedAlbum, value);
        }



        public void AddAlbum()
        {
            AlbumViewModel a = new AlbumViewModel();
            a.Titre = "Nouvel Album";
            a.Artiste = "Artiste";
            a.Pistes = new ObservableCollection<PisteViewModel>()
            {
                new PisteViewModel(1),
                new PisteViewModel(2),
                new PisteViewModel(3),
            };

            _albums.Add(a);
            SelectedAlbum = a;
        }

        public void RemoveAlbum()
        {
            if (_selectedAlbum != null)
            {
                _albums.Remove(_selectedAlbum);
                if (_albums.Count > 0) SelectedAlbum = _albums[0];
                else SelectedAlbum = null;
            }
        }
    }
}
