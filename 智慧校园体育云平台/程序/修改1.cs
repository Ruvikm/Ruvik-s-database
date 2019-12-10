using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;
using SQLServer;


namespace 智慧校园体育云平台
{
    //与"信息"窗口连接
    public partial class 修改1 : Skin_Mac
    {
        private Operation Main;
        public string item_name = string.Empty;//要修改属性的名字
        public string value = string.Empty;//要修改属性原有的值
        public int row = 0;//要修改行的位置
        public string changed = string.Empty;//修改后属性的值
        public string update = string.Empty;//SQL Server更新语句



        public 修改1(Operation Main)
        {
            InitializeComponent();
            this.Main = Main;
        }



        //当窗口刚刚打开时，更新5(4)个按钮上显示的属性的名字
        private void 修改_Shown(object sender, EventArgs e)
        {
            int i = 0;
            if (Main.Text == "Student")
            { 
                //如果要修改的是学生，则有5个按钮(属性)
                item1.Visible = true;
               
            }
            //通过循环批量给按钮赋值
            foreach (Control item in this.Controls)
            {
                if (item is Button)
                {
                    var comm = item as Button;
                    if (i < Main.back_datatable.Columns.Count)//检查是否越界
                        comm.Text = Main.back_datatable.Columns[i++].ColumnName;
                }
            }

        }


        #region 点击5(4)个按钮修改属性

        private void item1_Click(object sender, EventArgs e)
        {
            //跳转到"修改2"窗口获取修改后的值
            修改2 t = new 修改2(this);
            item_name =this.item1.Text;//获取按钮上的属性名字
            int i;
            //通过循环找到要修改属性原有的值,并赋值给value，以便弹出的窗口使用
            for (i = 0; i < Main.back_datatable.Rows.Count; i++)
            {
                string strName = Main.back_datatable.Rows[i]["Sno"].ToString().Trim();//先转化成字符串，然后去空格
                if (strName ==Main.Change_text.Text)//找到了
                {
                    row = i;
                    value = Main.back_datatable.Rows[i][item_name].ToString();
                    break;
                }
            }
            t.ShowDialog();
            if (changed != "")//如果在跳转的窗口中修改了
            {
                update = "Update " + Main.Text + " Set " + this.item1.Text + " = " + "'" + changed + "'" + " where Sno= " + Main.Change_text.Text;
                //MessageBox.Show(update);
                Main.back_datatable.Rows[i][item_name] = changed;//修改back_datatable数据源的值
                Main.sQLServerConnectionTool.DataTableSqlUpdateExeCute(Main.back_datatable, update);//修改数据库的值
            }
        }

        private void item2_Click(object sender, EventArgs e)
        {
            修改2 t = new 修改2(this);
            item_name = this.item2.Text;
            int i;
            for (i = 0; i < Main.back_datatable.Rows.Count; i++)
            {
                string strName = Main.back_datatable.Rows[i]["Sno"].ToString().Trim();//先转化成字符串，然后去空格
                if (strName == Main.Change_text.Text)
                {
                    row = i;
                    value = Main.back_datatable.Rows[i][item_name].ToString();
                    break;
                }
            }
            t.ShowDialog();
            if (changed != "")
            {
                update = "Update " + Main.Text + " Set " + this.item2.Text + " = " + "'" + changed + "'" + " where Sno= " + Main.Change_text.Text;
                //MessageBox.Show(update);
                Main.back_datatable.Rows[i][item_name] = changed;
                Main.sQLServerConnectionTool.DataTableSqlUpdateExeCute(Main.back_datatable, update);
            }
        }

        private void item3_Click(object sender, EventArgs e)
        {
            修改2 t = new 修改2(this);
            item_name = this.item3.Text;
            int i;
            for (i = 0; i < Main.back_datatable.Rows.Count; i++)
            {
                string strName = Main.back_datatable.Rows[i]["Sno"].ToString().Trim();//先转化成字符串，然后去空格
                if (strName == Main.Change_text.Text)
                {
                    row = i;
                    value = Main.back_datatable.Rows[i][item_name].ToString();
                    break;
                }
            }
            t.ShowDialog();
            if (changed != "")
            {
                update = "Update " + Main.Text + " Set " + this.item3.Text + " = " + "'" + changed + "'" + " where Sno= " + Main.Change_text.Text;
                //MessageBox.Show(update);
                Main.back_datatable.Rows[i][item_name] = changed;
                Main.sQLServerConnectionTool.DataTableSqlUpdateExeCute(Main.back_datatable, update);
            }
        }

        private void item4_Click(object sender, EventArgs e)
        {
            修改2 t = new 修改2(this);
            item_name = this.item4.Text;
            int i;
            for (i = 0; i < Main.back_datatable.Rows.Count; i++)
            {
                string strName = Main.back_datatable.Rows[i]["Sno"].ToString().Trim();//先转化成字符串，然后去空格
                if (strName == Main.Change_text.Text)
                {
                    row = i;
                    value = Main.back_datatable.Rows[i][item_name].ToString();
                    break;
                }
            }
            t.ShowDialog();
            if (changed != "")
            {
                update = "Update " + Main.Text + " Set " + this.item4.Text + " = " + "'" + changed + "'" + " where Sno= " + Main.Change_text.Text;
                //MessageBox.Show(update);
                Main.back_datatable.Rows[i][item_name] = changed;
                Main.sQLServerConnectionTool.DataTableSqlUpdateExeCute(Main.back_datatable, update);
            }
        }

        private void item5_Click(object sender, EventArgs e)
        {
            修改2 t = new 修改2(this);
            item_name = this.item5.Text;
            int i;
            for (i = 0; i < Main.back_datatable.Rows.Count; i++)
            {
                string strName = Main.back_datatable.Rows[i]["Sno"].ToString().Trim();//先转化成字符串，然后去空格
                if (strName == Main.Change_text.Text)
                {
                    row = i;
                    value = Main.back_datatable.Rows[i][item_name].ToString();
                    break;
                }
            }
            t.ShowDialog();
            if (changed != "")
            {
                update = "Update " + Main.Text + " Set " + this.item5.Text + " = " + "'" + changed + "'" + " where Sno= " + Main.Change_text.Text;
                //MessageBox.Show(update);
                Main.back_datatable.Rows[i][item_name] = changed;
                Main.sQLServerConnectionTool.DataTableSqlUpdateExeCute(Main.back_datatable, update);
            }
        }

        #endregion

    }
}