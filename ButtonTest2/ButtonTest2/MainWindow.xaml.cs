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

namespace ButtonTest2
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Title = "Image the Button";

            Uri uri = new Uri("pack://application:,,,/캡처.jpg");

            BitmapImage bitmap = new BitmapImage(uri);

            Image img = new Image();
            img.Source = bitmap;

            // 할당된 공간을 채우기 위해 이미지의 크기를 조정하는 방법을 제공
            // None : 원래 크기를 그대로 유지
            // Uniform : 원래의 가로 세로 비율을 유지하면서 대상 크기에 맞게
            // 콘텐츠 크기가 조정됩니다.
            // UniformToFill : 원래의 가로 세로 비율을 유지하면서 대상 크기에 맞게
            // 콘텐츠 크기가 조정됩니다. 대상 사각형의 가로 세로 비율이
            // 원본과 다를 경우 원본 콘텐츠가 대상 크기에 맞게 잘린다.
            img.Stretch = Stretch.None;

            Button btn = new Button();
            btn.Content = img;
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;

            Content = btn;
        }
    }
}
