using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace LoadXamlWindow
{
    class LoadXamlWindow
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            // Pack Uri 체계를 통한 리소스 파일을 식별하여 로딩
            // 로컬 어셈블리의 프로젝트 폴더 루트에 있는 리소스 파일에 대한 Pack URI
            Uri uri = new Uri("pack://application:,,,/XamlWindow.xml");
            Stream stream = Application.GetResourceStream(uri).Stream;
            Window win = XamlReader.Load(stream) as Window;

            win.AddHandler(Button.ClickEvent, new RoutedEventHandler(Button_Click1));
            Button b = (Button)win.FindName("XamlButton");  //XAML파일에 정의
            b.Click += Button_Click2;
            app.Run(win);
        }

        private static void Button_Click1(object sender, RoutedEventArgs args)
        {
            MessageBox.Show((args.Source as Button).Content.ToString() + "1");
        }

        private static void Button_Click2(object sender, EventArgs e)
        {
            MessageBox.Show(((Button)sender).Content.ToString() + "2");
        }
    }
}
