namespace ClickThrough
{
    partial class ClickThrough
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
            this.btnSelectShortcut = new System.Windows.Forms.Button();
            this.btnEnableShortcut = new System.Windows.Forms.Button();
            this.btnLeftWindow = new System.Windows.Forms.Button();
            this.btnRightWindow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSelectShortcut
            // 
            this.btnSelectShortcut.Location = new System.Drawing.Point(12, 12);
            this.btnSelectShortcut.Name = "btnSelectShortcut";
            this.btnSelectShortcut.Size = new System.Drawing.Size(256, 23);
            this.btnSelectShortcut.TabIndex = 3;
            this.btnSelectShortcut.Text = "Select Shortcut";
            this.btnSelectShortcut.UseVisualStyleBackColor = true;
            this.btnSelectShortcut.Click += new System.EventHandler(this.btnSelectShortcut_Click);
            // 
            // btnEnableShortcut
            // 
            this.btnEnableShortcut.Location = new System.Drawing.Point(12, 41);
            this.btnEnableShortcut.Name = "btnEnableShortcut";
            this.btnEnableShortcut.Size = new System.Drawing.Size(256, 23);
            this.btnEnableShortcut.TabIndex = 4;
            this.btnEnableShortcut.Text = "Enable Shortcut";
            this.btnEnableShortcut.UseVisualStyleBackColor = true;
            this.btnEnableShortcut.Click += new System.EventHandler(this.btnEnableShortcut_Click);
            // 
            // btnLeftWindow
            // 
            this.btnLeftWindow.Location = new System.Drawing.Point(12, 70);
            this.btnLeftWindow.Name = "btnLeftWindow";
            this.btnLeftWindow.Size = new System.Drawing.Size(256, 23);
            this.btnLeftWindow.TabIndex = 5;
            this.btnLeftWindow.Text = "Left Shortcut";
            this.btnLeftWindow.UseVisualStyleBackColor = true;
            this.btnLeftWindow.Click += new System.EventHandler(this.btnLeftWindow_Click);
            // 
            // btnRightWindow
            // 
            this.btnRightWindow.Location = new System.Drawing.Point(12, 99);
            this.btnRightWindow.Name = "btnRightWindow";
            this.btnRightWindow.Size = new System.Drawing.Size(256, 23);
            this.btnRightWindow.TabIndex = 6;
            this.btnRightWindow.Text = "Right Shortcut";
            this.btnRightWindow.UseVisualStyleBackColor = true;
            this.btnRightWindow.Click += new System.EventHandler(this.btnRightWindow_Click);
            // 
            // ClickThrough
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 132);
            this.Controls.Add(this.btnRightWindow);
            this.Controls.Add(this.btnLeftWindow);
            this.Controls.Add(this.btnEnableShortcut);
            this.Controls.Add(this.btnSelectShortcut);
            this.Name = "ClickThrough";
            this.Text = "Click Through";
            this.Load += new System.EventHandler(this.ClickThrough_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSelectShortcut;
        private System.Windows.Forms.Button btnEnableShortcut;
        private System.Windows.Forms.Button btnLeftWindow;
        private System.Windows.Forms.Button btnRightWindow;
    }
}

