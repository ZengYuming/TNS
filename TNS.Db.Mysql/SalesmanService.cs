using TNS.DataService.Interface;
using Framework.Core.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace TNS.Db.Mysql
{
    public class SalesmanService : BaseService, ISalesmanService
    {
        public Salesman Get(string id)
        {
            //创建一个MySqlCommand对象
            MySqlCommand cmd = new MySqlCommand();


            try
            {
                string sql = "SELECT SalesmanId,Account,PassWord,Name,AliAccount FROM Salesman WHERE  SalesmanId=?SalesmanId";

                MySqlParameter[] parameter = new MySqlParameter[] { new MySqlParameter("?SalesmanId", id) };

                //调用 PrepareCommand 方法，对 MySqlCommand 对象设置参数
                MySqlHelper.PrepareCommand(cmd, null, CommandType.Text, sql, parameter);
                //调用 MySqlCommand  的 ExecuteReader 方法
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet ds = new DataSet();

                adapter.Fill(ds);

                return TNS.Db.Util.ConvertHelper.DataSetToEntity<Salesman>(ds, 0);
            }
            catch (Exception e)
            {
                MySqlHelper.CloseDBConnection();
                throw e;
            }
            finally
            {
                //清除参数
                cmd.Parameters.Clear();

            }

        }

        public Salesman Get(string account, string passWord)
        {
            //创建一个MySqlCommand对象
            MySqlCommand cmd = new MySqlCommand();

            try
            {
                string sql = "SELECT SalesmanId,Account,PassWord,Name,AliAccount FROM Salesman WHERE  Account=?Account AND PassWord=?PassWord";


                MySqlParameter[] parameter = new MySqlParameter[] { new MySqlParameter("?Account", account), new MySqlParameter("?PassWord", passWord) };

                //调用 PrepareCommand 方法，对 MySqlCommand 对象设置参数
                MySqlHelper.PrepareCommand(cmd, null, CommandType.Text, sql, parameter);
                //调用 MySqlCommand  的 ExecuteReader 方法
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet ds = new DataSet();

                adapter.Fill(ds);

                return TNS.Db.Util.ConvertHelper.DataSetToEntity<Salesman>(ds, 0);
            }
            catch (Exception e)
            {
                MySqlHelper.CloseDBConnection();
                throw e;
            }
            finally
            {
                //清除参数
                cmd.Parameters.Clear();

            }

        }

        public IEnumerable<Salesman> GetList(PageInfo pageInfo)
        {
            //创建一个MySqlCommand对象
            MySqlCommand cmd = new MySqlCommand();

            try
            {
                int startPageIndex = pageInfo.PageIndex * pageInfo.PageSize;
                int endPageIndex = (pageInfo.PageIndex + 1) * pageInfo.PageSize;

                string sql = string.Format(@"SELECT SalesmanId,Account,PassWord,Name,AliAccount FROM Salesman LIMIT {0} , {1} ", startPageIndex, endPageIndex);
                 
                //调用 PrepareCommand 方法，对 MySqlCommand 对象设置参数
                MySqlHelper.PrepareCommand(cmd, null, CommandType.Text, sql, null);
                //调用 MySqlCommand  的 ExecuteReader 方法
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet ds = new DataSet();

                adapter.Fill(ds);


                return TNS.Db.Util.ConvertHelper.DataSetToEntityList<Salesman>(ds, 0);
            }
            catch (Exception e)
            {
                MySqlHelper.CloseDBConnection();
                throw e;
            }
            finally
            {
                //清除参数
                cmd.Parameters.Clear();
            }
        }

        public string GetErrorMessage()
        {
            return base.ErrorMessage;
        }

        public void ClearErrorMessage()
        {
            base.ErrorMessage = string.Empty;
        }

        public bool Update(Salesman salesman)
        {
            try
            {
                string sql = "UPDATE salesman SET Account=?Account,PassWord=?PassWord,Name=?Name,AliAccount=?AliAccount WHERE SalesmanId=?SalesmanId ";

                MySqlParameter[] parameter = new MySqlParameter[] { 
                    new MySqlParameter("?SalesmanId", salesman.SalesmanId),
                    new MySqlParameter("?Account", salesman.Account),
                    new MySqlParameter("?PassWord", salesman.PassWord) ,
                    new MySqlParameter("?Name", salesman.Name) ,
                    new MySqlParameter("?AliAccount", salesman.AliAccount)
                };

                return MySqlHelper.ExecuteNonQuery(CommandType.Text, sql, parameter) == 1;
            }
            catch (Exception e)
            {
                MySqlHelper.CloseDBConnection();
                throw e;
            }
            finally
            {

            }
        }

        public bool Add(Salesman salesman)
        {
            try
            {
                string sql = "INSERT INTO salesman values(?SalesmanId,?Account,?PassWord,?Name,?AliAccount)";

                MySqlParameter[] parameter = new MySqlParameter[] { 
                    new MySqlParameter("?SalesmanId", salesman.SalesmanId),
                    new MySqlParameter("?Account", salesman.Account),
                    new MySqlParameter("?PassWord", salesman.PassWord) ,
                    new MySqlParameter("?Name", salesman.Name) ,
                    new MySqlParameter("?AliAccount", salesman.AliAccount)
                };
                return MySqlHelper.ExecuteNonQuery(CommandType.Text, sql, parameter) == 1;
            }
            catch (Exception e)
            {
                MySqlHelper.CloseDBConnection();
                throw e;
            }
            finally
            {

            }
        }

        public bool Delete(string id)
        {
            try
            {
                string sql = "Delete FROM salesman WHERE SalesmanId=?SalesmanId";

                MySqlParameter[] parameter = new MySqlParameter[] { 
                    new MySqlParameter("?SalesmanId",id)                   
                };
                return MySqlHelper.ExecuteNonQuery(CommandType.Text, sql, parameter) == 1;
            }
            catch (Exception e)
            {
                MySqlHelper.CloseDBConnection();
                throw e;
            }
            finally
            {

            }
        }
    }
}