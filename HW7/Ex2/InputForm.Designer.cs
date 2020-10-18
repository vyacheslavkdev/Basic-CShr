using System;
using System.ComponentModel;

namespace Ex2
{
    partial class InputForm
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
            this.InputBox = new System.Windows.Forms.TextBox();
            this.EnterButton = new System.Windows.Forms.Button();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // InputBox
            // 
            this.InputBox.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.InputBox.Location = new System.Drawing.Point(47, 47);
            this.InputBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(268, 43);
            this.InputBox.TabIndex = 0;
            // 
            // EnterButton
            // 
            this.EnterButton.Location = new System.Drawing.Point(94, 116);
            this.EnterButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.Size = new System.Drawing.Size(174, 45);
            this.EnterButton.TabIndex = 1;
            this.EnterButton.Text = "Ввод";
            this.EnterButton.UseVisualStyleBackColor = true;
            this.EnterButton.Click += new System.EventHandler(this.EnterButton_Click);
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.Location = new System.Drawing.Point(53, 7);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(261, 31);
            this.ErrorLabel.TabIndex = 2;
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 194);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.EnterButton);
            this.Controls.Add(this.InputBox);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "InputForm";
            this.Text = "Введите число";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox InputBox;
        private System.Windows.Forms.Button EnterButton;
        private System.Windows.Forms.Label ErrorLabel;
    }
}