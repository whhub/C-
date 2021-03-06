﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Oracle.ManagedDataAccess.Client;

namespace SqlConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            //string constr = "server=10.6.14.158;initial catalog=VRVEIS;user id=vrvsync;pwd=Uih123456;Integrated Security=true";
            //string constr = "server=10.6.201.1;initial catalog=VRVEIS;user id=vrvsync;pwd=Uih123456";
            string constr = @"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.6.204.13) (PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=HR92PRD)));User Id=ifpsis; Password=Asdf5623";
            //string constr = "server=10.6.14.158;initial catalog=VRVEIS;user id=vrvsync;pwd=Uih123456";
            //string constr = "server=10.6.14.158;database=VRVEIS;user id=vrvsync;pwd=Uih123456";

            var sql = "select count(*) from PS_UIH_IFIS_VW";

            //连接 SQL SERVER
            //var sql = "select count(*) from dbo.PMoveableDiskEvent";
            //var con = new System.Data.SqlClient.SqlConnection(constr);
            //var com = new SqlCommand(sql, con);
            //try
            //{
            //    con.Open();
            //    Console.WriteLine("成功连接数据库");
            //    var x = com.ExecuteScalar();
            //    Console.WriteLine("成功读取{0}条记录", x);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            // 连接 Oracle
            //var con = new OracleConnection(constr);
            //try
            //{
            //    con.Open();
            //    Console.WriteLine("成功连接数据库");
            //    var com = con.CreateCommand();
            //    com.CommandText = sql;
            //    var x = com.ExecuteScalar();
            //    Console.WriteLine("成功读取{0}条记录", x);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //finally
            //{
            //    con.Close();
            //}


            // 从 Oracle 读取数据
            //var subordinates = GetSubordinates("xiangyu.huang");
            //Console.WriteLine(string.Join(",", subordinates));
            var employeeService = new EmployeeService();
            Console.WriteLine(employeeService.Subordinates("xiangyu.huang"));
            Console.WriteLine(employeeService.Subordinates("xiangyu.huang"));


            Console.WriteLine("Enter a key to exit");
            Console.ReadKey();
        }

        private static IEnumerable<string> GetSubordinates(string id)
        {
            string constr = @"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.6.204.13) (PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=HR92PRD)));User Id=ifpsis; Password=Asdf5623";

            IList<string> subOrdinates = new List<string>();
            Queue<string> idQueue = new Queue<string>();
            idQueue.Enqueue(id);

            var con = new OracleConnection(constr);
            try
            {
                con.Open();
                Console.WriteLine("成功连接数据库");
                while (idQueue.Count > 0)
                {
                    var currentId = idQueue.Dequeue();
                    var com = con.CreateCommand();
                    var sql = string.Format("select OPRID from PS_UIH_IFIS_VW WHERE OPRID2 = '{0}'", currentId);
                    Console.WriteLine(sql);
                    com.CommandText = sql;
                    var oracleDataReader = com.ExecuteReader();
                    while (oracleDataReader.Read())
                    {
                        var subordinateId = oracleDataReader.GetString(0);
                        Console.Write(subordinateId);
                        if (!subOrdinates.Contains(subordinateId))
                        {
                            Console.WriteLine(" found");
                            subOrdinates.Add(subordinateId);
                            idQueue.Enqueue(subordinateId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                con.Close();
            }
            return subOrdinates;
        }
    }
}
