using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    interface IDBOperation<A>
    {
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="sql">添加的sql</param>
        void addOneData(String sql);

        /// <summary>
        /// 通过期数查找一条记录
        /// </summary>
        /// <param name="term">期数</param>
        /// <returns></returns>
        Boolean findNumByTerm(String term);

        /// <summary>
        /// 获取单个历史数据
        /// </summary>
        /// <param name="year">获取数据的年份</param>
        /// <returns></returns>
        List<int> findListOfOneNum(String year);

        /// <summary>
        /// 根据最新期数获取同期不重复的红球
        /// </summary>
        /// <param name="term">最新期数</param>
        /// <returns>同期不重复的红球列表</returns>
        List<int> findSameForecastListOfTerm(String term);

        /// <summary>
        /// 根据期数获得最新几期红球和篮球
        /// </summary>
        /// <param name="num">多少期数</param>
        /// <returns></returns>
        Hashtable findBallListOfNum(int num);
    }

