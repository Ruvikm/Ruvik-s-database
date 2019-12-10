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

namespace 智慧校园体育云平台
{
    public partial class 查询 : Skin_Mac
    {
        //与"信息"窗口建立连接
        private Operation Main;
        public 查询(Operation operation)
        {
            InitializeComponent();
            this.Main = operation;
        }

        //当查询按钮被点击
        private void button1_Click(object sender, EventArgs e)
        {
            #region 一坨乱七八糟的变量

            string select = "Student.Sno,";   //默认第一列是学号
            string s = string.Empty;    //  中间变量，用于加','
            string se_chart = "Student,"; // 存要查的表的名字
            string Connect_ = string.Empty;//存SQL Server连接表的命令
            string[] fom_chart = new string[4] {"Student,","Running,","Test,","Match_," };
            string[] chart = new string[4] { "Student.Sno", "Running.Sno", "Test.Sno", "Match_.Sno" };
            bool[] flag = new bool[4] { false, false, false, false };//4个判断标志位，用来判断是否用连接groupbox里所对应的表

            #endregion


            #region 依次寻找4个groupbox里被勾选的项

            foreach (Control c in groupBox1.Controls)//遍历组1内的所有控件
            {
                if (c is CheckBox && ((CheckBox)c).CheckState == CheckState.Checked)//只遍历选中的CheckBox控件 
                {
                    flag[0] = true;
                    s = c.Text + ",";
                    select += s;
                }
            }

            foreach (Control c in groupBox2.Controls)//遍历组2内的所有控件
            {
                if (c is CheckBox && ((CheckBox)c).CheckState == CheckState.Checked)//只遍历选中的CheckBox控件 
                {
                    flag[1] = true;
                    s = c.Text + ",";
                    select += s;
                }
            }

            foreach (Control c in groupBox3.Controls)//遍历组3内的所有控件
            {
                if (c is CheckBox && ((CheckBox)c).CheckState == CheckState.Checked)//只遍历选中的CheckBox控件 
                {
                    flag[2] = true;
                    s = c.Text + ",";
                    select += s;
                }
            }

            foreach (Control c in groupBox4.Controls)
            //遍历组4的所有控件
            {
                if (c is CheckBox && ((CheckBox)c).CheckState == CheckState.Checked)//只遍历选中的CheckBox控件 
                {
                    flag[3] = true;
                    s = c.Text + ",";
                    select += s;
                }
            }

            #endregion


            //通过循环把要连的表选出来并补全SQL Server连接代码
            for (int i = 1; i < 4; i++)
            {
                if (flag[i])
                {
                    se_chart += fom_chart[i];
                    Connect_ += chart[i] + " = " + chart[0] + " and ";
                }
            }

            //去掉字符串select,se_chart中的最后一个逗号
            int len = select.Length;
            select = select.Substring(0, len - 1);
            len = se_chart.Length;
            se_chart = se_chart.Substring(0, len - 1);

            //MessageBox.Show(select);
            //MessageBox.Show(se_chart);
            //MessageBox.Show(Connect_);

            //将参数传递到"信息"窗口
            Main.Select_ = select;  
            Main.Group = Connect_;  //这个最后不用去and因为后面还要和查学号绑定
            Main.Se_chart = se_chart;
            this.Close();
        }

    }
}
