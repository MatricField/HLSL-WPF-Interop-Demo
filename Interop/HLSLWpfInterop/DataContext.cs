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
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Effect> _Effects;

        public ObservableCollection<Effect> Effects
        {
            get => _Effects;
            set
            {
                _Effects = value;
                OnPropertyChanged();
            }
        }

        public DataContext()
        {
            Effects = new ObservableCollection<Effect>();
            Effects.Add(null);
            Effects.Add(new ColorComplementEffect());
            Effects.Add(new EdgeDetection());
            //Effects.Add(
            //    new GreyScaleConvolution()
            //    {
            //        ConvolutionParam = new ConvolutionParam()
            //    }
            //    );
            Effects.Add(new GaussianBlur());
        }

        protected virtual void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
