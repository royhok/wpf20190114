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

namespace ContentTest2
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        //StringBuilder s;
        String s;

        public MainWindow()
        {
            InitializeComponent();

            Title = "사용자 입력을 Window의 Content 속성에 매핑하기";
            //s = new StringBuilder("");
            s = String.Empty;
            Content = s;
        }

        //키가 눌릴때 마다 Content 프로퍼티가 변경되고 Window 클래스는 여기에 반응해서
        //클라이언트 영역을 다시 그린다.
        protected override void OnTextInput(TextCompositionEventArgs e)
        {
            string str = Content.ToString();

            if (e.Text == "\b")
            {
                if (str.Length > 0)
                    //s.Remove(s.Length - 1, 1);
                    s = s.Remove(s.Length - 1, 1);
            }
            else
            {
                //s.Append(e.Text);
                s = s + e.Text;
            }

            // s를 string을 선언하면 null로 설정하지 않아도 된다.
            // string 클래스는 문자열을 추가하면 새로 메모리 allocation을 한다.
            // StringBuilder는 문자열이 추가되는 경우 기존의 문자열 뒤에 추가를 한다.
            Content = null;

            Content = s;
        }
    }
}
