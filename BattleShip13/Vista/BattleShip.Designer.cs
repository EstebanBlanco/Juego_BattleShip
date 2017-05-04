namespace BattleShip13.Vista
{
    partial class BattleShip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BattleShip));
            this.nivel1 = new System.Windows.Forms.Button();
            this.nivel2 = new System.Windows.Forms.Button();
            this.nivel3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nivel1
            // 
            this.nivel1.Location = new System.Drawing.Point(411, 130);
            this.nivel1.Name = "nivel1";
            this.nivel1.Size = new System.Drawing.Size(75, 23);
            this.nivel1.TabIndex = 0;
            this.nivel1.Text = "Nivel 1";
            this.nivel1.UseVisualStyleBackColor = true;
            this.nivel1.Click += new System.EventHandler(this.nivel1_Click_1);
            // 
            // nivel2
            // 
            this.nivel2.Location = new System.Drawing.Point(411, 159);
            this.nivel2.Name = "nivel2";
            this.nivel2.Size = new System.Drawing.Size(75, 23);
            this.nivel2.TabIndex = 1;
            this.nivel2.Text = "Nivel 2";
            this.nivel2.UseVisualStyleBackColor = true;
            this.nivel2.Click += new System.EventHandler(this.nivel2_Click_1);
            // 
            // nivel3
            // 
            this.nivel3.Location = new System.Drawing.Point(411, 188);
            this.nivel3.Name = "nivel3";
            this.nivel3.Size = new System.Drawing.Size(75, 23);
            this.nivel3.TabIndex = 2;
            this.nivel3.Text = "Nivel 3";
            this.nivel3.UseVisualStyleBackColor = true;
            this.nivel3.Click += new System.EventHandler(this.nivel3_Click_1);
            // 
            // BattleShip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(608, 358);
            this.Controls.Add(this.nivel3);
            this.Controls.Add(this.nivel2);
            this.Controls.Add(this.nivel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "BattleShip";
            this.Text = "BattleShip";
            this.Load += new System.EventHandler(this.BattleShip_Load_1);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button nivel1;
        private System.Windows.Forms.Button nivel2;
        private System.Windows.Forms.Button nivel3;
    }
}