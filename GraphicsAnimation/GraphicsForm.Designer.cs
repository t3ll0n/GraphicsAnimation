namespace Program8_Graphics
{
    partial class GraphicsForm
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
            this.components = new System.ComponentModel.Container();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.db_panel = new Program8_Graphics.DoubleBufferedPanel();
            this.flash_imageCheckBox = new System.Windows.Forms.CheckBox();
            this.start_stopButton = new System.Windows.Forms.Button();
            this.db_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer2
            // 
            this.timer2.Interval = 250;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // db_panel
            // 
            this.db_panel.Controls.Add(this.flash_imageCheckBox);
            this.db_panel.Controls.Add(this.start_stopButton);
            this.db_panel.Location = new System.Drawing.Point(0, 0);
            this.db_panel.Name = "db_panel";
            this.db_panel.Size = new System.Drawing.Size(640, 480);
            this.db_panel.TabIndex = 0;
            this.db_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.db_panel_Paint);
            // 
            // flash_imageCheckBox
            // 
            this.flash_imageCheckBox.AutoSize = true;
            this.flash_imageCheckBox.Location = new System.Drawing.Point(553, 422);
            this.flash_imageCheckBox.Name = "flash_imageCheckBox";
            this.flash_imageCheckBox.Size = new System.Drawing.Size(83, 17);
            this.flash_imageCheckBox.TabIndex = 1;
            this.flash_imageCheckBox.Text = "Flash Image";
            this.flash_imageCheckBox.UseVisualStyleBackColor = true;
            this.flash_imageCheckBox.Click += new System.EventHandler(this.flash_imageCheckBox_Click);
            // 
            // start_stopButton
            // 
            this.start_stopButton.Location = new System.Drawing.Point(553, 445);
            this.start_stopButton.Name = "start_stopButton";
            this.start_stopButton.Size = new System.Drawing.Size(75, 23);
            this.start_stopButton.TabIndex = 0;
            this.start_stopButton.Text = "START";
            this.start_stopButton.UseVisualStyleBackColor = true;
            this.start_stopButton.Click += new System.EventHandler(this.start_stopButton_Click);
            // 
            // GraphicsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.Controls.Add(this.db_panel);
            this.Name = "GraphicsForm";
            this.Text = "Graphics";
            this.db_panel.ResumeLayout(false);
            this.db_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DoubleBufferedPanel db_panel;
        private System.Windows.Forms.Button start_stopButton;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox flash_imageCheckBox;
    }
}

