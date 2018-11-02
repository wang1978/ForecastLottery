using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;

/// <summary>
/// 数据采集规则
/// </summary>
class NetGetRules
{
    private WebClient wc = new WebClient();

    /// <summary>
    /// 用正则表达式获取内容
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public List<String> getDataByMatch(String url)
    {
        List<String> list = new List<String>();
        String htmlData = Encoding.UTF8.GetString(wc.DownloadData(string.Format(url)));
        Regex reg = new Regex(@"<li class=ball_red>[\s\S]*?</li>");
        Match m = reg.Match(htmlData);
        while (m.Success)
        {
            Console.Write(m.Value + ":aa:" + m.Index);
            m.NextMatch();
        }

        return list;
    }

    public List<String> getDataByString(String url)
    {
        List<String> list = new List<String>();
        String htmlData = Encoding.UTF8.GetString(wc.DownloadData(string.Format(url)));
        //插入红球
        int redfirst = htmlData.IndexOf("<li class=\"ball_red\">") + "<li class=\"ball_red\">".Length;
        int redlast = htmlData.LastIndexOf("<li class=\"ball_blue\">");
        String redstr = htmlData.Substring(redfirst, redlast - redfirst);
        redstr = redstr.Replace("<li class=\"ball_red\">", ",");
        redstr = redstr.Replace("\"", "");
        redstr = redstr.Replace("</li>", "");
        redstr = redstr.Replace("\r\n\t\t\t\t\t\t\t\t\t", "");
        char[] charSeparators = new char[] { ',' };
        String[] strArray = redstr.Split(charSeparators, StringSplitOptions.None);
        List<String> strList = strArray.ToList<String>();
        list = list.Union(strList).ToList<String>();
        //插入篮球
        int bluefirst = htmlData.IndexOf("<li class=\"ball_blue\">") + "<li class=\"ball_red\">".Length + 1;
        String bluestr = htmlData.Substring(bluefirst, 2);
        list.Add(bluestr);
        //插入期数
        int term = htmlData.IndexOf("<font class=\"cfont2\"><strong>") + "<font class=\"cfont2\"><strong>".Length;
        String termstr = "20" + htmlData.Substring(term, 5);
        list.Add(termstr);
        //插入开奖日期
        int opentime = htmlData.IndexOf("<span class=\"span_right\">") + "<span class=\"span_right\">".Length;
        String opentimestr = htmlData.Substring(opentime, 21);
        opentimestr = opentimestr.Replace("�", "");
        opentimestr = opentimestr.Replace("ڣ", "");
        if (opentimestr.Length == 7)
        {
            opentimestr = opentimestr.Substring(0, 4) + "-0" + opentimestr.Substring(4, 1) + "-" + opentimestr.Substring(5, 2);
        }
        else if (opentimestr.Length == 6)
        {
            opentimestr = opentimestr.Substring(0, 4) + "-0" + opentimestr.Substring(4, 1) + "-0" + opentimestr.Substring(5, 1);
        }
        else
        {
            opentimestr = opentimestr.Substring(0, 4) + "-" + opentimestr.Substring(4, 2) + "-" + opentimestr.Substring(6, 2);
        }
        list.Add(opentimestr);
        return list;
    }
}

