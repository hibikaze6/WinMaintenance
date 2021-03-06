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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.cpuProgress = new System.Windows.Forms.ProgressBar();
            this.cpuNameLabel = new System.Windows.Forms.Label();
            this.memoryAvailableLabel = new System.Windows.Forms.Label();
            this.memoryProgress = new System.Windows.Forms.ProgressBar();
            this.applyButton = new System.Windows.Forms.Button();
            this.cpuUsePerLabel = new System.Windows.Forms.Label();
            this.memUsePerLabel = new System.Windows.Forms.Label();
            this.wmTabControl = new System.Windows.Forms.TabControl();
            this.taskMgrTab = new System.Windows.Forms.TabPage();
            this.diskListCb = new System.Windows.Forms.ComboBox();
            this.diskUsePerLabel = new System.Windows.Forms.Label();
            this.diskAvailableLabel = new System.Windows.Forms.Label();
            this.diskProgress = new System.Windows.Forms.ProgressBar();
            this.memoryTypeLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.gpuNameLabel = new System.Windows.Forms.Label();
            this.nowTimeLabel = new System.Windows.Forms.Label();
            this.settingsTab = new System.Windows.Forms.TabPage();
            this.explorerSettingsGroupbox = new System.Windows.Forms.GroupBox();
            this.pcHideGroupbox = new System.Windows.Forms.GroupBox();
            this.pcHideDesktopCheckbox = new System.Windows.Forms.CheckBox();
            this.pcHideMusicCheckbox = new System.Windows.Forms.CheckBox();
            this.pcHideDocumentCheckbox = new System.Windows.Forms.CheckBox();
            this.pcHideDownloadCheckbox = new System.Windows.Forms.CheckBox();
            this.pcHideVideoCheckbox = new System.Windows.Forms.CheckBox();
            this.pcHidePictureCheckbox = new System.Windows.Forms.CheckBox();
            this.toolTab = new System.Windows.Forms.TabPage();
            this.cpuPictureBox = new System.Windows.Forms.PictureBox();
            this.gpuPictureBox = new System.Windows.Forms.PictureBox();
            this.cleanupButton = new System.Windows.Forms.Button();
            this.defragButton = new System.Windows.Forms.Button();
            this.dismButton = new System.Windows.Forms.Button();
            this.sfcButton = new System.Windows.Forms.Button();
            this.wmTabControl.SuspendLayout();
            this.taskMgrTab.SuspendLayout();
            this.settingsTab.SuspendLayout();
            this.explorerSettingsGroupbox.SuspendLayout();
            this.pcHideGroupbox.SuspendLayout();
            this.toolTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpuPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpuPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // cpuProgress
            // 
            this.cpuProgress.Location = new System.Drawing.Point(18, 30);
            this.cpuProgress.Name = "cpuProgress";
            this.cpuProgress.Size = new System.Drawing.Size(171, 23);
            this.cpuProgress.TabIndex = 0;
            // 
            // cpuNameLabel
            // 
            this.cpuNameLabel.AutoSize = true;
            this.cpuNameLabel.Location = new System.Drawing.Point(16, 15);
            this.cpuNameLabel.Name = "cpuNameLabel";
            this.cpuNameLabel.Size = new System.Drawing.Size(64, 12);
            this.cpuNameLabel.TabIndex = 1;
            this.cpuNameLabel.Text = "CPU_NAME";
            this.cpuNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // memoryAvailableLabel
            // 
            this.memoryAvailableLabel.AutoSize = true;
            this.memoryAvailableLabel.Location = new System.Drawing.Point(331, 17);
            this.memoryAvailableLabel.Name = "memoryAvailableLabel";
            this.memoryAvailableLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.memoryAvailableLabel.Size = new System.Drawing.Size(96, 12);
            this.memoryAvailableLabel.TabIndex = 2;
            this.memoryAvailableLabel.Text = "Memory_Available";
            // 
            // memoryProgress
            // 
            this.memoryProgress.Location = new System.Drawing.Point(333, 32);
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
            this.cpuUsePerLabel.Location = new System.Drawing.Point(193, 36);
            this.cpuUsePerLabel.Name = "cpuUsePerLabel";
            this.cpuUsePerLabel.Size = new System.Drawing.Size(29, 12);
            this.cpuUsePerLabel.TabIndex = 5;
            this.cpuUsePerLabel.Text = "--％";
            // 
            // memUsePerLabel
            // 
            this.memUsePerLabel.AutoSize = true;
            this.memUsePerLabel.Location = new System.Drawing.Point(511, 38);
            this.memUsePerLabel.Name = "memUsePerLabel";
            this.memUsePerLabel.Size = new System.Drawing.Size(29, 12);
            this.memUsePerLabel.TabIndex = 6;
            this.memUsePerLabel.Text = "--％";
            // 
            // wmTabControl
            // 
            this.wmTabControl.Controls.Add(this.taskMgrTab);
            this.wmTabControl.Controls.Add(this.settingsTab);
            this.wmTabControl.Controls.Add(this.toolTab);
            this.wmTabControl.Location = new System.Drawing.Point(12, 12);
            this.wmTabControl.Name = "wmTabControl";
            this.wmTabControl.SelectedIndex = 0;
            this.wmTabControl.Size = new System.Drawing.Size(787, 397);
            this.wmTabControl.TabIndex = 7;
            // 
            // taskMgrTab
            // 
            this.taskMgrTab.Controls.Add(this.diskListCb);
            this.taskMgrTab.Controls.Add(this.diskUsePerLabel);
            this.taskMgrTab.Controls.Add(this.diskAvailableLabel);
            this.taskMgrTab.Controls.Add(this.diskProgress);
            this.taskMgrTab.Controls.Add(this.memoryTypeLabel);
            this.taskMgrTab.Controls.Add(this.progressBar1);
            this.taskMgrTab.Controls.Add(this.label1);
            this.taskMgrTab.Controls.Add(this.cpuPictureBox);
            this.taskMgrTab.Controls.Add(this.gpuPictureBox);
            this.taskMgrTab.Controls.Add(this.gpuNameLabel);
            this.taskMgrTab.Controls.Add(this.nowTimeLabel);
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
            // diskListCb
            // 
            this.diskListCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.diskListCb.FormattingEnabled = true;
            this.diskListCb.Location = new System.Drawing.Point(333, 245);
            this.diskListCb.Name = "diskListCb";
            this.diskListCb.Size = new System.Drawing.Size(207, 20);
            this.diskListCb.TabIndex = 18;
            this.diskListCb.SelectedIndexChanged += new System.EventHandler(this.diskListCb_SelectedIndexChanged);
            // 
            // diskUsePerLabel
            // 
            this.diskUsePerLabel.AutoSize = true;
            this.diskUsePerLabel.Location = new System.Drawing.Point(511, 222);
            this.diskUsePerLabel.Name = "diskUsePerLabel";
            this.diskUsePerLabel.Size = new System.Drawing.Size(29, 12);
            this.diskUsePerLabel.TabIndex = 17;
            this.diskUsePerLabel.Text = "--％";
            // 
            // diskAvailableLabel
            // 
            this.diskAvailableLabel.AutoSize = true;
            this.diskAvailableLabel.Location = new System.Drawing.Point(331, 200);
            this.diskAvailableLabel.Name = "diskAvailableLabel";
            this.diskAvailableLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.diskAvailableLabel.Size = new System.Drawing.Size(79, 12);
            this.diskAvailableLabel.TabIndex = 15;
            this.diskAvailableLabel.Text = "Disk_Available";
            // 
            // diskProgress
            // 
            this.diskProgress.Location = new System.Drawing.Point(333, 215);
            this.diskProgress.Name = "diskProgress";
            this.diskProgress.Size = new System.Drawing.Size(172, 23);
            this.diskProgress.TabIndex = 16;
            // 
            // memoryTypeLabel
            // 
            this.memoryTypeLabel.AutoSize = true;
            this.memoryTypeLabel.Location = new System.Drawing.Point(468, 17);
            this.memoryTypeLabel.Name = "memoryTypeLabel";
            this.memoryTypeLabel.Size = new System.Drawing.Size(85, 12);
            this.memoryTypeLabel.TabIndex = 14;
            this.memoryTypeLabel.Text = "MEMORY_TYPE";
            this.memoryTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(18, 212);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(171, 23);
            this.progressBar1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(195, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "--％";
            // 
            // gpuNameLabel
            // 
            this.gpuNameLabel.AutoSize = true;
            this.gpuNameLabel.Location = new System.Drawing.Point(18, 195);
            this.gpuNameLabel.Name = "gpuNameLabel";
            this.gpuNameLabel.Size = new System.Drawing.Size(64, 12);
            this.gpuNameLabel.TabIndex = 9;
            this.gpuNameLabel.Text = "GPU_NAME";
            this.gpuNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nowTimeLabel
            // 
            this.nowTimeLabel.AutoSize = true;
            this.nowTimeLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.nowTimeLabel.Location = new System.Drawing.Point(661, 15);
            this.nowTimeLabel.Name = "nowTimeLabel";
            this.nowTimeLabel.Size = new System.Drawing.Size(111, 14);
            this.nowTimeLabel.TabIndex = 8;
            this.nowTimeLabel.Text = "yyyy MM-dd HH:mm";
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
            // pcHideGroupbox
            // 
            this.pcHideGroupbox.Controls.Add(this.pcHideDesktopCheckbox);
            this.pcHideGroupbox.Controls.Add(this.pcHideMusicCheckbox);
            this.pcHideGroupbox.Controls.Add(this.pcHideDocumentCheckbox);
            this.pcHideGroupbox.Controls.Add(this.pcHideDownloadCheckbox);
            this.pcHideGroupbox.Controls.Add(this.pcHideVideoCheckbox);
            this.pcHideGroupbox.Controls.Add(this.pcHidePictureCheckbox);
            this.pcHideGroupbox.Location = new System.Drawing.Point(15, 20);
            this.pcHideGroupbox.Name = "pcHideGroupbox";
            this.pcHideGroupbox.Size = new System.Drawing.Size(189, 155);
            this.pcHideGroupbox.TabIndex = 1;
            this.pcHideGroupbox.TabStop = false;
            this.pcHideGroupbox.Text = "エクスプローラのPCのフォルダ非表示";
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
            // toolTab
            // 
            this.toolTab.Controls.Add(this.cleanupButton);
            this.toolTab.Controls.Add(this.defragButton);
            this.toolTab.Controls.Add(this.dismButton);
            this.toolTab.Controls.Add(this.sfcButton);
            this.toolTab.Location = new System.Drawing.Point(4, 22);
            this.toolTab.Name = "toolTab";
            this.toolTab.Padding = new System.Windows.Forms.Padding(3);
            this.toolTab.Size = new System.Drawing.Size(779, 371);
            this.toolTab.TabIndex = 2;
            this.toolTab.Text = "Tools";
            this.toolTab.UseVisualStyleBackColor = true;
            // 
            // cpuPictureBox
            // 
            this.cpuPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cpuPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cpuPictureBox.Location = new System.Drawing.Point(18, 59);
            this.cpuPictureBox.Name = "cpuPictureBox";
            this.cpuPictureBox.Size = new System.Drawing.Size(115, 115);
            this.cpuPictureBox.TabIndex = 11;
            this.cpuPictureBox.TabStop = false;
            // 
            // gpuPictureBox
            // 
            this.gpuPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gpuPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gpuPictureBox.Location = new System.Drawing.Point(18, 241);
            this.gpuPictureBox.Name = "gpuPictureBox";
            this.gpuPictureBox.Size = new System.Drawing.Size(115, 115);
            this.gpuPictureBox.TabIndex = 10;
            this.gpuPictureBox.TabStop = false;
            // 
            // cleanupButton
            // 
            this.cleanupButton.Image = ((System.Drawing.Image)(resources.GetObject("cleanupButton.Image")));
            this.cleanupButton.Location = new System.Drawing.Point(335, 17);
            this.cleanupButton.Name = "cleanupButton";
            this.cleanupButton.Size = new System.Drawing.Size(100, 100);
            this.cleanupButton.TabIndex = 3;
            this.cleanupButton.UseVisualStyleBackColor = true;
            this.cleanupButton.Click += new System.EventHandler(this.cleanupButton_Click);
            // 
            // defragButton
            // 
            this.defragButton.Image = global::WinMaintenance.Properties.Resources.DEFRAG_ICON;
            this.defragButton.Location = new System.Drawing.Point(229, 17);
            this.defragButton.Name = "defragButton";
            this.defragButton.Size = new System.Drawing.Size(100, 100);
            this.defragButton.TabIndex = 2;
            this.defragButton.UseVisualStyleBackColor = true;
            this.defragButton.Click += new System.EventHandler(this.defragButton_Click);
            // 
            // dismButton
            // 
            this.dismButton.Image = global::WinMaintenance.Properties.Resources.BAT_ICON_DISM;
            this.dismButton.Location = new System.Drawing.Point(123, 17);
            this.dismButton.Name = "dismButton";
            this.dismButton.Size = new System.Drawing.Size(100, 100);
            this.dismButton.TabIndex = 1;
            this.dismButton.UseVisualStyleBackColor = true;
            this.dismButton.Click += new System.EventHandler(this.dismButton_Click);
            // 
            // sfcButton
            // 
            this.sfcButton.Image = global::WinMaintenance.Properties.Resources.BAT_ICON_SFC;
            this.sfcButton.Location = new System.Drawing.Point(17, 17);
            this.sfcButton.Name = "sfcButton";
            this.sfcButton.Size = new System.Drawing.Size(100, 100);
            this.sfcButton.TabIndex = 0;
            this.sfcButton.UseVisualStyleBackColor = true;
            this.sfcButton.Click += new System.EventHandler(this.sfcButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.wmTabControl);
            this.Controls.Add(this.applyButton);
            this.Name = "Main";
            this.Text = "WinMaintenance";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.wmTabControl.ResumeLayout(false);
            this.taskMgrTab.ResumeLayout(false);
            this.taskMgrTab.PerformLayout();
            this.settingsTab.ResumeLayout(false);
            this.explorerSettingsGroupbox.ResumeLayout(false);
            this.pcHideGroupbox.ResumeLayout(false);
            this.pcHideGroupbox.PerformLayout();
            this.toolTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpuPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpuPictureBox)).EndInit();
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
        private System.Windows.Forms.TabControl wmTabControl;
        private System.Windows.Forms.TabPage taskMgrTab;
        private System.Windows.Forms.TabPage settingsTab;
        private System.Windows.Forms.GroupBox explorerSettingsGroupbox;
        private System.Windows.Forms.CheckBox pcHidePictureCheckbox;
        private System.Windows.Forms.GroupBox pcHideGroupbox;
        private System.Windows.Forms.CheckBox pcHideDesktopCheckbox;
        private System.Windows.Forms.CheckBox pcHideMusicCheckbox;
        private System.Windows.Forms.CheckBox pcHideDocumentCheckbox;
        private System.Windows.Forms.CheckBox pcHideDownloadCheckbox;
        private System.Windows.Forms.CheckBox pcHideVideoCheckbox;
        private System.Windows.Forms.Label nowTimeLabel;
        private System.Windows.Forms.Label gpuNameLabel;
        private System.Windows.Forms.PictureBox gpuPictureBox;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox cpuPictureBox;
        private System.Windows.Forms.Label memoryTypeLabel;
        private System.Windows.Forms.Label diskUsePerLabel;
        private System.Windows.Forms.Label diskAvailableLabel;
        private System.Windows.Forms.ProgressBar diskProgress;
        private System.Windows.Forms.ComboBox diskListCb;
        private System.Windows.Forms.TabPage toolTab;
        private System.Windows.Forms.Button sfcButton;
        private System.Windows.Forms.Button dismButton;
        private System.Windows.Forms.Button defragButton;
        private System.Windows.Forms.Button cleanupButton;
    }
}

