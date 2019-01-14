using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SelectColorFromGrid
{
    class Test
    {
        static void Main() { }
    }

    public class ColorGridBox : ListBox
    {
        // 화면에 출력할 칼러 목록.
        string[] strColors =
        {
             "Black", "Brown", "DarkGreen", "MidnightBlue",
             "Navy", "DarkBlue", "Indigo", "DimGray",
             "DarkRed", "OrangeRed", "Olive", "Green",
             "Teal", "Blue", "SlateGray", "Gray",
             "Red", "Orange", "YellowGreen", "SeaGreen",
             "Aqua", "LightBlue", "Violet", "DarkGray",
             "Pink", "Gold", "Yellow", "Lime",
             "Turquoise", "SkyBlue", "Plum", "LightGray",
             "LightPink", "Tan", "LightYellow", "LightGreen",
             "LightCyan", "LightSkyBlue", "Lavender", "White"
        };

        public ColorGridBox()
        {
            //ItemsPanel Template을 정의
            FrameworkElementFactory factoryUnigrid = new FrameworkElementFactory(typeof(UniformGrid));
            factoryUnigrid.SetValue(UniformGrid.ColumnsProperty, 8);

            //ListBox의 ItemsPanel 속성에 UniformGrid로 설정
            ItemsPanel = new ItemsPanelTemplate(factoryUnigrid);

            //ListBox에 아이템을 넣는다.
            foreach (string strColor in strColors)
            {
                //직사각형(Rectanggle)을 생성하고 ListBox에 넣는다.
                Rectangle rect = new Rectangle();
                rect.Width = 12;
                rect.Height = 12;
                rect.Margin = new Thickness(4);

                rect.Fill = (Brush)typeof(Brushes).GetProperty(strColor).GetValue(null, null);
                Items.Add(rect);

                //직사각형(Rectangle)에 툴팁 추가
                ToolTip tip = new ToolTip();
                tip.Content = strColor;
                rect.ToolTip = tip;
            }

            SelectedValuePath = "Fill";
        }
    }
}
