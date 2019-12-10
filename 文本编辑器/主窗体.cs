using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 作业5
{
    public partial class frmEditor : Form
    {
        string _findStr;
        string _replaceStr;
        int _nCharIndex = 0;
        RichTextBoxFinds _findOption;
        private String title = "Untitled";  //保存打开的文件的标题
        Encoding ec = Encoding.UTF8;          //设置文本的格式为 UTF-8
        public frmEditor()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "MacOS.ssk"; //DiamondBlue.ssk可换用皮肤目录中你喜欢的.ssk文件
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            新建_Click(sender, e);
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            保存_Click(sender, e);
        }

        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            另存为_Click(sender, e);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            退出_Click(sender, e);
        }

        private void 重复ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            重复_Click(sender, e);
        }

        private void 撤销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            撤销_Click(sender, e);
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            复制_Click(sender, e);
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            粘贴_Click(sender, e);
        }

        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            剪切_Click(sender, e);
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            删除_Click(sender, e);
        }

        private void 查找ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            查找_Click(sender, e);
        }

        private void 替换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            替换_Click(sender, e);
        }

        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            全选_Click(sender, e);
        }

        private void 字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            字体_Click(sender, e);
        }

        private void 文本前景色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            文本前景色_Click(sender, e);
        }

        private void 文本背景色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            文本背景色_Click(sender, e);
        }

        private void 左对齐ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            左对齐_Click(sender, e);
        }

        private void 居中ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            居中_Click(sender, e);
        }

        private void 右对齐ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            右对齐_Click(sender, e);
        }

        private void 复制CtrlCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            复制_Click(sender, e);
        }

        private void 剪切CtrlVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            粘贴_Click(sender, e);
        }

        private void 剪切CtrlXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            剪切_Click(sender, e);
        }

        private void 全选CtrlAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            全选_Click(sender, e);
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            打开_Click(sender, e);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            子窗体 c = new 子窗体();
            c.Show();
        }

        private void 新建_Click(object sender, EventArgs e)
        {
            rtbEditor.Text = "";
            title = "";
        }

        private void 打开_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "文本文件|*.txt;*.html;*.docx;*.doc;*.rtf|所有文件|*.*"; //文件打开的过滤器
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                title = openFileDialog1.FileName;
                this.Text = title;                  //显示打开的文件名
                rtbEditor.Modified = false;
                string ext = title.Substring(title.LastIndexOf(".") + 1);//获取文件格式
                ext = ext.ToLower();
                FileStream fs = new FileStream(title, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs, ec);
                if (ext == "rtf")  //如果后缀是 rtf 加载文件进来
                {
                    rtbEditor.LoadFile(title, RichTextBoxStreamType.RichText);
                }
                else
                {
                    rtbEditor.Text = sr.ReadToEnd();
                }
                fs.Close();
                sr.Close();
            }
        }

        private void 保存_Click(object sender, EventArgs e)
        {
            if (title == "Untitled")//如果是不是打开文件然后编辑的话 点击保存就相当于另存为咯
                另存为_Click(sender, e);//这个另存为的按钮是在顶部的菜单栏
            else
            {
                string ext = title.Substring(title.LastIndexOf(".") + 1);
                ext = ext.ToLower();
                if (ext == "rtf")//按照不同的格式保存文件
                    rtbEditor.SaveFile(title, RichTextBoxStreamType.RichText);
                else if (ext == "doc" || ext == "txt")
                    rtbEditor.SaveFile(title, RichTextBoxStreamType.PlainText);
                else if (ext == "uni")
                    rtbEditor.SaveFile(title, RichTextBoxStreamType.UnicodePlainText);
                else
                    rtbEditor.SaveFile(title, RichTextBoxStreamType.PlainText);
                rtbEditor.Modified = false;
            }
        }

        private void 另存为_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                title = saveFileDialog1.FileName;
                this.Text = title;
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        rtbEditor.SaveFile(title, RichTextBoxStreamType.RichText);
                        break;
                    case 2:
                        rtbEditor.SaveFile(title, RichTextBoxStreamType.PlainText);
                        break;
                    case 3:
                        rtbEditor.SaveFile(title, RichTextBoxStreamType.UnicodePlainText);
                        break;
                    default:
                        rtbEditor.SaveFile(title, RichTextBoxStreamType.PlainText);
                        break;
                }
                rtbEditor.Modified = false;
            }
        }

        private void 退出_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 重复_Click(object sender, EventArgs e)
        {
            rtbEditor.Redo();
        }

        private void 撤销_Click(object sender, EventArgs e)
        {
            rtbEditor.Undo();
        }

        private void 复制_Click(object sender, EventArgs e)
        {
            rtbEditor.Copy();
        }

        private void 粘贴_Click(object sender, EventArgs e)
        {
            rtbEditor.Paste();
        }

        private void 剪切_Click(object sender, EventArgs e)
        {
            rtbEditor.Cut();
        }

        private void 删除_Click(object sender, EventArgs e)
        {
            this.rtbEditor.SelectedText = "";
        }

        public void Find(string findStr, RichTextBoxFinds findOption)
        {
            _findStr = findStr;
            _findOption = findOption;
            _nCharIndex = rtbEditor.Find(_findStr, _nCharIndex, _findOption) + _findStr.Length;
            this.Activate();
        }
        private void 查找_Click(object sender, EventArgs e)
        {
            frmFindAndReplace dlgFind = new frmFindAndReplace(this);
            dlgFind.FindStr = _findStr;
            dlgFind.FindOption = _findOption;
            dlgFind.Editor = this;
            dlgFind.Show();
        }

        public void Replace(string findStr, string replaceStr, RichTextBoxFinds findOption)
        {
            _findStr = findStr;
            _replaceStr = replaceStr;
            _findOption = findOption;
            //  查找字符串
            rtbEditor.Find(_findStr, _nCharIndex, _findOption);
            //  替换字符串
            rtbEditor.SelectedText = _replaceStr;
            _nCharIndex += _replaceStr.Length;
            this.Activate();
        }
        public void ReplaceAll(string findStr, string replaceStr, RichTextBoxFinds findOption)
        {
            _findStr = findStr;
            _replaceStr = replaceStr;
            _findOption = findOption;
            //  查找字符串
            _nCharIndex = 0;
            while (rtbEditor.Find(_findStr, _nCharIndex, _findOption) >= 0)
            {
                //  替换字符串
                rtbEditor.SelectedText = _replaceStr;
                _nCharIndex += _replaceStr.Length;
            };
            this.Activate();
        }
        private void 替换_Click(object sender, EventArgs e)
        {
            frmFindAndReplace dlgReplace = new frmFindAndReplace(this);
            dlgReplace.FindStr = _findStr;
            dlgReplace.ReplaceStr = _replaceStr;
            dlgReplace.FindOption = _findOption;
            dlgReplace.Editor = this;
            //dlgReplace.SetFindOrReplace(false);
            dlgReplace.Show();
        }

        private void 全选_Click(object sender, EventArgs e)
        {
            rtbEditor.SelectAll();
        }

        private void 字体_Click(object sender, EventArgs e)
        {
            //  创建字体对话框
            FontDialog dlgFont = new FontDialog();
            dlgFont.ShowColor = true;
            dlgFont.ShowApply = true;
            //  设置字体对框的默认字体，
            //  如果已经有选择文本，则设置为选择文本的字体和颜色
            //  否则设置为全文的字体和姿色
            if (rtbEditor.SelectionLength > 0)
            {
                dlgFont.Font = rtbEditor.SelectionFont;
                dlgFont.Color = rtbEditor.SelectionColor;
            }
            else
            {
                dlgFont.Font = rtbEditor.Font;
                dlgFont.Color = rtbEditor.ForeColor;
            }
            //  显示字体对话框，且用户按下了 “确认 ”按钮
            if (dlgFont.ShowDialog() == DialogResult.OK)
            {
                //  如果有选择文件，刚修改选择文本的字体和颜色
                if (rtbEditor.SelectionLength > 0)
                {
                    rtbEditor.SelectionFont = dlgFont.Font;
                    rtbEditor.SelectionColor = dlgFont.Color;
                }
                //  否则修改整个文本的字体和颜色
                else
                {
                    rtbEditor.Font = dlgFont.Font;
                    rtbEditor.ForeColor = dlgFont.Color;
                }
            }
        }

        private void 文本前景色_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                rtbEditor.SelectionColor = colorDialog1.Color;//直接设置选中的字段的颜色
        }

        private void 文本背景色_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
                rtbEditor.BackColor = colorDialog2.Color;//直接设置选中的字段的颜色
        }

        private void 左对齐_Click(object sender, EventArgs e)
        {
            rtbEditor.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void 居中_Click(object sender, EventArgs e)
        {
            rtbEditor.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void 右对齐_Click(object sender, EventArgs e)
        {
            rtbEditor.SelectionAlignment = HorizontalAlignment.Right;
        }

    } 
}
