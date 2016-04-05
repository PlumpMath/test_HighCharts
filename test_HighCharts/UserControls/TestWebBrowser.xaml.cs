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
using CefSharp;
using CefSharp.Wpf;
using System.Xml;

namespace test_HighCharts.UserControls
{
    /// <summary>
    /// TestWebBrowser.xaml 的交互逻辑
    /// </summary>
    public partial class TestWebBrowser : UserControl,IRequestHandler
    {
        private WebView view;
        public TestWebBrowser(string url)
        {
            InitializeComponent();
            InitCEF(url);
        }

        private void InitCEF(string url)
        {
            CEF.Initialize(new Settings { LogSeverity = LogSeverity.Disable, PackLoadingDisabled = true });
            BrowserSettings browserSettings = new BrowserSettings { ApplicationCacheDisabled = true, PageCacheDisabled = true };
            view = new WebView(string.Empty, browserSettings)
            {
                Address = url,
                RequestHandler = this,
                Background = Brushes.White
            };
            
            //register JS class
            //view.RegisterJsObject("callbackObj", new CallbackObjectForJs());
            
            view.LoadCompleted += view_LoadCompleted;
            MainGrid.Children.Insert(0, view);
        }

        private void view_LoadCompleted(object sender, LoadCompletedEventArgs url)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                maskLoading.Visibility = Visibility.Collapsed;
            }));
        }

        public void View(string url)
        {
            if (view.IsBrowserInitialized)
            {
                view.Visibility = Visibility.Hidden;
                maskLoading.Visibility = Visibility.Visible;
                view.Load(url);               
            }
        }

        public void TestChartChange(string chartStyleLoad)
        {
            //xml 格式定义


            List<string> xAxisList = new List<string>()
            {
                "Apples","Pears","Oranges"
            };

            List<ChartDataTemplate> data = new List<ChartDataTemplate>() { 
            new ChartDataTemplate(){name="China",point= new long[]{1,2,3}},
            new ChartDataTemplate(){name="America",point=new long[]{5,6,3}},
            //new ChartDataTemplate(){name="France",point=new long[]{4,8,3}},
            };


            //List<ChartDataTemplate> data = new List<ChartDataTemplate>() { 
            //new ChartDataTemplate(){name="China",point= new long[]{40}},
            //new ChartDataTemplate(){name="America",point=new long[]{50}},
            //new ChartDataTemplate(){name="France",point=new long[]{10}},
            //};

            string xmlString = Common.CreateXmlString(xAxisList, data);


            //Prepare xml Data
            //System.IO.FileStream fs = new System.IO.FileStream("F:/Code Save/HTML5Learn/HTML5_HelloWorld/TestHtml/data.xml", System.IO.FileMode.Open);
            //XmlDocument doc = new XmlDocument();
            //doc.Load(fs);



            //string inputjsonstring = "{[{name:'100',data:[1, 2, 3]}]}";
            //byte[] bs = Encoding.Default.GetBytes(doc.InnerXml.ToString());
            //string basestring = Convert.ToBase64String(bs);

            //TmkgSGFvIQ==
            ////testchart
            ////"$('#modify-me').text('See how easy that was?')"
            //string scripTest = "tmp='" + "We" + "'";
            //view.ExecuteScript(scripTest);

            //Right
            //string chartStyleLoad = "FromCSharpChartStyle('" + "<chart><type>bar</type>" + "<title>外部更改图标样式</title>" + "<type>column</type>" + "<xAxistitle>x-米</xAxistitle>" + "<yAxistitle>x-米</yAxistitle></chart>" + "')";
            view.ExecuteScript(chartStyleLoad);

            string chartDataLoad = "FromCSharpDataLoad('" + xmlString + "')";
            view.ExecuteScript(chartDataLoad);
        }

        #region IRequestHandler  接口实现
        /// <summary>
        /// 验证证书
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="isProxy"></param>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="realm"></param>
        /// <param name="scheme"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool GetAuthCredentials(IWebBrowser browser, bool isProxy, string host, int port, string realm, string scheme, ref string username, ref string password)
        {
            return false;
        }

        public bool GetDownloadHandler(IWebBrowser browser, string mimeType, string fileName, long contentLength, ref IDownloadHandler handler)
        {
            return true;
        }

        public bool OnBeforeBrowse(IWebBrowser browser, IRequest request, NavigationType naigationvType, bool isRedirect)
        {
            return false;
        }

        public bool OnBeforeResourceLoad(IWebBrowser browser, IRequestResponse requestResponse)
        {
            return false;
        }

        public void OnResourceResponse(IWebBrowser browser, string url, int status, string statusText, string mimeType, System.Net.WebHeaderCollection headers)
        {
           
        }
        #endregion
    }
}
