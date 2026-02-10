namespace AgendaContactos.Componentes
{
    partial class UCCollapsedContact
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pictureBoxFoto = new PictureBox();
            lblNombre = new Label();
            lblTelefono = new Label();
            lblEmail = new Label();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBoxFoto).BeginInit();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBoxFoto
            // 
            pictureBoxFoto.Location = new Point(43, 29);
            pictureBoxFoto.Name = "pictureBoxFoto";
            pictureBoxFoto.Size = new Size(160, 146);
            pictureBoxFoto.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxFoto.TabIndex = 0;
            pictureBoxFoto.TabStop = false;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.BackColor = Color.FromArgb(227, 211, 208);
            lblNombre.Font = new Font("Cambria", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombre.ForeColor = Color.FromArgb(73, 37, 10);
            lblNombre.Location = new Point(239, 29);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(0, 21);
            lblNombre.TabIndex = 1;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.BackColor = Color.FromArgb(227, 211, 208);
            lblTelefono.Font = new Font("Cambria", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTelefono.ForeColor = Color.FromArgb(73, 37, 10);
            lblTelefono.Location = new Point(239, 91);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(0, 21);
            lblTelefono.TabIndex = 2;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.BackColor = Color.FromArgb(227, 211, 208);
            lblEmail.Font = new Font("Cambria", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.ForeColor = Color.FromArgb(73, 37, 10);
            lblEmail.Location = new Point(239, 155);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(0, 21);
            lblEmail.TabIndex = 3;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BorderRadius = 50;
            guna2Panel1.Controls.Add(pictureBoxFoto);
            guna2Panel1.Controls.Add(lblTelefono);
            guna2Panel1.Controls.Add(lblEmail);
            guna2Panel1.Controls.Add(lblNombre);
            guna2Panel1.CustomizableEdges = customizableEdges1;
            guna2Panel1.Dock = DockStyle.Fill;
            guna2Panel1.FillColor = Color.FromArgb(227, 211, 208);
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Panel1.Size = new Size(584, 207);
            guna2Panel1.TabIndex = 6;
            // 
            // UCCollapsedContact
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(239, 230, 228);
            Controls.Add(guna2Panel1);
            Name = "UCCollapsedContact";
            Size = new Size(584, 207);
            ((System.ComponentModel.ISupportInitialize)pictureBoxFoto).EndInit();
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxFoto;
        private Label lblNombre;
        private Label lblTelefono;
        private Label lblEmail;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}
