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
    //与"修改1"窗口连接
    public partial class 修改2 : Skin_Mac
    {
        private 修改1 Main;

        public 修改2(修改1 main)
        {
            InitializeComponent();
            this.Main = main;
        }

        //当窗口刚刚启动时
        private void 修改2_Shown(object sender, EventArgs e)
        {
            this.Text = Main.item_name;//修改窗口的text为属性名
            label2.Text = Main.value;//修改label2的值为属性的原有值
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim() != String.Empty)//如果textbox里的值不为空(修改了)
                Main.changed = textBox1.Text;//把值传给"修改1"的changed字符串
            this.Close();
        }
    }
}
