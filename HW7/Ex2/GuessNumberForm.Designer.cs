using System.ComponentModel;

namespace Ex2
{
    partial class GuessNumberForm
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
            this.GameLabel = new System.Windows.Forms.Label();
            this.GuessButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GameLabel
            // 
            this.GameLabel.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.GameLabel.Location = new System.Drawing.Point(66, 42);
            this.GameLabel.Name = "GameLabel";
            this.GameLabel.Size = new System.Drawing.Size(622, 101);
            this.GameLabel.TabIndex = 0;
            // 
            // GuessButton
            // 
            this.GuessButton.Location = new System.Drawing.Point(228, 203);
            this.GuessButton.Name = "GuessButton";
            this.GuessButton.Size = new System.Drawing.Size(241, 72);
            this.GuessButton.TabIndex = 1;
            this.GuessButton.Text = "Угадать";
            this.GuessButton.UseVisualStyleBackColor = true;
            this.GuessButton.Click += new System.EventHandler(this.GuessButton_Click);
            // 
            // GuessNumberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 318);
            this.Controls.Add(this.GuessButton);
            this.Controls.Add(this.GameLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GuessNumberForm";
            this.Text = "GuessNumber";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label GameLabel;
        private System.Windows.Forms.Button GuessButton;
    }
}