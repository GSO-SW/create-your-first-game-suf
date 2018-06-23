namespace TowerDefense_Test
{
    partial class Main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.candyLabel = new System.Windows.Forms.Label();
            this.candyCounterLabel = new System.Windows.Forms.Label();
            this.healthPointLabel = new System.Windows.Forms.Label();
            this.healthPointCounterLabel = new System.Windows.Forms.Label();
            this.VanKaputtbutton = new System.Windows.Forms.Button();
            this.minusChildrenButton = new System.Windows.Forms.Button();
            this.towerlabel = new System.Windows.Forms.Label();
            this.towerCountLabel = new System.Windows.Forms.Label();
            this.byTowerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // candyLabel
            // 
            this.candyLabel.AutoSize = true;
            this.candyLabel.Location = new System.Drawing.Point(551, 50);
            this.candyLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.candyLabel.Name = "candyLabel";
            this.candyLabel.Size = new System.Drawing.Size(37, 13);
            this.candyLabel.TabIndex = 0;
            this.candyLabel.Text = "Candy";
            // 
            // candyCounterLabel
            // 
            this.candyCounterLabel.AutoSize = true;
            this.candyCounterLabel.Location = new System.Drawing.Point(551, 72);
            this.candyCounterLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.candyCounterLabel.Name = "candyCounterLabel";
            this.candyCounterLabel.Size = new System.Drawing.Size(31, 13);
            this.candyCounterLabel.TabIndex = 1;
            this.candyCounterLabel.Text = "1000";
            // 
            // healthPointLabel
            // 
            this.healthPointLabel.AutoSize = true;
            this.healthPointLabel.Location = new System.Drawing.Point(551, 184);
            this.healthPointLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.healthPointLabel.Name = "healthPointLabel";
            this.healthPointLabel.Size = new System.Drawing.Size(37, 13);
            this.healthPointLabel.TabIndex = 2;
            this.healthPointLabel.Text = "Kinder";
            // 
            // healthPointCounterLabel
            // 
            this.healthPointCounterLabel.AutoSize = true;
            this.healthPointCounterLabel.Location = new System.Drawing.Point(551, 197);
            this.healthPointCounterLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.healthPointCounterLabel.Name = "healthPointCounterLabel";
            this.healthPointCounterLabel.Size = new System.Drawing.Size(19, 13);
            this.healthPointCounterLabel.TabIndex = 3;
            this.healthPointCounterLabel.Text = "50";
            // 
            // VanKaputtbutton
            // 
            this.VanKaputtbutton.Location = new System.Drawing.Point(554, 88);
            this.VanKaputtbutton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.VanKaputtbutton.Name = "VanKaputtbutton";
            this.VanKaputtbutton.Size = new System.Drawing.Size(69, 34);
            this.VanKaputtbutton.TabIndex = 4;
            this.VanKaputtbutton.Text = "VanKaputtbutton";
            this.VanKaputtbutton.UseVisualStyleBackColor = true;
            // 
            // minusChildrenButton
            // 
            this.minusChildrenButton.Location = new System.Drawing.Point(554, 228);
            this.minusChildrenButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.minusChildrenButton.Name = "minusChildrenButton";
            this.minusChildrenButton.Size = new System.Drawing.Size(69, 30);
            this.minusChildrenButton.TabIndex = 5;
            this.minusChildrenButton.Text = "-Kinder";
            this.minusChildrenButton.UseVisualStyleBackColor = true;
            // 
            // towerlabel
            // 
            this.towerlabel.AutoSize = true;
            this.towerlabel.Location = new System.Drawing.Point(554, 344);
            this.towerlabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.towerlabel.Name = "towerlabel";
            this.towerlabel.Size = new System.Drawing.Size(37, 13);
            this.towerlabel.TabIndex = 6;
            this.towerlabel.Text = "Tower";
            // 
            // towerCountLabel
            // 
            this.towerCountLabel.AutoSize = true;
            this.towerCountLabel.Location = new System.Drawing.Point(551, 367);
            this.towerCountLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.towerCountLabel.Name = "towerCountLabel";
            this.towerCountLabel.Size = new System.Drawing.Size(13, 13);
            this.towerCountLabel.TabIndex = 8;
            this.towerCountLabel.Text = "0";
            // 
            // byTowerButton
            // 
            this.byTowerButton.Location = new System.Drawing.Point(554, 396);
            this.byTowerButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.byTowerButton.Name = "byTowerButton";
            this.byTowerButton.Size = new System.Drawing.Size(56, 19);
            this.byTowerButton.TabIndex = 9;
            this.byTowerButton.Text = "Tower";
            this.byTowerButton.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 488);
            this.Controls.Add(this.byTowerButton);
            this.Controls.Add(this.towerCountLabel);
            this.Controls.Add(this.towerlabel);
            this.Controls.Add(this.minusChildrenButton);
            this.Controls.Add(this.VanKaputtbutton);
            this.Controls.Add(this.healthPointCounterLabel);
            this.Controls.Add(this.healthPointLabel);
            this.Controls.Add(this.candyCounterLabel);
            this.Controls.Add(this.candyLabel);
            this.Name = "Main";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label candyLabel;
        private System.Windows.Forms.Label candyCounterLabel;
        private System.Windows.Forms.Label healthPointLabel;
        private System.Windows.Forms.Label healthPointCounterLabel;
        private System.Windows.Forms.Button VanKaputtbutton;
        private System.Windows.Forms.Button minusChildrenButton;
        private System.Windows.Forms.Label towerlabel;
        private System.Windows.Forms.Label towerCountLabel;
        private System.Windows.Forms.Button byTowerButton;
    }
}

