﻿namespace BimManager.Client.WipApp
{
    partial class FrmPrespuestoCategoria
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
            this.BnNuevo = new System.Windows.Forms.Button();
            this.BnEditar = new System.Windows.Forms.Button();
            this.BnDeshabilitar = new System.Windows.Forms.Button();
            this.BnBuscar = new System.Windows.Forms.Button();
            this.BnSalir = new System.Windows.Forms.Button();
            this.tvPresupuestoCategoria = new System.Windows.Forms.TreeView();
            this.BnNuevoSubcategoria = new System.Windows.Forms.Button();
            this.ChkExpandirTodo = new System.Windows.Forms.CheckBox();
            this.ChkContraerTodo = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Highlight;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(982, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mantenedor - Presupuesto Categoría";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BnNuevo
            // 
            this.BnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BnNuevo.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnNuevo.Image = global::BimManager.Client.WipApp.Properties.Resources.Nuevo;
            this.BnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnNuevo.Location = new System.Drawing.Point(12, 658);
            this.BnNuevo.Name = "BnNuevo";
            this.BnNuevo.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnNuevo.Size = new System.Drawing.Size(160, 35);
            this.BnNuevo.TabIndex = 4;
            this.BnNuevo.Text = "Nueva Categoría";
            this.BnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnNuevo.UseVisualStyleBackColor = true;
            this.BnNuevo.Click += new System.EventHandler(this.BnNuevo_Click);
            // 
            // BnEditar
            // 
            this.BnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BnEditar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnEditar.Image = global::BimManager.Client.WipApp.Properties.Resources.Editar;
            this.BnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnEditar.Location = new System.Drawing.Point(364, 658);
            this.BnEditar.Name = "BnEditar";
            this.BnEditar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnEditar.Size = new System.Drawing.Size(110, 35);
            this.BnEditar.TabIndex = 6;
            this.BnEditar.Text = "Editar";
            this.BnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnEditar.UseVisualStyleBackColor = true;
            this.BnEditar.Click += new System.EventHandler(this.BnEditar_Click);
            // 
            // BnDeshabilitar
            // 
            this.BnDeshabilitar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BnDeshabilitar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnDeshabilitar.Image = global::BimManager.Client.WipApp.Properties.Resources.Anular;
            this.BnDeshabilitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnDeshabilitar.Location = new System.Drawing.Point(480, 658);
            this.BnDeshabilitar.Name = "BnDeshabilitar";
            this.BnDeshabilitar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnDeshabilitar.Size = new System.Drawing.Size(137, 35);
            this.BnDeshabilitar.TabIndex = 7;
            this.BnDeshabilitar.Text = "Deshabilitar";
            this.BnDeshabilitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnDeshabilitar.UseVisualStyleBackColor = true;
            this.BnDeshabilitar.Click += new System.EventHandler(this.BnDeshabilitar_Click);
            // 
            // BnBuscar
            // 
            this.BnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BnBuscar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnBuscar.Image = global::BimManager.Client.WipApp.Properties.Resources.Buscar;
            this.BnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnBuscar.Location = new System.Drawing.Point(623, 658);
            this.BnBuscar.Name = "BnBuscar";
            this.BnBuscar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnBuscar.Size = new System.Drawing.Size(110, 35);
            this.BnBuscar.TabIndex = 8;
            this.BnBuscar.Text = "Buscar";
            this.BnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnBuscar.UseVisualStyleBackColor = true;
            this.BnBuscar.Click += new System.EventHandler(this.BnBuscar_Click);
            // 
            // BnSalir
            // 
            this.BnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BnSalir.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnSalir.Image = global::BimManager.Client.WipApp.Properties.Resources.Cerrar;
            this.BnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnSalir.Location = new System.Drawing.Point(860, 658);
            this.BnSalir.Name = "BnSalir";
            this.BnSalir.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnSalir.Size = new System.Drawing.Size(110, 35);
            this.BnSalir.TabIndex = 9;
            this.BnSalir.Text = "Salir";
            this.BnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnSalir.UseVisualStyleBackColor = true;
            this.BnSalir.Click += new System.EventHandler(this.BnSalir_Click);
            // 
            // tvPresupuestoCategoria
            // 
            this.tvPresupuestoCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvPresupuestoCategoria.FullRowSelect = true;
            this.tvPresupuestoCategoria.HideSelection = false;
            this.tvPresupuestoCategoria.Location = new System.Drawing.Point(12, 66);
            this.tvPresupuestoCategoria.Name = "tvPresupuestoCategoria";
            this.tvPresupuestoCategoria.Size = new System.Drawing.Size(958, 584);
            this.tvPresupuestoCategoria.TabIndex = 3;
            // 
            // BnNuevoSubcategoria
            // 
            this.BnNuevoSubcategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BnNuevoSubcategoria.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BnNuevoSubcategoria.Image = global::BimManager.Client.WipApp.Properties.Resources.Nuevo;
            this.BnNuevoSubcategoria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BnNuevoSubcategoria.Location = new System.Drawing.Point(178, 658);
            this.BnNuevoSubcategoria.Name = "BnNuevoSubcategoria";
            this.BnNuevoSubcategoria.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BnNuevoSubcategoria.Size = new System.Drawing.Size(181, 35);
            this.BnNuevoSubcategoria.TabIndex = 5;
            this.BnNuevoSubcategoria.Text = "Nueva Subcategoría";
            this.BnNuevoSubcategoria.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BnNuevoSubcategoria.UseVisualStyleBackColor = true;
            this.BnNuevoSubcategoria.Click += new System.EventHandler(this.BnNuevoSubcategoria_Click);
            // 
            // ChkExpandirTodo
            // 
            this.ChkExpandirTodo.AutoSize = true;
            this.ChkExpandirTodo.Location = new System.Drawing.Point(12, 39);
            this.ChkExpandirTodo.Name = "ChkExpandirTodo";
            this.ChkExpandirTodo.Size = new System.Drawing.Size(138, 25);
            this.ChkExpandirTodo.TabIndex = 10;
            this.ChkExpandirTodo.Text = "Expandir Todo";
            this.ChkExpandirTodo.UseVisualStyleBackColor = true;
            this.ChkExpandirTodo.CheckedChanged += new System.EventHandler(this.ChkExpandirTodo_CheckedChanged);
            // 
            // ChkContraerTodo
            // 
            this.ChkContraerTodo.AutoSize = true;
            this.ChkContraerTodo.Location = new System.Drawing.Point(142, 39);
            this.ChkContraerTodo.Name = "ChkContraerTodo";
            this.ChkContraerTodo.Size = new System.Drawing.Size(138, 25);
            this.ChkContraerTodo.TabIndex = 11;
            this.ChkContraerTodo.Text = "Contraer Todo";
            this.ChkContraerTodo.UseVisualStyleBackColor = true;
            this.ChkContraerTodo.CheckedChanged += new System.EventHandler(this.ChkContraerTodo_CheckedChanged);
            // 
            // FrmPrespuestoCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 703);
            this.Controls.Add(this.ChkContraerTodo);
            this.Controls.Add(this.ChkExpandirTodo);
            this.Controls.Add(this.BnNuevoSubcategoria);
            this.Controls.Add(this.tvPresupuestoCategoria);
            this.Controls.Add(this.BnSalir);
            this.Controls.Add(this.BnBuscar);
            this.Controls.Add(this.BnDeshabilitar);
            this.Controls.Add(this.BnEditar);
            this.Controls.Add(this.BnNuevo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmPrespuestoCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Mantenedor - Presupuesto Categoría";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrespuestoCategoria_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCliente_FormClosed);
            this.Load += new System.EventHandler(this.FrmPrespuestoCategoria_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BnNuevo;
        private System.Windows.Forms.Button BnEditar;
        private System.Windows.Forms.Button BnDeshabilitar;
        private System.Windows.Forms.Button BnSalir;
        private System.Windows.Forms.Button BnNuevoSubcategoria;
        private System.Windows.Forms.CheckBox ChkExpandirTodo;
        private System.Windows.Forms.CheckBox ChkContraerTodo;
        public System.Windows.Forms.TreeView tvPresupuestoCategoria;
        public System.Windows.Forms.Button BnBuscar;
    }
}