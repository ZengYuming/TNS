using TNS.DataService.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace TNS.Db.Mysql
{
    public class PersonService : BaseService, IPersonService
    {
        public string GetErrorMessage()
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<TNS.Db.Person> GetList(Framework.Core.Model.PageInfo pageInfo)
        {
            //创建一个MySqlCommand对象
            MySqlCommand cmd = new MySqlCommand();

            try
            {
                int startPageIndex = pageInfo.PageIndex * pageInfo.PageSize;
                int endPageIndex = (pageInfo.PageIndex + 1) * pageInfo.PageSize;

                string sql = string.Format(@"SELECT personId,firstName,secondName,comments FROM Person LIMIT {0} , {1} ", startPageIndex, endPageIndex);



                //调用 PrepareCommand 方法，对 MySqlCommand 对象设置参数
                MySqlHelper.PrepareCommand(cmd, null, CommandType.Text, sql, null);
                //调用 MySqlCommand  的 ExecuteReader 方法
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet ds = new DataSet();

                adapter.Fill(ds);


                return TNS.Db.Util.ConvertHelper.DataSetToEntityList<Person>(ds, 0);
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

        public TNS.Db.Person GetPerson(int id)
        {
            //创建一个MySqlCommand对象
            MySqlCommand cmd = new MySqlCommand();

            try
            {
                string sql = string.Format(@"SELECT personId,firstName,secondName,comments FROM Person WHERE personId={0} ", id);



                //调用 PrepareCommand 方法，对 MySqlCommand 对象设置参数
                MySqlHelper.PrepareCommand(cmd, null, CommandType.Text, sql, null);
                //调用 MySqlCommand  的 ExecuteReader 方法
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet ds = new DataSet();

                adapter.Fill(ds);

                return TNS.Db.Util.ConvertHelper.DataSetToEntity<Person>(ds, 0);
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

        public bool UpdatePerson(Person person)
        {
            try
            {
                string sql = string.Format("UPDATE person SET firstName='{0}' , secondName='{1}' , comments='{2}'    WHERE personId={3} ", person.firstName, person.secondName, person.comments, person.personId);

                MySqlHelper.ExecuteScalar(CommandType.Text, sql, null);
                return true;
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

        public void ClearErrorMessage()
        {
            base.ErrorMessage = string.Empty;
        }
    }
}
