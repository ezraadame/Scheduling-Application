namespace C969_Scheduling_App.Forms
{
    partial class AddAppointment
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
            this.lblTitleAddAppointment = new System.Windows.Forms.Label();
            this.btnAddCustomerSave = new System.Windows.Forms.Button();
            this.btnAddCustomerCancel = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.dtpStartDateTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDateTime = new System.Windows.Forms.DateTimePicker();
            this.lblStartDateTime = new System.Windows.Forms.Label();
            this.lblEndDateTime = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.lblContact = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.lblCustomerId = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtAppointmentId = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAppointmentId = new System.Windows.Forms.Label();
            this.lblUserId = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEasternStartTime = new System.Windows.Forms.Label();
            this.lblEasternEndTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitleAddAppointment
            // 
            this.lblTitleAddAppointment.AutoSize = true;
            this.lblTitleAddAppointment.Font = new System.Drawing.Font("Gadugi", 18.25F, System.Drawing.FontStyle.Bold);
            this.lblTitleAddAppointment.Location = new System.Drawing.Point(210, 9);
            this.lblTitleAddAppointment.Name = "lblTitleAddAppointment";
            this.lblTitleAddAppointment.Size = new System.Drawing.Size(227, 30);
            this.lblTitleAddAppointment.TabIndex = 5;
            this.lblTitleAddAppointment.Text = "Add Appointment";
            // 
            // btnAddCustomerSave
            // 
            this.btnAddCustomerSave.Location = new System.Drawing.Point(498, 408);
            this.btnAddCustomerSave.Name = "btnAddCustomerSave";
            this.btnAddCustomerSave.Size = new System.Drawing.Size(83, 39);
            this.btnAddCustomerSave.TabIndex = 9;
            this.btnAddCustomerSave.Text = "Save";
            this.btnAddCustomerSave.UseVisualStyleBackColor = true;
            this.btnAddCustomerSave.Click += new System.EventHandler(this.btnAddCustomerSave_Click);
            // 
            // btnAddCustomerCancel
            // 
            this.btnAddCustomerCancel.Location = new System.Drawing.Point(587, 408);
            this.btnAddCustomerCancel.Name = "btnAddCustomerCancel";
            this.btnAddCustomerCancel.Size = new System.Drawing.Size(83, 39);
            this.btnAddCustomerCancel.TabIndex = 8;
            this.btnAddCustomerCancel.Text = "Cancel";
            this.btnAddCustomerCancel.UseVisualStyleBackColor = true;
            this.btnAddCustomerCancel.Click += new System.EventHandler(this.btnAddCustomerCancel_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Gadugi", 10.25F);
            this.lblDescription.Location = new System.Drawing.Point(360, 72);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(77, 17);
            this.lblDescription.TabIndex = 36;
            this.lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(470, 72);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 135);
            this.txtDescription.TabIndex = 37;
            // 
            // dtpStartDateTime
            // 
            this.dtpStartDateTime.Location = new System.Drawing.Point(470, 233);
            this.dtpStartDateTime.Name = "dtpStartDateTime";
            this.dtpStartDateTime.ShowCheckBox = true;
            this.dtpStartDateTime.Size = new System.Drawing.Size(200, 20);
            this.dtpStartDateTime.TabIndex = 42;
            this.dtpStartDateTime.ValueChanged += new System.EventHandler(this.dtpStartDateTime_ValueChanged);
            // 
            // dtpEndDateTime
            // 
            this.dtpEndDateTime.Location = new System.Drawing.Point(470, 328);
            this.dtpEndDateTime.Name = "dtpEndDateTime";
            this.dtpEndDateTime.ShowCheckBox = true;
            this.dtpEndDateTime.Size = new System.Drawing.Size(200, 20);
            this.dtpEndDateTime.TabIndex = 43;
            this.dtpEndDateTime.ValueChanged += new System.EventHandler(this.dtpEndDateTime_ValueChanged);
            // 
            // lblStartDateTime
            // 
            this.lblStartDateTime.AutoSize = true;
            this.lblStartDateTime.Font = new System.Drawing.Font("Gadugi", 10.25F);
            this.lblStartDateTime.Location = new System.Drawing.Point(360, 219);
            this.lblStartDateTime.Name = "lblStartDateTime";
            this.lblStartDateTime.Size = new System.Drawing.Size(104, 34);
            this.lblStartDateTime.TabIndex = 44;
            this.lblStartDateTime.Text = "Start Date/Time\r\n(Local)\r\n";
            // 
            // lblEndDateTime
            // 
            this.lblEndDateTime.AutoSize = true;
            this.lblEndDateTime.Font = new System.Drawing.Font("Gadugi", 10.25F);
            this.lblEndDateTime.Location = new System.Drawing.Point(360, 314);
            this.lblEndDateTime.Name = "lblEndDateTime";
            this.lblEndDateTime.Size = new System.Drawing.Size(98, 34);
            this.lblEndDateTime.TabIndex = 45;
            this.lblEndDateTime.Text = "End Date/Time\r\n(Loca)\r\n";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(130, 376);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(185, 20);
            this.txtType.TabIndex = 82;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Gadugi", 10.25F);
            this.lblType.Location = new System.Drawing.Point(23, 376);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(37, 17);
            this.lblType.TabIndex = 81;
            this.lblType.Text = "Type";
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(130, 328);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(185, 20);
            this.txtContact.TabIndex = 80;
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Font = new System.Drawing.Font("Gadugi", 10.25F);
            this.lblContact.Location = new System.Drawing.Point(23, 328);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(56, 17);
            this.lblContact.TabIndex = 79;
            this.lblContact.Text = "Contact";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(130, 287);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(185, 20);
            this.txtLocation.TabIndex = 78;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Gadugi", 10.25F);
            this.lblLocation.Location = new System.Drawing.Point(23, 287);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(60, 17);
            this.lblLocation.TabIndex = 77;
            this.lblLocation.Text = "Location";
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Location = new System.Drawing.Point(130, 113);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.ReadOnly = true;
            this.txtCustomerId.Size = new System.Drawing.Size(185, 20);
            this.txtCustomerId.TabIndex = 74;
            // 
            // lblCustomerId
            // 
            this.lblCustomerId.AutoSize = true;
            this.lblCustomerId.Font = new System.Drawing.Font("Gadugi", 10.25F);
            this.lblCustomerId.Location = new System.Drawing.Point(23, 113);
            this.lblCustomerId.Name = "lblCustomerId";
            this.lblCustomerId.Size = new System.Drawing.Size(86, 17);
            this.lblCustomerId.TabIndex = 73;
            this.lblCustomerId.Text = "Customer ID";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(130, 250);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(185, 20);
            this.txtTitle.TabIndex = 72;
            // 
            // txtAppointmentId
            // 
            this.txtAppointmentId.Location = new System.Drawing.Point(130, 72);
            this.txtAppointmentId.Name = "txtAppointmentId";
            this.txtAppointmentId.ReadOnly = true;
            this.txtAppointmentId.Size = new System.Drawing.Size(185, 20);
            this.txtAppointmentId.TabIndex = 71;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Gadugi", 10.25F);
            this.lblTitle.Location = new System.Drawing.Point(23, 250);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(33, 17);
            this.lblTitle.TabIndex = 70;
            this.lblTitle.Text = "Title";
            // 
            // lblAppointmentId
            // 
            this.lblAppointmentId.AutoSize = true;
            this.lblAppointmentId.Font = new System.Drawing.Font("Gadugi", 10.25F);
            this.lblAppointmentId.Location = new System.Drawing.Point(23, 72);
            this.lblAppointmentId.Name = "lblAppointmentId";
            this.lblAppointmentId.Size = new System.Drawing.Size(22, 17);
            this.lblAppointmentId.TabIndex = 69;
            this.lblAppointmentId.Text = "ID";
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Font = new System.Drawing.Font("Gadugi", 10.25F);
            this.lblUserId.Location = new System.Drawing.Point(23, 205);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(54, 17);
            this.lblUserId.TabIndex = 75;
            this.lblUserId.Text = "User ID";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(130, 205);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.ReadOnly = true;
            this.txtUserId.Size = new System.Drawing.Size(185, 20);
            this.txtUserId.TabIndex = 76;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(130, 161);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(185, 20);
            this.txtCustomerName.TabIndex = 84;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Gadugi", 10.25F);
            this.lblCustomerName.Location = new System.Drawing.Point(23, 161);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(108, 17);
            this.lblCustomerName.TabIndex = 83;
            this.lblCustomerName.Text = "Customer Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(546, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 85;
            // 
            // lblEasternStartTime
            // 
            this.lblEasternStartTime.AutoSize = true;
            this.lblEasternStartTime.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEasternStartTime.Location = new System.Drawing.Point(467, 257);
            this.lblEasternStartTime.Name = "lblEasternStartTime";
            this.lblEasternStartTime.Size = new System.Drawing.Size(28, 16);
            this.lblEasternStartTime.TabIndex = 86;
            this.lblEasternStartTime.Text = "EST";
            // 
            // lblEasternEndTime
            // 
            this.lblEasternEndTime.AutoSize = true;
            this.lblEasternEndTime.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEasternEndTime.Location = new System.Drawing.Point(467, 351);
            this.lblEasternEndTime.Name = "lblEasternEndTime";
            this.lblEasternEndTime.Size = new System.Drawing.Size(28, 16);
            this.lblEasternEndTime.TabIndex = 87;
            this.lblEasternEndTime.Text = "EST";
            // 
            // AddAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 459);
            this.Controls.Add(this.lblEasternEndTime);
            this.Controls.Add(this.lblEasternStartTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.txtCustomerId);
            this.Controls.Add(this.lblCustomerId);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtAppointmentId);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblAppointmentId);
            this.Controls.Add(this.lblEndDateTime);
            this.Controls.Add(this.lblStartDateTime);
            this.Controls.Add(this.dtpEndDateTime);
            this.Controls.Add(this.dtpStartDateTime);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnAddCustomerSave);
            this.Controls.Add(this.btnAddCustomerCancel);
            this.Controls.Add(this.lblTitleAddAppointment);
            this.Name = "AddAppointment";
            this.Text = "Add Appointment";
            this.Load += new System.EventHandler(this.AddAppointment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitleAddAppointment;
        private System.Windows.Forms.Button btnAddCustomerSave;
        private System.Windows.Forms.Button btnAddCustomerCancel;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.DateTimePicker dtpStartDateTime;
        private System.Windows.Forms.DateTimePicker dtpEndDateTime;
        private System.Windows.Forms.Label lblStartDateTime;
        private System.Windows.Forms.Label lblEndDateTime;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.Label lblCustomerId;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtAppointmentId;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAppointmentId;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEasternStartTime;
        private System.Windows.Forms.Label lblEasternEndTime;
    }
}