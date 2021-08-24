namespace WinMaintenance
{
    partial class Main
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.cpuProgress = new System.Windows.Forms.ProgressBar();
            this.cpuNameLabel = new System.Windows.Forms.Label();
            this.memoryAvailableLabel = new System.Windows.Forms.Label();
            this.memoryProgress = new System.Windows.Forms.ProgressBar();
            this.applyButton = new System.Windows.Forms.Button();
            this.cpuUsePerLabel = new System.Windows.Forms.Label();
            this.memUsePerLabel = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.taskMgrTab = new System.Windows.Forms.TabPage();
            this.settingsTab = new System.Windows.Forms.TabPage();
            this.explorerSettingsGroupbox = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.taskMgrTab.SuspendLayout();
            this.settingsTab.SuspendLayout();
            this.explorerSettingsGroupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // cpuProgress
            // 
            this.cpuProgress.Location = new System.Drawing.Point(27, 32);
            this.cpuProgress.Name = "cpuProgress";
            this.cpuProgress.Size = new System.Drawing.Size(171, 23);
            this.cpuProgress.TabIndex = 0;
            // 
            // cpuNameLabel
            // 
            this.cpuNameLabel.AutoSize = true;
            this.cpuNameLabel.Location = new System.Drawing.Point(25, 17);
            this.cpuNameLabel.Name = "cpuNameLabel";
            this.cpuNameLabel.Size = new System.Drawing.Size(64, 12);
            this.cpuNameLabel.TabIndex = 1;
            this.cpuNameLabel.Text = "CPU_NAME";
            this.cpuNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // memoryAvailableLabel
            // 
            this.memoryAvailableLabel.AutoSize = true;
            this.memoryAvailableLabel.Location = new System.Drawing.Point(25, 75);
            this.memoryAvailableLabel.Name = "memoryAvailableLabel";
            this.memoryAvailableLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.memoryAvailableLabel.Size = new System.Drawing.Size(96, 12);
            this.memoryAvailableLabel.TabIndex = 2;
            this.memoryAvailableLabel.Text = "Memory_Available";
            // 
            // memoryProgress
            // 
            this.memoryProgress.Location = new System.Drawing.Point(27, 90);
            this.memoryProgress.Name = "memoryProgress";
            this.memoryProgress.Size = new System.Drawing.Size(172, 23);
            this.memoryProgress.TabIndex = 3;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(12, 415);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 4;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // cpuUsePerLabel
            // 
            this.cpuUsePerLabel.AutoSize = true;
            this.cpuUsePerLabel.Location = new System.Drawing.Point(204, 38);
            this.cpuUsePerLabel.Name = "cpuUsePerLabel";
            this.cpuUsePerLabel.Size = new System.Drawing.Size(29, 12);
            this.cpuUsePerLabel.TabIndex = 5;
            this.cpuUsePerLabel.Text = "--％";
            // 
            // memUsePerLabel
            // 
            this.memUsePerLabel.AutoSize = true;
            this.memUsePerLabel.Location = new System.Drawing.Point(205, 96);
            this.memUsePerLabel.Name = "memUsePerLabel";
            this.memUsePerLabel.Size = new System.Drawing.Size(29, 12);
            this.memUsePerLabel.TabIndex = 6;
            this.memUsePerLabel.Text = "--％";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.taskMgrTab);
            this.tabControl1.Controls.Add(this.settingsTab);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(787, 397);
            this.tabControl1.TabIndex = 7;
            // 
            // taskMgrTab
            // 
            this.taskMgrTab.Controls.Add(this.cpuProgress);
            this.taskMgrTab.Controls.Add(this.memUsePerLabel);
            this.taskMgrTab.Controls.Add(this.cpuNameLabel);
            this.taskMgrTab.Controls.Add(this.cpuUsePerLabel);
            this.taskMgrTab.Controls.Add(this.memoryAvailableLabel);
            this.taskMgrTab.Controls.Add(this.memoryProgress);
            this.taskMgrTab.Location = new System.Drawing.Point(4, 22);
            this.taskMgrTab.Name = "taskMgrTab";
            this.taskMgrTab.Padding = new System.Windows.Forms.Padding(3);
            this.taskMgrTab.Size = new System.Drawing.Size(779, 371);
            this.taskMgrTab.TabIndex = 0;
            this.taskMgrTab.Text = "TaskMgr";
            this.taskMgrTab.UseVisualStyleBackColor = true;
            // 
            // settingsTab
            // 
            this.settingsTab.Controls.Add(this.explorerSettingsGroupbox);
            this.settingsTab.Location = new System.Drawing.Point(4, 22);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.settingsTab.Size = new System.Drawing.Size(779, 371);
            this.settingsTab.TabIndex = 1;
            this.settingsTab.Text = "Settings";
            this.settingsTab.UseVisualStyleBackColor = true;
            // 
            // explorerSettingsGroupbox
            // 
            this.explorerSettingsGroupbox.Controls.Add(this.checkBox1);
            this.explorerSettingsGroupbox.Location = new System.Drawing.Point(12, 7);
            this.explorerSettingsGroupbox.Name = "explorerSettingsGroupbox";
            this.explorerSettingsGroupbox.Size = new System.Drawing.Size(405, 265);
            this.explorerSettingsGroupbox.TabIndex = 0;
            this.explorerSettingsGroupbox.TabStop = false;
            this.explorerSettingsGroupbox.Text = "Explorer_Settings";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(18, 23);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 16);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.applyButton);
            this.Name = "Main";
            this.Text = "WinMaintenance";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.tabControl1.ResumeLayout(false);
            this.taskMgrTab.ResumeLayout(false);
            this.taskMgrTab.PerformLayout();
            this.settingsTab.ResumeLayout(false);
            this.explorerSettingsGroupbox.ResumeLayout(false);
            this.explorerSettingsGroupbox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar cpuProgress;
        private System.Windows.Forms.Label cpuNameLabel;
        private System.Windows.Forms.Label memoryAvailableLabel;
        private System.Windows.Forms.ProgressBar memoryProgress;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Label cpuUsePerLabel;
        private System.Windows.Forms.Label memUsePerLabel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage taskMgrTab;
        private System.Windows.Forms.TabPage settingsTab;
        private System.Windows.Forms.GroupBox explorerSettingsGroupbox;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

