using TNS.DataService.Interface;
using Framework.Core.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace TNS.Db.Mysql
{
    public class ManagerService : BaseService, IManagerService
    {
        public string GetErrorMessage()
        {
            return base.ErrorMessage;
        }

        public void ClearErrorMessage()
        {
            base.ErrorMessage = string.Empty;
        }

        public Manager Get(int id)
        {
            //创建一个MySqlCommand对象
            MySqlCommand cmd = new MySqlCommand();

            try
            {
                string sql = "SELECT ManagerId,Account,PassWord,Name FROM Manager WHERE  ManagerId=?ManagerId";

                MySqlParameter[] parameter = new MySqlParameter[] { new MySqlParameter("?ManagerId", id) };
                //MySqlParameter[] parameter = new MySqlParameter[] { new MySqlParameter("Account", account), new MySqlParameter("PassWord", passWord) };

                //调用 PrepareCommand 方法，对 MySqlCommand 对象设置参数
                MySqlHelper.PrepareCommand(cmd, null, CommandType.Text, sql, parameter);
                //调用 MySqlCommand  的 ExecuteReader 方法
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet ds = new DataSet();

                adapter.Fill(ds);

                return TNS.Db.Util.ConvertHelper.DataSetToEntity<Manager>(ds, 0);
            }
            catch (Exception e)
            {
                MySqlHelper.CloseDBConnection();
                base.ErrorMessage = "";
                throw e;
            }
            finally
            {
                //清除参数
                cmd.Parameters.Clear();
            }

        }

        public Manager Get(string account, string passWord)
        {
            //clear errorMessage.
            base.ErrorMessage = null;

            //创建一个MySqlCommand对象
            MySqlCommand cmd = new MySqlCommand();

            try
            {
                string sql = "SELECT ManagerId,Account,PassWord,Name FROM Manager WHERE  Account=?Account AND PassWord=?PassWord";
                
                MySqlParameter[] parameter = new MySqlParameter[] { new MySqlParameter("?Account", account), new MySqlParameter("?PassWord", passWord) };

                //调用 PrepareCommand 方法，对 MySqlCommand 对象设置参数
                MySqlHelper.PrepareCommand(cmd, null, CommandType.Text, sql, parameter);
                //调用 MySqlCommand  的 ExecuteReader 方法
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet ds = new DataSet();

                adapter.Fill(ds);

                return TNS.Db.Util.ConvertHelper.DataSetToEntity<Manager>(ds, 0);
            }
            catch (MySqlException ex)
            {
                MySqlHelper.CloseDBConnection();
                //To log
                base.ErrorMessage = "数据库查询失败，请检查您的网络是否打开？";
            }
            catch (Exception ex)
            {
                MySqlHelper.CloseDBConnection();
                //To log
                base.ErrorMessage = "数据库查询失败.";
            }
            finally
            {
                //清除参数
                cmd.Parameters.Clear();

            }

            return null;
        }

        public IEnumerable<Manager> GetList(PageInfo pageInfo)
        {
            //创建一个MySqlCommand对象
            MySqlCommand cmd = new MySqlCommand();

            try
            {
                int startPageIndex = pageInfo.PageIndex * pageInfo.PageSize;
                int endPageIndex = (pageInfo.PageIndex + 1) * pageInfo.PageSize;

                string sql = string.Format(@"SELECT ManagerId,Account,PassWord,Name FROM Manager LIMIT {0} , {1} ", startPageIndex, endPageIndex);



                //调用 PrepareCommand 方法，对 MySqlCommand 对象设置参数
                MySqlHelper.PrepareCommand(cmd, null, CommandType.Text, sql, null);
                //调用 MySqlCommand  的 ExecuteReader 方法
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet ds = new DataSet();

                adapter.Fill(ds);


                return TNS.Db.Util.ConvertHelper.DataSetToEntityList<Manager>(ds, 0);
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
    }
}
