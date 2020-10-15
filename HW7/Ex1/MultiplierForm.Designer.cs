using System.ComponentModel;

namespace Ex1
{
    partial class MultiplierForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.GameGoalLabel = new System.Windows.Forms.Label();
            this.CurrentNumberLabel = new System.Windows.Forms.Label();
            this.PlusButton = new System.Windows.Forms.Button();
            this.MultButton = new System.Windows.Forms.Button();
            this.RevertButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.GameMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PlayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GameGoalLabel
            // 
            this.GameGoalLabel.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.GameGoalLabel.Location = new System.Drawing.Point(47, 33);
            this.GameGoalLabel.Name = "GameGoalLabel";
            this.GameGoalLabel.Size = new System.Drawing.Size(529, 45);
            this.GameGoalLabel.TabIndex = 0;
            this.GameGoalLabel.Text = "GameGoalLabel";
            // 
            // CurrentNumberLabel
            // 
            this.CurrentNumberLabel.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.CurrentNumberLabel.Location = new System.Drawing.Point(47, 96);
            this.CurrentNumberLabel.Name = "CurrentNumberLabel";
            this.CurrentNumberLabel.Size = new System.Drawing.Size(529, 45);
            this.CurrentNumberLabel.TabIndex = 1;
            this.CurrentNumberLabel.Text = "CurrentNumberLabel";
            // 
            // PlusButton
            // 
            this.PlusButton.Location = new System.Drawing.Point(642, 45);
            this.PlusButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PlusButton.Name = "PlusButton";
            this.PlusButton.Size = new System.Drawing.Size(195, 52);
            this.PlusButton.TabIndex = 2;
            this.PlusButton.Text = "+1";
            this.PlusButton.UseVisualStyleBackColor = true;
            this.PlusButton.Click += new System.EventHandler(this.PlusButton_Click);
            // 
            // MultButton
            // 
            this.MultButton.Location = new System.Drawing.Point(642, 116);
            this.MultButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MultButton.Name = "MultButton";
            this.MultButton.Size = new System.Drawing.Size(195, 52);
            this.MultButton.TabIndex = 3;
            this.MultButton.Text = "x2";
            this.MultButton.UseVisualStyleBackColor = true;
            this.MultButton.Click += new System.EventHandler(this.MultButton_Click);
            // 
            // RevertButton
            // 
            this.RevertButton.Location = new System.Drawing.Point(642, 186);
            this.RevertButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RevertButton.Name = "RevertButton";
            this.RevertButton.Size = new System.Drawing.Size(195, 52);
            this.RevertButton.TabIndex = 4;
            this.RevertButton.Text = "Cancel";
            this.RevertButton.UseVisualStyleBackColor = true;
            this.RevertButton.Click += new System.EventHandler(this.RevertButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.GameMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(900, 28);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // GameMenu
            // 
            this.GameMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.PlayMenuItem});
            this.GameMenu.Name = "GameMenu";
            this.GameMenu.Size = new System.Drawing.Size(65, 24);
            this.GameMenu.Text = "Меню";
            // 
            // PlayMenuItem
            // 
            this.PlayMenuItem.Name = "PlayMenuItem";
            this.PlayMenuItem.Size = new System.Drawing.Size(134, 26);
            this.PlayMenuItem.Text = "Играть";
            this.PlayMenuItem.Click += new System.EventHandler(this.PlayMenuItem_Click);
            // 
            // MultiplierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 295);
            this.Controls.Add(this.RevertButton);
            this.Controls.Add(this.MultButton);
            this.Controls.Add(this.PlusButton);
            this.Controls.Add(this.CurrentNumberLabel);
            this.Controls.Add(this.GameGoalLabel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MultiplierForm";
            this.Text = "Multiplier";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button RevertButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button PlusButton;
        private System.Windows.Forms.Button MultButton;
        private System.Windows.Forms.ToolStripMenuItem GameMenu;
        private System.Windows.Forms.ToolStripMenuItem PlayMenuItem;
        public System.Windows.Forms.Label CurrentNumberLabel;
        public System.Windows.Forms.Label GameGoalLabel;
    }
}