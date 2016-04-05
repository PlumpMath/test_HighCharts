using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test_HighCharts
{

    /********************************************************************************
    ** Author： Xiaokai Zh
    ** Created：YYYY-MM-DD
    ** Desc：Founction Description
    *********************************************************************************/

    public class ChartDataTemplate
    {

        //单个数据集 名称
        public string name { get; set; }

        //单个数据集 所有数据
        public long[] point { get; set; }
    }
}
