using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 作业5
{
    public partial class frmFindAndReplace : Form
    {
        frmEditor mainform1;
        public frmFindAndReplace(frmEditor FrmEditor)
        {
            InitializeComponent();
            mainform1 = FrmEditor;
            
        }
        //  要查找的字符串
        string _findStr;
        public string FindStr
        {
            get
            {
                return _findStr;
            }
            set
            {
                _findStr = value;
                txtReplaceFind.Text = _findStr;
            }
        }
        //  要替换的字符串
        string _replaceStr;
        public string ReplaceStr
        {
            get
            {
                return _replaceStr;
            }
            set
            {
                _replaceStr = value;
                txtReplaceReplace.Text = _replaceStr;
            }
        }
        //  查找或替换选项
        RichTextBoxFinds _findOption;
        public RichTextBoxFinds FindOption
        {
            get
            {
                return _findOption;
            }
            set
            {
                _findOption = value;
                cbReplaceWholeWord.Checked = (_findOption & RichTextBoxFinds.WholeWord) > 0;
                cbReplaceMatchCase.Checked = (_findOption & RichTextBoxFinds.MatchCase) > 0;
            }
        }
        //  文本编辑器
        frmEditor _editor;
        public frmEditor Editor
        {
            set
            {
                _editor = value;
            }
        }

        private void btnReplaceFindNext_Click(object sender, EventArgs e)
        {
            _findStr = txtReplaceFind.Text;
            _findOption = RichTextBoxFinds.None;
            if (cbReplaceWholeWord.Checked)
                _findOption |= RichTextBoxFinds.WholeWord;
            if (cbReplaceMatchCase.Checked)
                _findOption |= RichTextBoxFinds.MatchCase;
            _editor.Find(_findStr, _findOption);
        }

        private void btnReplaceReplace_Click(object sender, EventArgs e)
        {
            _findStr = txtReplaceFind.Text;
            _replaceStr = txtReplaceReplace.Text;
            _findOption = RichTextBoxFinds.None;
            if (cbReplaceWholeWord.Checked)
                _findOption |= RichTextBoxFinds.WholeWord;
            if (cbReplaceMatchCase.Checked)
                _findOption |= RichTextBoxFinds.MatchCase;
            _editor.Replace(_findStr, _replaceStr, _findOption);
        }

        private void btnReplaceReplaceAll_Click(object sender, EventArgs e)
        {
            _findStr = txtReplaceFind.Text;
            _replaceStr = txtReplaceReplace.Text;
            _findOption = RichTextBoxFinds.None;
            if (cbReplaceWholeWord.Checked)
                _findOption |= RichTextBoxFinds.WholeWord;
            if (cbReplaceMatchCase.Checked)
                _findOption |= RichTextBoxFinds.MatchCase;
            _editor.ReplaceAll(_findStr, _replaceStr, _findOption);
        }

        private void btnReplaceCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
    
