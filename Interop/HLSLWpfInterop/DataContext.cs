using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media.Effects;
using System.Text;
using System.Threading.Tasks;
using HLSLWpfInterop.Effects;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HLSLWpfInterop
{
    public class DataContext :
        INotifyPropertyChanged
    {
        private static readonly ImageSource DefaultImage =
            new BitmapImage(new Uri("pack://application:,,,/Resources/Example.jpeg"));

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Effect> _Effects =
            new ObservableCollection<Effect>()
            {
                null,
                new ColorComplementEffect(),
                new EdgeDetection(),
                new GaussianBlur()
            };

        public ObservableCollection<Effect> Effects
        {
            get => _Effects;
            set
            {
                _Effects = value;
                OnPropertyChanged();
            }
        }

        public ImageSource _DisplayImage = DefaultImage;

        public ImageSource DisplayImage
        {
            get => _DisplayImage;
            set
            {
                _DisplayImage = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
