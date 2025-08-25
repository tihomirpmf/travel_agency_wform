namespace travel_agency_wform.Forms
{
    partial class ReservationForm
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
            this.labelClientInfo = new System.Windows.Forms.Label();
            this.labelPackageInfo = new System.Windows.Forms.Label();
            this.labelNumberOfTravelers = new System.Windows.Forms.Label();
            this.numericUpDownNumberOfTravelers = new System.Windows.Forms.NumericUpDown();
            this.labelTotalPrice = new System.Windows.Forms.Label();
            this.textBoxTotalPrice = new System.Windows.Forms.TextBox();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxClientDetails = new System.Windows.Forms.GroupBox();
            this.groupBoxPackageDetails = new System.Windows.Forms.GroupBox();
            this.groupBoxReservationDetails = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfTravelers)).BeginInit();
            this.groupBoxClientDetails.SuspendLayout();
            this.groupBoxPackageDetails.SuspendLayout();
            this.groupBoxReservationDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelClientInfo
            // 
            this.labelClientInfo.AutoSize = true;
            this.labelClientInfo.Location = new System.Drawing.Point(20, 30);
            this.labelClientInfo.Name = "labelClientInfo";
            this.labelClientInfo.Size = new System.Drawing.Size(200, 15);
            this.labelClientInfo.TabIndex = 0;
            this.labelClientInfo.Text = "Client: [Client Name]";
            // 
            // labelPackageInfo
            // 
            this.labelPackageInfo.AutoSize = true;
            this.labelPackageInfo.Location = new System.Drawing.Point(20, 30);
            this.labelPackageInfo.Name = "labelPackageInfo";
            this.labelPackageInfo.Size = new System.Drawing.Size(200, 15);
            this.labelPackageInfo.TabIndex = 0;
            this.labelPackageInfo.Text = "Package: [Package Name]";
            // 
            // labelNumberOfTravelers
            // 
            this.labelNumberOfTravelers.AutoSize = true;
            this.labelNumberOfTravelers.Location = new System.Drawing.Point(20, 30);
            this.labelNumberOfTravelers.Name = "labelNumberOfTravelers";
            this.labelNumberOfTravelers.Size = new System.Drawing.Size(120, 15);
            this.labelNumberOfTravelers.TabIndex = 0;
            this.labelNumberOfTravelers.Text = "Number of Travelers:";
            // 
            // numericUpDownNumberOfTravelers
            // 
            this.numericUpDownNumberOfTravelers.Location = new System.Drawing.Point(150, 27);
            this.numericUpDownNumberOfTravelers.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownNumberOfTravelers.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNumberOfTravelers.Name = "numericUpDownNumberOfTravelers";
            this.numericUpDownNumberOfTravelers.Size = new System.Drawing.Size(100, 23);
            this.numericUpDownNumberOfTravelers.TabIndex = 1;
            this.numericUpDownNumberOfTravelers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});

            // 
            // labelTotalPrice
            // 
            this.labelTotalPrice.AutoSize = true;
            this.labelTotalPrice.Location = new System.Drawing.Point(20, 70);
            this.labelTotalPrice.Name = "labelTotalPrice";
            this.labelTotalPrice.Size = new System.Drawing.Size(70, 15);
            this.labelTotalPrice.TabIndex = 2;
            this.labelTotalPrice.Text = "Total Price:";
            // 
            // textBoxTotalPrice
            // 
            this.textBoxTotalPrice.Location = new System.Drawing.Point(150, 67);
            this.textBoxTotalPrice.Name = "textBoxTotalPrice";
            this.textBoxTotalPrice.ReadOnly = true;
            this.textBoxTotalPrice.Size = new System.Drawing.Size(100, 23);
            this.textBoxTotalPrice.TabIndex = 3;
            this.textBoxTotalPrice.Text = "$0.00";
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(100, 300);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirm.TabIndex = 4;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(200, 300);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBoxClientDetails
            // 
            this.groupBoxClientDetails.Controls.Add(this.labelClientInfo);
            this.groupBoxClientDetails.Location = new System.Drawing.Point(20, 20);
            this.groupBoxClientDetails.Name = "groupBoxClientDetails";
            this.groupBoxClientDetails.Size = new System.Drawing.Size(350, 70);
            this.groupBoxClientDetails.TabIndex = 6;
            this.groupBoxClientDetails.TabStop = false;
            this.groupBoxClientDetails.Text = "Client Details";
            // 
            // groupBoxPackageDetails
            // 
            this.groupBoxPackageDetails.Controls.Add(this.labelPackageInfo);
            this.groupBoxPackageDetails.Location = new System.Drawing.Point(20, 100);
            this.groupBoxPackageDetails.Name = "groupBoxPackageDetails";
            this.groupBoxPackageDetails.Size = new System.Drawing.Size(350, 70);
            this.groupBoxPackageDetails.TabIndex = 7;
            this.groupBoxPackageDetails.TabStop = false;
            this.groupBoxPackageDetails.Text = "Package Details";
            // 
            // groupBoxReservationDetails
            // 
            this.groupBoxReservationDetails.Controls.Add(this.textBoxTotalPrice);
            this.groupBoxReservationDetails.Controls.Add(this.labelTotalPrice);
            this.groupBoxReservationDetails.Controls.Add(this.numericUpDownNumberOfTravelers);
            this.groupBoxReservationDetails.Controls.Add(this.labelNumberOfTravelers);
            this.groupBoxReservationDetails.Location = new System.Drawing.Point(20, 180);
            this.groupBoxReservationDetails.Name = "groupBoxReservationDetails";
            this.groupBoxReservationDetails.Size = new System.Drawing.Size(350, 110);
            this.groupBoxReservationDetails.TabIndex = 8;
            this.groupBoxReservationDetails.TabStop = false;
            this.groupBoxReservationDetails.Text = "Reservation Details";
            // 
            // ReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 350);
            this.Controls.Add(this.groupBoxReservationDetails);
            this.Controls.Add(this.groupBoxPackageDetails);
            this.Controls.Add(this.groupBoxClientDetails);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonConfirm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReservationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Make Reservation";
            this.groupBoxClientDetails.ResumeLayout(false);
            this.groupBoxClientDetails.PerformLayout();
            this.groupBoxPackageDetails.ResumeLayout(false);
            this.groupBoxPackageDetails.PerformLayout();
            this.groupBoxReservationDetails.ResumeLayout(false);
            this.groupBoxReservationDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfTravelers)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label labelClientInfo;
        private System.Windows.Forms.Label labelPackageInfo;
        private System.Windows.Forms.Label labelNumberOfTravelers;
        private System.Windows.Forms.NumericUpDown numericUpDownNumberOfTravelers;
        private System.Windows.Forms.Label labelTotalPrice;
        private System.Windows.Forms.TextBox textBoxTotalPrice;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBoxClientDetails;
        private System.Windows.Forms.GroupBox groupBoxPackageDetails;
        private System.Windows.Forms.GroupBox groupBoxReservationDetails;
    }
}
