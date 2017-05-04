namespace BattleShip13.Vista
{
    partial class opciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(opciones));
            this.tipoNave = new System.Windows.Forms.CheckedListBox();
            this.aceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tipoNave
            // 
            this.tipoNave.BackColor = System.Drawing.Color.LightSlateGray;
            this.tipoNave.Font = new System.Drawing.Font("Ravie", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoNave.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.tipoNave.FormattingEnabled = true;
            this.tipoNave.Items.AddRange(new object[] {
            "Avión",
            "Barco",
            "Submarino"});
            this.tipoNave.Location = new System.Drawing.Point(84, 62);
            this.tipoNave.Name = "tipoNave";
            this.tipoNave.Size = new System.Drawing.Size(120, 94);
            this.tipoNave.TabIndex = 0;
            // 
            // aceptar
            // 
            this.aceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("aceptar.BackgroundImage")));
            this.aceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aceptar.ForeColor = System.Drawing.Color.Teal;
            this.aceptar.Location = new System.Drawing.Point(198, 226);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(74, 23);
            this.aceptar.TabIndex = 1;
            this.aceptar.Text = "Aceptar";
            this.aceptar.UseVisualStyleBackColor = true;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click_1);
            // 
            // opciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.tipoNave);
            this.Name = "opciones";
            this.Text = "opciones";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox tipoNave;
        private System.Windows.Forms.Button aceptar;
    }
}