namespace FastFoodDemo
{
    partial class ManagerEmployeeForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label7 = new System.Windows.Forms.Label();
            this.data_employee = new System.Windows.Forms.DataGridView();
            this.id_employee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEmployee = new System.Windows.Forms.Panel();
            this.cbxEmpType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdE = new System.Windows.Forms.TextBox();
            this.txtLastNameE = new System.Windows.Forms.TextBox();
            this.txtNameE = new System.Windows.Forms.TextBox();
            this.cbxIDType = new System.Windows.Forms.ComboBox();
            this.lblIdType = new System.Windows.Forms.Label();
            this.lblIDNo = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnEditEmployee = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.lblIdEmployee = new System.Windows.Forms.Label();
            this.panelUser = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtPass2 = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtActualPass = new System.Windows.Forms.TextBox();
            this.lblClave2 = new System.Windows.Forms.Label();
            this.lblClave = new System.Windows.Forms.Label();
            this.lblActualPass = new System.Windows.Forms.Label();
            this.btnAllowedEdituser = new System.Windows.Forms.Button();
            this.lblPass = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNewUser = new System.Windows.Forms.Button();
            this.btnNewEmployee = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblUserId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.data_employee)).BeginInit();
            this.panelEmployee.SuspendLayout();
            this.panelUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(184, 25);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(489, 31);
            this.label7.TabIndex = 132;
            this.label7.Text = "Manejador de Empleados y Usuarios";
            // 
            // data_employee
            // 
            this.data_employee.AllowUserToAddRows = false;
            this.data_employee.AllowUserToDeleteRows = false;
            this.data_employee.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.data_employee.BackgroundColor = System.Drawing.Color.White;
            this.data_employee.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.data_employee.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.data_employee.ColumnHeadersHeight = 29;
            this.data_employee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_employee,
            this.employeeName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.data_employee.DefaultCellStyle = dataGridViewCellStyle2;
            this.data_employee.EnableHeadersVisualStyles = false;
            this.data_employee.GridColor = System.Drawing.Color.Black;
            this.data_employee.Location = new System.Drawing.Point(13, 70);
            this.data_employee.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.data_employee.Name = "data_employee";
            this.data_employee.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.data_employee.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.data_employee.RowHeadersVisible = false;
            this.data_employee.RowHeadersWidth = 51;
            this.data_employee.RowTemplate.Height = 24;
            this.data_employee.Size = new System.Drawing.Size(444, 261);
            this.data_employee.TabIndex = 133;
            this.data_employee.Click += new System.EventHandler(this.data_employee_Click);
            this.data_employee.DoubleClick += new System.EventHandler(this.data_employee_DoubleClick);
            // 
            // id_employee
            // 
            this.id_employee.FillWeight = 50.17418F;
            this.id_employee.HeaderText = "ID Employee";
            this.id_employee.MinimumWidth = 45;
            this.id_employee.Name = "id_employee";
            this.id_employee.ReadOnly = true;
            this.id_employee.Visible = false;
            // 
            // employeeName
            // 
            this.employeeName.FillWeight = 177.6333F;
            this.employeeName.HeaderText = "Nombres";
            this.employeeName.MinimumWidth = 6;
            this.employeeName.Name = "employeeName";
            this.employeeName.ReadOnly = true;
            // 
            // panelEmployee
            // 
            this.panelEmployee.BackColor = System.Drawing.Color.White;
            this.panelEmployee.Controls.Add(this.cbxEmpType);
            this.panelEmployee.Controls.Add(this.label1);
            this.panelEmployee.Controls.Add(this.txtIdE);
            this.panelEmployee.Controls.Add(this.txtLastNameE);
            this.panelEmployee.Controls.Add(this.txtNameE);
            this.panelEmployee.Controls.Add(this.cbxIDType);
            this.panelEmployee.Controls.Add(this.lblIdType);
            this.panelEmployee.Controls.Add(this.lblIDNo);
            this.panelEmployee.Controls.Add(this.lblLastName);
            this.panelEmployee.Controls.Add(this.lblName);
            this.panelEmployee.Location = new System.Drawing.Point(12, 364);
            this.panelEmployee.Name = "panelEmployee";
            this.panelEmployee.Size = new System.Drawing.Size(473, 314);
            this.panelEmployee.TabIndex = 134;
            this.panelEmployee.Visible = false;
            // 
            // cbxEmpType
            // 
            this.cbxEmpType.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxEmpType.FormattingEnabled = true;
            this.cbxEmpType.Location = new System.Drawing.Point(216, 256);
            this.cbxEmpType.Name = "cbxEmpType";
            this.cbxEmpType.Size = new System.Drawing.Size(244, 39);
            this.cbxEmpType.TabIndex = 91;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 24);
            this.label1.TabIndex = 90;
            this.label1.Text = "Tipo de Empleado";
            // 
            // txtIdE
            // 
            this.txtIdE.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdE.Location = new System.Drawing.Point(216, 141);
            this.txtIdE.Name = "txtIdE";
            this.txtIdE.Size = new System.Drawing.Size(244, 35);
            this.txtIdE.TabIndex = 89;
            // 
            // txtLastNameE
            // 
            this.txtLastNameE.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastNameE.Location = new System.Drawing.Point(216, 80);
            this.txtLastNameE.Name = "txtLastNameE";
            this.txtLastNameE.Size = new System.Drawing.Size(244, 35);
            this.txtLastNameE.TabIndex = 88;
            // 
            // txtNameE
            // 
            this.txtNameE.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameE.Location = new System.Drawing.Point(216, 25);
            this.txtNameE.Name = "txtNameE";
            this.txtNameE.Size = new System.Drawing.Size(244, 35);
            this.txtNameE.TabIndex = 87;
            // 
            // cbxIDType
            // 
            this.cbxIDType.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxIDType.FormattingEnabled = true;
            this.cbxIDType.Location = new System.Drawing.Point(216, 198);
            this.cbxIDType.Name = "cbxIDType";
            this.cbxIDType.Size = new System.Drawing.Size(244, 39);
            this.cbxIDType.TabIndex = 86;
            // 
            // lblIdType
            // 
            this.lblIdType.AutoSize = true;
            this.lblIdType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdType.Location = new System.Drawing.Point(14, 208);
            this.lblIdType.Name = "lblIdType";
            this.lblIdType.Size = new System.Drawing.Size(162, 24);
            this.lblIdType.TabIndex = 85;
            this.lblIdType.Text = "Tipo Identificacion";
            // 
            // lblIDNo
            // 
            this.lblIDNo.AutoSize = true;
            this.lblIDNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDNo.Location = new System.Drawing.Point(14, 148);
            this.lblIDNo.Name = "lblIDNo";
            this.lblIDNo.Size = new System.Drawing.Size(119, 24);
            this.lblIDNo.TabIndex = 84;
            this.lblIDNo.Text = "Identificacion";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.Location = new System.Drawing.Point(14, 87);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(88, 24);
            this.lblLastName.TabIndex = 83;
            this.lblLastName.Text = "Apellidos";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(14, 32);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(88, 24);
            this.lblName.TabIndex = 82;
            this.lblName.Text = "Nombres";
            // 
            // btnEditEmployee
            // 
            this.btnEditEmployee.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEditEmployee.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnEditEmployee.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnEditEmployee.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnEditEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditEmployee.ForeColor = System.Drawing.Color.Black;
            this.btnEditEmployee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditEmployee.Location = new System.Drawing.Point(464, 70);
            this.btnEditEmployee.Name = "btnEditEmployee";
            this.btnEditEmployee.Size = new System.Drawing.Size(159, 72);
            this.btnEditEmployee.TabIndex = 135;
            this.btnEditEmployee.Text = "Editar Empleado";
            this.btnEditEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditEmployee.UseVisualStyleBackColor = false;
            this.btnEditEmployee.Visible = false;
            this.btnEditEmployee.Click += new System.EventHandler(this.btnEditEmployee_Click);
            // 
            // btnEditUser
            // 
            this.btnEditUser.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEditUser.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnEditUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnEditUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnEditUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditUser.ForeColor = System.Drawing.Color.Black;
            this.btnEditUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditUser.Location = new System.Drawing.Point(464, 148);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(159, 72);
            this.btnEditUser.TabIndex = 136;
            this.btnEditUser.Text = "Editar Usuario";
            this.btnEditUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditUser.UseVisualStyleBackColor = false;
            this.btnEditUser.Visible = false;
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // lblIdEmployee
            // 
            this.lblIdEmployee.AutoSize = true;
            this.lblIdEmployee.Location = new System.Drawing.Point(13, 51);
            this.lblIdEmployee.Name = "lblIdEmployee";
            this.lblIdEmployee.Size = new System.Drawing.Size(13, 13);
            this.lblIdEmployee.TabIndex = 137;
            this.lblIdEmployee.Text = "0";
            this.lblIdEmployee.Visible = false;
            // 
            // panelUser
            // 
            this.panelUser.BackColor = System.Drawing.Color.White;
            this.panelUser.Controls.Add(this.lblUserName);
            this.panelUser.Controls.Add(this.txtPass2);
            this.panelUser.Controls.Add(this.txtPass);
            this.panelUser.Controls.Add(this.txtActualPass);
            this.panelUser.Controls.Add(this.lblClave2);
            this.panelUser.Controls.Add(this.lblClave);
            this.panelUser.Controls.Add(this.lblActualPass);
            this.panelUser.Location = new System.Drawing.Point(511, 364);
            this.panelUser.Name = "panelUser";
            this.panelUser.Size = new System.Drawing.Size(376, 250);
            this.panelUser.TabIndex = 135;
            this.panelUser.Visible = false;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(144, 25);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(66, 24);
            this.lblUserName.TabIndex = 90;
            this.lblUserName.Text = "@user";
            // 
            // txtPass2
            // 
            this.txtPass2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass2.Location = new System.Drawing.Point(148, 196);
            this.txtPass2.Name = "txtPass2";
            this.txtPass2.PasswordChar = '*';
            this.txtPass2.Size = new System.Drawing.Size(218, 35);
            this.txtPass2.TabIndex = 89;
            this.txtPass2.Visible = false;
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.Location = new System.Drawing.Point(148, 135);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(218, 35);
            this.txtPass.TabIndex = 88;
            this.txtPass.Visible = false;
            // 
            // txtActualPass
            // 
            this.txtActualPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActualPass.Location = new System.Drawing.Point(148, 80);
            this.txtActualPass.Name = "txtActualPass";
            this.txtActualPass.PasswordChar = '*';
            this.txtActualPass.Size = new System.Drawing.Size(218, 35);
            this.txtActualPass.TabIndex = 87;
            // 
            // lblClave2
            // 
            this.lblClave2.AutoSize = true;
            this.lblClave2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClave2.Location = new System.Drawing.Point(17, 203);
            this.lblClave2.Name = "lblClave2";
            this.lblClave2.Size = new System.Drawing.Size(121, 24);
            this.lblClave2.TabIndex = 84;
            this.lblClave2.Text = "Confirmacion";
            this.lblClave2.Visible = false;
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClave.Location = new System.Drawing.Point(17, 142);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(57, 24);
            this.lblClave.TabIndex = 83;
            this.lblClave.Text = "Clave";
            this.lblClave.Visible = false;
            // 
            // lblActualPass
            // 
            this.lblActualPass.AutoSize = true;
            this.lblActualPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualPass.Location = new System.Drawing.Point(17, 87);
            this.lblActualPass.Name = "lblActualPass";
            this.lblActualPass.Size = new System.Drawing.Size(114, 24);
            this.lblActualPass.TabIndex = 82;
            this.lblActualPass.Text = "Clave Actual";
            // 
            // btnAllowedEdituser
            // 
            this.btnAllowedEdituser.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAllowedEdituser.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnAllowedEdituser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnAllowedEdituser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnAllowedEdituser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllowedEdituser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAllowedEdituser.ForeColor = System.Drawing.Color.Black;
            this.btnAllowedEdituser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAllowedEdituser.Location = new System.Drawing.Point(728, 254);
            this.btnAllowedEdituser.Name = "btnAllowedEdituser";
            this.btnAllowedEdituser.Size = new System.Drawing.Size(159, 72);
            this.btnAllowedEdituser.TabIndex = 138;
            this.btnAllowedEdituser.Text = "Confirmar Usuario";
            this.btnAllowedEdituser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAllowedEdituser.UseVisualStyleBackColor = false;
            this.btnAllowedEdituser.Visible = false;
            this.btnAllowedEdituser.Click += new System.EventHandler(this.btnAllowedEdituser_Click);
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(13, 38);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(27, 13);
            this.lblPass.TabIndex = 138;
            this.lblPass.Text = "xxxx";
            this.lblPass.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(728, 254);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(159, 72);
            this.btnSave.TabIndex = 140;
            this.btnSave.Text = "Guardar Cambios";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNewUser
            // 
            this.btnNewUser.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNewUser.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnNewUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnNewUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnNewUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewUser.ForeColor = System.Drawing.Color.Black;
            this.btnNewUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewUser.Location = new System.Drawing.Point(464, 148);
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Size = new System.Drawing.Size(159, 72);
            this.btnNewUser.TabIndex = 142;
            this.btnNewUser.Text = "Nuevo Usuario";
            this.btnNewUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewUser.UseVisualStyleBackColor = false;
            this.btnNewUser.Click += new System.EventHandler(this.btnNewUser_Click);
            // 
            // btnNewEmployee
            // 
            this.btnNewEmployee.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNewEmployee.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnNewEmployee.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnNewEmployee.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnNewEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewEmployee.ForeColor = System.Drawing.Color.Black;
            this.btnNewEmployee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewEmployee.Location = new System.Drawing.Point(464, 70);
            this.btnNewEmployee.Name = "btnNewEmployee";
            this.btnNewEmployee.Size = new System.Drawing.Size(159, 72);
            this.btnNewEmployee.TabIndex = 141;
            this.btnNewEmployee.Text = "Nuevo Empleado";
            this.btnNewEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewEmployee.UseVisualStyleBackColor = false;
            this.btnNewEmployee.Click += new System.EventHandler(this.btnNewEmployee_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(464, 148);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 72);
            this.button1.TabIndex = 144;
            this.button1.Text = "Eliminar Usuario";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(464, 70);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(159, 72);
            this.button2.TabIndex = 143;
            this.button2.Text = "Eliminar Empleado";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Location = new System.Drawing.Point(13, 25);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(24, 13);
            this.lblUserId.TabIndex = 145;
            this.lblUserId.Text = "@1";
            this.lblUserId.Visible = false;
            // 
            // ManagerEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(896, 690);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnNewUser);
            this.Controls.Add(this.btnNewEmployee);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAllowedEdituser);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.panelUser);
            this.Controls.Add(this.lblIdEmployee);
            this.Controls.Add(this.btnEditUser);
            this.Controls.Add(this.btnEditEmployee);
            this.Controls.Add(this.panelEmployee);
            this.Controls.Add(this.data_employee);
            this.Controls.Add(this.label7);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManagerEmployeeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.ManagerEmployeeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data_employee)).EndInit();
            this.panelEmployee.ResumeLayout(false);
            this.panelEmployee.PerformLayout();
            this.panelUser.ResumeLayout(false);
            this.panelUser.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView data_employee;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_employee;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeName;
        public System.Windows.Forms.Button btnEditEmployee;
        public System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.Label lblIdEmployee;
        private System.Windows.Forms.Label lblIDNo;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblIdType;
        private System.Windows.Forms.ComboBox cbxIDType;
        private System.Windows.Forms.TextBox txtIdE;
        private System.Windows.Forms.TextBox txtLastNameE;
        private System.Windows.Forms.TextBox txtNameE;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtPass2;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtActualPass;
        private System.Windows.Forms.Label lblClave2;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.Label lblActualPass;
        public System.Windows.Forms.Button btnAllowedEdituser;
        private System.Windows.Forms.Label lblPass;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnNewUser;
        public System.Windows.Forms.Button btnNewEmployee;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbxEmpType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUserId;
        public System.Windows.Forms.Panel panelEmployee;
        public System.Windows.Forms.Panel panelUser;
    }
}