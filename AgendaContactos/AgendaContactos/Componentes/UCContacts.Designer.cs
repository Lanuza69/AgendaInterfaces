namespace AgendaContactos.Componentes
{
    partial class UCContacts
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
            ucContactList = new UCContactList();
            ucExpandedContact = new UCExpandedContact();
            SuspendLayout();
            // 
            // ucContactList
            // 
            ucContactList.BackColor = Color.FromArgb(239, 230, 228);
            ucContactList.Location = new Point(12, 0);
            ucContactList.Name = "ucContactList";
            ucContactList.Size = new Size(799, 898);
            ucContactList.TabIndex = 0;
            // 
            // ucExpandedContact
            // 
            ucExpandedContact.BackColor = Color.FromArgb(239, 230, 228);
            ucExpandedContact.Location = new Point(3, 3);
            ucExpandedContact.Name = "ucExpandedContact";
            ucExpandedContact.Size = new Size(827, 689);
            ucExpandedContact.TabIndex = 1;
            // 
            // UCContacts
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(239, 230, 228);
            Controls.Add(ucExpandedContact);
            Controls.Add(ucContactList);
            Name = "UCContacts";
            Size = new Size(830, 784);
            ResumeLayout(false);
        }

        #endregion

        private UCContactList ucContactList;
        private UCExpandedContact ucExpandedContact;
    }
}
