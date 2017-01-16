namespace 成绩查询
{
    partial class 管理员界面
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.管理员选项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开课情况查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.学生成绩查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.学生信息维护ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.学生记录维护ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.管理员选项ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 管理员选项ToolStripMenuItem
            // 
            this.管理员选项ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开课情况查询ToolStripMenuItem,
            this.学生成绩查询ToolStripMenuItem,
            this.学生信息维护ToolStripMenuItem,
            this.学生记录维护ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.管理员选项ToolStripMenuItem.Name = "管理员选项ToolStripMenuItem";
            this.管理员选项ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.管理员选项ToolStripMenuItem.Text = "管理员选项";
            // 
            // 开课情况查询ToolStripMenuItem
            // 
            this.开课情况查询ToolStripMenuItem.Name = "开课情况查询ToolStripMenuItem";
            this.开课情况查询ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.开课情况查询ToolStripMenuItem.Text = "开课情况查询";
            this.开课情况查询ToolStripMenuItem.Click += new System.EventHandler(this.开课情况查询ToolStripMenuItem_Click);
            // 
            // 学生成绩查询ToolStripMenuItem
            // 
            this.学生成绩查询ToolStripMenuItem.Name = "学生成绩查询ToolStripMenuItem";
            this.学生成绩查询ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.学生成绩查询ToolStripMenuItem.Text = "学生成绩查询";
            this.学生成绩查询ToolStripMenuItem.Click += new System.EventHandler(this.学生成绩查询ToolStripMenuItem_Click);
            // 
            // 学生信息维护ToolStripMenuItem
            // 
            this.学生信息维护ToolStripMenuItem.Name = "学生信息维护ToolStripMenuItem";
            this.学生信息维护ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.学生信息维护ToolStripMenuItem.Text = "学生信息维护";
            this.学生信息维护ToolStripMenuItem.Click += new System.EventHandler(this.学生信息维护ToolStripMenuItem_Click);
            // 
            // 学生记录维护ToolStripMenuItem
            // 
            this.学生记录维护ToolStripMenuItem.Name = "学生记录维护ToolStripMenuItem";
            this.学生记录维护ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.学生记录维护ToolStripMenuItem.Text = "学生成绩维护";
            this.学生记录维护ToolStripMenuItem.Click += new System.EventHandler(this.学生记录维护ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.帮助ToolStripMenuItem.Text = "帮助";
            this.帮助ToolStripMenuItem.Click += new System.EventHandler(this.帮助ToolStripMenuItem_Click);
            // 
            // 管理员界面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "管理员界面";
            this.Text = "管理员界面";
            this.Load += new System.EventHandler(this.管理员界面_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 管理员选项ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开课情况查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 学生成绩查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 学生信息维护ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 学生记录维护ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
    }
}