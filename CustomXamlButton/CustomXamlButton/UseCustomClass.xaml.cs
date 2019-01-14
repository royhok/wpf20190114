using System;
using System.Windows;

namespace CustomXamlButton
{

public partial class UseCustomClass : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new UseCustomClass());
        }
        public UseCustomClass()
        {
            InitializeComponent();

            //버튼 2개를 추가로 생성
            for (int i = 0; i < 2; i++)
            {
                CenteredButton b = new CenteredButton();
                b.Content = "Button " + (i + 1);
                mystack.Children.Add(b);
            }
        }
    }
}