namespace GraphingApplication
{
    partial class Form1
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
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.getStatsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.getComparedStatsButton = new System.Windows.Forms.Button();
            this.getWeaponUsePercentagesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(106, 12);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(204, 20);
            this.usernameBox.TabIndex = 0;
            // 
            // getStatsButton
            // 
            this.getStatsButton.Location = new System.Drawing.Point(12, 38);
            this.getStatsButton.Name = "getStatsButton";
            this.getStatsButton.Size = new System.Drawing.Size(142, 23);
            this.getStatsButton.TabIndex = 1;
            this.getStatsButton.Text = "Graph Individual Stats";
            this.getStatsButton.UseVisualStyleBackColor = true;
            this.getStatsButton.Click += new System.EventHandler(this.getStatsButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Steam Username";
            // 
            // getComparedStatsButton
            // 
            this.getComparedStatsButton.Location = new System.Drawing.Point(160, 38);
            this.getComparedStatsButton.Name = "getComparedStatsButton";
            this.getComparedStatsButton.Size = new System.Drawing.Size(150, 23);
            this.getComparedStatsButton.TabIndex = 4;
            this.getComparedStatsButton.Text = "Graph Compared Stats";
            this.getComparedStatsButton.UseVisualStyleBackColor = true;
            this.getComparedStatsButton.Click += new System.EventHandler(this.getComparedStatsButton_Click);
            // 
            // getWeaponUsePercentagesButton
            // 
            this.getWeaponUsePercentagesButton.Location = new System.Drawing.Point(12, 67);
            this.getWeaponUsePercentagesButton.Name = "getWeaponUsePercentagesButton";
            this.getWeaponUsePercentagesButton.Size = new System.Drawing.Size(185, 23);
            this.getWeaponUsePercentagesButton.TabIndex = 5;
            this.getWeaponUsePercentagesButton.Text = "Graph Weapon Usage Percentages";
            this.getWeaponUsePercentagesButton.UseVisualStyleBackColor = true;
            this.getWeaponUsePercentagesButton.Click += new System.EventHandler(this.getWeaponUsePercentagesButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 98);
            this.Controls.Add(this.getWeaponUsePercentagesButton);
            this.Controls.Add(this.getComparedStatsButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.getStatsButton);
            this.Controls.Add(this.usernameBox);
            this.Name = "Form1";
            this.Text = "CS:GO Stat Graphing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.Button getStatsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button getComparedStatsButton;
        private System.Windows.Forms.Button getWeaponUsePercentagesButton;
    }
}

