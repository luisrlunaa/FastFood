namespace FastFoodDemo
{
    partial class NCFForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label7 = new System.Windows.Forms.Label();
            this.data_comprobante = new System.Windows.Forms.DataGridView();
            this.Ncf_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Initialsequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Finalsequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpfinal = new System.Windows.Forms.DateTimePicker();
            this.dtpinicio = new System.Windows.Forms.DateTimePicker();
            this.txtfinal = new System.Windows.Forms.TextBox();
            this.txtinicio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblcomp = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.data_ncf = new System.Windows.Forms.DataGridView();
            this.id_ncf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description_ncf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.data_comprobante)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_ncf)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(250, 22);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(331, 31);
            this.label7.TabIndex = 132;
            this.label7.Text = "Limitaciones de los NCF";
            // 
            // data_comprobante
            // 
            this.data_comprobante.AllowUserToAddRows = false;
            this.data_comprobante.AllowUserToDeleteRows = false;
            this.data_comprobante.BackgroundColor = System.Drawing.Color.White;
            this.data_comprobante.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.data_comprobante.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.data_comprobante.ColumnHeadersHeight = 29;
            this.data_comprobante.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ncf_id,
            this.Initialsequence,
            this.Finalsequence,
            this.DateFrom,
            this.DateTo});
            this.data_comprobante.EnableHeadersVisualStyles = false;
            this.data_comprobante.GridColor = System.Drawing.Color.Black;
            this.data_comprobante.Location = new System.Drawing.Point(19, 393);
            this.data_comprobante.Margin = new System.Windows.Forms.Padding(2);
            this.data_comprobante.Name = "data_comprobante";
            this.data_comprobante.ReadOnly = true;
            this.data_comprobante.RowHeadersWidth = 51;
            this.data_comprobante.RowTemplate.Height = 24;
            this.data_comprobante.Size = new System.Drawing.Size(853, 266);
            this.data_comprobante.TabIndex = 131;
            // 
            // Ncf_id
            // 
            this.Ncf_id.HeaderText = "ID";
            this.Ncf_id.MinimumWidth = 6;
            this.Ncf_id.Name = "Ncf_id";
            this.Ncf_id.ReadOnly = true;
            this.Ncf_id.Visible = false;
            this.Ncf_id.Width = 125;
            // 
            // Initialsequence
            // 
            this.Initialsequence.HeaderText = "Secuencia Inicial";
            this.Initialsequence.MinimumWidth = 6;
            this.Initialsequence.Name = "Initialsequence";
            this.Initialsequence.ReadOnly = true;
            this.Initialsequence.Width = 200;
            // 
            // Finalsequence
            // 
            this.Finalsequence.HeaderText = "Secuancia Final";
            this.Finalsequence.MinimumWidth = 6;
            this.Finalsequence.Name = "Finalsequence";
            this.Finalsequence.ReadOnly = true;
            this.Finalsequence.Width = 200;
            // 
            // DateFrom
            // 
            this.DateFrom.HeaderText = "Fecha Inicial";
            this.DateFrom.MinimumWidth = 6;
            this.DateFrom.Name = "DateFrom";
            this.DateFrom.ReadOnly = true;
            this.DateFrom.Width = 200;
            // 
            // DateTo
            // 
            this.DateTo.HeaderText = "Fecha Final";
            this.DateTo.MinimumWidth = 6;
            this.DateTo.Name = "DateTo";
            this.DateTo.ReadOnly = true;
            this.DateTo.Width = 200;
            // 
            // btnAplicar
            // 
            this.btnAplicar.BackColor = System.Drawing.Color.SpringGreen;
            this.btnAplicar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnAplicar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnAplicar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicar.ForeColor = System.Drawing.Color.Black;
            this.btnAplicar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAplicar.Location = new System.Drawing.Point(760, 11);
            this.btnAplicar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(125, 61);
            this.btnAplicar.TabIndex = 130;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = false;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.txtid);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dtpfinal);
            this.groupBox2.Controls.Add(this.dtpinicio);
            this.groupBox2.Controls.Add(this.txtfinal);
            this.groupBox2.Controls.Add(this.txtinicio);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(525, 139);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(360, 237);
            this.groupBox2.TabIndex = 129;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Limitantes";
            // 
            // txtid
            // 
            this.txtid.BackColor = System.Drawing.Color.White;
            this.txtid.Enabled = false;
            this.txtid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtid.Location = new System.Drawing.Point(60, 21);
            this.txtid.Margin = new System.Windows.Forms.Padding(2);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(62, 20);
            this.txtid.TabIndex = 75;
            this.txtid.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 24);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 74;
            this.label6.Text = "ID NCF";
            this.label6.Visible = false;
            // 
            // dtpfinal
            // 
            this.dtpfinal.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpfinal.CalendarTrailingForeColor = System.Drawing.SystemColors.Desktop;
            this.dtpfinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfinal.Location = new System.Drawing.Point(198, 93);
            this.dtpfinal.Margin = new System.Windows.Forms.Padding(2);
            this.dtpfinal.Name = "dtpfinal";
            this.dtpfinal.Size = new System.Drawing.Size(141, 29);
            this.dtpfinal.TabIndex = 72;
            // 
            // dtpinicio
            // 
            this.dtpinicio.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpinicio.CalendarTrailingForeColor = System.Drawing.SystemColors.Desktop;
            this.dtpinicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpinicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpinicio.Location = new System.Drawing.Point(198, 51);
            this.dtpinicio.Margin = new System.Windows.Forms.Padding(2);
            this.dtpinicio.Name = "dtpinicio";
            this.dtpinicio.Size = new System.Drawing.Size(141, 29);
            this.dtpinicio.TabIndex = 71;
            // 
            // txtfinal
            // 
            this.txtfinal.BackColor = System.Drawing.Color.White;
            this.txtfinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfinal.Location = new System.Drawing.Point(198, 186);
            this.txtfinal.Margin = new System.Windows.Forms.Padding(2);
            this.txtfinal.Name = "txtfinal";
            this.txtfinal.Size = new System.Drawing.Size(141, 29);
            this.txtfinal.TabIndex = 70;
            this.txtfinal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfinal_KeyPress);
            // 
            // txtinicio
            // 
            this.txtinicio.BackColor = System.Drawing.Color.White;
            this.txtinicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtinicio.Location = new System.Drawing.Point(198, 141);
            this.txtinicio.Margin = new System.Windows.Forms.Padding(2);
            this.txtinicio.Name = "txtinicio";
            this.txtinicio.Size = new System.Drawing.Size(141, 29);
            this.txtinicio.TabIndex = 69;
            this.txtinicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtinicio_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 146);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 24);
            this.label4.TabIndex = 68;
            this.label4.Text = "Secuencia Inicial:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 191);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 24);
            this.label3.TabIndex = 67;
            this.label3.Text = "Secuencia Final:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 99);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 24);
            this.label2.TabIndex = 66;
            this.label2.Text = "Fecha Final:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 24);
            this.label1.TabIndex = 65;
            this.label1.Text = "Fecha Inicial:";
            // 
            // lblcomp
            // 
            this.lblcomp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblcomp.AutoEllipsis = true;
            this.lblcomp.AutoSize = true;
            this.lblcomp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblcomp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcomp.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblcomp.Location = new System.Drawing.Point(521, 109);
            this.lblcomp.Margin = new System.Windows.Forms.Padding(0);
            this.lblcomp.Name = "lblcomp";
            this.lblcomp.Size = new System.Drawing.Size(181, 20);
            this.lblcomp.TabIndex = 76;
            this.lblcomp.Text = "Tipo de Comprobante";
            this.lblcomp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.data_ncf);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 72);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(497, 304);
            this.groupBox1.TabIndex = 128;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Elige el NCF que vas a Limitar";
            // 
            // data_ncf
            // 
            this.data_ncf.AllowUserToAddRows = false;
            this.data_ncf.AllowUserToDeleteRows = false;
            this.data_ncf.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.data_ncf.BackgroundColor = System.Drawing.Color.White;
            this.data_ncf.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.data_ncf.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.data_ncf.ColumnHeadersHeight = 29;
            this.data_ncf.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_ncf,
            this.Description_ncf,
            this.Active});
            this.data_ncf.EnableHeadersVisualStyles = false;
            this.data_ncf.GridColor = System.Drawing.Color.Black;
            this.data_ncf.Location = new System.Drawing.Point(8, 37);
            this.data_ncf.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.data_ncf.Name = "data_ncf";
            this.data_ncf.ReadOnly = true;
            this.data_ncf.RowHeadersVisible = false;
            this.data_ncf.RowHeadersWidth = 51;
            this.data_ncf.RowTemplate.Height = 24;
            this.data_ncf.Size = new System.Drawing.Size(481, 261);
            this.data_ncf.TabIndex = 0;
            this.data_ncf.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.data_ncf_CellFormatting);
            this.data_ncf.DoubleClick += new System.EventHandler(this.data_ncf_DoubleClick);
            // 
            // id_ncf
            // 
            this.id_ncf.FillWeight = 50.17418F;
            this.id_ncf.HeaderText = "ID NCF";
            this.id_ncf.MinimumWidth = 45;
            this.id_ncf.Name = "id_ncf";
            this.id_ncf.ReadOnly = true;
            this.id_ncf.Visible = false;
            // 
            // Description_ncf
            // 
            this.Description_ncf.FillWeight = 177.6333F;
            this.Description_ncf.HeaderText = "Tipo De NCF";
            this.Description_ncf.MinimumWidth = 6;
            this.Description_ncf.Name = "Description_ncf";
            this.Description_ncf.ReadOnly = true;
            // 
            // Active
            // 
            this.Active.FillWeight = 72.19251F;
            this.Active.HeaderText = "Activo";
            this.Active.MinimumWidth = 45;
            this.Active.Name = "Active";
            this.Active.ReadOnly = true;
            // 
            // NCFForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(896, 690);
            this.Controls.Add(this.lblcomp);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.data_comprobante);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NCFForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.NCFForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data_comprobante)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.data_ncf)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView data_comprobante;
        private System.Windows.Forms.GroupBox groupBox2;
        protected System.Windows.Forms.Label lblcomp;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpfinal;
        private System.Windows.Forms.DateTimePicker dtpinicio;
        private System.Windows.Forms.TextBox txtfinal;
        private System.Windows.Forms.TextBox txtinicio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView data_ncf;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ncf_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Initialsequence;
        private System.Windows.Forms.DataGridViewTextBoxColumn Finalsequence;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_ncf;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description_ncf;
        private System.Windows.Forms.DataGridViewTextBoxColumn Active;
        public System.Windows.Forms.Button btnAplicar;
    }
}