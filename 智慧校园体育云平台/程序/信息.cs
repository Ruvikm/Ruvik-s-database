using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CCWin;//引用UI美化文件
using SQLServer;//引用与数据库连接的文件

namespace 智慧校园体育云平台
{
    public partial class Operation : Skin_Mac
    {
        public string Se_chart = string.Empty; 
        public string Select_ = string.Empty;
        public string Group = string.Empty;
        public DataTable dataTable;//建立数据源---查询用
        public DataTable back_datatable;//建立数据源---增删改用
        internal SQLServerConnectionTool sQLServerConnectionTool;//与数据库建立连接的变量
        //和"主菜单"窗口连接
        private Main Main;
        public Operation(Main Main)
        {
            InitializeComponent();
            sQLServerConnectionTool = new SQLServerConnectionTool();
            sQLServerConnectionTool.serverConnetion();
            
            dataTable = new DataTable();
            back_datatable = new DataTable();
            //将Chart表格的数据源设为dataTable
            this.Main = Main;
        }


        #region 删除
        private void delete_Click(object sender, EventArgs e)
        {
            Pretreatment();
            bool flag = false;//删除成功或失败的标志位
            string delete = string.Empty;//删除的SQL命令 
            int i;
            //通过标题判断从哪个表格里删除
            if (this.Text == "Student")
                delete = "delete from Student where sno=" + Delete_text.Text;
            else if (this.Text == "Running")
                delete = "delete from Running where sno=" + Delete_text.Text;
            else if (this.Text == "Test")
                delete = "delete from Test where sno=" + Delete_text.Text;
            else
                delete = "delete from Match_ where sno=" + Delete_text.Text;
            //MessageBox.Show(delete);

            //找到要删除的数据在哪一行
            for (i = 0; i < dataTable.Rows.Count; i++)
            {
                string strName = dataTable.Rows[i]["Sno"].ToString().Trim();//先转化成字符串，然后去空格
                if (strName == Delete_text.Text)
                { 
                    sQLServerConnectionTool.DataTableSqlDeleteExeCute(back_datatable, i, delete);
                    flag = true;
                }
            }
            if (flag)
                MessageBox.Show("删除成功");
            else
                MessageBox.Show("要删除的人不存在");
        }

        #endregion


        #region 修改
        private void change_Click(object sender, EventArgs e)
        {
            Pretreatment();
            //弹出"修改1"窗口，在其里修改
            修改1 t = new 修改1(this);
            t.Show();
        }

        #endregion


        #region 查询
        private void select_Click(object sender, EventArgs e)
        {
            //用于刷新数据
            Chart.Visible = false;
            dataTable.Clear();//清空行（会保留列表头）
            dataTable.Columns.Clear();//清空列
            Select_ = string.Empty;
            Group = string.Empty;
            string s = string.Empty;
            查询 t = new 查询(this);
            t.ShowDialog();
            s = "select " + Select_ + " from "+ Se_chart +
                "  where " + Group + 
                " Student.Sno = " + Select_text.Text;
            //MessageBox.Show(s);
            sQLServerConnectionTool.DataTableSqlSelectExeCute(dataTable, s);
            Chart.DataSource = dataTable;
            Chart.Visible = true;
        }

        #endregion


        #region 添加
        private void add_Click(object sender, EventArgs e)
        {
            //SQL 添加的命令
            string addCmd = string.Empty;
            Pretreatment();
            //通过窗口的Text判断SQL的命令是什么并插入
            if (this.Text == "Student")
            { 
                addCmd = "insert into Student values('{0}','{1}','{2}','{3}','{4}')";
                sQLServerConnectionTool.DataTableSqlInsertExeCute1(back_datatable, add_1.Text, add_2.Text, add_3.Text, add_4.Text, add_5.Text, addCmd);
            }
            
            else
            {
                addCmd = "insert into " + this.Text + " values('{0}','{1}','{2}','{3}')";
                sQLServerConnectionTool.DataTableSqlInsertExeCute(back_datatable, add_1.Text, add_2.Text, add_3.Text, add_4.Text,addCmd);
                
            }

        }

        #endregion


        #region 隐藏显示数据库的界面 
        private void Operation_MouseDown(object sender, MouseEventArgs e)
        {
            Chart.Visible = false;
            dataTable.Clear();
            dataTable.Columns.Clear();
        }

        #endregion


        #region 每当窗口出现时

        //后代预处理，把数据先装进back_datatable里，以便后面的控件赋值
        private void Pretreatment()
        {
            #region 后台预先把数据在窗口打开时放到数据源back_datatable里

            string s = string.Empty;//SQL查询命令
            if (this.Text == "Student")
            {
                s = "select * from Student";
                add_5.Visible = true;
            }
            else if (this.Text == "Running")
                s = "select * from Running ";
            else if (this.Text == "Test")
                s = "select * from Test";
            else
                s = "select * from Match_ ";
            sQLServerConnectionTool.DataTableSqlSelectExeCute(back_datatable, s);
            Chart.Visible = false;

            #endregion
        }

        private void Operation_Shown(object sender, EventArgs e)
        {
            this.Text = Main.name;//更新窗口的Text值

            #region 更新Label标签
            if (this.Text == "Student")
            {
                add_5.Visible = true;
                label9.Visible = true;
                label5.Text = "Sno";
                label6.Text = "Sname";
                label7.Text = "Sex";
                label8.Text = "Sdept";
                label9.Text = "Major";
            }
            else if (this.Text == "Running")
            {
                label5.Text = "Runman_id";
                label6.Text = "Pass_times";
                label7.Text = "Unpass_times";
                label8.Text = "Sno";
                label9.Text = "";
            }
            else if (this.Text == "Test")
            {
                label5.Text = "Test_id";
                label6.Text = "Test_name";
                label7.Text = "Test_grade";
                label8.Text = "Sno";
                label9.Text = "";
            }
            else
            {
                label5.Text = "Match_id";
                label6.Text = "Match_name";
                label7.Text = "Match_grade";
                label8.Text = "Sno";
                label9.Text = "";
            }

            #endregion

        }

        #endregion


    }
}
