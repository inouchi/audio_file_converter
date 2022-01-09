namespace audio_file_converter
{
    partial class AudioFileConverter
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
            this.SelectInputFileButton = new System.Windows.Forms.Button();
            this.MP3RadioButton = new System.Windows.Forms.RadioButton();
            this.WAVRadioButton = new System.Windows.Forms.RadioButton();
            this.AACRadioButton = new System.Windows.Forms.RadioButton();
            this.DeleteInputFilesCheckBox = new System.Windows.Forms.CheckBox();
            this.AlwaysOnTopCheckBox = new System.Windows.Forms.CheckBox();
            this.ExsitButton = new System.Windows.Forms.Button();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // SelectInputFileButton
            // 
            this.SelectInputFileButton.Location = new System.Drawing.Point(12, 12);
            this.SelectInputFileButton.Name = "SelectInputFileButton";
            this.SelectInputFileButton.Size = new System.Drawing.Size(166, 61);
            this.SelectInputFileButton.TabIndex = 0;
            this.SelectInputFileButton.Text = "Select Files in File Dialog\r\nor  Drag and Drop Them";
            this.SelectInputFileButton.UseVisualStyleBackColor = true;
            this.SelectInputFileButton.Click += new System.EventHandler(this.SelectInputFileButton_Click);
            // 
            // MP3RadioButton
            // 
            this.MP3RadioButton.AutoSize = true;
            this.MP3RadioButton.Checked = true;
            this.MP3RadioButton.Location = new System.Drawing.Point(184, 13);
            this.MP3RadioButton.Name = "MP3RadioButton";
            this.MP3RadioButton.Size = new System.Drawing.Size(103, 16);
            this.MP3RadioButton.TabIndex = 1;
            this.MP3RadioButton.TabStop = true;
            this.MP3RadioButton.Text = "Convert to MP3";
            this.MP3RadioButton.UseVisualStyleBackColor = true;
            this.MP3RadioButton.CheckedChanged += new System.EventHandler(this.MP3RadioButton_CheckedChanged);
            // 
            // WAVRadioButton
            // 
            this.WAVRadioButton.AutoSize = true;
            this.WAVRadioButton.Location = new System.Drawing.Point(184, 35);
            this.WAVRadioButton.Name = "WAVRadioButton";
            this.WAVRadioButton.Size = new System.Drawing.Size(106, 16);
            this.WAVRadioButton.TabIndex = 2;
            this.WAVRadioButton.Text = "Convert to WAV";
            this.WAVRadioButton.UseVisualStyleBackColor = true;
            this.WAVRadioButton.CheckedChanged += new System.EventHandler(this.WAVRadioButton_CheckedChanged);
            // 
            // AACRadioButton
            // 
            this.AACRadioButton.AutoSize = true;
            this.AACRadioButton.Location = new System.Drawing.Point(184, 57);
            this.AACRadioButton.Name = "AACRadioButton";
            this.AACRadioButton.Size = new System.Drawing.Size(105, 16);
            this.AACRadioButton.TabIndex = 3;
            this.AACRadioButton.Text = "Convert to AAC";
            this.AACRadioButton.UseVisualStyleBackColor = true;
            this.AACRadioButton.CheckedChanged += new System.EventHandler(this.AACRadioButton_CheckedChanged);
            // 
            // DeleteInputFilesCheckBox
            // 
            this.DeleteInputFilesCheckBox.AutoSize = true;
            this.DeleteInputFilesCheckBox.Location = new System.Drawing.Point(12, 114);
            this.DeleteInputFilesCheckBox.Name = "DeleteInputFilesCheckBox";
            this.DeleteInputFilesCheckBox.Size = new System.Drawing.Size(115, 16);
            this.DeleteInputFilesCheckBox.TabIndex = 4;
            this.DeleteInputFilesCheckBox.Text = "Delete Input Files";
            this.DeleteInputFilesCheckBox.UseVisualStyleBackColor = true;
            this.DeleteInputFilesCheckBox.CheckedChanged += new System.EventHandler(this.DeleteInputFilesCheckBox_CheckedChanged);
            // 
            // AlwaysOnTopCheckBox
            // 
            this.AlwaysOnTopCheckBox.AutoSize = true;
            this.AlwaysOnTopCheckBox.Location = new System.Drawing.Point(133, 114);
            this.AlwaysOnTopCheckBox.Name = "AlwaysOnTopCheckBox";
            this.AlwaysOnTopCheckBox.Size = new System.Drawing.Size(100, 16);
            this.AlwaysOnTopCheckBox.TabIndex = 5;
            this.AlwaysOnTopCheckBox.Text = "Always on Top";
            this.AlwaysOnTopCheckBox.UseVisualStyleBackColor = true;
            this.AlwaysOnTopCheckBox.CheckedChanged += new System.EventHandler(this.AlwaysOnTopCheckBox_CheckedChanged);
            // 
            // ExsitButton
            // 
            this.ExsitButton.Location = new System.Drawing.Point(242, 108);
            this.ExsitButton.Name = "ExsitButton";
            this.ExsitButton.Size = new System.Drawing.Size(50, 25);
            this.ExsitButton.TabIndex = 6;
            this.ExsitButton.Text = "Exsit";
            this.ExsitButton.UseVisualStyleBackColor = true;
            this.ExsitButton.Click += new System.EventHandler(this.ExsitButton_Click);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(12, 85);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(280, 15);
            this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressBar.TabIndex = 7;
            // 
            // AudioFileConverter
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 141);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.ExsitButton);
            this.Controls.Add(this.AlwaysOnTopCheckBox);
            this.Controls.Add(this.DeleteInputFilesCheckBox);
            this.Controls.Add(this.AACRadioButton);
            this.Controls.Add(this.WAVRadioButton);
            this.Controls.Add(this.MP3RadioButton);
            this.Controls.Add(this.SelectInputFileButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AudioFileConverter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AudioFileConverter";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.AudioFileConverter_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.AudioFileConverter_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectInputFileButton;
        private System.Windows.Forms.RadioButton MP3RadioButton;
        private System.Windows.Forms.RadioButton WAVRadioButton;
        private System.Windows.Forms.RadioButton AACRadioButton;
        private System.Windows.Forms.CheckBox DeleteInputFilesCheckBox;
        private System.Windows.Forms.CheckBox AlwaysOnTopCheckBox;
        private System.Windows.Forms.Button ExsitButton;
        private System.Windows.Forms.ProgressBar ProgressBar;
    }
}

