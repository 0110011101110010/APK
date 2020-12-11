namespace akademine_sistema
{
    partial class MainWindow
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
            this.sideMenuPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.contentPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // sideMenuPanel
            // 
            this.sideMenuPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.sideMenuPanel.Location = new System.Drawing.Point(12, 12);
            this.sideMenuPanel.Name = "sideMenuPanel";
            this.sideMenuPanel.Size = new System.Drawing.Size(153, 426);
            this.sideMenuPanel.TabIndex = 0;
            // 
            // contentPanel
            // 
            this.contentPanel.Location = new System.Drawing.Point(171, 12);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(617, 426);
            this.contentPanel.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.sideMenuPanel);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel sideMenuPanel;
        private System.Windows.Forms.FlowLayoutPanel contentPanel;
    }
}

