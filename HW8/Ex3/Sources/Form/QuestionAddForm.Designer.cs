using System.ComponentModel;

namespace Ex3
{
    partial class QuestionAddForm
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
            this.FormMenu = new System.Windows.Forms.MenuStrip();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileNewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileOpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuSaveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuSaveAsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileNemuSeparatorItem = new System.Windows.Forms.ToolStripSeparator();
            this.FileMenuExitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuestionTextBox = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.IsTrueCheckBox = new System.Windows.Forms.CheckBox();
            this.FormMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.NumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // FormMenu
            // 
            this.FormMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.FormMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
                {this.FileMenuItem, this.AboutMenuItem});
            this.FormMenu.Location = new System.Drawing.Point(0, 0);
            this.FormMenu.Name = "FormMenu";
            this.FormMenu.Size = new System.Drawing.Size(900, 28);
            this.FormMenu.TabIndex = 0;
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.FileNewMenuItem, this.FileOpenMenuItem, this.FileMenuSaveItem, this.FileMenuSaveAsItem,
                this.FileNemuSeparatorItem, this.FileMenuExitItem
            });
            this.FileMenuItem.Name = "FileMenuItem";
            this.FileMenuItem.Size = new System.Drawing.Size(45, 24);
            this.FileMenuItem.Text = "File";
            // 
            // FileNewMenuItem
            // 
            this.FileNewMenuItem.Name = "FileNewMenuItem";
            this.FileNewMenuItem.Size = new System.Drawing.Size(146, 26);
            this.FileNewMenuItem.Text = "New";
            this.FileNewMenuItem.Click += new System.EventHandler(this.FileNewMenuItem_Click);
            // 
            // FileOpenMenuItem
            // 
            this.FileOpenMenuItem.Name = "FileOpenMenuItem";
            this.FileOpenMenuItem.Size = new System.Drawing.Size(146, 26);
            this.FileOpenMenuItem.Text = "Open";
            this.FileOpenMenuItem.Click += new System.EventHandler(this.FileOpenMenuItem_Click);
            // 
            // FileMenuSaveItem
            // 
            this.FileMenuSaveItem.Name = "FileMenuSaveItem";
            this.FileMenuSaveItem.Size = new System.Drawing.Size(146, 26);
            this.FileMenuSaveItem.Text = "Save";
            this.FileMenuSaveItem.Click += new System.EventHandler(this.FileMenuSaveItem_Click);
            // 
            // FileMenuSaveAsItem
            // 
            this.FileMenuSaveAsItem.Name = "FileMenuSaveAsItem";
            this.FileMenuSaveAsItem.Size = new System.Drawing.Size(146, 26);
            this.FileMenuSaveAsItem.Text = "SaveAs...";
            this.FileMenuSaveAsItem.Click += new System.EventHandler(this.FileMenuSaveAsItem_Click);
            // 
            // FileNemuSeparatorItem
            // 
            this.FileNemuSeparatorItem.Name = "FileNemuSeparatorItem";
            this.FileNemuSeparatorItem.Size = new System.Drawing.Size(143, 6);
            // 
            // FileMenuExitItem
            // 
            this.FileMenuExitItem.Name = "FileMenuExitItem";
            this.FileMenuExitItem.Size = new System.Drawing.Size(146, 26);
            this.FileMenuExitItem.Text = "Exit";
            this.FileMenuExitItem.Click += new System.EventHandler(this.FileMenuExitItem_Click);
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.Name = "AboutMenuItem";
            this.AboutMenuItem.Size = new System.Drawing.Size(65, 24);
            this.AboutMenuItem.Text = "About";
            this.AboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // QuestionTextBox
            // 
            this.QuestionTextBox.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.QuestionTextBox.Location = new System.Drawing.Point(1, 42);
            this.QuestionTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.QuestionTextBox.Multiline = true;
            this.QuestionTextBox.Name = "QuestionTextBox";
            this.QuestionTextBox.Size = new System.Drawing.Size(898, 223);
            this.QuestionTextBox.TabIndex = 1;
            // 
            // AddButton
            // 
            this.AddButton.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.AddButton.Location = new System.Drawing.Point(18, 309);
            this.AddButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(171, 61);
            this.AddButton.TabIndex = 2;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.DeleteButton.Location = new System.Drawing.Point(717, 309);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(171, 61);
            this.DeleteButton.TabIndex = 3;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.SaveButton.Location = new System.Drawing.Point(195, 309);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(171, 61);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // NumericUpDown
            // 
            this.NumericUpDown.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.NumericUpDown.Location = new System.Drawing.Point(393, 313);
            this.NumericUpDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NumericUpDown.Name = "NumericUpDown";
            this.NumericUpDown.Size = new System.Drawing.Size(66, 39);
            this.NumericUpDown.TabIndex = 5;
            this.NumericUpDown.Value = new decimal(new int[] {1, 0, 0, 0});
            this.NumericUpDown.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
            // 
            // IsTrueCheckBox
            // 
            this.IsTrueCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.IsTrueCheckBox.Font = new System.Drawing.Font("Segoe UI Semilight", 16.2F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.IsTrueCheckBox.Location = new System.Drawing.Point(493, 300);
            this.IsTrueCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.IsTrueCheckBox.Name = "IsTrueCheckBox";
            this.IsTrueCheckBox.Size = new System.Drawing.Size(112, 76);
            this.IsTrueCheckBox.TabIndex = 6;
            this.IsTrueCheckBox.Text = "true";
            this.IsTrueCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.IsTrueCheckBox.UseVisualStyleBackColor = true;
            // 
            // QuestionAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 398);
            this.Controls.Add(this.IsTrueCheckBox);
            this.Controls.Add(this.NumericUpDown);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.QuestionTextBox);
            this.Controls.Add(this.FormMenu);
            this.MainMenuStrip = this.FormMenu;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "QuestionAddForm";
            this.Text = "QuestionAddForm";
            this.FormMenu.ResumeLayout(false);
            this.FormMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.NumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem FileOpenMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileNewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileMenuSaveItem;
        private System.Windows.Forms.ToolStripMenuItem FileMenuExitItem;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuItem;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.CheckBox IsTrueCheckBox;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.MenuStrip FormMenu;
        private System.Windows.Forms.ToolStripSeparator FileNemuSeparatorItem;
        private System.Windows.Forms.ToolStripMenuItem FileMenuSaveAsItem;
        private System.Windows.Forms.TextBox QuestionTextBox;
        private System.Windows.Forms.NumericUpDown NumericUpDown;
    }
}