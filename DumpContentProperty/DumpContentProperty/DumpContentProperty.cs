using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows;
using System.Windows.Markup;

namespace DumpContentProperty
{
    class DumpContentProperty
    {
        [STAThread]
        public static void Main()
        {
            // PresentationCore, PresentationFramework 참조추가 되어 있어야 한다.
            UIElement dummy1 = new UIElement();
            FrameworkElement dummy2 = new FrameworkElement();
            // 클래스와 ContentProperty를 담을 SortedList 정의
            SortedList<string, string> listClass = new SortedList<string, string>();
            string strFormat = "{0,-35}{1}";
            // Loop through the loaded assemblies.
            foreach (AssemblyName asmblyname in

            Assembly.GetExecutingAssembly().GetReferencedAssemblies())
            {
                // Loop through the types.
                foreach (Type type in Assembly.Load(asmblyname).GetTypes())
                {
                    // Loop through the custom attributes.
                    // (Set argument to 'false' for non-inherited only!)
                    foreach (object obj in type.GetCustomAttributes(
                    typeof(ContentPropertyAttribute),
                   true))
                    {
                        // Add to list if ContentPropertyAttribute.
                        if (type.IsPublic && obj as ContentPropertyAttribute !=
                       null)
                            listClass.Add(type.Name,
                            (obj as
                           ContentPropertyAttribute).Name);
                    }
                }
            }

            // Display the results.
            Console.WriteLine(strFormat, "Class", "Content Property");
            Console.WriteLine(strFormat, "-----", "----------------");
            foreach (string strClass in listClass.Keys)
                Console.WriteLine(strFormat, strClass, listClass[strClass]);
            Console.ReadKey();
        }
    }
}
