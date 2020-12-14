namespace CapaGUI
{
    partial class PantallaMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mantenedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bodegaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bodegueroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transaccionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarEntradaProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarSalidaProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mantenedoresToolStripMenuItem,
            this.transaccionesToolStripMenuItem,
            this.cerrarSesionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(494, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mantenedoresToolStripMenuItem
            // 
            this.mantenedoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productosToolStripMenuItem,
            this.proveedoresToolStripMenuItem,
            this.bodegaToolStripMenuItem,
            this.bodegueroToolStripMenuItem});
            this.mantenedoresToolStripMenuItem.Name = "mantenedoresToolStripMenuItem";
            this.mantenedoresToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.mantenedoresToolStripMenuItem.Text = "Mantenedores";
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.productosToolStripMenuItem.Text = "Productos";
            this.productosToolStripMenuItem.Click += new System.EventHandler(this.productosToolStripMenuItem_Click);
            // 
            // proveedoresToolStripMenuItem
            // 
            this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            this.proveedoresToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.proveedoresToolStripMenuItem.Text = "Proveedores";
            this.proveedoresToolStripMenuItem.Click += new System.EventHandler(this.proveedoresToolStripMenuItem_Click);
            // 
            // bodegaToolStripMenuItem
            // 
            this.bodegaToolStripMenuItem.Name = "bodegaToolStripMenuItem";
            this.bodegaToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.bodegaToolStripMenuItem.Text = "Bodega";
            this.bodegaToolStripMenuItem.Click += new System.EventHandler(this.bodegaToolStripMenuItem_Click);
            // 
            // bodegueroToolStripMenuItem
            // 
            this.bodegueroToolStripMenuItem.Name = "bodegueroToolStripMenuItem";
            this.bodegueroToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.bodegueroToolStripMenuItem.Text = "Bodeguero";
            this.bodegueroToolStripMenuItem.Click += new System.EventHandler(this.bodegueroToolStripMenuItem_Click);
            // 
            // cerrarSesionToolStripMenuItem
            // 
            this.cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            this.cerrarSesionToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.cerrarSesionToolStripMenuItem.Text = "Cerrar sesión";
            this.cerrarSesionToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesionToolStripMenuItem_Click);
            // 
            // transaccionesToolStripMenuItem
            // 
            this.transaccionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarEntradaProductosToolStripMenuItem,
            this.registrarSalidaProductosToolStripMenuItem});
            this.transaccionesToolStripMenuItem.Name = "transaccionesToolStripMenuItem";
            this.transaccionesToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.transaccionesToolStripMenuItem.Text = "Transacciones";
            // 
            // registrarEntradaProductosToolStripMenuItem
            // 
            this.registrarEntradaProductosToolStripMenuItem.Name = "registrarEntradaProductosToolStripMenuItem";
            this.registrarEntradaProductosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.registrarEntradaProductosToolStripMenuItem.Text = "Entrada productos";
            this.registrarEntradaProductosToolStripMenuItem.Click += new System.EventHandler(this.registrarEntradaProductosToolStripMenuItem_Click);
            // 
            // registrarSalidaProductosToolStripMenuItem
            // 
            this.registrarSalidaProductosToolStripMenuItem.Name = "registrarSalidaProductosToolStripMenuItem";
            this.registrarSalidaProductosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.registrarSalidaProductosToolStripMenuItem.Text = "Salida productos";
            this.registrarSalidaProductosToolStripMenuItem.Click += new System.EventHandler(this.registrarSalidaProductosToolStripMenuItem_Click);
            // 
            // PantallaMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 317);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PantallaMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PantallaMenu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mantenedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bodegaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bodegueroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transaccionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarEntradaProductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarSalidaProductosToolStripMenuItem;
    }
}