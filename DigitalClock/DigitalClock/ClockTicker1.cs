using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace DigitalClock
{
    class ClockTicker1 : DependencyObject
    {
        public static DependencyProperty DateTimeProperty =
            DependencyProperty.Register("DateTime", typeof(string), typeof(ClockTicker1));

        public string DateTime
        {
            get { return (string)GetValue(DateTimeProperty); }
            set { SetValue(DateTimeProperty, value); }
        }

        public ClockTicker1()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += TimerOnTick;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            DateTime = System.DateTime.Now.ToString("yyyyMMdd HHmmss");
        }
    }
}
