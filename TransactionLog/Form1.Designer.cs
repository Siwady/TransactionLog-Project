namespace TransactionLog
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DataSource = new System.Windows.Forms.TextBox();
            this.Catalog = new System.Windows.Forms.TextBox();
            this.UserId = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.Table = new System.Windows.Forms.TextBox();
            this.bt_Cargar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(635, 228);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Convertir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(229, 54);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 168);
            this.dataGridView1.TabIndex = 2;
            // 
            // DataSource
            // 
            this.DataSource.Location = new System.Drawing.Point(82, 53);
            this.DataSource.Name = "DataSource";
            this.DataSource.Size = new System.Drawing.Size(135, 20);
            this.DataSource.TabIndex = 3;
            this.DataSource.Text = "SIWADY-PC";
            // 
            // Catalog
            // 
            this.Catalog.Location = new System.Drawing.Point(82, 90);
            this.Catalog.Name = "Catalog";
            this.Catalog.Size = new System.Drawing.Size(135, 20);
            this.Catalog.TabIndex = 4;
            this.Catalog.Text = "Proyecto";
            // 
            // UserId
            // 
            this.UserId.Location = new System.Drawing.Point(82, 126);
            this.UserId.Name = "UserId";
            this.UserId.Size = new System.Drawing.Size(135, 20);
            this.UserId.TabIndex = 5;
            this.UserId.Text = "sa";
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(82, 162);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(135, 20);
            this.Password.TabIndex = 6;
            this.Password.Text = "thekillers";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(64, 197);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Conectar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Table
            // 
            this.Table.Location = new System.Drawing.Point(277, 26);
            this.Table.Name = "Table";
            this.Table.Size = new System.Drawing.Size(266, 20);
            this.Table.TabIndex = 8;
            // 
            // bt_Cargar
            // 
            this.bt_Cargar.Location = new System.Drawing.Point(550, 26);
            this.bt_Cargar.Name = "bt_Cargar";
            this.bt_Cargar.Size = new System.Drawing.Size(75, 23);
            this.bt_Cargar.TabIndex = 9;
            this.bt_Cargar.Text = "Cargar";
            this.bt_Cargar.UseVisualStyleBackColor = true;
            this.bt_Cargar.Click += new System.EventHandler(this.bt_Cargar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(235, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tabla: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Computadora: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "BaseDeDatos: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Usuario: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Contraseña: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 262);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_Cargar);
            this.Controls.Add(this.Table);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.UserId);
            this.Controls.Add(this.Catalog);
            this.Controls.Add(this.DataSource);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox DataSource;
        private System.Windows.Forms.TextBox Catalog;
        private System.Windows.Forms.TextBox UserId;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox Table;
        private System.Windows.Forms.Button bt_Cargar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

