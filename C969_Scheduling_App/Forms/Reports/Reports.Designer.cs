namespace C969_Scheduling_App.Forms
{
    partial class Reports
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
            this.dgvNumberApptsTypeByMonth = new System.Windows.Forms.DataGridView();
            this.dgvSchedulePerUser = new System.Windows.Forms.DataGridView();
            this.dgvNumberApptLocationsByMonth = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblNumOfApptTypeByMonth = new System.Windows.Forms.Label();
            this.lblScheduleOfEachUser = new System.Windows.Forms.Label();
            this.lblNumOfApptLocationsByMonth = new System.Windows.Forms.Label();
            this.dtpNumApptTypeByMonth = new System.Windows.Forms.DateTimePicker();
            this.cmbBoxUserChoice = new System.Windows.Forms.ComboBox();
            this.dtpAppointmentLocationsByMonth = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumberApptsTypeByMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedulePerUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumberApptLocationsByMonth)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNumberApptsTypeByMonth
            // 
            this.dgvNumberApptsTypeByMonth.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNumberApptsTypeByMonth.Location = new System.Drawing.Point(12, 39);
            this.dgvNumberApptsTypeByMonth.Name = "dgvNumberApptsTypeByMonth";
            this.dgvNumberApptsTypeByMonth.Size = new System.Drawing.Size(356, 219);
            this.dgvNumberApptsTypeByMonth.TabIndex = 0;
            // 
            // dgvSchedulePerUser
            // 
            this.dgvSchedulePerUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedulePerUser.Location = new System.Drawing.Point(131, 372);
            this.dgvSchedulePerUser.Name = "dgvSchedulePerUser";
            this.dgvSchedulePerUser.Size = new System.Drawing.Size(501, 260);
            this.dgvSchedulePerUser.TabIndex = 1;
            // 
            // dgvNumberApptLocationsByMonth
            // 
            this.dgvNumberApptLocationsByMonth.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNumberApptLocationsByMonth.Location = new System.Drawing.Point(400, 40);
            this.dgvNumberApptLocationsByMonth.Name = "dgvNumberApptLocationsByMonth";
            this.dgvNumberApptLocationsByMonth.Size = new System.Drawing.Size(362, 219);
            this.dgvNumberApptLocationsByMonth.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(687, 593);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 41);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // lblNumOfApptTypeByMonth
            // 
            this.lblNumOfApptTypeByMonth.AutoSize = true;
            this.lblNumOfApptTypeByMonth.Font = new System.Drawing.Font("Gadugi", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblNumOfApptTypeByMonth.Location = new System.Drawing.Point(34, 18);
            this.lblNumOfApptTypeByMonth.Name = "lblNumOfApptTypeByMonth";
            this.lblNumOfApptTypeByMonth.Size = new System.Drawing.Size(286, 18);
            this.lblNumOfApptTypeByMonth.TabIndex = 4;
            this.lblNumOfApptTypeByMonth.Text = "Number Of Appointment Types By Month";
            // 
            // lblScheduleOfEachUser
            // 
            this.lblScheduleOfEachUser.AutoSize = true;
            this.lblScheduleOfEachUser.Font = new System.Drawing.Font("Gadugi", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblScheduleOfEachUser.Location = new System.Drawing.Point(133, 348);
            this.lblScheduleOfEachUser.Name = "lblScheduleOfEachUser";
            this.lblScheduleOfEachUser.Size = new System.Drawing.Size(156, 18);
            this.lblScheduleOfEachUser.TabIndex = 5;
            this.lblScheduleOfEachUser.Text = "Schedule Of Each User";
            // 
            // lblNumOfApptLocationsByMonth
            // 
            this.lblNumOfApptLocationsByMonth.AutoSize = true;
            this.lblNumOfApptLocationsByMonth.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblNumOfApptLocationsByMonth.Font = new System.Drawing.Font("Gadugi", 10.25F, System.Drawing.FontStyle.Bold);
            this.lblNumOfApptLocationsByMonth.Location = new System.Drawing.Point(429, 18);
            this.lblNumOfApptLocationsByMonth.Name = "lblNumOfApptLocationsByMonth";
            this.lblNumOfApptLocationsByMonth.Size = new System.Drawing.Size(310, 18);
            this.lblNumOfApptLocationsByMonth.TabIndex = 6;
            this.lblNumOfApptLocationsByMonth.Text = "Number Of Appointment Locations By Month";
            // 
            // dtpNumApptTypeByMonth
            // 
            this.dtpNumApptTypeByMonth.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNumApptTypeByMonth.Location = new System.Drawing.Point(73, 264);
            this.dtpNumApptTypeByMonth.Name = "dtpNumApptTypeByMonth";
            this.dtpNumApptTypeByMonth.Size = new System.Drawing.Size(216, 25);
            this.dtpNumApptTypeByMonth.TabIndex = 7;
            this.dtpNumApptTypeByMonth.Value = new System.DateTime(2025, 6, 28, 0, 0, 0, 0);
            // 
            // cmbBoxUserChoice
            // 
            this.cmbBoxUserChoice.FormattingEnabled = true;
            this.cmbBoxUserChoice.Location = new System.Drawing.Point(462, 345);
            this.cmbBoxUserChoice.Name = "cmbBoxUserChoice";
            this.cmbBoxUserChoice.Size = new System.Drawing.Size(160, 21);
            this.cmbBoxUserChoice.TabIndex = 8;
            // 
            // dtpAppointmentLocationsByMonth
            // 
            this.dtpAppointmentLocationsByMonth.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAppointmentLocationsByMonth.Location = new System.Drawing.Point(481, 265);
            this.dtpAppointmentLocationsByMonth.Name = "dtpAppointmentLocationsByMonth";
            this.dtpAppointmentLocationsByMonth.Size = new System.Drawing.Size(216, 25);
            this.dtpAppointmentLocationsByMonth.TabIndex = 9;
            this.dtpAppointmentLocationsByMonth.Value = new System.DateTime(2025, 6, 28, 0, 0, 0, 0);
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 646);
            this.Controls.Add(this.dtpAppointmentLocationsByMonth);
            this.Controls.Add(this.cmbBoxUserChoice);
            this.Controls.Add(this.dtpNumApptTypeByMonth);
            this.Controls.Add(this.lblNumOfApptLocationsByMonth);
            this.Controls.Add(this.lblScheduleOfEachUser);
            this.Controls.Add(this.lblNumOfApptTypeByMonth);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dgvNumberApptLocationsByMonth);
            this.Controls.Add(this.dgvSchedulePerUser);
            this.Controls.Add(this.dgvNumberApptsTypeByMonth);
            this.Name = "Reports";
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.Reports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumberApptsTypeByMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedulePerUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumberApptLocationsByMonth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNumberApptsTypeByMonth;
        private System.Windows.Forms.DataGridView dgvSchedulePerUser;
        private System.Windows.Forms.DataGridView dgvNumberApptLocationsByMonth;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblNumOfApptTypeByMonth;
        private System.Windows.Forms.Label lblScheduleOfEachUser;
        private System.Windows.Forms.Label lblNumOfApptLocationsByMonth;
        private System.Windows.Forms.DateTimePicker dtpNumApptTypeByMonth;
        private System.Windows.Forms.ComboBox cmbBoxUserChoice;
        private System.Windows.Forms.DateTimePicker dtpAppointmentLocationsByMonth;
    }
}