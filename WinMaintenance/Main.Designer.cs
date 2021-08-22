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
            this.SuspendLayout();
            // 
            // cpuProgress
            // 
            this.cpuProgress.Location = new System.Drawing.Point(14, 34);
            this.cpuProgress.Name = "cpuProgress";
            this.cpuProgress.Size = new System.Drawing.Size(171, 23);
            this.cpuProgress.TabIndex = 0;
            // 
            // cpuNameLabel
            // 
            this.cpuNameLabel.AutoSize = true;
            this.cpuNameLabel.Location = new System.Drawing.Point(12, 19);
            this.cpuNameLabel.Name = "cpuNameLabel";
            this.cpuNameLabel.Size = new System.Drawing.Size(64, 12);
            this.cpuNameLabel.TabIndex = 1;
            this.cpuNameLabel.Text = "CPU_NAME";
            this.cpuNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // memoryAvailableLabel
            // 
            this.memoryAvailableLabel.AutoSize = true;
            this.memoryAvailableLabel.Location = new System.Drawing.Point(12, 87);
            this.memoryAvailableLabel.Name = "memoryAvailableLabel";
            this.memoryAvailableLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.memoryAvailableLabel.Size = new System.Drawing.Size(96, 12);
            this.memoryAvailableLabel.TabIndex = 2;
            this.memoryAvailableLabel.Text = "Memory_Available";
            // 
            // memoryProgress
            // 
            this.memoryProgress.Location = new System.Drawing.Point(14, 102);
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
            this.applyButton.Text = "適用";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // cpuUsePerLabel
            // 
            this.cpuUsePerLabel.AutoSize = true;
            this.cpuUsePerLabel.Location = new System.Drawing.Point(192, 41);
            this.cpuUsePerLabel.Name = "cpuUsePerLabel";
            this.cpuUsePerLabel.Size = new System.Drawing.Size(35, 12);
            this.cpuUsePerLabel.TabIndex = 5;
            this.cpuUsePerLabel.Text = "label1";
            // 
            // memUsePerLabel
            // 
            this.memUsePerLabel.AutoSize = true;
            this.memUsePerLabel.Location = new System.Drawing.Point(192, 109);
            this.memUsePerLabel.Name = "memUsePerLabel";
            this.memUsePerLabel.Size = new System.Drawing.Size(35, 12);
            this.memUsePerLabel.TabIndex = 6;
            this.memUsePerLabel.Text = "label2";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.memUsePerLabel);
            this.Controls.Add(this.cpuUsePerLabel);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.memoryProgress);
            this.Controls.Add(this.memoryAvailableLabel);
            this.Controls.Add(this.cpuNameLabel);
            this.Controls.Add(this.cpuProgress);
            this.Name = "Main";
            this.Text = "WinMaintenance";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar cpuProgress;
        private System.Windows.Forms.Label cpuNameLabel;
        private System.Windows.Forms.Label memoryAvailableLabel;
        private System.Windows.Forms.ProgressBar memoryProgress;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Label cpuUsePerLabel;
        private System.Windows.Forms.Label memUsePerLabel;
    }
}

