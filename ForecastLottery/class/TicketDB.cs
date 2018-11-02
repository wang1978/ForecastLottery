using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;

/// <summary>
/// 彩票数据库操作
/// </summary>
class TicketDB : DbConnect, IDBOperation<Ticket>
{

    SqlCeDataReader rdr = null;
    NumConfig numConfig = new NumConfig();

    /// <summary>
    /// 添加一条数据
    /// </summary>
    /// <param name="sql">执行sql</param>
    public void addOneData(String sql) 
    {
        if (sql==null || sql=="")
        {
            return;
        }
        con.Open();
        SqlCeTransaction tx = con.BeginTransaction();
        SqlCeCommand cmd = con.CreateCommand();
        try
        {
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            tx.Commit();
        }
        catch (Exception)
        {
            tx.Rollback();
        }
        finally
        {
            cmd.Dispose();
            con.Close();
        }
    }

    /// <summary>
    /// 根据期数获取数据条数
    /// </summary>
    /// <param name="term">期数</param>
    /// <returns></returns>
    public Boolean findNumByTerm(String term)
    {
        if (term!=null && term!="")
        {
            Ticket ticket = new Ticket();
            con.Open();
            SqlCeCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT count(*) FROM ticket WHERE [term] = @Term";
            cmd.Parameters.Add("@Term", SqlDbType.NVarChar);
            cmd.Parameters["@Term"].Value = term;
            //Console.WriteLine(cmd.Parameters["@Term"].Value);
            int tnum = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            //cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            if (tnum < 1)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// 根据年份获取奖球集合
    /// </summary>
    /// <param name="year">年份</param>
    /// <returns></returns>
    public List<int> findListOfOneNum(string year)
    {
        con.Open();
        List<int> list = new List<int>();
        SqlCeCommand cmd = con.CreateCommand();
        try
        {
            cmd.CommandText = "SELECT * FROM ticket WHERE term like '%" + year + "%'";
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                list.Add(rdr.GetInt16(0));
            }
        }
        finally
        {
            cmd.Dispose();
            con.Close();
        }
        return list;
    }

    /// <summary>
    /// 根据最新期数获取同期不重复的红球
    /// </summary>
    /// <param name="term">最新期数</param>
    /// <returns>同期不重复的红球列表</returns>
    public List<int> findSameForecastListOfTerm(string term)
    {
        con.Open();
        List<int> list = new List<int>();
        Queue queue = new Queue();
        SqlCeCommand cmd = con.CreateCommand();
        try
        {
            String temp = term.Substring(4, 3);
            for (int i = 0; i < numConfig.fullTerm.Count; i++)
            {
                //查询一期的红球数据
                cmd = con.CreateCommand();
                String dterm = numConfig.fullTerm[i] + temp;
                cmd.CommandText = "SELECT red_num1,red_num2,red_num3,red_num4,red_num5,red_num6 FROM ticket WHERE [term] = @Term";
                cmd.Parameters.Add("@Term", SqlDbType.NVarChar);
                cmd.Parameters["@Term"].Value = dterm;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (!queue.Contains(rdr.GetInt16(0)))
                    {
                        queue.Enqueue(rdr.GetInt16(0));
                        list.Add(rdr.GetInt16(0));
                    }

                    if (!queue.Contains(rdr.GetInt16(1)))
                    {
                        queue.Enqueue(rdr.GetInt16(1));
                        list.Add(rdr.GetInt16(1));
                    }

                    if (!queue.Contains(rdr.GetInt16(2)))
                    {
                        queue.Enqueue(rdr.GetInt16(2));
                        list.Add(rdr.GetInt16(2));
                    }

                    if (!queue.Contains(rdr.GetInt16(3)))
                    {
                        queue.Enqueue(rdr.GetInt16(3));
                        list.Add(rdr.GetInt16(3));
                    }

                    if (!queue.Contains(rdr.GetInt16(4)))
                    {
                        queue.Enqueue(rdr.GetInt16(4));
                        list.Add(rdr.GetInt16(4));
                    }

                    if (!queue.Contains(rdr.GetInt16(5)))
                    {
                        queue.Enqueue(rdr.GetInt16(5));
                        list.Add(rdr.GetInt16(5));
                    }
                }
                cmd.Dispose();
            }
        }
        finally
        {
            cmd.Dispose();
            con.Close();
        }
        return list;
    }

    /// <summary>
    /// 根据期数获得最新几期红球和篮球
    /// </summary>
    /// <param name="num">多少期数</param>
    /// <returns></returns>
    public Hashtable findBallListOfNum(int num)
    {
        con.Open();
        Hashtable table = new Hashtable();
        Queue redQueue = new Queue();
        Queue blueQueue = new Queue();
        List<int> redList = new List<int>();
        List<int> blueList = new List<int>();
        List<int> redFullList = new List<int>();
        List<int> blueFullList = new List<int>();
        SqlCeCommand cmd = con.CreateCommand();
        try
        {
            cmd.CommandText = "SELECT TOP(@Num) red_num1,red_num2,red_num3,red_num4,red_num5,red_num6,blue_num FROM ticket ORDER BY opentime DESC";
            cmd.Parameters.Add("@Num", SqlDbType.SmallInt);
            cmd.Parameters["@Num"].Value = num;
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                //添加去重后的球
                if (!redQueue.Contains(rdr.GetInt16(0)))
                {
                    redQueue.Enqueue(rdr.GetInt16(0));
                    redList.Add(rdr.GetInt16(0));
                }

                if (!redQueue.Contains(rdr.GetInt16(1)))
                {
                    redQueue.Enqueue(rdr.GetInt16(1));
                    redList.Add(rdr.GetInt16(1));
                }

                if (!redQueue.Contains(rdr.GetInt16(2)))
                {
                    redQueue.Enqueue(rdr.GetInt16(2));
                    redList.Add(rdr.GetInt16(2));
                }

                if (!redQueue.Contains(rdr.GetInt16(3)))
                {
                    redQueue.Enqueue(rdr.GetInt16(3));
                    redList.Add(rdr.GetInt16(3));
                }

                if (!redQueue.Contains(rdr.GetInt16(4)))
                {
                    redQueue.Enqueue(rdr.GetInt16(4));
                    redList.Add(rdr.GetInt16(4));
                }

                if (!redQueue.Contains(rdr.GetInt16(5)))
                {
                    redQueue.Enqueue(rdr.GetInt16(5));
                    redList.Add(rdr.GetInt16(5));
                }

                if (!blueQueue.Contains(rdr.GetInt16(6)))
                {
                    blueQueue.Enqueue(rdr.GetInt16(6));
                    blueList.Add(rdr.GetInt16(6));
                }

                //添加所有的球
                redFullList.Add(rdr.GetInt16(0));
                redFullList.Add(rdr.GetInt16(1));
                redFullList.Add(rdr.GetInt16(2));
                redFullList.Add(rdr.GetInt16(3));
                redFullList.Add(rdr.GetInt16(4));
                redFullList.Add(rdr.GetInt16(5));
                blueFullList.Add(rdr.GetInt16(6));
            }
            table.Add("redList", redList);
            table.Add("blueList", blueList);
            table.Add("redFullList", redFullList);
            table.Add("blueFullList", blueFullList);
        }
        finally
        {
            cmd.Dispose();
            con.Close();
        }
        return table;
    }
}
