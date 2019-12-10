namespace 作业5
{
    partial class frmFindAndReplace
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFindAndReplace));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabReplace = new System.Windows.Forms.TabPage();
            this.txtReplaceReplace = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReplaceCancel = new System.Windows.Forms.Button();
            this.btnReplaceReplaceAll = new System.Windows.Forms.Button();
            this.btnReplaceReplace = new System.Windows.Forms.Button();
            this.btnReplaceFindNext = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbReplaceMatchCase = new System.Windows.Forms.CheckBox();
            this.cbReplaceWholeWord = new System.Windows.Forms.CheckBox();
            this.txtReplaceFind = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabReplace.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabReplace);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(556, 309);
            this.tabControl1.TabIndex = 0;
            // 
            // tabReplace
            // 
            this.tabReplace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.tabReplace.Controls.Add(this.txtReplaceReplace);
            this.tabReplace.Controls.Add(this.label3);
            this.tabReplace.Controls.Add(this.btnReplaceCancel);
            this.tabReplace.Controls.Add(this.btnReplaceReplaceAll);
            this.tabReplace.Controls.Add(this.btnReplaceReplace);
            this.tabReplace.Controls.Add(this.btnReplaceFindNext);
            this.tabReplace.Controls.Add(this.label1);
            this.tabReplace.Controls.Add(this.cbReplaceMatchCase);
            this.tabReplace.Controls.Add(this.cbReplaceWholeWord);
            this.tabReplace.Controls.Add(this.txtReplaceFind);
            this.tabReplace.Location = new System.Drawing.Point(4, 28);
            this.tabReplace.Name = "tabReplace";
            this.tabReplace.Padding = new System.Windows.Forms.Padding(3);
            this.tabReplace.Size = new System.Drawing.Size(548, 277);
            this.tabReplace.TabIndex = 1;
            this.tabReplace.Text = "替换";
            // 
            // txtReplaceReplace
            // 
            this.txtReplaceReplace.Location = new System.Drawing.Point(107, 98);
            this.txtReplaceReplace.Name = "txtReplaceReplace";
            this.txtReplaceReplace.Size = new System.Drawing.Size(184, 28);
            this.txtReplaceReplace.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "替换";
            // 
            // btnReplaceCancel
            // 
            this.btnReplaceCancel.Location = new System.Drawing.Point(381, 212);
            this.btnReplaceCancel.Name = "btnReplaceCancel";
            this.btnReplaceCancel.Size = new System.Drawing.Size(118, 44);
            this.btnReplaceCancel.TabIndex = 7;
            this.btnReplaceCancel.Text = "取消";
            this.btnReplaceCancel.UseVisualStyleBackColor = true;
            this.btnReplaceCancel.Click += new System.EventHandler(this.btnReplaceCancel_Click);
            // 
            // btnReplaceReplaceAll
            // 
            this.btnReplaceReplaceAll.Location = new System.Drawing.Point(381, 152);
            this.btnReplaceReplaceAll.Name = "btnReplaceReplaceAll";
            this.btnReplaceReplaceAll.Size = new System.Drawing.Size(118, 44);
            this.btnReplaceReplaceAll.TabIndex = 6;
            this.btnReplaceReplaceAll.Text = "全部替换";
            this.btnReplaceReplaceAll.UseVisualStyleBackColor = true;
            this.btnReplaceReplaceAll.Click += new System.EventHandler(this.btnReplaceReplaceAll_Click);
            // 
            // btnReplaceReplace
            // 
            this.btnReplaceReplace.Location = new System.Drawing.Point(381, 89);
            this.btnReplaceReplace.Name = "btnReplaceReplace";
            this.btnReplaceReplace.Size = new System.Drawing.Size(118, 44);
            this.btnReplaceReplace.TabIndex = 5;
            this.btnReplaceReplace.Text = "替换";
            this.btnReplaceReplace.UseVisualStyleBackColor = true;
            this.btnReplaceReplace.Click += new System.EventHandler(this.btnReplaceReplace_Click);
            // 
            // btnReplaceFindNext
            // 
            this.btnReplaceFindNext.Location = new System.Drawing.Point(381, 25);
            this.btnReplaceFindNext.Name = "btnReplaceFindNext";
            this.btnReplaceFindNext.Size = new System.Drawing.Size(118, 44);
            this.btnReplaceFindNext.TabIndex = 4;
            this.btnReplaceFindNext.Text = "查找下一个";
            this.btnReplaceFindNext.UseVisualStyleBackColor = true;
            this.btnReplaceFindNext.Click += new System.EventHandler(this.btnReplaceFindNext_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "查找";
            // 
            // cbReplaceMatchCase
            // 
            this.cbReplaceMatchCase.AutoSize = true;
            this.cbReplaceMatchCase.Location = new System.Drawing.Point(107, 187);
            this.cbReplaceMatchCase.Name = "cbReplaceMatchCase";
            this.cbReplaceMatchCase.Size = new System.Drawing.Size(124, 22);
            this.cbReplaceMatchCase.TabIndex = 2;
            this.cbReplaceMatchCase.Text = "区分大小写";
            this.cbReplaceMatchCase.UseVisualStyleBackColor = true;
            // 
            // cbReplaceWholeWord
            // 
            this.cbReplaceWholeWord.AutoSize = true;
            this.cbReplaceWholeWord.Location = new System.Drawing.Point(107, 149);
            this.cbReplaceWholeWord.Name = "cbReplaceWholeWord";
            this.cbReplaceWholeWord.Size = new System.Drawing.Size(106, 22);
            this.cbReplaceWholeWord.TabIndex = 1;
            this.cbReplaceWholeWord.Text = "全字匹配";
            this.cbReplaceWholeWord.UseVisualStyleBackColor = true;
            // 
            // txtReplaceFind
            // 
            this.txtReplaceFind.Location = new System.Drawing.Point(107, 48);
            this.txtReplaceFind.Name = "txtReplaceFind";
            this.txtReplaceFind.Size = new System.Drawing.Size(184, 28);
            this.txtReplaceFind.TabIndex = 0;
            // 
            // frmFindAndReplace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(554, 308);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFindAndReplace";
            this.Text = "查找与替换";
            this.TopMost = true;
            this.tabControl1.ResumeLayout(false);
            this.tabReplace.ResumeLayout(false);
            this.tabReplace.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabReplace;
        private System.Windows.Forms.Button btnReplaceCancel;
        private System.Windows.Forms.Button btnReplaceReplaceAll;
        private System.Windows.Forms.Button btnReplaceReplace;
        private System.Windows.Forms.Button btnReplaceFindNext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbReplaceMatchCase;
        private System.Windows.Forms.CheckBox cbReplaceWholeWord;
        private System.Windows.Forms.TextBox txtReplaceFind;
        private System.Windows.Forms.TextBox txtReplaceReplace;
        private System.Windows.Forms.Label label3;
    }
}