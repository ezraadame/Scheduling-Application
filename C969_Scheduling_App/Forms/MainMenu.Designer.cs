namespace C969_Scheduling_App.Forms
{
    partial class MainMenu
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
            this.dgvCustomerMGMT = new System.Windows.Forms.DataGridView();
            this.lblTitleCustomerManagement = new System.Windows.Forms.Label();
            this.lblTitleAppointmentManagement = new System.Windows.Forms.Label();
            this.dgvAppointmentMGMT = new System.Windows.Forms.DataGridView();
            this.btnAppointmentAdd = new System.Windows.Forms.Button();
            this.btnCustomerAdd = new System.Windows.Forms.Button();
            this.btnAppointmentUpdate = new System.Windows.Forms.Button();
            this.btnAppointmentDelete = new System.Windows.Forms.Button();
            this.btnCustomerUpdate = new System.Windows.Forms.Button();
            this.btnCustomerDelete = new System.Windows.Forms.Button();
            this.btnReportsMenu = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblTitleReports = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerMGMT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointmentMGMT)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCustomerMGMT
            // 
            this.dgvCustomerMGMT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerMGMT.Location = new System.Drawing.Point(32, 384);
            this.dgvCustomerMGMT.Name = "dgvCustomerMGMT";
            this.dgvCustomerMGMT.Size = new System.Drawing.Size(663, 233);
            this.dgvCustomerMGMT.TabIndex = 0;
            // 
            // lblTitleCustomerManagement
            // 
            this.lblTitleCustomerManagement.AutoSize = true;
            this.lblTitleCustomerManagement.Font = new System.Drawing.Font("Gadugi", 18.25F, System.Drawing.FontStyle.Bold);
            this.lblTitleCustomerManagement.Location = new System.Drawing.Point(27, 351);
            this.lblTitleCustomerManagement.Name = "lblTitleCustomerManagement";
            this.lblTitleCustomerManagement.Size = new System.Drawing.Size(290, 30);
            this.lblTitleCustomerManagement.TabIndex = 1;
            this.lblTitleCustomerManagement.Text = "Customer Management";
            // 
            // lblTitleAppointmentManagement
            // 
            this.lblTitleAppointmentManagement.AutoSize = true;
            this.lblTitleAppointmentManagement.Font = new System.Drawing.Font("Gadugi", 18.25F, System.Drawing.FontStyle.Bold);
            this.lblTitleAppointmentManagement.Location = new System.Drawing.Point(27, 15);
            this.lblTitleAppointmentManagement.Name = "lblTitleAppointmentManagement";
            this.lblTitleAppointmentManagement.Size = new System.Drawing.Size(335, 30);
            this.lblTitleAppointmentManagement.TabIndex = 3;
            this.lblTitleAppointmentManagement.Text = "Appointment Management";
            // 
            // dgvAppointmentMGMT
            // 
            this.dgvAppointmentMGMT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointmentMGMT.Location = new System.Drawing.Point(32, 51);
            this.dgvAppointmentMGMT.Name = "dgvAppointmentMGMT";
            this.dgvAppointmentMGMT.Size = new System.Drawing.Size(914, 230);
            this.dgvAppointmentMGMT.TabIndex = 4;
            // 
            // btnAppointmentAdd
            // 
            this.btnAppointmentAdd.Location = new System.Drawing.Point(32, 302);
            this.btnAppointmentAdd.Name = "btnAppointmentAdd";
            this.btnAppointmentAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAppointmentAdd.TabIndex = 5;
            this.btnAppointmentAdd.Text = "Add";
            this.btnAppointmentAdd.UseVisualStyleBackColor = true;
            this.btnAppointmentAdd.Click += new System.EventHandler(this.btnAppointmentAdd_Click);
            // 
            // btnCustomerAdd
            // 
            this.btnCustomerAdd.Location = new System.Drawing.Point(32, 646);
            this.btnCustomerAdd.Name = "btnCustomerAdd";
            this.btnCustomerAdd.Size = new System.Drawing.Size(75, 23);
            this.btnCustomerAdd.TabIndex = 6;
            this.btnCustomerAdd.Text = "Add";
            this.btnCustomerAdd.UseVisualStyleBackColor = true;
            this.btnCustomerAdd.Click += new System.EventHandler(this.btnCustomerAdd_Click);
            // 
            // btnAppointmentUpdate
            // 
            this.btnAppointmentUpdate.Location = new System.Drawing.Point(139, 302);
            this.btnAppointmentUpdate.Name = "btnAppointmentUpdate";
            this.btnAppointmentUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnAppointmentUpdate.TabIndex = 7;
            this.btnAppointmentUpdate.Text = "Update";
            this.btnAppointmentUpdate.UseVisualStyleBackColor = true;
            this.btnAppointmentUpdate.Click += new System.EventHandler(this.btnAppointmentUpdate_Click);
            // 
            // btnAppointmentDelete
            // 
            this.btnAppointmentDelete.Location = new System.Drawing.Point(254, 302);
            this.btnAppointmentDelete.Name = "btnAppointmentDelete";
            this.btnAppointmentDelete.Size = new System.Drawing.Size(75, 23);
            this.btnAppointmentDelete.TabIndex = 8;
            this.btnAppointmentDelete.Text = "Delete";
            this.btnAppointmentDelete.UseVisualStyleBackColor = true;
            // 
            // btnCustomerUpdate
            // 
            this.btnCustomerUpdate.Location = new System.Drawing.Point(139, 646);
            this.btnCustomerUpdate.Name = "btnCustomerUpdate";
            this.btnCustomerUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnCustomerUpdate.TabIndex = 9;
            this.btnCustomerUpdate.Text = "Update";
            this.btnCustomerUpdate.UseVisualStyleBackColor = true;
            this.btnCustomerUpdate.Click += new System.EventHandler(this.btnCustomerUpdate_Click);
            // 
            // btnCustomerDelete
            // 
            this.btnCustomerDelete.Location = new System.Drawing.Point(254, 646);
            this.btnCustomerDelete.Name = "btnCustomerDelete";
            this.btnCustomerDelete.Size = new System.Drawing.Size(75, 23);
            this.btnCustomerDelete.TabIndex = 10;
            this.btnCustomerDelete.Text = "Delete";
            this.btnCustomerDelete.UseVisualStyleBackColor = true;
            // 
            // btnReportsMenu
            // 
            this.btnReportsMenu.Location = new System.Drawing.Point(744, 384);
            this.btnReportsMenu.Name = "btnReportsMenu";
            this.btnReportsMenu.Size = new System.Drawing.Size(202, 58);
            this.btnReportsMenu.TabIndex = 11;
            this.btnReportsMenu.Text = "Reports Menu";
            this.btnReportsMenu.UseVisualStyleBackColor = true;
            this.btnReportsMenu.Click += new System.EventHandler(this.btnReportsMenu_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(798, 625);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 44);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblTitleReports
            // 
            this.lblTitleReports.AutoSize = true;
            this.lblTitleReports.Font = new System.Drawing.Font("Gadugi", 18.25F, System.Drawing.FontStyle.Bold);
            this.lblTitleReports.Location = new System.Drawing.Point(793, 351);
            this.lblTitleReports.Name = "lblTitleReports";
            this.lblTitleReports.Size = new System.Drawing.Size(105, 30);
            this.lblTitleReports.TabIndex = 13;
            this.lblTitleReports.Text = "Reports";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 695);
            this.Controls.Add(this.lblTitleReports);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnReportsMenu);
            this.Controls.Add(this.btnCustomerDelete);
            this.Controls.Add(this.btnCustomerUpdate);
            this.Controls.Add(this.btnAppointmentDelete);
            this.Controls.Add(this.btnAppointmentUpdate);
            this.Controls.Add(this.btnCustomerAdd);
            this.Controls.Add(this.btnAppointmentAdd);
            this.Controls.Add(this.dgvAppointmentMGMT);
            this.Controls.Add(this.lblTitleAppointmentManagement);
            this.Controls.Add(this.lblTitleCustomerManagement);
            this.Controls.Add(this.dgvCustomerMGMT);
            this.Name = "MainMenu";
            this.Text = "Main Menu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerMGMT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointmentMGMT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCustomerMGMT;
        private System.Windows.Forms.Label lblTitleCustomerManagement;
        private System.Windows.Forms.Label lblTitleAppointmentManagement;
        private System.Windows.Forms.DataGridView dgvAppointmentMGMT;
        private System.Windows.Forms.Button btnAppointmentAdd;
        private System.Windows.Forms.Button btnCustomerAdd;
        private System.Windows.Forms.Button btnAppointmentUpdate;
        private System.Windows.Forms.Button btnAppointmentDelete;
        private System.Windows.Forms.Button btnCustomerUpdate;
        private System.Windows.Forms.Button btnCustomerDelete;
        private System.Windows.Forms.Button btnReportsMenu;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblTitleReports;
    }
}