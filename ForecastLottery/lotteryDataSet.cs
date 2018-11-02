using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ATC.Static;
using System.Data.OleDb;
using LitJson;
using ATC.DataBaseLib;

        public class ticketDataTable
        {
            DataAccess DataAccessObj = new DataAccess();

            /// <summary>
            /// 添加数据
            /// </summary>
            /// <param name="row">数据</param>
            public void addOneData(JsonData row) 
            {
                if (row != null)
                {
                    String[] redNums = row["opencode"].ToString().Substring(0, row["opencode"].ToString().IndexOf("+")).Split(new char[] { ',' });
                    String blueNum = row["opencode"].ToString().Substring(row["opencode"].ToString().IndexOf("+") + 1, 2);
                    if (redNums != null && redNums.Length > 0 && blueNum != "")
                    {
                        String sqlSp = "";
                        sqlSp = "Insert into ticket(";
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
                        sqlSp = sqlSp + row["expect"].ToString() + ",";
                        sqlSp = sqlSp + row["opentime"].ToString() + ",";
                        sqlSp = sqlSp + row["opentimestamp"].ToString() + ");";
                       
                        DataAccessObj.ExecuteSQL(sqlSp);  
                    }
                    
                }
            }

        }
