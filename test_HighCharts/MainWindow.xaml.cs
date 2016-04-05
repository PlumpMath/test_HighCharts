using CefSharp;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml;
using System.Xml.Serialization;
using test_HighCharts.UserControls;

namespace test_HighCharts
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        TestWebBrowser viewer;
        public MainWindow()
        {
            InitializeComponent();
            this.cmbStyleSelect.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string url = tbAddress.Text;
            if (!string.IsNullOrWhiteSpace(url))
            {
                MainGrid.Children.Clear();
                viewer = new TestWebBrowser(url);
                MainGrid.Children.Insert(0, viewer);
            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            string chartStyleLoad = "FromCSharpChartStyle('" + "<chart><type>bar</type>" + "<title>" + this.tbTitle.Text+ "</title>" + "<type>column</type>" + "<xAxistitle>x-米</xAxistitle>" + "<yAxistitle>"+this.tbYaxis.Text+"</yAxistitle></chart>" + "')";

            //TestWebBrowser viewer = new TestWebBrowser(@"file:///F:/Code Save/HTML5Learn/HTML5_HelloWorld/TestHtml/test_HighChart.html");
            viewer.TestChartChange(chartStyleLoad);
        }

        private void cmbStyleSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cmbStyleSelect.SelectedIndex)
            {
                case 0:
                    tbAddress.Text = "www.baidu.com";
                    break;
                case 1:
                    tbAddress.Text = "file:///F:/Code Save/HTML5Learn/HTML5_HelloWorld/HighChartsHtml/BasicColumn.html";
                    break;
                case 2:
                    tbAddress.Text = "file:///F:/Code Save/HTML5Learn/HTML5_HelloWorld/HighChartsHtml/BasicLine.html";
                    break;
                case 3:
                    tbAddress.Text = "file:///F:/Code Save/HTML5Learn/HTML5_HelloWorld/HighChartsHtml/Basic3DColumn.html";
                    break;
                case 4:
                    tbAddress.Text = "file:///F:/Code Save/HTML5Learn/HTML5_HelloWorld/HighChartsHtml/BasicPie.html";
                    break;
                default:
                    break;
            }
        }
    }


}
