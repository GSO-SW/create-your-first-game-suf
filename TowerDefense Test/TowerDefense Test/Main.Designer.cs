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
            this.candyShowLabel = new System.Windows.Forms.Label();
            this.childrenLabel = new System.Windows.Forms.Label();
            this.childrenShowLabel = new System.Windows.Forms.Label();
            this.VanKaputtbutton = new System.Windows.Forms.Button();
            this.minusChildrenButton = new System.Windows.Forms.Button();
            this.towerlabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.candyLabel.Location = new System.Drawing.Point(735, 61);
            this.candyLabel.Name = "candyLabel";
            this.candyLabel.Size = new System.Drawing.Size(48, 17);
            this.candyLabel.TabIndex = 0;
            this.candyLabel.Text = "Candy";
            // 
            // candyShowLabel
            // 
            this.candyShowLabel.AutoSize = true;
            this.candyShowLabel.Location = new System.Drawing.Point(735, 88);
            this.candyShowLabel.Name = "candyShowLabel";
            this.candyShowLabel.Size = new System.Drawing.Size(40, 17);
            this.candyShowLabel.TabIndex = 1;
            this.candyShowLabel.Text = "1000";
            this.candyShowLabel.Click += new System.EventHandler(this.candyShowLabel_Click);
            // 
            // childrenLabel
            // 
            this.childrenLabel.AutoSize = true;
            this.childrenLabel.Location = new System.Drawing.Point(735, 226);
            this.childrenLabel.Name = "childrenLabel";
            this.childrenLabel.Size = new System.Drawing.Size(49, 17);
            this.childrenLabel.TabIndex = 2;
            this.childrenLabel.Text = "Kinder";
            this.childrenLabel.Click += new System.EventHandler(this.towerLabel_Click);
            // 
            // childrenShowLabel
            // 
            this.childrenShowLabel.AutoSize = true;
            this.childrenShowLabel.Location = new System.Drawing.Point(735, 261);
            this.childrenShowLabel.Name = "childrenShowLabel";
            this.childrenShowLabel.Size = new System.Drawing.Size(24, 17);
            this.childrenShowLabel.TabIndex = 3;
            this.childrenShowLabel.Text = "50";
            // 
            // VanKaputtbutton
            // 
            this.VanKaputtbutton.Location = new System.Drawing.Point(738, 108);
            this.VanKaputtbutton.Name = "VanKaputtbutton";
            this.VanKaputtbutton.Size = new System.Drawing.Size(92, 42);
            this.VanKaputtbutton.TabIndex = 4;
            this.VanKaputtbutton.Text = "VanKaputtbutton";
            this.VanKaputtbutton.UseVisualStyleBackColor = true;
            this.VanKaputtbutton.Click += new System.EventHandler(this.VanKaputtbutton_Click);
            // 
            // minusChildrenButton
            // 
            this.minusChildrenButton.Location = new System.Drawing.Point(738, 281);
            this.minusChildrenButton.Name = "minusChildrenButton";
            this.minusChildrenButton.Size = new System.Drawing.Size(92, 37);
            this.minusChildrenButton.TabIndex = 5;
            this.minusChildrenButton.Text = "-Kinder";
            this.minusChildrenButton.UseVisualStyleBackColor = true;
            this.minusChildrenButton.Click += new System.EventHandler(this.minusLebenButton_Click);
            // 
            // towerlabel
            // 
            this.towerlabel.AutoSize = true;
            this.towerlabel.Location = new System.Drawing.Point(738, 424);
            this.towerlabel.Name = "towerlabel";
            this.towerlabel.Size = new System.Drawing.Size(47, 17);
            this.towerlabel.TabIndex = 6;
            this.towerlabel.Text = "Tower";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // towerCountLabel
            // 
            this.towerCountLabel.AutoSize = true;
            this.towerCountLabel.Location = new System.Drawing.Point(735, 452);
            this.towerCountLabel.Name = "towerCountLabel";
            this.towerCountLabel.Size = new System.Drawing.Size(16, 17);
            this.towerCountLabel.TabIndex = 8;
            this.towerCountLabel.Text = "0";
            this.towerCountLabel.Click += new System.EventHandler(this.towerCountLabel_Click);
            // 
            // byTowerButton
            // 
            this.byTowerButton.Location = new System.Drawing.Point(738, 487);
            this.byTowerButton.Name = "byTowerButton";
            this.byTowerButton.Size = new System.Drawing.Size(75, 23);
            this.byTowerButton.TabIndex = 9;
            this.byTowerButton.Text = "Tower";
            this.byTowerButton.UseVisualStyleBackColor = true;
            this.byTowerButton.Click += new System.EventHandler(this.byTowerButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 601);
            this.Controls.Add(this.byTowerButton);
            this.Controls.Add(this.towerCountLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.towerlabel);
            this.Controls.Add(this.minusChildrenButton);
            this.Controls.Add(this.VanKaputtbutton);
            this.Controls.Add(this.childrenShowLabel);
            this.Controls.Add(this.childrenLabel);
            this.Controls.Add(this.candyShowLabel);
            this.Controls.Add(this.candyLabel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label candyLabel;
        private System.Windows.Forms.Label candyShowLabel;
        private System.Windows.Forms.Label childrenLabel;
        private System.Windows.Forms.Label childrenShowLabel;
        private System.Windows.Forms.Button VanKaputtbutton;
        private System.Windows.Forms.Button minusChildrenButton;
        private System.Windows.Forms.Label towerlabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label towerCountLabel;
        private System.Windows.Forms.Button byTowerButton;
    }
}

