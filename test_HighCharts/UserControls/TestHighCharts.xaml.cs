using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace test_HighCharts.UserControls
{
    /// <summary>
    /// TestHighCharts.xaml 的交互逻辑
    /// </summary>
    public partial class TestHighCharts : UserControl
    {
        public TestHighCharts()
        {
            InitializeComponent();
            
        }

        private void Init()
        {
            var web = new WebView
            {
                Address = @"file:///F:/Code Save/HTML5Learn/HTML5_HelloWorld/TestHtml/test_HighChart.html",
            };
            web.RegisterJsObject("chartdata", new HighChartDataInteract());
            chartView.Children.Insert(0, web);
        }
    }
}
