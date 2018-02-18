using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using SharpDX.Direct3D12;

namespace HLSLWpfInterop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public ImageSource DisplayImage
        {
            get { return (ImageSource)GetValue(DisplayImageProperty); }
            set { SetValue(DisplayImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DisplayImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DisplayImageProperty =
            DependencyProperty.Register(
                "DisplayImage",
                typeof(ImageSource),
                typeof(MainWindow),
                new PropertyMetadata(new BitmapImage(new Uri(@"pack://application:,,,/Resources/Cleveland(CL-55)_NewYorkPort_2015_12_28.png"))));



        public MainWindow()
        {
            InitializeComponent();
        }

        private void Image_Drop(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                DisplayImage = new BitmapImage(new Uri(files[0]));
            }
        }
    }
}
