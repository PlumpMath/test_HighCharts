using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace test_HighCharts
{

    /********************************************************************************
    ** Author： Xiaokai Zh
    ** Created：2016-02-16
    ** Desc：Common Class
    *********************************************************************************/

    public static class Common
    {
        public static string CreateXmlString(List<string> xAxisList, List<ChartDataTemplate> data)
        {
            
            XmlDocument doc = new XmlDocument();
            //主内容
            XmlElement root = doc.CreateElement("chart");
            doc.AppendChild(root);

            //生成横坐标信息集合
            if (xAxisList!=null&&xAxisList.Count!=0)
            {
                
                XmlElement child0 = doc.CreateElement("categories");
                root.AppendChild(child0);

                for (int i = 0; i < xAxisList.Count; i++)
                {
                    XmlElement child00 = doc.CreateElement("item");
                    child00.InnerText = xAxisList[i];
                    child0.AppendChild(child00);
                }          
            }


            //生成数据部分
            for (int i = 0; i < data.Count; i++)
            {
                XmlElement childData = doc.CreateElement("series");
                root.AppendChild(childData);

                XmlElement child1 = doc.CreateElement("name");
                child1.InnerText = data[i].name;
                childData.AppendChild(child1);

                XmlElement child2 = doc.CreateElement("data");
                childData.AppendChild(child2);

                for (int j = 0; j < data[i].point.Count(); j++)
                {
                    XmlElement child3 = doc.CreateElement("point");
                    child3.InnerText = data[i].point[j].ToString();
                    child2.AppendChild(child3);
                }
            }

            return doc.InnerXml.ToString();
        }
    }
}
