namespace CapaGUI
{
    partial class PantallaMantenedorBodega
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigoBodega = new System.Windows.Forms.TextBox();
            this.txtNombreBodega = new System.Windows.Forms.TextBox();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnPrimero = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btoUltimo = new System.Windows.Forms.Button();
            this.btnListar = new System.Windows.Forms.Button();
            this.txtPosicion = new System.Windows.Forms.TextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre";
            // 
            // txtCodigoBodega
            // 
            this.txtCodigoBodega.Enabled = false;
            this.txtCodigoBodega.Location = new System.Drawing.Point(118, 40);
            this.txtCodigoBodega.Name = "txtCodigoBodega";
            this.txtCodigoBodega.Size = new System.Drawing.Size(155, 20);
            this.txtCodigoBodega.TabIndex = 2;
            // 
            // txtNombreBodega
            // 
            this.txtNombreBodega.Enabled = false;
            this.txtNombreBodega.Location = new System.Drawing.Point(118, 66);
            this.txtNombreBodega.Name = "txtNombreBodega";
            this.txtNombreBodega.Size = new System.Drawing.Size(155, 20);
            this.txtNombreBodega.TabIndex = 3;
            // 
            // btnAnterior
            // 
            this.btnAnterior.Location = new System.Drawing.Point(118, 149);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(75, 23);
            this.btnAnterior.TabIndex = 10;
            this.btnAnterior.Text = "<";
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnPrimero
            // 
            this.btnPrimero.Location = new System.Drawing.Point(37, 149);
            this.btnPrimero.Name = "btnPrimero";
            this.btnPrimero.Size = new System.Drawing.Size(75, 23);
            this.btnPrimero.TabIndex = 9;
            this.btnPrimero.Text = "<|";
            this.btnPrimero.UseVisualStyleBackColor = true;
            this.btnPrimero.Click += new System.EventHandler(this.btnPrimero_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(280, 149);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(75, 23);
            this.btnSiguiente.TabIndex = 11;
            this.btnSiguiente.Text = ">";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(361, 120);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btoUltimo
            // 
            this.btoUltimo.Location = new System.Drawing.Point(361, 149);
            this.btoUltimo.Name = "btoUltimo";
            this.btoUltimo.Size = new System.Drawing.Size(75, 23);
            this.btoUltimo.TabIndex = 12;
            this.btoUltimo.Text = "|>";
            this.btoUltimo.UseVisualStyleBackColor = true;
            this.btoUltimo.Click += new System.EventHandler(this.btoUltimo_Click);
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(280, 120);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(75, 23);
            this.btnListar.TabIndex = 7;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // txtPosicion
            // 
            this.txtPosicion.Enabled = false;
            this.txtPosicion.Location = new System.Drawing.Point(199, 149);
            this.txtPosicion.Name = "txtPosicion";
            this.txtPosicion.Size = new System.Drawing.Size(74, 20);
            this.txtPosicion.TabIndex = 13;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(199, 120);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(118, 120);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 5;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(37, 120);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(75, 23);
            this.btnRegistrar.TabIndex = 4;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // PantallaMantenedorBodega
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 200);
            this.Controls.Add(this.txtNombreBodega);
            this.Controls.Add(this.txtCodigoBodega);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnAnterior);
            this.Controls.Add(this.btnPrimero);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btoUltimo);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.txtPosicion);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnActualizar);
            this.Name = "PantallaMantenedorBodega";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PantallaMantenedorBodega";
            this.Load += new System.EventHandler(this.PantallaMantenedorBodega_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigoBodega;
        private System.Windows.Forms.TextBox txtNombreBodega;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnPrimero;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btoUltimo;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.TextBox txtPosicion;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnRegistrar;
    }
}