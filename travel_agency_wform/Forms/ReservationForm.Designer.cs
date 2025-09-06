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
            labelClientInfo = new Label();
            labelPackageInfo = new Label();
            labelNumberOfTravelers = new Label();
            numericUpDownNumberOfTravelers = new NumericUpDown();
            labelTotalPrice = new Label();
            textBoxTotalPrice = new TextBox();
            buttonConfirm = new Button();
            buttonCancel = new Button();
            groupBoxClientDetails = new GroupBox();
            groupBoxPackageDetails = new GroupBox();
            groupBoxReservationDetails = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDownNumberOfTravelers).BeginInit();
            groupBoxClientDetails.SuspendLayout();
            groupBoxPackageDetails.SuspendLayout();
            groupBoxReservationDetails.SuspendLayout();
            SuspendLayout();
            // 
            // labelClientInfo
            // 
            labelClientInfo.AutoSize = true;
            labelClientInfo.Location = new Point(20, 30);
            labelClientInfo.Name = "labelClientInfo";
            labelClientInfo.Size = new Size(118, 15);
            labelClientInfo.TabIndex = 0;
            labelClientInfo.Text = "Client: [Client Name]";
            // 
            // labelPackageInfo
            // 
            labelPackageInfo.AutoSize = true;
            labelPackageInfo.Location = new Point(20, 30);
            labelPackageInfo.Name = "labelPackageInfo";
            labelPackageInfo.Size = new Size(144, 15);
            labelPackageInfo.TabIndex = 0;
            labelPackageInfo.Text = "Package: [Package Name]";
            // 
            // labelNumberOfTravelers
            // 
            labelNumberOfTravelers.AutoSize = true;
            labelNumberOfTravelers.Location = new Point(20, 30);
            labelNumberOfTravelers.Name = "labelNumberOfTravelers";
            labelNumberOfTravelers.Size = new Size(117, 15);
            labelNumberOfTravelers.TabIndex = 0;
            labelNumberOfTravelers.Text = "Number of Travelers:";
            // 
            // numericUpDownNumberOfTravelers
            // 
            numericUpDownNumberOfTravelers.Location = new Point(150, 27);
            numericUpDownNumberOfTravelers.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownNumberOfTravelers.Name = "numericUpDownNumberOfTravelers";
            numericUpDownNumberOfTravelers.Size = new Size(100, 23);
            numericUpDownNumberOfTravelers.TabIndex = 1;
            numericUpDownNumberOfTravelers.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // labelTotalPrice
            // 
            labelTotalPrice.AutoSize = true;
            labelTotalPrice.Location = new Point(20, 70);
            labelTotalPrice.Name = "labelTotalPrice";
            labelTotalPrice.Size = new Size(65, 15);
            labelTotalPrice.TabIndex = 2;
            labelTotalPrice.Text = "Total Price:";
            // 
            // textBoxTotalPrice
            // 
            textBoxTotalPrice.Location = new Point(150, 67);
            textBoxTotalPrice.Name = "textBoxTotalPrice";
            textBoxTotalPrice.ReadOnly = true;
            textBoxTotalPrice.Size = new Size(100, 23);
            textBoxTotalPrice.TabIndex = 3;
            textBoxTotalPrice.Text = "$0.00";
            // 
            // buttonConfirm
            // 
            buttonConfirm.Location = new Point(519, 301);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(75, 23);
            buttonConfirm.TabIndex = 4;
            buttonConfirm.Text = "Confirm";
            buttonConfirm.UseVisualStyleBackColor = true;
            buttonConfirm.Click += buttonConfirm_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(618, 301);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // groupBoxClientDetails
            // 
            groupBoxClientDetails.Controls.Add(labelClientInfo);
            groupBoxClientDetails.Location = new Point(20, 20);
            groupBoxClientDetails.Name = "groupBoxClientDetails";
            groupBoxClientDetails.Size = new Size(673, 70);
            groupBoxClientDetails.TabIndex = 6;
            groupBoxClientDetails.TabStop = false;
            groupBoxClientDetails.Text = "Client Details";
            // 
            // groupBoxPackageDetails
            // 
            groupBoxPackageDetails.Controls.Add(labelPackageInfo);
            groupBoxPackageDetails.Location = new Point(20, 100);
            groupBoxPackageDetails.Name = "groupBoxPackageDetails";
            groupBoxPackageDetails.Size = new Size(673, 70);
            groupBoxPackageDetails.TabIndex = 7;
            groupBoxPackageDetails.TabStop = false;
            groupBoxPackageDetails.Text = "Package Details";
            // 
            // groupBoxReservationDetails
            // 
            groupBoxReservationDetails.Controls.Add(textBoxTotalPrice);
            groupBoxReservationDetails.Controls.Add(labelTotalPrice);
            groupBoxReservationDetails.Controls.Add(numericUpDownNumberOfTravelers);
            groupBoxReservationDetails.Controls.Add(labelNumberOfTravelers);
            groupBoxReservationDetails.Location = new Point(20, 180);
            groupBoxReservationDetails.Name = "groupBoxReservationDetails";
            groupBoxReservationDetails.Size = new Size(673, 110);
            groupBoxReservationDetails.TabIndex = 8;
            groupBoxReservationDetails.TabStop = false;
            groupBoxReservationDetails.Text = "Reservation Details";
            // 
            // ReservationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(711, 336);
            Controls.Add(groupBoxReservationDetails);
            Controls.Add(groupBoxPackageDetails);
            Controls.Add(groupBoxClientDetails);
            Controls.Add(buttonCancel);
            Controls.Add(buttonConfirm);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReservationForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Make Reservation";
            ((System.ComponentModel.ISupportInitialize)numericUpDownNumberOfTravelers).EndInit();
            groupBoxClientDetails.ResumeLayout(false);
            groupBoxClientDetails.PerformLayout();
            groupBoxPackageDetails.ResumeLayout(false);
            groupBoxPackageDetails.PerformLayout();
            groupBoxReservationDetails.ResumeLayout(false);
            groupBoxReservationDetails.PerformLayout();
            ResumeLayout(false);
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
