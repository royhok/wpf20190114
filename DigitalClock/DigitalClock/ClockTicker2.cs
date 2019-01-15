using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.ComponentModel;

namespace DigitalClock
{
    class ClockTicker2 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string DateTime
        {
            get { return System.DateTime.Now.ToString("yyyyMMddHHmmss"); }
        }

        public ClockTicker2()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += TimerOnTick;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("DateTime"));
            }
        }
    }
}
