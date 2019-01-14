using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Windows.Markup;
using System.IO;
using System.Windows.Controls;

namespace LoadXaml
{
    class LoadXaml : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new LoadXaml());
        }

        public LoadXaml()
        {
            Title = "Load Embedded Xaml";

            string strXaml = "<Button xmlns='http://schemas.microsoft.com/" +
                             "winfx/2006/xaml/presentation'" +
                             " Foreground='LightSeaGreen' FontSize='24pt'>" +
                             " Hello, WPF!" +
                             "</Button>";

            StringReader strReader = new StringReader(strXaml);
            XmlTextReader xmlReader = new XmlTextReader(strReader);
            Button b = (Button)XamlReader.Load(xmlReader);
            b.Click += Button_Click;

            Content = b;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Emnbedded Xaml Test");
        }
    }
}
