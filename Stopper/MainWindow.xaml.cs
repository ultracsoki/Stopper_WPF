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

namespace Stopper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int szamlalo = 0;
        private DispatcherTimer timer;
        private DateTime startTime;
        TimeSpan eltelt;
        TimeSpan elapsed;

        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += dt_Tick;
        }


        private void dt_Tick(object sender, EventArgs e)
        {
            elapsed = DateTime.Now - startTime + eltelt;
            labelIdo.Content = $"{elapsed.Hours:D2}:{elapsed.Minutes:D2}:{elapsed.Seconds:D2}.{elapsed.Milliseconds:D3}";
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            szamlalo++;
            if (szamlalo % 2 == 1)
            {
                buttonStart.Content = "Stop";
                buttonReszido.Content = "Részidő";
                timer.Start();
                startTime = DateTime.Now;
            }
            else
            {
                buttonStart.Content = "Start";
                buttonReszido.Content = "Reset";
                eltelt += DateTime.Now - startTime;
                timer.Stop();
            }
        }

        private void buttonReszido_Click(object sender, RoutedEventArgs e)
        {
            if (szamlalo % 2 == 1)
            {
                //Részidő
                listboxReszidok.Items.Add(elapsed);
            }
            else
            {
                //Reset
                eltelt = TimeSpan.Zero;
                labelIdo.Content = "00:00:00.000";
                listboxReszidok.Items.Clear();
            }
        }
    }
}
