using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace test_HighCharts.UserControls
{
    public class CallbackObjectForJs
    {
        //http://localhost:63342/HTML5Learn/HTML5_HelloWorld/TestHtml/test_CefSharp.html
        public void showMessage(string msg)
        {
            MessageBox.Show(msg);
        }
        public static string inputJsonString = "["+
                
                  "{name:'100',data:[1, 2, 3]},"+
                    "{name:'101',data:[1, 4, 3]},"+
                    "{name:'102',data:[1, 8, 3]}"+
                "]";
        
    }
}
