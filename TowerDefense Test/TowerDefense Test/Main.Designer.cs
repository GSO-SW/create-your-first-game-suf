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
            this.label_Info = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.candyLabel = new System.Windows.Forms.Label();
            this.candyAnzeigeLabel = new System.Windows.Forms.Label();
            this.lebensLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lebensAnzeigeLabel = new System.Windows.Forms.Label();
            this.tower1Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label_Info
            // 
            this.label_Info.AutoSize = true;
            this.label_Info.Location = new System.Drawing.Point(17, 16);
            this.label_Info.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Info.Name = "label_Info";
            this.label_Info.Size = new System.Drawing.Size(46, 17);
            this.label_Info.TabIndex = 0;
            this.label_Info.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 52);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Van loschicken";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(135, 161);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(18, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // candyLabel
            // 
            this.candyLabel.AutoSize = true;
            this.candyLabel.Location = new System.Drawing.Point(810, 30);
            this.candyLabel.Name = "candyLabel";
            this.candyLabel.Size = new System.Drawing.Size(48, 17);
            this.candyLabel.TabIndex = 4;
            this.candyLabel.Text = "Candy";
            // 
            // candyAnzeigeLabel
            // 
            this.candyAnzeigeLabel.AutoSize = true;
            this.candyAnzeigeLabel.Location = new System.Drawing.Point(810, 60);
            this.candyAnzeigeLabel.Name = "candyAnzeigeLabel";
            this.candyAnzeigeLabel.Size = new System.Drawing.Size(32, 17);
            this.candyAnzeigeLabel.TabIndex = 5;
            this.candyAnzeigeLabel.Text = "100";
            // 
            // lebensLabel
            // 
            this.lebensLabel.AutoSize = true;
            this.lebensLabel.Location = new System.Drawing.Point(810, 180);
            this.lebensLabel.Name = "lebensLabel";
            this.lebensLabel.Size = new System.Drawing.Size(49, 17);
            this.lebensLabel.TabIndex = 6;
            this.lebensLabel.Text = "Kinder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "label2";
            // 
            // lebensAnzeigeLabel
            // 
            this.lebensAnzeigeLabel.AutoSize = true;
            this.lebensAnzeigeLabel.Location = new System.Drawing.Point(810, 210);
            this.lebensAnzeigeLabel.Name = "lebensAnzeigeLabel";
            this.lebensAnzeigeLabel.Size = new System.Drawing.Size(24, 17);
            this.lebensAnzeigeLabel.TabIndex = 8;
            this.lebensAnzeigeLabel.Text = "10";
            // 
            // tower1Label
            // 
            this.tower1Label.AutoSize = true;
            this.tower1Label.Location = new System.Drawing.Point(813, 315);
            this.tower1Label.Name = "tower1Label";
            this.tower1Label.Size = new System.Drawing.Size(59, 17);
            this.tower1Label.TabIndex = 9;
            this.tower1Label.Text = "Tower 1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 593);
            this.Controls.Add(this.tower1Label);
            this.Controls.Add(this.lebensAnzeigeLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lebensLabel);
            this.Controls.Add(this.candyAnzeigeLabel);
            this.Controls.Add(this.candyLabel);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_Info);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label_Info;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label candyLabel;
        private System.Windows.Forms.Label candyAnzeigeLabel;
        private System.Windows.Forms.Label lebensLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lebensAnzeigeLabel;
        private System.Windows.Forms.Label tower1Label;
    }
}

