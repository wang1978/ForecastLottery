using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 筛选显示红篮球
/// </summary>
class ScreenBall
{

    /// <summary>
    /// 获取已经出现的红球字符串
    /// </summary>
    /// <param name="list">红球列表</param>
    /// <returns></returns>
    public String getAppearRedBall(List<int> list)
    {
        String str = "";
        str = "历史同期出现的红球有：\r\n";
        for (int i = 0; i < list.Count; i++)
        {
            if (i == (list.Count - 1))
            {
                str += list[i] + " \r\n出现的红球共" + list.Count + "次。\r\n";
            }
            else
            {
                str += list[i] + " ,";
            }
        }
        return str;
    }

    /// <summary>
    /// 获取未出现的红球字符串
    /// </summary>
    /// <param name="list">红球列表</param>
    /// <returns></returns>
    public String getNoAppearRedBall(List<int> list)
    {
        NumConfig numConfig = new NumConfig();
        String str = "";
        for (int j = 0; j < list.Count; j++)
        {
            if (numConfig.redFull.Contains(list[j]))
            {
                numConfig.redFull.Remove(list[j]);
            }
        }

        for (int i = 0; i < numConfig.redFull.Count; i++)
        {
            if (i == (numConfig.redFull.Count - 1))
            {
                str += numConfig.redFull[i] + " \r\n未出现的红球共" + numConfig.redFull.Count + "次。\r\n";
            }
            else
            {
                str += numConfig.redFull[i] + " ,";
            }
        }
        return str;
    }

    /// <summary>
    /// 获取已经出现的蓝球字符串
    /// </summary>
    /// <param name="list">蓝球列表</param>
    /// <returns></returns>
    public String getAppearBlueBall(List<int> list)
    {
        String str = "";
        str = "历史同期出现的蓝球有：\r\n";
        for (int i = 0; i < list.Count; i++)
        {
            if (i == (list.Count - 1))
            {
                str += list[i] + " \r\n出现的蓝球共" + list.Count + "次。\r\n";
            }
            else
            {
                str += list[i] + " ,";
            }
        }
        return str;
    }

    /// <summary>
    /// 获取未出现的蓝球字符串
    /// </summary>
    /// <param name="list">蓝球列表</param>
    /// <returns></returns>
    public String getNoAppearBlueBall(List<int> list)
    {
        NumConfig numConfig = new NumConfig();
        String str = "";
        for (int j = 0; j < list.Count; j++)
        {
            if (numConfig.blueFull.Contains(list[j]))
            {
                numConfig.blueFull.Remove(list[j]);
            }
        }

        for (int i = 0; i < numConfig.blueFull.Count; i++)
        {
            if (i == (numConfig.blueFull.Count - 1))
            {
                str += numConfig.blueFull[i] + " \r\n未出现的蓝球共" + numConfig.blueFull.Count + "次。\r\n";
            }
            else
            {
                str += numConfig.blueFull[i] + " ,";
            }
        }
        return str;
    }

    /// <summary>
    /// 根据奖球列表获取所有红球频次
    /// </summary>
    /// <param name="list">奖球列表</param>
    /// <returns>红球频次</returns>
    public String getRedBallFrequency(List<int> list)
    {
        String str = "红球出现的频次： \r\n";
        int red1, red2, red3, red4, red5, red6, red7, red8, red9, red10, red11, red12, red13, red14, red15, red16, red17, red18, red19, red20, red21, red22, red23, red24, red25, red26, red27, red28, red29, red30, red31, red32;
        red1 = red2 = red3 = red4 = red5 = red6 = red7 = red8 = red9 = red10 = red11 = red12 = red13 = red14 = red15 = red16 = red17 = red18 = red19 = red20 = red21 = red22 = red23 = red24 = red25 = red26 = red27 = red28 = red29 = red30 = red31 = red32 = 0;
        for (int i = 0; i < list.Count; i++)
        {
            switch (list[i])
            {
                case 1:
                    red1 += 1;
                    break;
                case 2:
                    red2 += 1;
                    break;
                case 3:
                    red3 += 1;
                    break;
                case 4:
                    red4 += 1;
                    break;
                case 5:
                    red5 += 1;
                    break;
                case 6:
                    red6 += 1;
                    break;
                case 7:
                    red7 += 1;
                    break;
                case 8:
                    red8 += 1;
                    break;
                case 9:
                    red9 += 1;
                    break;
                case 10:
                    red10 += 1;
                    break;
                case 11:
                    red11 += 1;
                    break;
                case 12:
                    red12 += 1;
                    break;
                case 13:
                    red13 += 1;
                    break;
                case 14:
                    red14 += 1;
                    break;
                case 15:
                    red15 += 1;
                    break;
                case 16:
                    red16 += 1;
                    break;
                case 17:
                    red17 += 1;
                    break;
                case 18:
                    red18 += 1;
                    break;
                case 19:
                    red19 += 1;
                    break;
                case 20:
                    red20 += 1;
                    break;
                case 21:
                    red21 += 1;
                    break;
                case 22:
                    red22 += 1;
                    break;
                case 23:
                    red23 += 1;
                    break;
                case 24:
                    red24 += 1;
                    break;
                case 25:
                    red25 += 1;
                    break;
                case 26:
                    red26 += 1;
                    break;
                case 27:
                    red27 += 1;
                    break;
                case 28:
                    red28 += 1;
                    break;
                case 29:
                    red29 += 1;
                    break;
                case 30:
                    red30 += 1;
                    break;
                case 31:
                    red31 += 1;
                    break;
                case 32:
                    red32 += 1;
                    break;
                default:
                    break;
            }
        }
        str += "1号球出现了" + red1 + "次。 ||\r\n" + "2号球出现了" + red2 + "次。 ||\r\n" + "3号球出现了" + red3 + "次。 ||\r\n" + "4号球出现了" + red4 + "次。 ||\r\n" + "5号球出现了" + red5 + "次。 ||\r\n" + "6号球出现了" + red6 + "次。 ||\r\n" + "7号球出现了" + red7 + "次。 ||\r\n" + "8号球出现了" + red8 + "次。 ||\r\n" + "9号球出现了" + red9 + "次。 || \r\n" + "10号球出现了" + red10 + "次。 ||\r\n" + "11号球出现了" + red11 + "次。 ||\r\n" + "12号球出现了" + red12 + "次。 ||\r\n" + "13号球出现了" + red13 + "次。 ||\r\n" + "14号球出现了" + red14 + "次。 ||\r\n" + "15号球出现了" + red15 + "次。 ||\r\n" + "16号球出现了" + red16 + "次。 ||\r\n" + "17号球出现了" + red17 + "次。 ||\r\n" + "18号球出现了" + red18 + "次。 ||\r\n" + "19号球出现了" + red19 + "次。 ||\r\n" + "20号球出现了" + red20 + "次。 ||\r\n" + "21号球出现了" + red21 + "次。 ||\r\n" + "22号球出现了" + red22 + "次。 ||\r\n" + "23号球出现了" + red23 + "次。 ||\r\n" + "24号球出现了" + red24 + "次。 ||\r\n" + "25号球出现了" + red25 + "次。 ||\r\n" + "26号球出现了" + red26 + "次。 ||\r\n" + "27号球出现了" + red27 + "次。 ||\r\n" + "28号球出现了" + red28 + "次。 ||\r\n" + "29号球出现了" + red29 + "次。 ||\r\n" + "30号球出现了" + red30 + "次。 ||\r\n" + "31号球出现了" + red31 + "次。 ||\r\n" + "32号球出现了" + red32 + "次。\r\n";
        return str;
    }

    /// <summary>
    /// 根据奖球列表获取所有蓝球频次
    /// </summary>
    /// <param name="list">奖球列表</param>
    /// <returns>蓝球频次</returns>
    public String getBlueBallFrequency(List<int> list)
    {
        String str = "蓝球出现的频次： \r\n";
        int red1, red2, red3, red4, red5, red6, red7, red8, red9, red10, red11, red12, red13, red14, red15, red16;
        red1 = red2 = red3 = red4 = red5 = red6 = red7 = red8 = red9 = red10 = red11 = red12 = red13 = red14 = red15 = red16 = 0;
        for (int i = 0; i < list.Count; i++)
        {
            switch (list[i])
            {
                case 1:
                    red1 += 1;
                    break;
                case 2:
                    red2 += 1;
                    break;
                case 3:
                    red3 += 1;
                    break;
                case 4:
                    red4 += 1;
                    break;
                case 5:
                    red5 += 1;
                    break;
                case 6:
                    red6 += 1;
                    break;
                case 7:
                    red7 += 1;
                    break;
                case 8:
                    red8 += 1;
                    break;
                case 9:
                    red9 += 1;
                    break;
                case 10:
                    red10 += 1;
                    break;
                case 11:
                    red11 += 1;
                    break;
                case 12:
                    red12 += 1;
                    break;
                case 13:
                    red13 += 1;
                    break;
                case 14:
                    red14 += 1;
                    break;
                case 15:
                    red15 += 1;
                    break;
                case 16:
                    red16 += 1;
                    break;
                default:
                    break;
            }
        }
        str += "1号球出现了" + red1 + "次。 ||\r\n" + "2号球出现了" + red2 + "次。 ||\r\n" + "3号球出现了" + red3 + "次。 ||\r\n" + "4号球出现了" + red4 + "次。 ||\r\n" + "5号球出现了" + red5 + "次。 ||\r\n" + "6号球出现了" + red6 + "次。 ||\r\n" + "7号球出现了" + red7 + "次。 ||\r\n" + "8号球出现了" + red8 + "次。 ||\r\n" + "9号球出现了" + red9 + "次。 ||\r\n" + "10号球出现了" + red10 + "次。 ||\r\n" + "11号球出现了" + red11 + "次。 ||\r\n" + "12号球出现了" + red12 + "次。 ||\r\n" + "13号球出现了" + red13 + "次。 ||\r\n" + "14号球出现了" + red14 + "次。 ||\r\n" + "15号球出现了" + red15 + "次。 ||\r\n" + "16号球出现了" + red16 + "次。\r\n";
        return str;
    }

}
