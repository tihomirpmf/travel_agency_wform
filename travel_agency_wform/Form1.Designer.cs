namespace travel_agency_wform
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBoxClients = new ListBox();
            listBoxPackages = new ListBox();
            listBoxReservations = new ListBox();
            groupBoxClients = new GroupBox();
            textBoxSearch = new TextBox();
            buttonSearch = new Button();
            buttonAddClient = new Button();
            groupBoxPackages = new GroupBox();
            buttonAddPackage = new Button();
            groupBoxReservations = new GroupBox();
            buttonReservePackage = new Button();
            buttonCancelReservation = new Button();
            groupBoxClientInfo = new GroupBox();
            labelClientPhone = new Label();
            labelClientEmail = new Label();
            labelClientName = new Label();
            textBoxClientPhone = new TextBox();
            textBoxClientEmail = new TextBox();
            textBoxClientName = new TextBox();
            labelClientDob = new Label();
            textBoxClientDob = new TextBox();
            groupBoxActions = new GroupBox();
            buttonBackup = new Button();
            buttonViewDestinations = new Button();
            groupBoxClients.SuspendLayout();
            groupBoxPackages.SuspendLayout();
            groupBoxReservations.SuspendLayout();
            groupBoxClientInfo.SuspendLayout();
            groupBoxActions.SuspendLayout();
            SuspendLayout();
            // 
            // listBoxClients
            // 
            listBoxClients.FormattingEnabled = true;
            listBoxClients.ItemHeight = 15;
            listBoxClients.Location = new Point(6, 50);
            listBoxClients.Name = "listBoxClients";
            listBoxClients.Size = new Size(300, 229);
            listBoxClients.TabIndex = 0;
            listBoxClients.SelectedIndexChanged += listBoxClients_SelectedIndexChanged;
            // 
            // listBoxPackages
            // 
            listBoxPackages.FormattingEnabled = true;
            listBoxPackages.ItemHeight = 15;
            listBoxPackages.Location = new Point(6, 50);
            listBoxPackages.Name = "listBoxPackages";
            listBoxPackages.Size = new Size(387, 229);
            listBoxPackages.TabIndex = 1;
            // 
            // listBoxReservations
            // 
            listBoxReservations.FormattingEnabled = true;
            listBoxReservations.ItemHeight = 15;
            listBoxReservations.Location = new Point(6, 50);
            listBoxReservations.Name = "listBoxReservations";
            listBoxReservations.Size = new Size(391, 229);
            listBoxReservations.TabIndex = 2;
            // 
            // groupBoxClients
            // 
            groupBoxClients.Controls.Add(listBoxClients);
            groupBoxClients.Controls.Add(textBoxSearch);
            groupBoxClients.Controls.Add(buttonSearch);
            groupBoxClients.Controls.Add(buttonAddClient);
            groupBoxClients.Location = new Point(12, 12);
            groupBoxClients.Name = "groupBoxClients";
            groupBoxClients.Size = new Size(320, 334);
            groupBoxClients.TabIndex = 3;
            groupBoxClients.TabStop = false;
            groupBoxClients.Text = "Clients";
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(6, 22);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.PlaceholderText = "Search by name or surname";
            textBoxSearch.Size = new Size(200, 23);
            textBoxSearch.TabIndex = 3;
            textBoxSearch.TextChanged += textBoxSearch_TextChanged;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(212, 22);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(94, 23);
            buttonSearch.TabIndex = 4;
            buttonSearch.Text = "Search";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // buttonAddClient
            // 
            buttonAddClient.Location = new Point(6, 285);
            buttonAddClient.Name = "buttonAddClient";
            buttonAddClient.Size = new Size(160, 35);
            buttonAddClient.TabIndex = 5;
            buttonAddClient.Text = "Add New Client";
            buttonAddClient.UseVisualStyleBackColor = true;
            buttonAddClient.Click += buttonAddClient_Click;
            // 
            // groupBoxPackages
            // 
            groupBoxPackages.Controls.Add(listBoxPackages);
            groupBoxPackages.Controls.Add(buttonAddPackage);
            groupBoxPackages.Location = new Point(360, 12);
            groupBoxPackages.Name = "groupBoxPackages";
            groupBoxPackages.Size = new Size(399, 334);
            groupBoxPackages.TabIndex = 4;
            groupBoxPackages.TabStop = false;
            groupBoxPackages.Text = "Travel Packages";
            // 
            // buttonAddPackage
            // 
            buttonAddPackage.Location = new Point(6, 285);
            buttonAddPackage.Name = "buttonAddPackage";
            buttonAddPackage.Size = new Size(160, 35);
            buttonAddPackage.TabIndex = 6;
            buttonAddPackage.Text = "Add New Package";
            buttonAddPackage.UseVisualStyleBackColor = true;
            buttonAddPackage.Click += buttonAddPackage_Click;
            // 
            // groupBoxReservations
            // 
            groupBoxReservations.Controls.Add(listBoxReservations);
            groupBoxReservations.Controls.Add(buttonReservePackage);
            groupBoxReservations.Controls.Add(buttonCancelReservation);
            groupBoxReservations.Location = new Point(765, 12);
            groupBoxReservations.Name = "groupBoxReservations";
            groupBoxReservations.Size = new Size(403, 334);
            groupBoxReservations.TabIndex = 5;
            groupBoxReservations.TabStop = false;
            groupBoxReservations.Text = "Client Reservations";
            // 
            // buttonReservePackage
            // 
            buttonReservePackage.Location = new Point(6, 285);
            buttonReservePackage.Name = "buttonReservePackage";
            buttonReservePackage.Size = new Size(160, 35);
            buttonReservePackage.TabIndex = 7;
            buttonReservePackage.Text = "Reserve Package";
            buttonReservePackage.UseVisualStyleBackColor = true;
            buttonReservePackage.Click += buttonReservePackage_Click;
            // 
            // buttonCancelReservation
            // 
            buttonCancelReservation.Location = new Point(237, 285);
            buttonCancelReservation.Name = "buttonCancelReservation";
            buttonCancelReservation.Size = new Size(160, 35);
            buttonCancelReservation.TabIndex = 8;
            buttonCancelReservation.Text = "Cancel Reservation";
            buttonCancelReservation.UseVisualStyleBackColor = true;
            buttonCancelReservation.Click += buttonCancelReservation_Click;
            // 
            // groupBoxClientInfo
            // 
            groupBoxClientInfo.Controls.Add(labelClientPhone);
            groupBoxClientInfo.Controls.Add(labelClientEmail);
            groupBoxClientInfo.Controls.Add(labelClientName);
            groupBoxClientInfo.Controls.Add(textBoxClientPhone);
            groupBoxClientInfo.Controls.Add(textBoxClientEmail);
            groupBoxClientInfo.Controls.Add(textBoxClientName);
            groupBoxClientInfo.Controls.Add(labelClientDob);
            groupBoxClientInfo.Controls.Add(textBoxClientDob);
            groupBoxClientInfo.Location = new Point(12, 364);
            groupBoxClientInfo.Name = "groupBoxClientInfo";
            groupBoxClientInfo.Size = new Size(320, 164);
            groupBoxClientInfo.TabIndex = 6;
            groupBoxClientInfo.TabStop = false;
            groupBoxClientInfo.Text = "Selected Client Information";
            groupBoxClientInfo.Visible = false;
            // 
            // labelClientPhone
            // 
            labelClientPhone.AutoSize = true;
            labelClientPhone.Location = new Point(20, 98);
            labelClientPhone.Name = "labelClientPhone";
            labelClientPhone.Size = new Size(44, 15);
            labelClientPhone.TabIndex = 5;
            labelClientPhone.Text = "Phone:";
            // 
            // labelClientEmail
            // 
            labelClientEmail.AutoSize = true;
            labelClientEmail.Location = new Point(20, 63);
            labelClientEmail.Name = "labelClientEmail";
            labelClientEmail.Size = new Size(39, 15);
            labelClientEmail.TabIndex = 4;
            labelClientEmail.Text = "Email:";
            // 
            // labelClientName
            // 
            labelClientName.AutoSize = true;
            labelClientName.Location = new Point(20, 28);
            labelClientName.Name = "labelClientName";
            labelClientName.Size = new Size(42, 15);
            labelClientName.TabIndex = 3;
            labelClientName.Text = "Name:";
            // 
            // textBoxClientPhone
            // 
            textBoxClientPhone.Location = new Point(100, 95);
            textBoxClientPhone.Name = "textBoxClientPhone";
            textBoxClientPhone.ReadOnly = true;
            textBoxClientPhone.Size = new Size(200, 23);
            textBoxClientPhone.TabIndex = 2;
            // 
            // textBoxClientEmail
            // 
            textBoxClientEmail.Location = new Point(100, 60);
            textBoxClientEmail.Name = "textBoxClientEmail";
            textBoxClientEmail.ReadOnly = true;
            textBoxClientEmail.Size = new Size(200, 23);
            textBoxClientEmail.TabIndex = 1;
            // 
            // textBoxClientName
            // 
            textBoxClientName.Location = new Point(100, 25);
            textBoxClientName.Name = "textBoxClientName";
            textBoxClientName.ReadOnly = true;
            textBoxClientName.Size = new Size(200, 23);
            textBoxClientName.TabIndex = 0;
            // 
            // labelClientDob
            // 
            labelClientDob.AutoSize = true;
            labelClientDob.Location = new Point(20, 133);
            labelClientDob.Name = "labelClientDob";
            labelClientDob.Size = new Size(74, 15);
            labelClientDob.TabIndex = 6;
            labelClientDob.Text = "Date of birth:";
            // 
            // textBoxClientDob
            // 
            textBoxClientDob.Location = new Point(100, 130);
            textBoxClientDob.Name = "textBoxClientDob";
            textBoxClientDob.ReadOnly = true;
            textBoxClientDob.Size = new Size(200, 23);
            textBoxClientDob.TabIndex = 7;
            // 
            // groupBoxActions
            // 
            groupBoxActions.Controls.Add(buttonBackup);
            groupBoxActions.Controls.Add(buttonViewDestinations);
            groupBoxActions.Location = new Point(765, 352);
            groupBoxActions.Name = "groupBoxActions";
            groupBoxActions.Size = new Size(403, 64);
            groupBoxActions.TabIndex = 7;
            groupBoxActions.TabStop = false;
            groupBoxActions.Text = "Actions";
            // 
            // buttonBackup
            // 
            buttonBackup.Location = new Point(6, 18);
            buttonBackup.Name = "buttonBackup";
            buttonBackup.Size = new Size(160, 35);
            buttonBackup.TabIndex = 2;
            buttonBackup.Text = "Create Database Backup";
            buttonBackup.UseVisualStyleBackColor = true;
            buttonBackup.Click += buttonBackup_Click;
            // 
            // buttonViewDestinations
            // 
            buttonViewDestinations.Location = new Point(237, 18);
            buttonViewDestinations.Name = "buttonViewDestinations";
            buttonViewDestinations.Size = new Size(160, 35);
            buttonViewDestinations.TabIndex = 5;
            buttonViewDestinations.Text = "View Destinations";
            buttonViewDestinations.UseVisualStyleBackColor = true;
            buttonViewDestinations.Click += buttonViewDestinations_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1180, 540);
            Controls.Add(groupBoxActions);
            Controls.Add(groupBoxClientInfo);
            Controls.Add(groupBoxReservations);
            Controls.Add(groupBoxPackages);
            Controls.Add(groupBoxClients);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Travel Agency Management System";
            groupBoxClients.ResumeLayout(false);
            groupBoxClients.PerformLayout();
            groupBoxPackages.ResumeLayout(false);
            groupBoxReservations.ResumeLayout(false);
            groupBoxClientInfo.ResumeLayout(false);
            groupBoxClientInfo.PerformLayout();
            groupBoxActions.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxClients;
        private System.Windows.Forms.ListBox listBoxPackages;
        private System.Windows.Forms.ListBox listBoxReservations;
        private System.Windows.Forms.GroupBox groupBoxClients;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonAddClient;
        private System.Windows.Forms.GroupBox groupBoxPackages;
        private System.Windows.Forms.Button buttonAddPackage;
        private System.Windows.Forms.GroupBox groupBoxReservations;
        private System.Windows.Forms.Button buttonReservePackage;
        private System.Windows.Forms.Button buttonCancelReservation;
        private System.Windows.Forms.GroupBox groupBoxClientInfo;
        private System.Windows.Forms.TextBox textBoxClientName;
        private System.Windows.Forms.TextBox textBoxClientEmail;
        private System.Windows.Forms.TextBox textBoxClientPhone;
        private System.Windows.Forms.Label labelClientName;
        private System.Windows.Forms.Label labelClientEmail;
        private System.Windows.Forms.Label labelClientPhone;
        private System.Windows.Forms.GroupBox groupBoxActions;
        private System.Windows.Forms.Button buttonBackup;

        private System.Windows.Forms.Button buttonViewDestinations;
        private System.Windows.Forms.Label labelClientDob;
        private System.Windows.Forms.TextBox textBoxClientDob;
    }
}
