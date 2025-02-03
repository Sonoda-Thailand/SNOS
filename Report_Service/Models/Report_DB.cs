using Report_Service.Enum;
using Report_Service.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Report_Service.Models
{
    class Report_DB
    {
        private List<DPROCING_Entity> timechart;
        private List<DPROC_Entity> product_List;
        private MLINE_INFO_Entity LINE_INFO = new MLINE_INFO_Entity();
        private List<U_Rate> U_Rates = new List<U_Rate>();
        Databaseconnection db = new Databaseconnection();
        public List<DPROC_Entity> get_Product_List(DateTime start, DateTime end, int line)
        {
            set_product(start, end, line);
            set_DPROCING_time_chart(start, end, line);
            return product_List;
        }
        public List<U_Rate> get_List_U_Rate()
        {
            return U_Rates;
        }
        public string getLinename(int LINE)
        {
            SqlConnection cnn = db.get_connection();
            string sql = "SELECT TOP (1) [LINE],[LINE_NAME],[LINE_TYPE],[IP],[PORT_TCP],[PORT_UDP],[ENABLE]  " +
                "FROM [dbo].[MLINE_INFO] " +
                "WHERE LINE = " + LINE + "";
            SqlCommand command;
            SqlDataReader sqlDataReader;
            cnn.Open();
            command = new SqlCommand(sql, cnn);
            sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                LINE_INFO.LINE = (int)sqlDataReader.GetValue(0);
                LINE_INFO.LINE_NAME = (string)sqlDataReader.GetValue(1);
                LINE_INFO.LINE_TYPE = (short)sqlDataReader.GetValue(2);
                LINE_INFO.IP = (string)sqlDataReader.GetValue(3);
                LINE_INFO.PORT_TCP = (int)sqlDataReader.GetValue(4);
                LINE_INFO.PORT_UDP = (int)sqlDataReader.GetValue(5);
                LINE_INFO.ENABLE = (short)sqlDataReader.GetValue(6);
            }
            sqlDataReader.Close();
            command.Dispose();
            cnn.Close();
            return LINE_INFO.LINE_NAME;
        }
        public List<DPROCING_Entity> get_DPROCING_time_chart()
        {
            return timechart;
        }
        #region private
        private void set_product(DateTime start, DateTime end, int line)
        {
            product_List = get_range_DPROC(start, end, line);
            set_userate(product_List);
        }
        private void set_userate(List<DPROC_Entity> product_List)
        {
            foreach (DPROC_Entity item in product_List)
            {
                bool fisrt = true;
                List<DPROCING_Entity> active_log = get_DPROCING_record_range(item.START_TIME, item.END_TIME, item.LINE);
                U_Rate uR_Rec = new U_Rate();
                short status = 0;
                DateTime? lasttime = null;
                double size = 0;
                foreach (var log in active_log)
                {
                    if (fisrt)
                    {
                        lasttime = log.GET_TIME;
                        fisrt = false;
                    }
                    else
                    {
                        TimeSpan time = log.GET_TIME - lasttime.Value;
                        switch (status)
                        {
                            case ((int)M_EVENT.Power_On):
                                uR_Rec.PowerOn += time;
                                break;
                            case ((int)M_EVENT.Stop):
                                uR_Rec.StopTime += time;
                                uR_Rec.PowerOn += time;
                                break;
                            case ((int)M_EVENT.Error):
                                uR_Rec.PowerOn += time;
                                uR_Rec.StopTime += time;
                                break;
                            case ((int)M_EVENT.Power_Off):
                                break;
                            case ((int)M_EVENT.Drive):
                                uR_Rec.PowerOn += time;
                                uR_Rec.Runtime += time;
                                break;
                        }
                        lasttime = log.GET_TIME;
                    }
                    if (size < log.SHEET_RESULT)
                    {
                        size = log.SHEET_RESULT;
                    }
                    status = log.LINE_STATUS;
                }
                uR_Rec.U_rate = getUilization(Math.Round(uR_Rec.Runtime.TotalSeconds, 0), Math.Round(uR_Rec.PowerOn.TotalSeconds, 0));
                //TimeSpan alltime = item.END_TIME- item.START_TIME;
                int min = (int)Math.Round(uR_Rec.Runtime.TotalMinutes, 0);
                if (min > 0)
                {
                    uR_Rec.AV_LineSpeed = size / min;
                }
                else
                {
                    uR_Rec.AV_LineSpeed = 0;
                }
                U_Rates.Add(uR_Rec);
            }
        }
        private double getUilization(double Run_time, double Power_on_Time)
        {
            double utr = 0.00;
            if (Power_on_Time == 0)
            {
                return 0.00;
            }
            else
            {
                utr = (Run_time / Power_on_Time) * 100.0;
                return Math.Round(utr, 2);
            }
        }
        private List<DPROC_Entity> get_range_DPROC(DateTime from, DateTime to, int line)
        {
            List<DPROC_Entity> list = new List<DPROC_Entity>();
            SqlConnection cnn = db.get_connection();
            string sql = "SELECT [LINE],[SIZE],[THICK],[SHEET_SCHED],[SHEET_RESULT],[START_TIME],[END_TIME],[SPEED]  " +
                "FROM [dbo].[DPROC]  " +
                "where  START_TIME >= '" + from + "' " +
                "and END_TIME <= '" + to + "'" +
                "and LINE = " + line + "" +
                "ORDER BY START_TIME asc";
            SqlCommand command;
            //MessageBox.Show(sql, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            SqlDataReader sqlDataReader;
            cnn.Open();
            command = new SqlCommand(sql, cnn);
            sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                DPROC_Entity log = new DPROC_Entity();
                log.LINE = (int)sqlDataReader.GetValue(0);
                log.SIZE = (decimal)sqlDataReader.GetValue(1);
                log.THICK = (decimal)sqlDataReader.GetValue(2);
                log.SHEET_SCHED = (short)sqlDataReader.GetValue(3);
                log.SHEET_RESULT = (short)sqlDataReader.GetValue(4);
                log.START_TIME = (DateTime)sqlDataReader.GetValue(5);
                log.END_TIME = (DateTime)sqlDataReader.GetValue(6);
                log.SPEED = (short)sqlDataReader.GetValue(7);
                list.Add(log);
            }
            sqlDataReader.Close();
            command.Dispose();
            cnn.Close();
            return list;
        }
        private List<DPROCING_Entity> get_DPROCING_record_range(DateTime from, DateTime to, int line)
        {
            List<DPROCING_Entity> list = new List<DPROCING_Entity>();
            SqlConnection cnn = db.get_connection();
            cnn.Open();
            //Before 1 Rec//指定範囲'以前'のレコードを１件取得指定範囲'以前'のレコードを１件取得
            string sql = "SELECT top (1) [LINE],[GET_TIME],[LINE_STATUS],[SPEED],[SIZE],[THICK],[SHEET_SCHED],[SHEET_RESULT],[START_TIME]  FROM [dbo].[DPROCING] " +
               "where  GET_TIME < '" + from + "'" +
               "and LINE = " + line + "" +
               "ORDER BY GET_TIME desc";
            SqlCommand command;
            SqlDataReader sqlDataReader;
            command = new SqlCommand(sql, cnn);
            sqlDataReader = command.ExecuteReader();

            while (sqlDataReader.Read())
            {
                DPROCING_Entity log = new DPROCING_Entity();
                log.LINE = (int)sqlDataReader.GetValue(0);
                log.GET_TIME = (DateTime)sqlDataReader.GetValue(1);
                log.LINE_STATUS = (short)sqlDataReader.GetValue(2);
                log.SPEED = (short)sqlDataReader.GetValue(3);
                log.SIZE = (decimal)sqlDataReader.GetValue(4);
                log.THICK = (decimal)sqlDataReader.GetValue(5);
                log.SHEET_SCHED = (short)sqlDataReader.GetValue(6);
                log.SHEET_RESULT = (short)sqlDataReader.GetValue(7);
                log.START_TIME = (DateTime)sqlDataReader.GetValue(8);
                list.Add(log);
            }
            sqlDataReader.Close();
            command.Dispose();
            //Rec//指定範囲のレコードを取得
            sql = "SELECT [LINE],[GET_TIME],[LINE_STATUS],[SPEED],[SIZE],[THICK],[SHEET_SCHED],[SHEET_RESULT],[START_TIME]  FROM [dbo].[DPROCING] " +
                "where  GET_TIME >= '" + from + "'" +
                "and GET_TIME < '" + to + "' " +
                "and LINE = " + line + "";
            command = new SqlCommand(sql, cnn);
            sqlDataReader = command.ExecuteReader();

            while (sqlDataReader.Read())
            {
                DPROCING_Entity log = new DPROCING_Entity();
                log.LINE = (int)sqlDataReader.GetValue(0);
                log.GET_TIME = (DateTime)sqlDataReader.GetValue(1);
                log.LINE_STATUS = (short)sqlDataReader.GetValue(2);
                log.SPEED = (short)sqlDataReader.GetValue(3);
                log.SIZE = (decimal)sqlDataReader.GetValue(4);
                log.THICK = (decimal)sqlDataReader.GetValue(5);
                log.SHEET_SCHED = (short)sqlDataReader.GetValue(6);
                log.SHEET_RESULT = (short)sqlDataReader.GetValue(7);
                log.START_TIME = (DateTime)sqlDataReader.GetValue(8);
                list.Add(log);
            }
            sqlDataReader.Close();
            command.Dispose();
            //After 1 Rec//指定範囲'以後'のレコードを１件取得
            sql = "SELECT top (1) [LINE],[GET_TIME],[LINE_STATUS],[SPEED],[SIZE],[THICK],[SHEET_SCHED],[SHEET_RESULT],[START_TIME]  FROM [dbo].[DPROCING] " +
                "where GET_TIME >= '" + to + "' " +
                "and LINE = " + line + "";
            command = new SqlCommand(sql, cnn);
            sqlDataReader = command.ExecuteReader();

            while (sqlDataReader.Read())
            {
                DPROCING_Entity log = new DPROCING_Entity();
                log.LINE = (int)sqlDataReader.GetValue(0);
                log.GET_TIME = (DateTime)sqlDataReader.GetValue(1);
                log.LINE_STATUS = (short)sqlDataReader.GetValue(2);
                log.SPEED = (short)sqlDataReader.GetValue(3);
                log.SIZE = (decimal)sqlDataReader.GetValue(4);
                log.THICK = (decimal)sqlDataReader.GetValue(5);
                log.SHEET_SCHED = (short)sqlDataReader.GetValue(6);
                log.SHEET_RESULT = (short)sqlDataReader.GetValue(7);
                log.START_TIME = (DateTime)sqlDataReader.GetValue(8);
                list.Add(log);
            }
            sqlDataReader.Close();
            command.Dispose();
            cnn.Close();
            return list;
        }

        private void set_DPROCING_time_chart(DateTime from, DateTime to, int line)
        {
            List<DPROCING_Entity> list = new List<DPROCING_Entity>();
            SqlConnection cnn = db.get_connection();
            cnn.Open();
            string sql = "SELECT [LINE],[GET_TIME],[LINE_STATUS],[SPEED],[SIZE],[THICK],[SHEET_SCHED],[SHEET_RESULT],[START_TIME]  FROM [dbo].[DPROCING] " +
                "where  GET_TIME >= '" + from + "'" +
                "and GET_TIME <= '" + to + "' " +
                "and LINE = " + line + "";
            SqlCommand command;
            SqlDataReader sqlDataReader;
            command = new SqlCommand(sql, cnn);
            sqlDataReader = command.ExecuteReader();

            while (sqlDataReader.Read())
            {
                DPROCING_Entity log = new DPROCING_Entity();
                log.LINE = (int)sqlDataReader.GetValue(0);
                log.GET_TIME = (DateTime)sqlDataReader.GetValue(1);
                log.LINE_STATUS = (short)sqlDataReader.GetValue(2);
                log.SPEED = (short)sqlDataReader.GetValue(3);
                log.SIZE = (decimal)sqlDataReader.GetValue(4);
                log.THICK = (decimal)sqlDataReader.GetValue(5);
                log.SHEET_SCHED = (short)sqlDataReader.GetValue(6);
                log.SHEET_RESULT = (short)sqlDataReader.GetValue(7);
                log.START_TIME = (DateTime)sqlDataReader.GetValue(8);
                list.Add(log);
            }
            sqlDataReader.Close();
            command.Dispose();
            cnn.Close();
            timechart = list;
        }
        #endregion
    }
}