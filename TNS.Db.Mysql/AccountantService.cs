using TNS.DataService.Interface;
using Framework.Core.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace TNS.Db.Mysql
{
    public class AccountantService : BaseService, IAccountantService
    {
        public Accountant Get(int id)
        {
            //创建一个MySqlCommand对象
            MySqlCommand cmd = new MySqlCommand();

            try
            {
                string sql = "SELECT AccountantId,Account,PassWord,Name FROM Accountant WHERE  AccountantId=?AccountantId";



                MySqlParameter[] parameter = new MySqlParameter[] { new MySqlParameter("?AccountantId", id) };

                //调用 PrepareCommand 方法，对 MySqlCommand 对象设置参数
                MySqlHelper.PrepareCommand(cmd, null, CommandType.Text, sql, parameter);
                //调用 MySqlCommand  的 ExecuteReader 方法
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet ds = new DataSet();

                adapter.Fill(ds);

                return TNS.Db.Util.ConvertHelper.DataSetToEntity<Accountant>(ds, 0);
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

        public Accountant Get(string account, string passWord)
        {
            //创建一个MySqlCommand对象
            MySqlCommand cmd = new MySqlCommand();

            try
            {
                string sql = "SELECT AccountantId,Account,PassWord,Name FROM Accountant WHERE  Account=?Account AND PassWord=?PassWord";
                //string sql = "SELECT ManagerId,Account,PassWord,Name FROM Manager WHERE Account=@Account AND  PassWord=@PassWord";



                MySqlParameter[] parameter = new MySqlParameter[] { new MySqlParameter("?Account", account), new MySqlParameter("?PassWord", passWord) };

                //调用 PrepareCommand 方法，对 MySqlCommand 对象设置参数
                MySqlHelper.PrepareCommand(cmd, null, CommandType.Text, sql, parameter);
                //调用 MySqlCommand  的 ExecuteReader 方法
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet ds = new DataSet();

                adapter.Fill(ds);

                return TNS.Db.Util.ConvertHelper.DataSetToEntity<Accountant>(ds, 0);
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

        public IEnumerable<Accountant> GetList(PageInfo pageInfo)
        {
            //创建一个MySqlCommand对象
            MySqlCommand cmd = new MySqlCommand();

            try
            {
                int startPageIndex = pageInfo.PageIndex * pageInfo.PageSize;
                int endPageIndex = (pageInfo.PageIndex + 1) * pageInfo.PageSize;

                string sql = string.Format(@"SELECT AccountantId,Account,PassWord,Name FROM Accountant LIMIT {0} , {1} ", startPageIndex, endPageIndex);

                //调用 PrepareCommand 方法，对 MySqlCommand 对象设置参数
                MySqlHelper.PrepareCommand(cmd, null, CommandType.Text, sql, null);
                //调用 MySqlCommand  的 ExecuteReader 方法
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet ds = new DataSet();

                adapter.Fill(ds);

                return TNS.Db.Util.ConvertHelper.DataSetToEntityList<Accountant>(ds, 0);
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

        public bool Update(Accountant accountant)
        {
            try
            {
                string sql = "UPDATE accountant SET Account=?Account,PassWord=?PassWord,Name=?Name WHERE AccountantId=?AccountantId";

                MySqlParameter[] parameter = new MySqlParameter[] { 
                    new MySqlParameter("?AccountantId", accountant.AccountantId),
                    new MySqlParameter("?Account", accountant.Account),
                    new MySqlParameter("?PassWord", accountant.PassWord) ,
                    new MySqlParameter("?Name", accountant.Name) 
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

        public bool Add(Accountant accountant)
        {
            try
            {
                string sql = "INSERT INTO accountant values(?AccountantId,?Account,?PassWord,?Name)";

                MySqlParameter[] parameter = new MySqlParameter[] { 
                    new MySqlParameter("?AccountantId", accountant.AccountantId),
                    new MySqlParameter("?Account", accountant.Account),
                    new MySqlParameter("?PassWord", accountant.PassWord) ,
                    new MySqlParameter("?Name", accountant.Name) 
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
                string sql = "Delete FROM accountant WHERE AccountantId=?AccountantId";

                MySqlParameter[] parameter = new MySqlParameter[] { 
                    new MySqlParameter("?AccountantId",id)                   
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
