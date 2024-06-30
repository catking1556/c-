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
using System.Windows.Threading;

namespace WpfStopky
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            casovac.Interval = TimeSpan.FromSeconds(1);
            casovac.Tick += casovac_Tick;


        }
        private void casovac_Tick(object sender, EventArgs e)
        {
           
            
                rucka.RenderTransform = new RotateTransform(sek * 6 - 360);
            if (sek % 60 < 10)
                sekundy.Content = (sek / 60).ToString() + ":0" + (sek % 60).ToString();
            else sekundy.Content = (sek / 60).ToString() + ":" + (sek % 60).ToString();

                sek++;
            
            
           
        }

        DispatcherTimer casovac = new DispatcherTimer();
        int sek;

        

        private void start_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            sek = 0;
            casovac.Start();
        }

        private void stop_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            casovac.Stop();
        }
    }
}
