namespace Agenda
{
    partial class FormAgenda
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAgenda));
            tableLayoutPanelPrincipal = new TableLayoutPanel();
            uc = new AgendaContactos.Componentes.UCContacts();
            panel1 = new Panel();
            guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            btnminus = new Guna.UI2.WinForms.Guna2CircleButton();
            tableLayoutPanelPrincipal.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanelPrincipal
            // 
            tableLayoutPanelPrincipal.ColumnCount = 1;
            tableLayoutPanelPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelPrincipal.Controls.Add(uc, 0, 1);
            tableLayoutPanelPrincipal.Controls.Add(panel1, 0, 0);
            tableLayoutPanelPrincipal.Dock = DockStyle.Fill;
            tableLayoutPanelPrincipal.Location = new Point(0, 0);
            tableLayoutPanelPrincipal.Name = "tableLayoutPanelPrincipal";
            tableLayoutPanelPrincipal.RowCount = 2;
            tableLayoutPanelPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanelPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelPrincipal.Size = new Size(667, 607);
            tableLayoutPanelPrincipal.TabIndex = 0;
            // 
            // uc
            // 
            uc.BackColor = Color.FromArgb(239, 230, 228);
            uc.Dock = DockStyle.Fill;
            uc.Location = new Point(3, 52);
            uc.Margin = new Padding(3, 2, 3, 2);
            uc.Name = "uc";
            uc.Size = new Size(661, 553);
            uc.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(239, 230, 228);
            panel1.Controls.Add(guna2CircleButton1);
            panel1.Controls.Add(btnminus);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(661, 44);
            panel1.TabIndex = 1;
            // 
            // guna2CircleButton1
            // 
            guna2CircleButton1.DisabledState.BorderColor = Color.DarkGray;
            guna2CircleButton1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2CircleButton1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2CircleButton1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2CircleButton1.FillColor = Color.FromArgb(227, 211, 208);
            guna2CircleButton1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2CircleButton1.ForeColor = Color.FromArgb(73, 37, 10);
            guna2CircleButton1.Location = new Point(609, 5);
            guna2CircleButton1.Margin = new Padding(3, 2, 3, 2);
            guna2CircleButton1.Name = "guna2CircleButton1";
            guna2CircleButton1.ShadowDecoration.CustomizableEdges = customizableEdges1;
            guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CircleButton1.Size = new Size(43, 37);
            guna2CircleButton1.TabIndex = 33;
            guna2CircleButton1.Text = "X";
            guna2CircleButton1.Click += guna2CircleButton1_Click;
            // 
            // btnminus
            // 
            btnminus.DisabledState.BorderColor = Color.DarkGray;
            btnminus.DisabledState.CustomBorderColor = Color.DarkGray;
            btnminus.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnminus.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnminus.FillColor = Color.FromArgb(227, 211, 208);
            btnminus.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnminus.ForeColor = Color.FromArgb(73, 37, 10);
            btnminus.Location = new Point(560, 5);
            btnminus.Margin = new Padding(3, 2, 3, 2);
            btnminus.Name = "btnminus";
            btnminus.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnminus.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            btnminus.Size = new Size(43, 37);
            btnminus.TabIndex = 32;
            btnminus.Text = "__";
            btnminus.Click += btnminus_Click;
            // 
            // FormAgenda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(239, 230, 228);
            ClientSize = new Size(667, 607);
            ControlBox = false;
            Controls.Add(tableLayoutPanelPrincipal);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormAgenda";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Agenda";
            tableLayoutPanelPrincipal.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanelPrincipal;
        private AgendaContactos.Componentes.UCContacts uc;
        private Panel panel1;
        private Guna.UI2.WinForms.Guna2CircleButton btnminus;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
    }
}
