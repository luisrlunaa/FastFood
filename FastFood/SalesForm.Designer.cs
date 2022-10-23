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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSales = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelIdentify = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.dgProductSelected = new System.Windows.Forms.DataGridView();
            this.IdVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblIgvAmount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDelivery = new System.Windows.Forms.TextBox();
            this.lblDelivery = new System.Windows.Forms.Label();
            this.txtDAmount = new System.Windows.Forms.TextBox();
            this.lblDAmount = new System.Windows.Forms.Label();
            this.lblRNC = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRncCli = new System.Windows.Forms.TextBox();
            this.lblRncCli = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
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
            // dgProductSelected
            // 
            this.dgProductSelected.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProductSelected.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgProductSelected.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProductSelected.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdVenta,
            this.IdProd,
            this.NameProd,
            this.Quantity,
            this.PriceProd,
            this.IGV,
            this.SubTotal});
            this.dgProductSelected.Location = new System.Drawing.Point(371, 282);
            this.dgProductSelected.Name = "dgProductSelected";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProductSelected.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgProductSelected.Size = new System.Drawing.Size(659, 303);
            this.dgProductSelected.TabIndex = 106;
            this.dgProductSelected.Click += new System.EventHandler(this.dgProductSelected_Click);
            // 
            // IdVenta
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IdVenta.DefaultCellStyle = dataGridViewCellStyle5;
            this.IdVenta.HeaderText = "ID";
            this.IdVenta.Name = "IdVenta";
            this.IdVenta.ReadOnly = true;
            // 
            // IdProd
            // 
            this.IdProd.HeaderText = "Id Producto";
            this.IdProd.Name = "IdProd";
            this.IdProd.Visible = false;
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
            // IGV
            // 
            this.IGV.HeaderText = "Itbis";
            this.IGV.Name = "IGV";
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
            this.btnVender.Location = new System.Drawing.Point(872, 593);
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
            this.btnEnviar.Location = new System.Drawing.Point(871, 593);
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
            this.lblsubt.Location = new System.Drawing.Point(367, 592);
            this.lblsubt.Name = "lblsubt";
            this.lblsubt.Size = new System.Drawing.Size(95, 24);
            this.lblsubt.TabIndex = 109;
            this.lblsubt.Text = "SubTotal :";
            // 
            // txttotal
            // 
            this.txttotal.AutoSize = true;
            this.txttotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotal.Location = new System.Drawing.Point(367, 658);
            this.txttotal.Name = "txttotal";
            this.txttotal.Size = new System.Drawing.Size(61, 24);
            this.txttotal.TabIndex = 110;
            this.txttotal.Text = "Total :";
            // 
            // lblSubTotalAmount
            // 
            this.lblSubTotalAmount.AutoSize = true;
            this.lblSubTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotalAmount.Location = new System.Drawing.Point(484, 596);
            this.lblSubTotalAmount.Name = "lblSubTotalAmount";
            this.lblSubTotalAmount.Size = new System.Drawing.Size(16, 18);
            this.lblSubTotalAmount.TabIndex = 111;
            this.lblSubTotalAmount.Text = "0";
            this.lblSubTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(484, 662);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(16, 18);
            this.lblTotalAmount.TabIndex = 112;
            this.lblTotalAmount.Text = "0";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTel2
            // 
            this.lblTel2.AutoSize = true;
            this.lblTel2.BackColor = System.Drawing.Color.Transparent;
            this.lblTel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTel2.Location = new System.Drawing.Point(205, 161);
            this.lblTel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTel2.Name = "lblTel2";
            this.lblTel2.Size = new System.Drawing.Size(35, 20);
            this.lblTel2.TabIndex = 117;
            this.lblTel2.Text = "tel2";
            // 
            // lblTel1
            // 
            this.lblTel1.AutoSize = true;
            this.lblTel1.BackColor = System.Drawing.Color.Transparent;
            this.lblTel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTel1.Location = new System.Drawing.Point(205, 135);
            this.lblTel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTel1.Name = "lblTel1";
            this.lblTel1.Size = new System.Drawing.Size(35, 20);
            this.lblTel1.TabIndex = 116;
            this.lblTel1.Text = "tel1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(12, 146);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(187, 20);
            this.label14.TabIndex = 115;
            this.label14.Text = "Numeros Telefonicos :";
            // 
            // lblDir
            // 
            this.lblDir.AutoSize = true;
            this.lblDir.BackColor = System.Drawing.Color.Transparent;
            this.lblDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDir.Location = new System.Drawing.Point(12, 81);
            this.lblDir.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDir.Name = "lblDir";
            this.lblDir.Size = new System.Drawing.Size(29, 20);
            this.lblDir.TabIndex = 114;
            this.lblDir.Text = "dir";
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.BackColor = System.Drawing.Color.Transparent;
            this.lblLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(8)))), ((int)(((byte)(55)))));
            this.lblLogo.Location = new System.Drawing.Point(11, 101);
            this.lblLogo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(65, 29);
            this.lblLogo.TabIndex = 113;
            this.lblLogo.Text = "logo";
            // 
            // chkComprobante
            // 
            this.chkComprobante.AutoSize = true;
            this.chkComprobante.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkComprobante.Location = new System.Drawing.Point(801, 202);
            this.chkComprobante.Margin = new System.Windows.Forms.Padding(2);
            this.chkComprobante.Name = "chkComprobante";
            this.chkComprobante.Size = new System.Drawing.Size(229, 33);
            this.chkComprobante.TabIndex = 122;
            this.chkComprobante.Text = "Con Comprobante";
            this.chkComprobante.UseVisualStyleBackColor = true;
            this.chkComprobante.CheckedChanged += new System.EventHandler(this.chkComprobante_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(468, 208);
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
            this.label13.Location = new System.Drawing.Point(468, 169);
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
            this.txtNCF.Location = new System.Drawing.Point(558, 205);
            this.txtNCF.Name = "txtNCF";
            this.txtNCF.Size = new System.Drawing.Size(238, 26);
            this.txtNCF.TabIndex = 119;
            // 
            // combo_tipo_NCF
            // 
            this.combo_tipo_NCF.BackColor = System.Drawing.Color.White;
            this.combo_tipo_NCF.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_tipo_NCF.ForeColor = System.Drawing.Color.MidnightBlue;
            this.combo_tipo_NCF.FormattingEnabled = true;
            this.combo_tipo_NCF.Location = new System.Drawing.Point(558, 159);
            this.combo_tipo_NCF.Name = "combo_tipo_NCF";
            this.combo_tipo_NCF.Size = new System.Drawing.Size(472, 37);
            this.combo_tipo_NCF.TabIndex = 118;
            this.combo_tipo_NCF.SelectedIndexChanged += new System.EventHandler(this.combo_tipo_NCF_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(890, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(159, 56);
            this.groupBox2.TabIndex = 123;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fecha de Venta";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarForeColor = System.Drawing.Color.MidnightBlue;
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(4, 25);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(149, 29);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(468, 595);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.TabIndex = 124;
            this.label1.Text = "$";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(468, 661);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 20);
            this.label3.TabIndex = 125;
            this.label3.Text = "$";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.BackColor = System.Drawing.Color.Transparent;
            this.lblDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.ForeColor = System.Drawing.Color.Black;
            this.lblDireccion.Location = new System.Drawing.Point(11, 243);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(84, 20);
            this.lblDireccion.TabIndex = 127;
            this.lblDireccion.Text = "Direccion";
            this.lblDireccion.Visible = false;
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.Color.White;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtDireccion.Location = new System.Drawing.Point(111, 240);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(920, 26);
            this.txtDireccion.TabIndex = 126;
            this.txtDireccion.Visible = false;
            // 
            // btnBorrar
            // 
            this.btnBorrar.BackColor = System.Drawing.Color.Red;
            this.btnBorrar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnBorrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnBorrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrar.ForeColor = System.Drawing.Color.White;
            this.btnBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBorrar.Location = new System.Drawing.Point(699, 593);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(159, 72);
            this.btnBorrar.TabIndex = 128;
            this.btnBorrar.Text = "Eliminar Item";
            this.btnBorrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBorrar.UseVisualStyleBackColor = false;
            this.btnBorrar.Visible = false;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(9, 282);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 130;
            this.label4.Text = "Cliente";
            // 
            // txtClientName
            // 
            this.txtClientName.BackColor = System.Drawing.Color.White;
            this.txtClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientName.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtClientName.Location = new System.Drawing.Point(111, 279);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(247, 26);
            this.txtClientName.TabIndex = 131;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(468, 628);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 20);
            this.label5.TabIndex = 134;
            this.label5.Text = "$";
            // 
            // lblIgvAmount
            // 
            this.lblIgvAmount.AutoSize = true;
            this.lblIgvAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIgvAmount.Location = new System.Drawing.Point(484, 629);
            this.lblIgvAmount.Name = "lblIgvAmount";
            this.lblIgvAmount.Size = new System.Drawing.Size(16, 18);
            this.lblIgvAmount.TabIndex = 133;
            this.lblIgvAmount.Text = "0";
            this.lblIgvAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(367, 625);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 24);
            this.label7.TabIndex = 132;
            this.label7.Text = "ITBIS :";
            // 
            // txtDelivery
            // 
            this.txtDelivery.BackColor = System.Drawing.Color.White;
            this.txtDelivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelivery.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtDelivery.Location = new System.Drawing.Point(127, 425);
            this.txtDelivery.Name = "txtDelivery";
            this.txtDelivery.Size = new System.Drawing.Size(232, 26);
            this.txtDelivery.TabIndex = 136;
            this.txtDelivery.Visible = false;
            // 
            // lblDelivery
            // 
            this.lblDelivery.AutoSize = true;
            this.lblDelivery.BackColor = System.Drawing.Color.Transparent;
            this.lblDelivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelivery.ForeColor = System.Drawing.Color.Black;
            this.lblDelivery.Location = new System.Drawing.Point(12, 428);
            this.lblDelivery.Name = "lblDelivery";
            this.lblDelivery.Size = new System.Drawing.Size(72, 20);
            this.lblDelivery.TabIndex = 135;
            this.lblDelivery.Text = "Delivery";
            this.lblDelivery.Visible = false;
            // 
            // txtDAmount
            // 
            this.txtDAmount.BackColor = System.Drawing.Color.White;
            this.txtDAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDAmount.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtDAmount.Location = new System.Drawing.Point(127, 469);
            this.txtDAmount.Name = "txtDAmount";
            this.txtDAmount.Size = new System.Drawing.Size(158, 26);
            this.txtDAmount.TabIndex = 138;
            this.txtDAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDAmount.Visible = false;
            // 
            // lblDAmount
            // 
            this.lblDAmount.AutoSize = true;
            this.lblDAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblDAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDAmount.ForeColor = System.Drawing.Color.Black;
            this.lblDAmount.Location = new System.Drawing.Point(12, 472);
            this.lblDAmount.Name = "lblDAmount";
            this.lblDAmount.Size = new System.Drawing.Size(82, 20);
            this.lblDAmount.TabIndex = 137;
            this.lblDAmount.Text = "D. Monto";
            this.lblDAmount.Visible = false;
            // 
            // lblRNC
            // 
            this.lblRNC.AutoSize = true;
            this.lblRNC.BackColor = System.Drawing.Color.Transparent;
            this.lblRNC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRNC.Location = new System.Drawing.Point(205, 190);
            this.lblRNC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRNC.Name = "lblRNC";
            this.lblRNC.Size = new System.Drawing.Size(31, 20);
            this.lblRNC.TabIndex = 139;
            this.lblRNC.Text = "rnc";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 190);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 20);
            this.label6.TabIndex = 140;
            this.label6.Text = "RNC :";
            // 
            // txtRncCli
            // 
            this.txtRncCli.BackColor = System.Drawing.Color.White;
            this.txtRncCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRncCli.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtRncCli.Location = new System.Drawing.Point(126, 324);
            this.txtRncCli.Name = "txtRncCli";
            this.txtRncCli.Size = new System.Drawing.Size(232, 26);
            this.txtRncCli.TabIndex = 142;
            // 
            // lblRncCli
            // 
            this.lblRncCli.AutoSize = true;
            this.lblRncCli.BackColor = System.Drawing.Color.Transparent;
            this.lblRncCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRncCli.ForeColor = System.Drawing.Color.Black;
            this.lblRncCli.Location = new System.Drawing.Point(9, 327);
            this.lblRncCli.Name = "lblRncCli";
            this.lblRncCli.Size = new System.Drawing.Size(107, 20);
            this.lblRncCli.TabIndex = 141;
            this.lblRncCli.Text = "RNC Cliente";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(12, 374);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(145, 24);
            this.checkBox1.TabIndex = 143;
            this.checkBox1.Text = "Buscar Cliente";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // SalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1052, 691);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.txtRncCli);
            this.Controls.Add(this.lblRncCli);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblRNC);
            this.Controls.Add(this.txtDAmount);
            this.Controls.Add(this.lblDAmount);
            this.Controls.Add(this.txtDelivery);
            this.Controls.Add(this.lblDelivery);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblIgvAmount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtClientName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.txtDireccion);
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
        public System.Windows.Forms.Label lblSales;
        public System.Windows.Forms.Panel panelIdentify;
        private System.Windows.Forms.DataGridView dgProductSelected;
        public System.Windows.Forms.Button btnVender;
        public System.Windows.Forms.Button btnEnviar;
        public System.Windows.Forms.Label lblTel2;
        public System.Windows.Forms.Label lblTel1;
        public System.Windows.Forms.Label lblDir;
        public System.Windows.Forms.Label lblLogo;
        public System.Windows.Forms.TextBox txtNCF;
        private System.Windows.Forms.ComboBox combo_tipo_NCF;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtDireccion;
        public System.Windows.Forms.Label lblDireccion;
        public System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn IGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        public System.Windows.Forms.TextBox txtClientName;
        public System.Windows.Forms.TextBox txtDelivery;
        public System.Windows.Forms.Label lblDelivery;
        public System.Windows.Forms.TextBox txtDAmount;
        public System.Windows.Forms.Label lblDAmount;
        public System.Windows.Forms.Label lblRNC;
        public System.Windows.Forms.TextBox txtRncCli;
        public System.Windows.Forms.Label lblRncCli;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label lblsubt;
        public System.Windows.Forms.Label txttotal;
        public System.Windows.Forms.Label lblSubTotalAmount;
        public System.Windows.Forms.Label lblTotalAmount;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.CheckBox chkComprobante;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label lblIgvAmount;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.CheckBox checkBox1;
    }
}