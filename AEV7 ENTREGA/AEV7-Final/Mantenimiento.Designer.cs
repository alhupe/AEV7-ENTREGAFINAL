namespace EjemploFechasHoras
{
    partial class Mantenimiento
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
            this.components = new System.ComponentModel.Container();
            this.btnListarEmpleados = new System.Windows.Forms.Button();
            this.dgvFichajes = new System.Windows.Forms.DataGridView();
            this.dgvEmpleados = new System.Windows.Forms.DataGridView();
            this.btnAgregarEmpleado = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBorrarEmpleado = new System.Windows.Forms.Button();
            this.lblClaveNuevo = new System.Windows.Forms.Label();
            this.lblApellidoNuevo = new System.Windows.Forms.Label();
            this.lblNombreNuevo = new System.Windows.Forms.Label();
            this.lblNifNuevo = new System.Windows.Forms.Label();
            this.chbAdministradorNuevo = new System.Windows.Forms.CheckBox();
            this.txtClaveNuevo = new System.Windows.Forms.TextBox();
            this.txtApellidoNuevo = new System.Windows.Forms.TextBox();
            this.txtNombreNuevo = new System.Windows.Forms.TextBox();
            this.txtNifNuevo = new System.Windows.Forms.TextBox();
            this.btnSalirMantenimiento = new System.Windows.Forms.Button();
            this.btnCerrarApp = new System.Windows.Forms.Button();
            this.empleadoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.fichajeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.empleadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFichajes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.empleadoBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fichajeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empleadoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnListarEmpleados
            // 
            this.btnListarEmpleados.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.btnListarEmpleados.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListarEmpleados.Location = new System.Drawing.Point(930, 442);
            this.btnListarEmpleados.Margin = new System.Windows.Forms.Padding(4);
            this.btnListarEmpleados.Name = "btnListarEmpleados";
            this.btnListarEmpleados.Size = new System.Drawing.Size(228, 68);
            this.btnListarEmpleados.TabIndex = 17;
            this.btnListarEmpleados.Text = "Informe Empleados";
            this.btnListarEmpleados.UseVisualStyleBackColor = false;
            this.btnListarEmpleados.Click += new System.EventHandler(this.btnListarEmpleados_Click);
            // 
            // dgvFichajes
            // 
            this.dgvFichajes.AllowUserToOrderColumns = true;
            this.dgvFichajes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFichajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFichajes.Location = new System.Drawing.Point(26, 306);
            this.dgvFichajes.Name = "dgvFichajes";
            this.dgvFichajes.RowHeadersWidth = 51;
            this.dgvFichajes.RowTemplate.Height = 24;
            this.dgvFichajes.Size = new System.Drawing.Size(833, 220);
            this.dgvFichajes.TabIndex = 18;
            // 
            // dgvEmpleados
            // 
            this.dgvEmpleados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpleados.Location = new System.Drawing.Point(26, 49);
            this.dgvEmpleados.Name = "dgvEmpleados";
            this.dgvEmpleados.RowHeadersWidth = 51;
            this.dgvEmpleados.RowTemplate.Height = 24;
            this.dgvEmpleados.Size = new System.Drawing.Size(833, 225);
            this.dgvEmpleados.TabIndex = 19;
            // 
            // btnAgregarEmpleado
            // 
            this.btnAgregarEmpleado.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.btnAgregarEmpleado.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarEmpleado.Location = new System.Drawing.Point(26, 277);
            this.btnAgregarEmpleado.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregarEmpleado.Name = "btnAgregarEmpleado";
            this.btnAgregarEmpleado.Size = new System.Drawing.Size(228, 65);
            this.btnAgregarEmpleado.TabIndex = 20;
            this.btnAgregarEmpleado.Text = "Agregar Empleado";
            this.btnAgregarEmpleado.UseVisualStyleBackColor = false;
            this.btnAgregarEmpleado.Click += new System.EventHandler(this.btnAgregarEmpleado_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBorrarEmpleado);
            this.groupBox1.Controls.Add(this.lblClaveNuevo);
            this.groupBox1.Controls.Add(this.lblApellidoNuevo);
            this.groupBox1.Controls.Add(this.btnAgregarEmpleado);
            this.groupBox1.Controls.Add(this.lblNombreNuevo);
            this.groupBox1.Controls.Add(this.lblNifNuevo);
            this.groupBox1.Controls.Add(this.chbAdministradorNuevo);
            this.groupBox1.Controls.Add(this.txtClaveNuevo);
            this.groupBox1.Controls.Add(this.txtApellidoNuevo);
            this.groupBox1.Controls.Add(this.txtNombreNuevo);
            this.groupBox1.Controls.Add(this.txtNifNuevo);
            this.groupBox1.Location = new System.Drawing.Point(904, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(545, 361);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // btnBorrarEmpleado
            // 
            this.btnBorrarEmpleado.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.btnBorrarEmpleado.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrarEmpleado.Location = new System.Drawing.Point(289, 277);
            this.btnBorrarEmpleado.Margin = new System.Windows.Forms.Padding(4);
            this.btnBorrarEmpleado.Name = "btnBorrarEmpleado";
            this.btnBorrarEmpleado.Size = new System.Drawing.Size(228, 65);
            this.btnBorrarEmpleado.TabIndex = 31;
            this.btnBorrarEmpleado.Text = "Borrar Empleado";
            this.btnBorrarEmpleado.UseVisualStyleBackColor = false;
            this.btnBorrarEmpleado.Click += new System.EventHandler(this.btnBorrarEmpleado_Click);
            // 
            // lblClaveNuevo
            // 
            this.lblClaveNuevo.AutoSize = true;
            this.lblClaveNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClaveNuevo.Location = new System.Drawing.Point(27, 223);
            this.lblClaveNuevo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClaveNuevo.Name = "lblClaveNuevo";
            this.lblClaveNuevo.Size = new System.Drawing.Size(86, 29);
            this.lblClaveNuevo.TabIndex = 30;
            this.lblClaveNuevo.Text = "Clave:";
            // 
            // lblApellidoNuevo
            // 
            this.lblApellidoNuevo.AutoSize = true;
            this.lblApellidoNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellidoNuevo.Location = new System.Drawing.Point(27, 140);
            this.lblApellidoNuevo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApellidoNuevo.Name = "lblApellidoNuevo";
            this.lblApellidoNuevo.Size = new System.Drawing.Size(117, 29);
            this.lblApellidoNuevo.TabIndex = 29;
            this.lblApellidoNuevo.Text = "Apellido:";
            // 
            // lblNombreNuevo
            // 
            this.lblNombreNuevo.AutoSize = true;
            this.lblNombreNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreNuevo.Location = new System.Drawing.Point(27, 89);
            this.lblNombreNuevo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreNuevo.Name = "lblNombreNuevo";
            this.lblNombreNuevo.Size = new System.Drawing.Size(114, 29);
            this.lblNombreNuevo.TabIndex = 28;
            this.lblNombreNuevo.Text = "Nombre:";
            // 
            // lblNifNuevo
            // 
            this.lblNifNuevo.AutoSize = true;
            this.lblNifNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNifNuevo.Location = new System.Drawing.Point(27, 39);
            this.lblNifNuevo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNifNuevo.Name = "lblNifNuevo";
            this.lblNifNuevo.Size = new System.Drawing.Size(62, 29);
            this.lblNifNuevo.TabIndex = 27;
            this.lblNifNuevo.Text = "NIF:";
            // 
            // chbAdministradorNuevo
            // 
            this.chbAdministradorNuevo.AutoSize = true;
            this.chbAdministradorNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbAdministradorNuevo.Location = new System.Drawing.Point(190, 186);
            this.chbAdministradorNuevo.Name = "chbAdministradorNuevo";
            this.chbAdministradorNuevo.Size = new System.Drawing.Size(167, 29);
            this.chbAdministradorNuevo.TabIndex = 26;
            this.chbAdministradorNuevo.Text = "Administrador";
            this.chbAdministradorNuevo.UseVisualStyleBackColor = true;
            // 
            // txtClaveNuevo
            // 
            this.txtClaveNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClaveNuevo.Location = new System.Drawing.Point(190, 223);
            this.txtClaveNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.txtClaveNuevo.Name = "txtClaveNuevo";
            this.txtClaveNuevo.Size = new System.Drawing.Size(255, 30);
            this.txtClaveNuevo.TabIndex = 25;
            // 
            // txtApellidoNuevo
            // 
            this.txtApellidoNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidoNuevo.Location = new System.Drawing.Point(190, 140);
            this.txtApellidoNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.txtApellidoNuevo.Name = "txtApellidoNuevo";
            this.txtApellidoNuevo.Size = new System.Drawing.Size(255, 30);
            this.txtApellidoNuevo.TabIndex = 24;
            this.txtApellidoNuevo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellidoNuevo_KeyPress);
            // 
            // txtNombreNuevo
            // 
            this.txtNombreNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreNuevo.Location = new System.Drawing.Point(190, 88);
            this.txtNombreNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreNuevo.Name = "txtNombreNuevo";
            this.txtNombreNuevo.Size = new System.Drawing.Size(255, 30);
            this.txtNombreNuevo.TabIndex = 23;
            this.txtNombreNuevo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreNuevo_KeyPress);
            // 
            // txtNifNuevo
            // 
            this.txtNifNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNifNuevo.Location = new System.Drawing.Point(190, 39);
            this.txtNifNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.txtNifNuevo.Name = "txtNifNuevo";
            this.txtNifNuevo.Size = new System.Drawing.Size(255, 30);
            this.txtNifNuevo.TabIndex = 22;
            this.txtNifNuevo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNifNuevo_KeyPress);
            // 
            // btnSalirMantenimiento
            // 
            this.btnSalirMantenimiento.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.btnSalirMantenimiento.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalirMantenimiento.Location = new System.Drawing.Point(1193, 442);
            this.btnSalirMantenimiento.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalirMantenimiento.Name = "btnSalirMantenimiento";
            this.btnSalirMantenimiento.Size = new System.Drawing.Size(228, 68);
            this.btnSalirMantenimiento.TabIndex = 22;
            this.btnSalirMantenimiento.Text = "Salir de Mantenimiento";
            this.btnSalirMantenimiento.UseVisualStyleBackColor = false;
            this.btnSalirMantenimiento.Click += new System.EventHandler(this.btnSalirMantenimiento_Click);
            // 
            // btnCerrarApp
            // 
            this.btnCerrarApp.BackColor = System.Drawing.Color.LightCoral;
            this.btnCerrarApp.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarApp.Location = new System.Drawing.Point(1193, 542);
            this.btnCerrarApp.Margin = new System.Windows.Forms.Padding(4);
            this.btnCerrarApp.Name = "btnCerrarApp";
            this.btnCerrarApp.Size = new System.Drawing.Size(228, 68);
            this.btnCerrarApp.TabIndex = 23;
            this.btnCerrarApp.Text = "Cerrar Aplicación";
            this.btnCerrarApp.UseVisualStyleBackColor = false;
            this.btnCerrarApp.Click += new System.EventHandler(this.btnCerrarApp_Click);
            // 
            // empleadoBindingSource1
            // 
            this.empleadoBindingSource1.DataSource = typeof(EjemploFechasHoras.Empleado);
            // 
            // fichajeBindingSource
            // 
            this.fichajeBindingSource.DataSource = typeof(EjemploFechasHoras.Fichaje);
            // 
            // empleadoBindingSource
            // 
            this.empleadoBindingSource.DataSource = typeof(EjemploFechasHoras.Empleado);
            // 
            // Mantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 633);
            this.Controls.Add(this.btnCerrarApp);
            this.Controls.Add(this.btnSalirMantenimiento);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvEmpleados);
            this.Controls.Add(this.dgvFichajes);
            this.Controls.Add(this.btnListarEmpleados);
            this.Name = "Mantenimiento";
            this.Text = "Mantenimiento";
            this.Load += new System.EventHandler(this.Mantenimiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFichajes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.empleadoBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fichajeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empleadoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource empleadoBindingSource;
        private System.Windows.Forms.BindingSource empleadoBindingSource1;
        private System.Windows.Forms.Button btnListarEmpleados;
        private System.Windows.Forms.BindingSource fichajeBindingSource;
        private System.Windows.Forms.DataGridView dgvFichajes;
        private System.Windows.Forms.DataGridView dgvEmpleados;
        private System.Windows.Forms.Button btnAgregarEmpleado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chbAdministradorNuevo;
        private System.Windows.Forms.TextBox txtClaveNuevo;
        private System.Windows.Forms.TextBox txtApellidoNuevo;
        private System.Windows.Forms.TextBox txtNombreNuevo;
        private System.Windows.Forms.TextBox txtNifNuevo;
        private System.Windows.Forms.Label lblClaveNuevo;
        private System.Windows.Forms.Label lblApellidoNuevo;
        private System.Windows.Forms.Label lblNombreNuevo;
        private System.Windows.Forms.Label lblNifNuevo;
        private System.Windows.Forms.Button btnBorrarEmpleado;
        private System.Windows.Forms.Button btnSalirMantenimiento;
        private System.Windows.Forms.Button btnCerrarApp;
    }
}