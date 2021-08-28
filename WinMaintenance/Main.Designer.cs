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
            this.pcHidePictureCheckbox = new System.Windows.Forms.CheckBox();
            this.pcHideGroupbox = new System.Windows.Forms.GroupBox();
            this.pcHideVideoCheckbox = new System.Windows.Forms.CheckBox();
            this.pcHideDownloadCheckbox = new System.Windows.Forms.CheckBox();
            this.pcHideDocumentCheckbox = new System.Windows.Forms.CheckBox();
            this.pcHideMusicCheckbox = new System.Windows.Forms.CheckBox();
            this.pcHideDesktopCheckbox = new System.Windows.Forms.CheckBox();
            this.pcHide3dObjectCheckbox = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.taskMgrTab.SuspendLayout();
            this.settingsTab.SuspendLayout();
            this.explorerSettingsGroupbox.SuspendLayout();
            this.pcHideGroupbox.SuspendLayout();
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
            this.explorerSettingsGroupbox.Controls.Add(this.pcHideGroupbox);
            this.explorerSettingsGroupbox.Location = new System.Drawing.Point(12, 7);
            this.explorerSettingsGroupbox.Name = "explorerSettingsGroupbox";
            this.explorerSettingsGroupbox.Size = new System.Drawing.Size(405, 358);
            this.explorerSettingsGroupbox.TabIndex = 0;
            this.explorerSettingsGroupbox.TabStop = false;
            this.explorerSettingsGroupbox.Text = "Explorer_Settings";
            // 
            // pcHidePictureCheckbox
            // 
            this.pcHidePictureCheckbox.AutoSize = true;
            this.pcHidePictureCheckbox.Location = new System.Drawing.Point(11, 23);
            this.pcHidePictureCheckbox.Name = "pcHidePictureCheckbox";
            this.pcHidePictureCheckbox.Size = new System.Drawing.Size(93, 16);
            this.pcHidePictureCheckbox.TabIndex = 0;
            this.pcHidePictureCheckbox.Text = "ピクチャフォルダ";
            this.pcHidePictureCheckbox.UseVisualStyleBackColor = true;
            // 
            // pcHideGroupbox
            // 
            this.pcHideGroupbox.Controls.Add(this.pcHide3dObjectCheckbox);
            this.pcHideGroupbox.Controls.Add(this.pcHideDesktopCheckbox);
            this.pcHideGroupbox.Controls.Add(this.pcHideMusicCheckbox);
            this.pcHideGroupbox.Controls.Add(this.pcHideDocumentCheckbox);
            this.pcHideGroupbox.Controls.Add(this.pcHideDownloadCheckbox);
            this.pcHideGroupbox.Controls.Add(this.pcHideVideoCheckbox);
            this.pcHideGroupbox.Controls.Add(this.pcHidePictureCheckbox);
            this.pcHideGroupbox.Location = new System.Drawing.Point(15, 20);
            this.pcHideGroupbox.Name = "pcHideGroupbox";
            this.pcHideGroupbox.Size = new System.Drawing.Size(189, 180);
            this.pcHideGroupbox.TabIndex = 1;
            this.pcHideGroupbox.TabStop = false;
            this.pcHideGroupbox.Text = "エクスプローラのPCのフォルダ非表示";
            // 
            // pcHideVideoCheckbox
            // 
            this.pcHideVideoCheckbox.AutoSize = true;
            this.pcHideVideoCheckbox.Location = new System.Drawing.Point(11, 45);
            this.pcHideVideoCheckbox.Name = "pcHideVideoCheckbox";
            this.pcHideVideoCheckbox.Size = new System.Drawing.Size(86, 16);
            this.pcHideVideoCheckbox.TabIndex = 1;
            this.pcHideVideoCheckbox.Text = "ビデオフォルダ";
            this.pcHideVideoCheckbox.UseVisualStyleBackColor = true;
            // 
            // pcHideDownloadCheckbox
            // 
            this.pcHideDownloadCheckbox.AutoSize = true;
            this.pcHideDownloadCheckbox.Location = new System.Drawing.Point(11, 67);
            this.pcHideDownloadCheckbox.Name = "pcHideDownloadCheckbox";
            this.pcHideDownloadCheckbox.Size = new System.Drawing.Size(114, 16);
            this.pcHideDownloadCheckbox.TabIndex = 2;
            this.pcHideDownloadCheckbox.Text = "ダウンロードフォルダ";
            this.pcHideDownloadCheckbox.UseVisualStyleBackColor = true;
            // 
            // pcHideDocumentCheckbox
            // 
            this.pcHideDocumentCheckbox.AutoSize = true;
            this.pcHideDocumentCheckbox.Location = new System.Drawing.Point(11, 111);
            this.pcHideDocumentCheckbox.Name = "pcHideDocumentCheckbox";
            this.pcHideDocumentCheckbox.Size = new System.Drawing.Size(111, 16);
            this.pcHideDocumentCheckbox.TabIndex = 3;
            this.pcHideDocumentCheckbox.Text = "ドキュメントフォルダ";
            this.pcHideDocumentCheckbox.UseVisualStyleBackColor = true;
            // 
            // pcHideMusicCheckbox
            // 
            this.pcHideMusicCheckbox.AutoSize = true;
            this.pcHideMusicCheckbox.Location = new System.Drawing.Point(11, 89);
            this.pcHideMusicCheckbox.Name = "pcHideMusicCheckbox";
            this.pcHideMusicCheckbox.Size = new System.Drawing.Size(109, 16);
            this.pcHideMusicCheckbox.TabIndex = 4;
            this.pcHideMusicCheckbox.Text = "ミュージックフォルダ";
            this.pcHideMusicCheckbox.UseVisualStyleBackColor = true;
            // 
            // pcHideDesktopCheckbox
            // 
            this.pcHideDesktopCheckbox.AutoSize = true;
            this.pcHideDesktopCheckbox.Location = new System.Drawing.Point(11, 133);
            this.pcHideDesktopCheckbox.Name = "pcHideDesktopCheckbox";
            this.pcHideDesktopCheckbox.Size = new System.Drawing.Size(110, 16);
            this.pcHideDesktopCheckbox.TabIndex = 5;
            this.pcHideDesktopCheckbox.Text = "デスクトップフォルダ";
            this.pcHideDesktopCheckbox.UseVisualStyleBackColor = true;
            // 
            // pcHide3dObjectCheckbox
            // 
            this.pcHide3dObjectCheckbox.AutoSize = true;
            this.pcHide3dObjectCheckbox.Location = new System.Drawing.Point(11, 155);
            this.pcHide3dObjectCheckbox.Name = "pcHide3dObjectCheckbox";
            this.pcHide3dObjectCheckbox.Size = new System.Drawing.Size(124, 16);
            this.pcHide3dObjectCheckbox.TabIndex = 6;
            this.pcHide3dObjectCheckbox.Text = "3Dオブジェクトフォルダ";
            this.pcHide3dObjectCheckbox.UseVisualStyleBackColor = true;
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
            this.pcHideGroupbox.ResumeLayout(false);
            this.pcHideGroupbox.PerformLayout();
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
        private System.Windows.Forms.CheckBox pcHidePictureCheckbox;
        private System.Windows.Forms.GroupBox pcHideGroupbox;
        private System.Windows.Forms.CheckBox pcHide3dObjectCheckbox;
        private System.Windows.Forms.CheckBox pcHideDesktopCheckbox;
        private System.Windows.Forms.CheckBox pcHideMusicCheckbox;
        private System.Windows.Forms.CheckBox pcHideDocumentCheckbox;
        private System.Windows.Forms.CheckBox pcHideDownloadCheckbox;
        private System.Windows.Forms.CheckBox pcHideVideoCheckbox;
    }
}

