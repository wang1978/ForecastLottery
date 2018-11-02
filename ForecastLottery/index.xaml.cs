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
using LitJson;
using System.Threading;
using System.Collections;

namespace lottery
{
    /// <summary>
    /// index.xaml 的交互逻辑
    /// </summary>
    public partial class index : Page
    {
        TicketDB dc = new TicketDB();
        ScreenBall sb = new ScreenBall();

        public index()
        {
            InitializeComponent();
        }

        private void wjwNext_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String html = api.HttpGet(this.url.Text, Encoding.UTF8);
                if (!html.Substring(0, 5).Equals("{\"row", StringComparison.OrdinalIgnoreCase))
                    throw new Exception(html);

                JsonData json = JsonMapper.ToObject(html);
                this.content.Text = "采集方式：UTF8编码标准下的Json格式\r\n";
                this.content.Text += "采集时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff") + "\r\n";
                this.content.Text += "采集行数：" + json["rows"].ToString() + "行\r\n";
                int i = 0;
                foreach (JsonData row in json["data"])
                {
                    this.content.Text += "\r\n";
                    this.content.Text += "开奖期号：" + row["expect"].ToString() + "\r\n";
                    this.content.Text += "开奖号码：\r\n";
                    this.content.Text += "红球号码：" + row["opencode"].ToString().Substring(0, row["opencode"].ToString().IndexOf("+")) + "  ||  篮球号码：" + row["opencode"].ToString().Substring(row["opencode"].ToString().IndexOf("+")+1, 2) + "\r\n";
                    this.content.Text += "开奖时间：" + row["opentime"].ToString() + "\r\n";
                    String sql = createSql(row);
                    if (dc.findNumByTerm(row["expect"].ToString()) && sql != "")
                    {
                        dc.addOneData(sql);
                        i++;
                    }
                }
                this.content.Text += "彩票数据成功采集：" + i + "条！";
                MessageBox.Show("彩票数据成功采集："+i+"条！");
            }
            catch (Exception ex) { this.content.Text = "采集出现错误：" + ex.Message; }
        }

        private String createSql(JsonData row)
        {
            String sqlSp = "";
            String[] redNums = row["opencode"].ToString().Substring(0, row["opencode"].ToString().IndexOf("+")).Split(new char[] { ',' });
            String blueNum = row["opencode"].ToString().Substring(row["opencode"].ToString().IndexOf("+") + 1, 2);
            if (redNums != null && redNums.Length > 0 && blueNum != "")
            {
                sqlSp = "insert into ticket(";
                sqlSp = sqlSp + "red_num1,";
                sqlSp = sqlSp + "red_num2,";
                sqlSp = sqlSp + "red_num3,";
                sqlSp = sqlSp + "red_num4,";
                sqlSp = sqlSp + "red_num5,";
                sqlSp = sqlSp + "red_num6,";
                sqlSp = sqlSp + "blue_num,";
                sqlSp = sqlSp + "term,";
                sqlSp = sqlSp + "opentime,";
                sqlSp = sqlSp + "opentimestamp";
                sqlSp = sqlSp + ")  values (";
                sqlSp = sqlSp + redNums[0] + ",";
                sqlSp = sqlSp + redNums[1] + ",";
                sqlSp = sqlSp + redNums[2] + ",";
                sqlSp = sqlSp + redNums[3] + ",";
                sqlSp = sqlSp + redNums[4] + ",";
                sqlSp = sqlSp + redNums[5] + ",";
                sqlSp = sqlSp + blueNum + ",";
                sqlSp = sqlSp + "'" + row["expect"].ToString() + "',";
                sqlSp = sqlSp + "'" + row["opentime"].ToString() + "',";
                sqlSp = sqlSp + row["opentimestamp"].ToString() + ")";
                return sqlSp;
            }
            return sqlSp;
        }

        private String createSqlByList(List<String> list)
        {
            String sqlSp = "";
            if (list != null && list.Count > 0)
            {
                sqlSp = "insert into ticket(";
                sqlSp = sqlSp + "red_num1,";
                sqlSp = sqlSp + "red_num2,";
                sqlSp = sqlSp + "red_num3,";
                sqlSp = sqlSp + "red_num4,";
                sqlSp = sqlSp + "red_num5,";
                sqlSp = sqlSp + "red_num6,";
                sqlSp = sqlSp + "blue_num,";
                sqlSp = sqlSp + "term,";
                sqlSp = sqlSp + "opentime";
                sqlSp = sqlSp + ")  values (";
                sqlSp = sqlSp + list[0] + ",";
                sqlSp = sqlSp + list[1] + ",";
                sqlSp = sqlSp + list[2] + ",";
                sqlSp = sqlSp + list[3] + ",";
                sqlSp = sqlSp + list[4] + ",";
                sqlSp = sqlSp + list[5] + ",";
                sqlSp = sqlSp + list[6] + ",";
                sqlSp = sqlSp + "'" + list[7] + "',";
                sqlSp = sqlSp + "'" + list[8] + "')";
                return sqlSp;
            }
            return sqlSp;
        }

        private void FormDemo_Load(object sender, EventArgs e)
        {

        }

        private void wjwNetGet_Click(object sender, RoutedEventArgs e)
        {
            
            NetGetRules ngr = new NetGetRules();
            for (int i = 9154; i > 0; i--)
            {
                try
                {
                    //每隔1分钟访问网站抓取数据一次
                    String url = "";
                        if (i < 10000)
                        {
                            url = "http://kaijiang.500.com/shtml/ssq/0" + i + ".shtml?0_ala_baidu";
                        }
                        else 
                        {
                            url = "http://kaijiang.500.com/shtml/ssq/" + i + ".shtml?0_ala_baidu";
                        }
                        List<string> list = ngr.getDataByString(url);
                        String sql = createSqlByList(list);
                        if (dc.findNumByTerm(list[7]) && sql != "")
                        {
                            dc.addOneData(sql);
                            this.content.Text = "开奖期号：" + list[7].ToString() + ",采集成功！\r\n";
                        }
                        Thread.Sleep(1000);
                    }
                catch (Exception)
                {
                    continue;
                    //this.content.Text = "互联网数据采集出现错误：" + ex.Message; 
                }
            }
            MessageBox.Show("互联网数据采集成功！");
        }

        private void wjwOperation_Click(object sender, RoutedEventArgs e)
        {
            TicketDB ticket = new TicketDB();
            List<int> list = ticket.findListOfOneNum("2018");
            if (list != null && list.Count > 0)
            {
                var result = new DiscreteMarkov(list,33,5);
                this.content.Text = "预测状态概率：:" + result.PredictValue[0] + "\r\n" + "概率转移矩阵:" + result.ProbMatrix + "\r\n";
            }
        }

        private void wjwSameForecast_Click(object sender, RoutedEventArgs e)
        {
            NumConfig numConfig = new NumConfig();
            String termStr = term.Text;
            if (termStr == null || termStr == "")
            {
                return;
            }
            TicketDB ticket = new TicketDB();
            List<int> list = ticket.findSameForecastListOfTerm(termStr);
            if (list != null)
            {
                this.content.Text = sb.getAppearRedBall(list) + sb.getNoAppearRedBall(list);
            }
            else
            {
                this.content.Text = "没有相关数据！\r\n";
            }
        }

        private void wjwCountNum_Click(object sender, RoutedEventArgs e)
        {
            TicketDB ticket = new TicketDB();
            int num = int.Parse(count.Text);
            Hashtable table = new Hashtable();
            if (num > 0)
            {
                table = ticket.findBallListOfNum(num);
            }

            if (table != null)
            {
                List<int> redList = (List<int>)table["redList"];
                List<int> blueList = (List<int>)table["blueList"];
                List<int> redFullList = (List<int>)table["redFullList"];
                List<int> blueFullList = (List<int>)table["blueFullList"];
                if (redList != null && blueList != null && redList.Count > 0 && blueList.Count > 0)
                {
                    this.content.Text = sb.getAppearRedBall(redList) + sb.getNoAppearRedBall(redList) + sb.getAppearBlueBall(blueList) + sb.getNoAppearBlueBall(blueList) + sb.getRedBallFrequency(redFullList) + sb.getBlueBallFrequency(blueFullList);
                }
                else
                {
                    this.content.Text = "没有相关数据！\r\n";
                }
            }
        }
    }

}
