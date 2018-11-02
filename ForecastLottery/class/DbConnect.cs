using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;

/// <summary>
/// 本地数据库连接
/// </summary>
class DbConnect
{
   private static String dbPath = AppDomain.CurrentDomain.BaseDirectory.Substring(0, AppDomain.CurrentDomain.BaseDirectory.IndexOf("bin"));
   public static SqlCeConnection con = new SqlCeConnection("Data Source = " + dbPath + "lottery.sdf;password = wang@1978");
}

