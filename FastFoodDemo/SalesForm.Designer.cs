namespace FastFoodDemo
{
    partial class SalesForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSales = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelIdentify = new System.Windows.Forms.Panel();
            this.dgProductSelected = new System.Windows.Forms.DataGridView();
            this.IdVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnVender = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.lblsubt = new System.Windows.Forms.Label();
            this.txttotal = new System.Windows.Forms.Label();
            this.lblSubTotalAmount = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblTel2 = new System.Windows.Forms.Label();
            this.lblTel1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblDir = new System.Windows.Forms.Label();
            this.lblLogo = new System.Windows.Forms.Label();
            this.chkComprobante = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtNCF = new System.Windows.Forms.TextBox();
            this.combo_tipo_NCF = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panelIdentify.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductSelected)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.panel1.Location = new System.Drawing.Point(0, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1053, 5);
            this.panel1.TabIndex = 105;
            // 
            // lblSales
            // 
            this.lblSales.AutoSize = true;
            this.lblSales.BackColor = System.Drawing.Color.Transparent;
            this.lblSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSales.Location = new System.Drawing.Point(442, 18);
            this.lblSales.Name = "lblSales";
            this.lblSales.Size = new System.Drawing.Size(90, 31);
            this.lblSales.TabIndex = 106;
            this.lblSales.Text = "Venta";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1053, 5);
            this.panel2.TabIndex = 106;
            // 
            // panelIdentify
            // 
            this.panelIdentify.Controls.Add(this.label8);
            this.panelIdentify.Controls.Add(this.panel2);
            this.panelIdentify.Controls.Add(this.lblSales);
            this.panelIdentify.Location = new System.Drawing.Point(0, 0);
            this.panelIdentify.Name = "panelIdentify";
            this.panelIdentify.Size = new System.Drawing.Size(1053, 69);
            this.panelIdentify.TabIndex = 104;
            // 
            // dgProductSelected
            // 
            this.dgProductSelected.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProductSelected.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgProductSelected.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProductSelected.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdVenta,
            this.NameProd,
            this.Quantity,
            this.PriceProd,
            this.SubTotal});
            this.dgProductSelected.Location = new System.Drawing.Point(448, 195);
            this.dgProductSelected.Name = "dgProductSelected";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProductSelected.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgProductSelected.Size = new System.Drawing.Size(566, 321);
            this.dgProductSelected.TabIndex = 106;
            // 
            // IdVenta
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IdVenta.DefaultCellStyle = dataGridViewCellStyle2;
            this.IdVenta.HeaderText = "ID";
            this.IdVenta.Name = "IdVenta";
            this.IdVenta.ReadOnly = true;
            // 
            // NameProd
            // 
            this.NameProd.HeaderText = "Producto";
            this.NameProd.Name = "NameProd";
            this.NameProd.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Cantidad";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // PriceProd
            // 
            this.PriceProd.HeaderText = "Precio";
            this.PriceProd.Name = "PriceProd";
            this.PriceProd.ReadOnly = true;
            // 
            // SubTotal
            // 
            this.SubTotal.HeaderText = "SubTotal";
            this.SubTotal.Name = "SubTotal";
            this.SubTotal.ReadOnly = true;
            // 
            // btnVender
            // 
            this.btnVender.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnVender.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnVender.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnVender.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnVender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVender.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVender.ForeColor = System.Drawing.Color.Black;
            this.btnVender.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVender.Location = new System.Drawing.Point(855, 94);
            this.btnVender.Name = "btnVender";
            this.btnVender.Size = new System.Drawing.Size(159, 72);
            this.btnVender.TabIndex = 108;
            this.btnVender.Text = "Vender";
            this.btnVender.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVender.UseVisualStyleBackColor = false;
            this.btnVender.Visible = false;
            this.btnVender.Click += new System.EventHandler(this.btnVender_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.SpringGreen;
            this.btnEnviar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnEnviar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.ForeColor = System.Drawing.Color.Black;
            this.btnEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnviar.Location = new System.Drawing.Point(855, 94);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(159, 72);
            this.btnEnviar.TabIndex = 107;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // lblsubt
            // 
            this.lblsubt.AutoSize = true;
            this.lblsubt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsubt.Location = new System.Drawing.Point(444, 532);
            this.lblsubt.Name = "lblsubt";
            this.lblsubt.Size = new System.Drawing.Size(95, 24);
            this.lblsubt.TabIndex = 109;
            this.lblsubt.Text = "SubTotal :";
            // 
            // txttotal
            // 
            this.txttotal.AutoSize = true;
            this.txttotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotal.Location = new System.Drawing.Point(444, 575);
            this.txttotal.Name = "txttotal";
            this.txttotal.Size = new System.Drawing.Size(61, 24);
            this.txttotal.TabIndex = 110;
            this.txttotal.Text = "Total :";
            // 
            // lblSubTotalAmount
            // 
            this.lblSubTotalAmount.AutoSize = true;
            this.lblSubTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotalAmount.Location = new System.Drawing.Point(561, 536);
            this.lblSubTotalAmount.Name = "lblSubTotalAmount";
            this.lblSubTotalAmount.Size = new System.Drawing.Size(16, 18);
            this.lblSubTotalAmount.TabIndex = 111;
            this.lblSubTotalAmount.Text = "0";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(561, 579);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(16, 18);
            this.lblTotalAmount.TabIndex = 112;
            this.lblTotalAmount.Text = "0";
            // 
            // lblTel2
            // 
            this.lblTel2.AutoSize = true;
            this.lblTel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTel2.Location = new System.Drawing.Point(218, 172);
            this.lblTel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTel2.Name = "lblTel2";
            this.lblTel2.Size = new System.Drawing.Size(35, 20);
            this.lblTel2.TabIndex = 117;
            this.lblTel2.Text = "tel2";
            // 
            // lblTel1
            // 
            this.lblTel1.AutoSize = true;
            this.lblTel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTel1.Location = new System.Drawing.Point(218, 146);
            this.lblTel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTel1.Name = "lblTel1";
            this.lblTel1.Size = new System.Drawing.Size(35, 20);
            this.lblTel1.TabIndex = 116;
            this.lblTel1.Text = "tel1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(25, 157);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(187, 20);
            this.label14.TabIndex = 115;
            this.label14.Text = "Numeros Telefonicos :";
            // 
            // lblDir
            // 
            this.lblDir.AutoSize = true;
            this.lblDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDir.Location = new System.Drawing.Point(25, 94);
            this.lblDir.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDir.Name = "lblDir";
            this.lblDir.Size = new System.Drawing.Size(29, 20);
            this.lblDir.TabIndex = 114;
            this.lblDir.Text = "dir";
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.lblLogo.Location = new System.Drawing.Point(24, 114);
            this.lblLogo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(65, 29);
            this.lblLogo.TabIndex = 113;
            this.lblLogo.Text = "logo";
            // 
            // chkComprobante
            // 
            this.chkComprobante.AutoSize = true;
            this.chkComprobante.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkComprobante.Location = new System.Drawing.Point(136, 287);
            this.chkComprobante.Margin = new System.Windows.Forms.Padding(2);
            this.chkComprobante.Name = "chkComprobante";
            this.chkComprobante.Size = new System.Drawing.Size(158, 24);
            this.chkComprobante.TabIndex = 122;
            this.chkComprobante.Text = "Con Comprobante";
            this.chkComprobante.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(30, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 121;
            this.label2.Text = "NCF";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(30, 224);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 20);
            this.label13.TabIndex = 120;
            this.label13.Text = "Tipo NCF";
            // 
            // txtNCF
            // 
            this.txtNCF.BackColor = System.Drawing.Color.White;
            this.txtNCF.Enabled = false;
            this.txtNCF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNCF.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtNCF.Location = new System.Drawing.Point(136, 256);
            this.txtNCF.Name = "txtNCF";
            this.txtNCF.Size = new System.Drawing.Size(194, 26);
            this.txtNCF.TabIndex = 119;
            this.txtNCF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // combo_tipo_NCF
            // 
            this.combo_tipo_NCF.BackColor = System.Drawing.Color.White;
            this.combo_tipo_NCF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_tipo_NCF.ForeColor = System.Drawing.Color.MidnightBlue;
            this.combo_tipo_NCF.FormattingEnabled = true;
            this.combo_tipo_NCF.Location = new System.Drawing.Point(136, 221);
            this.combo_tipo_NCF.Name = "combo_tipo_NCF";
            this.combo_tipo_NCF.Size = new System.Drawing.Size(247, 28);
            this.combo_tipo_NCF.TabIndex = 118;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(688, 94);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(159, 72);
            this.groupBox2.TabIndex = 123;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fecha de Venta";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarForeColor = System.Drawing.Color.MidnightBlue;
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(5, 37);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(149, 29);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(545, 535);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.TabIndex = 124;
            this.label1.Text = "$";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(545, 578);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 20);
            this.label3.TabIndex = 125;
            this.label3.Text = "$";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(1017, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 33);
            this.label8.TabIndex = 126;
            this.label8.Text = "X";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // SalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1052, 691);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.chkComprobante);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtNCF);
            this.Controls.Add(this.combo_tipo_NCF);
            this.Controls.Add(this.lblTel2);
            this.Controls.Add(this.lblTel1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblDir);
            this.Controls.Add(this.lblLogo);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.lblSubTotalAmount);
            this.Controls.Add(this.txttotal);
            this.Controls.Add(this.lblsubt);
            this.Controls.Add(this.btnVender);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.dgProductSelected);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelIdentify);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SalesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.SalesForm_Load);
            this.panelIdentify.ResumeLayout(false);
            this.panelIdentify.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductSelected)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblSales;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Panel panelIdentify;
        private System.Windows.Forms.DataGridView dgProductSelected;
        public System.Windows.Forms.Button btnVender;
        public System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Label lblsubt;
        private System.Windows.Forms.Label txttotal;
        private System.Windows.Forms.Label lblSubTotalAmount;
        private System.Windows.Forms.Label lblTotalAmount;
        public System.Windows.Forms.Label lblTel2;
        public System.Windows.Forms.Label lblTel1;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label lblDir;
        public System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.CheckBox chkComprobante;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox txtNCF;
        private System.Windows.Forms.ComboBox combo_tipo_NCF;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.Label label8;
    }
}