namespace C969_Scheduling_App.Forms
{
    partial class UpdateAppointment
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
            this.lblEndDateTime = new System.Windows.Forms.Label();
            this.lblStartDateTime = new System.Windows.Forms.Label();
            this.dtpEndDateTime = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDateTime = new System.Windows.Forms.DateTimePicker();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.lblContact = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.lblCustomerId = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtAppointmentId = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAppointmentId = new System.Windows.Forms.Label();
            this.btnUpdateCustomerSave = new System.Windows.Forms.Button();
            this.btnUpdateCustomerCancel = new System.Windows.Forms.Button();
            this.lblTitleUpdateAppointment = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblUserId = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblEasternStartTime = new System.Windows.Forms.Label();
            this.lblEasternEndTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblEndDateTime
            // 
            this.lblEndDateTime.AutoSize = true;
            this.lblEndDateTime.Font = new System.Drawing.Font("Gadugi", 10.25F);
            this.lblEndDateTime.Location = new System.Drawing.Point(357, 316);
            this.lblEndDateTime.Name = "lblEndDateTime";
            this.lblEndDateTime.Size = new System.Drawing.Size(98, 34);
            this.lblEndDateTime.TabIndex = 66;
            this.lblEndDateTime.Text = "End Date/Time\r\n(Local)";
            // 
            // lblStartDateTime
            // 
            this.lblStartDateTime.AutoSize = true;
            this.lblStartDateTime.Font = new System.Drawing.Font("Gadugi", 10.25F);
            this.lblStartDateTime.Location = new System.Drawing.Point(357, 232);
            this.lblStartDateTime.Name = "lblStartDateTime";
            this.lblStartDateTime.Size = new System.Drawing.Size(104, 34);
            this.lblStartDateTime.TabIndex = 65;
            this.lblStartDateTime.Text = "Start Date/Time\r\n(Local)";
            // 
            // dtpEndDateTime
            // 
            this.dtpEndDateTime.Location = new System.Drawing.Point(467, 330);
            this.dtpEndDateTime.Name = "dtpEndDateTime";
            this.dtpEndDateTime.ShowCheckBox = true;
            this.dtpEndDateTime.Size = new System.Drawing.Size(200, 20);
            this.dtpEndDateTime.TabIndex = 64;
            this.dtpEndDateTime.ValueChanged += new System.EventHandler(this.dtpEndDateTime_ValueChanged);
            // 
            // dtpStartDateTime
            // 
            this.dtpStartDateTime.Location = new System.Drawing.Point(467, 246);
            this.dtpStartDateTime.Name = "dtpStartDateTime";
            this.dtpStartDateTime.ShowCheckBox = true;
            this.dtpStartDateTime.Size = new System.Drawing.Size(200, 20);
            this.dtpStartDateTime.TabIndex = 63;
            this.dtpStartDateTime.ValueChanged += new System.EventHandler(this.dtpStartDateTime_ValueChanged);
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(124, 314);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(185, 20);
            this.txtContact.TabIndex = 62;
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Font = new System.Drawing.Font("Gadugi", 10.25F);
            this.lblContact.Location = new System.Drawing.Point(17, 314);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(56, 17);
            this.lblContact.TabIndex = 61;
            this.lblContact.Text = "Contact";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(124, 273);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(185, 20);
            this.txtLocation.TabIndex = 60;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Gadugi", 10.25F);
            this.lblLocation.Location = new System.Drawing.Point(17, 273);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(60, 17);
            this.lblLocation.TabIndex = 59;
            this.lblLocation.Text = "Location";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(467, 75);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 153);
            this.txtDescription.TabIndex = 58;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Gadugi", 10.25F);
            this.lblDescription.Location = new System.Drawing.Point(357, 75);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(77, 17);
            this.lblDescription.TabIndex = 57;
            this.lblDescription.Text = "Description";
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Location = new System.Drawing.Point(124, 116);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.ReadOnly = true;
            this.txtCustomerId.Size = new System.Drawing.Size(185, 20);
            this.txtCustomerId.TabIndex = 54;
            // 
            // lblCustomerId
            // 
            this.lblCustomerId.AutoSize = true;
            this.lblCustomerId.Font = new System.Drawing.Font("Gadugi", 10.25F);
            this.lblCustomerId.Location = new System.Drawing.Point(17, 116);
            this.lblCustomerId.Name = "lblCustomerId";
            this.lblCustomerId.Size = new System.Drawing.Size(86, 17);
            this.lblCustomerId.TabIndex = 53;
            this.lblCustomerId.Text = "Customer ID";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(124, 236);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(185, 20);
            this.txtTitle.TabIndex = 52;
            // 
            // txtAppointmentId
            // 
            this.txtAppointmentId.Location = new System.Drawing.Point(124, 75);
            this.txtAppointmentId.Name = "txtAppointmentId";
            this.txtAppointmentId.ReadOnly = true;
            this.txtAppointmentId.Size = new System.Drawing.Size(185, 20);
            this.txtAppointmentId.TabIndex = 51;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Gadugi", 10.25F);
            this.lblTitle.Location = new System.Drawing.Point(17, 236);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(33, 17);
            this.lblTitle.TabIndex = 50;
            this.lblTitle.Text = "Title";
            // 
            // lblAppointmentId
            // 
            this.lblAppointmentId.AutoSize = true;
            this.lblAppointmentId.Font = new System.Drawing.Font("Gadugi", 10.25F);
            this.lblAppointmentId.Location = new System.Drawing.Point(17, 75);
            this.lblAppointmentId.Name = "lblAppointmentId";
            this.lblAppointmentId.Size = new System.Drawing.Size(22, 17);
            this.lblAppointmentId.TabIndex = 49;
            this.lblAppointmentId.Text = "ID";
            // 
            // btnUpdateCustomerSave
            // 
            this.btnUpdateCustomerSave.Location = new System.Drawing.Point(495, 408);
            this.btnUpdateCustomerSave.Name = "btnUpdateCustomerSave";
            this.btnUpdateCustomerSave.Size = new System.Drawing.Size(83, 39);
            this.btnUpdateCustomerSave.TabIndex = 48;
            this.btnUpdateCustomerSave.Text = "Save";
            this.btnUpdateCustomerSave.UseVisualStyleBackColor = true;
            this.btnUpdateCustomerSave.Click += new System.EventHandler(this.btnUpdateCustomerSave_Click);
            // 
            // btnUpdateCustomerCancel
            // 
            this.btnUpdateCustomerCancel.Location = new System.Drawing.Point(584, 408);
            this.btnUpdateCustomerCancel.Name = "btnUpdateCustomerCancel";
            this.btnUpdateCustomerCancel.Size = new System.Drawing.Size(83, 39);
            this.btnUpdateCustomerCancel.TabIndex = 47;
            this.btnUpdateCustomerCancel.Text = "Cancel";
            this.btnUpdateCustomerCancel.UseVisualStyleBackColor = true;
            this.btnUpdateCustomerCancel.Click += new System.EventHandler(this.btnUpdateCustomerCancel_Click);
            // 
            // lblTitleUpdateAppointment
            // 
            this.lblTitleUpdateAppointment.AutoSize = true;
            this.lblTitleUpdateAppointment.Font = new System.Drawing.Font("Gadugi", 18.25F, System.Drawing.FontStyle.Bold);
            this.lblTitleUpdateAppointment.Location = new System.Drawing.Point(196, 9);
            this.lblTitleUpdateAppointment.Name = "lblTitleUpdateAppointment";
            this.lblTitleUpdateAppointment.Size = new System.Drawing.Size(265, 30);
            this.lblTitleUpdateAppointment.TabIndex = 46;
            this.lblTitleUpdateAppointment.Text = "Update Appointment";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(124, 362);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(185, 20);
            this.txtType.TabIndex = 68;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Gadugi", 10.25F);
            this.lblType.Location = new System.Drawing.Point(17, 362);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(37, 17);
            this.lblType.TabIndex = 67;
            this.lblType.Text = "Type";
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Font = new System.Drawing.Font("Gadugi", 10.25F);
            this.lblUserId.Location = new System.Drawing.Point(17, 195);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(54, 17);
            this.lblUserId.TabIndex = 55;
            this.lblUserId.Text = "User ID";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(124, 195);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.ReadOnly = true;
            this.txtUserId.Size = new System.Drawing.Size(185, 20);
            this.txtUserId.TabIndex = 56;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(124, 156);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(185, 20);
            this.txtCustomerName.TabIndex = 70;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Gadugi", 10.25F);
            this.lblCustomerName.Location = new System.Drawing.Point(17, 156);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(108, 17);
            this.lblCustomerName.TabIndex = 69;
            this.lblCustomerName.Text = "Customer Name";
            // 
            // lblEasternStartTime
            // 
            this.lblEasternStartTime.AutoSize = true;
            this.lblEasternStartTime.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEasternStartTime.Location = new System.Drawing.Point(464, 269);
            this.lblEasternStartTime.Name = "lblEasternStartTime";
            this.lblEasternStartTime.Size = new System.Drawing.Size(28, 16);
            this.lblEasternStartTime.TabIndex = 88;
            this.lblEasternStartTime.Text = "EST";
            // 
            // lblEasternEndTime
            // 
            this.lblEasternEndTime.AutoSize = true;
            this.lblEasternEndTime.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEasternEndTime.Location = new System.Drawing.Point(464, 353);
            this.lblEasternEndTime.Name = "lblEasternEndTime";
            this.lblEasternEndTime.Size = new System.Drawing.Size(28, 16);
            this.lblEasternEndTime.TabIndex = 89;
            this.lblEasternEndTime.Text = "EST";
            // 
            // UpdateAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 459);
            this.Controls.Add(this.lblEasternEndTime);
            this.Controls.Add(this.lblEasternStartTime);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblEndDateTime);
            this.Controls.Add(this.lblStartDateTime);
            this.Controls.Add(this.dtpEndDateTime);
            this.Controls.Add(this.dtpStartDateTime);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.txtCustomerId);
            this.Controls.Add(this.lblCustomerId);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtAppointmentId);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblAppointmentId);
            this.Controls.Add(this.btnUpdateCustomerSave);
            this.Controls.Add(this.btnUpdateCustomerCancel);
            this.Controls.Add(this.lblTitleUpdateAppointment);
            this.Name = "UpdateAppointment";
            this.Text = "Update Appointment";
            this.Load += new System.EventHandler(this.UpdateAppointment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEndDateTime;
        private System.Windows.Forms.Label lblStartDateTime;
        private System.Windows.Forms.DateTimePicker dtpEndDateTime;
        private System.Windows.Forms.DateTimePicker dtpStartDateTime;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.Label lblCustomerId;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtAppointmentId;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAppointmentId;
        private System.Windows.Forms.Button btnUpdateCustomerSave;
        private System.Windows.Forms.Button btnUpdateCustomerCancel;
        private System.Windows.Forms.Label lblTitleUpdateAppointment;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblEasternStartTime;
        private System.Windows.Forms.Label lblEasternEndTime;
    }
}