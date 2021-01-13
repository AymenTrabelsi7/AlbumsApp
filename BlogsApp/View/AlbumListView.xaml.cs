using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Albums
{
    /// <summary>
    /// Logique d'interaction pour PostListView.xaml
    /// </summary>
    public partial class AlbumListView : UserControl
    {
        public AlbumListView()
        {
            InitializeComponent();
        }

        private void Album_AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainViewModel m)
            {
                m.AddAlbum();
            }
        }

        private void Album_RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainViewModel m)
            {
                m.RemoveAlbum();
            }
        }
    }
}
