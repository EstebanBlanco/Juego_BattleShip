namespace BattleShip13.Vista
{
    partial class Sea
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sea));
            this.jugar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // jugar
            // 
            this.jugar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.jugar.Font = new System.Drawing.Font("Moire", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jugar.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.jugar.Location = new System.Drawing.Point(745, 408);
            this.jugar.Name = "jugar";
            this.jugar.Size = new System.Drawing.Size(75, 29);
            this.jugar.TabIndex = 0;
            this.jugar.Text = "Jugar";
            this.jugar.UseVisualStyleBackColor = true;
            this.jugar.Click += new System.EventHandler(this.jugar_Click);
            // 
            // Sea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.jugar);
            this.DoubleBuffered = true;
            this.Name = "Sea";
            this.Text = "Sea";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button jugar;
    }
}