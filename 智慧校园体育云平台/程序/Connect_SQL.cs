using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLServer
{
    class SQLServerConnectionTool
    {
        /// <summary>
        /// Data Source 服务器名称
        /// Initial Catalog 数据库名字
        /// User ID 用户名(使用SQL Server身份验证登录，之前要把数据库的权限赋给这个用户)
        /// Password 密码
        /// </summary>
        //用于连接SQL Server的字符串

        string conString = @"Data Source=DESKTOP-KDFRFFI;
                            Initial Catalog=智慧校园数据库;
                            Persist Security Info=True;
                            User ID=Ruvik;
                            Password=123321";
        /// <summary> sql命令</summary>
        SqlCommand sqlCommand;
        /// <summary> sql查询语句</summary>
        SqlCommand sqlSelectCommand;
        /// <summary> 连接服务器</summary>
        SqlConnection sqlConnection;
        /// <summary> 建立数据库和dataGridView组建的桥梁-----》填充DataTable（表示数据库中一个库中的一个表）或者DataSet（表示数据库的一个库）类型</summary>
        SqlDataAdapter sqlDataAdapter;

        public SQLServerConnectionTool()
        {
            sqlConnection = new SqlConnection(conString);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlSelectCommand = new SqlCommand();
            sqlSelectCommand.CommandText = "";
            sqlSelectCommand.Connection = sqlConnection;

            sqlDataAdapter = new SqlDataAdapter();

        }


        #region 建立连接和关闭连接

        /// <summary>
        /// 建立一个数据库连接
        /// </summary>
        public void serverConnetion()

        {
            try
            {
                sqlConnection.Open();
                //sqlConnection.OpenAsync(cancellationToken);
            }
            catch (InvalidOperationException e)
            {
                Debug.WriteLine(e.ToString());
            }
            catch (SqlException e)
            {
                Debug.WriteLine(e.Message);
            }

        }


        /// <summary>
        /// 关闭连接，清理数据
        /// </summary>
        public void serverClose()
        {
            sqlCommand = null;
            sqlSelectCommand = null;
            sqlDataAdapter = null;
            try
            {

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection = null;
                }
            }
            catch
            {

            }
        }

        #endregion


        #region SQL语句
        /// <summary>
        /// 执行spl语句
        /// </summary>
        /// <param name="command"></param>
        public void SqlCommandExeCute(string command)
        {

            try
            {
                sqlCommand.CommandText = command;
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Debug.WriteLine("语句执行错误" + e.ToString());
            }
            //catch
            //{


            //}

        }
        #region sql包装 未使用
        public void SqlCommandInsertExeCute(string command)
        {


            SqlCommandExeCute(command);

        }
        public void SqlCommandDeleteExeCute(string command)
        {
            SqlCommandExeCute(command);
        }
        public void SqlCommandSelectExeCute(string command)
        {


            sqlCommand.CommandText = command;
            List<SqlParameter> list = new List<SqlParameter>();
            SqlDataReader sqlDataAdapter = sqlCommand.ExecuteReader();
            //添加参数
            sqlCommand.Parameters.AddRange(list.ToArray());
            while (sqlDataAdapter.Read())
            {
                Console.WriteLine("     {0}\t\t{1}", sqlDataAdapter["用户名"], sqlDataAdapter["性别"]);
            }
            sqlDataAdapter.Close();
        }
        #endregion


        #endregion


        #region sqlDataAdapter封装类查询


        #region 查询功能
        public DataTable DataTableSqlSelectExeCute(DataTable dataTable,string select)
        {
            try
            {
                dataTable.Clear();
                dataTable.Columns.Clear();
                sqlCommand.CommandText = select;
                //执行SQL命令
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataTable);
            }
            catch (Exception e)
            {
                MessageBox.Show("数据查询错误" + e.Message);
            }
            return dataTable;
        }

        #endregion


        #region 插入功能
        //插入5个数据
        public void DataTableSqlInsertExeCute(DataTable dataTable, string userId, string name, string sex, string age,string addcmd)
        {

            try
            {

                sqlCommand.CommandText = string.Format(addcmd, userId, name, sex, age);
                //SQL 插入命令
                sqlDataAdapter.InsertCommand = sqlCommand;
                //添加并更新dataTable
                dataTable.Rows.Add(userId, name, sex, age);
                sqlDataAdapter.Update(dataTable);
                //dataTable.Clear();
                //sqlDataAdapter.Fill(dataTable);
            }
            catch (Exception e)
            {
                MessageBox.Show("数据插入错误" + e.Message);
            }
        }


        //插入4个数据
        public void DataTableSqlInsertExeCute1(DataTable dataTable, string userId, string name, string sex, string age, string birthday,string addCmd)
        {

            try
            {

                sqlCommand.CommandText = string.Format(addCmd, userId, name, sex, age, birthday);

                sqlDataAdapter.InsertCommand = sqlCommand;
                dataTable.Rows.Add(userId, name, sex, age, birthday);
                sqlDataAdapter.Update(dataTable);
                //dataTable.Clear();
                //sqlDataAdapter.Fill(dataTable);
            }
            catch (Exception e)
            {
                MessageBox.Show("数据插入错误" + e.Message);
            }
        }

        #endregion


        #region 删除功能
        public DataTable DataTableSqlDeleteExeCute(DataTable dataTable, int row, string delete)
        {
            try
            { 
                sqlCommand.CommandText = string.Format(delete, dataTable.Rows[row]["Sno"]);
                //sqlDataAdapter.SelectCommand = sqlSelectCommand;
                //删除指令
                sqlDataAdapter.DeleteCommand = sqlCommand;
                dataTable.Rows[row].Delete();
                sqlDataAdapter.Update(dataTable);
                //dataTable.Clear();
                //sqlDataAdapter.Fill(dataTable);
            }
            catch (Exception e)
            {
                MessageBox.Show("删除错误" + e.Message);
            }
            return dataTable;
        }

        #endregion


        #region 更新功能
        public DataTable DataTableSqlUpdateExeCute(DataTable dataTable,string update)
        {
            try
            {
                sqlCommand.CommandText = update;
                //更新指令
                sqlDataAdapter.UpdateCommand = sqlCommand;
                //sqlDataAdapter.DeleteCommand = sqlCommand;
                sqlDataAdapter.Update(dataTable);
                //sqlDataAdapter.Fill(dataTable);
            }
            catch(Exception e)
            {
                MessageBox.Show("数据更改错误" + e.Message);
            }
            return dataTable;
        }

        #endregion


        #endregion


        ~SQLServerConnectionTool()
        {
            serverClose();
        }
 
    }
}
