namespace AgendaContactos.Componentes
{
    partial class UCContactList
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panelContacts = new FlowLayoutPanel();
            panelABC = new FlowLayoutPanel();
            btnNew = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // panelContacts
            // 
            panelContacts.AutoScroll = true;
            panelContacts.Location = new Point(18, 51);
            panelContacts.Margin = new Padding(3, 2, 3, 2);
            panelContacts.Name = "panelContacts";
            panelContacts.Size = new Size(540, 500);
            panelContacts.TabIndex = 1;
            // 
            // panelABC
            // 
            panelABC.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelABC.AutoSize = true;
            panelABC.FlowDirection = FlowDirection.TopDown;
            panelABC.Location = new Point(564, 51);
            panelABC.Margin = new Padding(3, 2, 3, 2);
            panelABC.Name = "panelABC";
            panelABC.Size = new Size(48, 519);
            panelABC.TabIndex = 2;
            // 
            // btnNew
            // 
            btnNew.BorderRadius = 20;
            btnNew.CustomizableEdges = customizableEdges3;
            btnNew.DisabledState.BorderColor = Color.DarkGray;
            btnNew.DisabledState.CustomBorderColor = Color.DarkGray;
            btnNew.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnNew.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnNew.FillColor = Color.FromArgb(205, 177, 171);
            btnNew.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNew.ForeColor = Color.FromArgb(73, 37, 10);
            btnNew.Location = new Point(416, 7);
            btnNew.Margin = new Padding(3, 2, 3, 2);
            btnNew.Name = "btnNew";
            btnNew.ShadowDecoration.BorderRadius = 20;
            btnNew.ShadowDecoration.Color = Color.FromArgb(64, 0, 0);
            btnNew.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnNew.Size = new Size(142, 37);
            btnNew.TabIndex = 27;
            btnNew.Text = "Nuevo Contacto";
            // 
            // UCContactList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(239, 230, 228);
            Controls.Add(btnNew);
            Controls.Add(panelABC);
            Controls.Add(panelContacts);
            Margin = new Padding(3, 2, 3, 2);
            Name = "UCContactList";
            Size = new Size(633, 837);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel panelContacts;
        private FlowLayoutPanel panelABC;
        private Guna.UI2.WinForms.Guna2Button btnNew;
    }
}
