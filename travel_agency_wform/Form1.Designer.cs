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
            this.listBoxClients = new System.Windows.Forms.ListBox();
            this.listBoxPackages = new System.Windows.Forms.ListBox();
            this.listBoxReservations = new System.Windows.Forms.ListBox();
            this.groupBoxClients = new System.Windows.Forms.GroupBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonAddClient = new System.Windows.Forms.Button();
            this.groupBoxPackages = new System.Windows.Forms.GroupBox();
            this.buttonAddPackage = new System.Windows.Forms.Button();
            this.groupBoxReservations = new System.Windows.Forms.GroupBox();
            this.buttonReservePackage = new System.Windows.Forms.Button();
            this.buttonCancelReservation = new System.Windows.Forms.Button();
            this.groupBoxClientInfo = new System.Windows.Forms.GroupBox();
            this.textBoxClientName = new System.Windows.Forms.TextBox();
            this.textBoxClientEmail = new System.Windows.Forms.TextBox();
            this.textBoxClientPhone = new System.Windows.Forms.TextBox();
            this.labelClientName = new System.Windows.Forms.Label();
            this.labelClientEmail = new System.Windows.Forms.Label();
            this.labelClientPhone = new System.Windows.Forms.Label();
            this.groupBoxActions = new System.Windows.Forms.GroupBox();
            this.buttonViewDestinations = new System.Windows.Forms.Button();
            this.buttonBackup = new System.Windows.Forms.Button();
            this.buttonUndo = new System.Windows.Forms.Button();
            this.buttonRedo = new System.Windows.Forms.Button();
            this.listBoxCommandHistory = new System.Windows.Forms.ListBox();
            this.groupBoxCommandHistory = new System.Windows.Forms.GroupBox();
            this.groupBoxClients.SuspendLayout();
            this.groupBoxPackages.SuspendLayout();
            this.groupBoxReservations.SuspendLayout();
            this.groupBoxClientInfo.SuspendLayout();
            this.groupBoxActions.SuspendLayout();
            this.groupBoxCommandHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxClients
            // 
            this.listBoxClients.FormattingEnabled = true;
            this.listBoxClients.ItemHeight = 15;
            this.listBoxClients.Location = new System.Drawing.Point(6, 50);
            this.listBoxClients.Name = "listBoxClients";
            this.listBoxClients.Size = new System.Drawing.Size(300, 240);
            this.listBoxClients.TabIndex = 0;
            this.listBoxClients.SelectedIndexChanged += new System.EventHandler(this.listBoxClients_SelectedIndexChanged);
            // 
            // listBoxPackages
            // 
            this.listBoxPackages.FormattingEnabled = true;
            this.listBoxPackages.ItemHeight = 15;
            this.listBoxPackages.Location = new System.Drawing.Point(6, 50);
            this.listBoxPackages.Name = "listBoxPackages";
            this.listBoxPackages.Size = new System.Drawing.Size(340, 240);
            this.listBoxPackages.TabIndex = 1;
            // 
            // listBoxReservations
            // 
            this.listBoxReservations.FormattingEnabled = true;
            this.listBoxReservations.ItemHeight = 15;
            this.listBoxReservations.Location = new System.Drawing.Point(6, 50);
            this.listBoxReservations.Name = "listBoxReservations";
            this.listBoxReservations.Size = new System.Drawing.Size(340, 240);
            this.listBoxReservations.TabIndex = 2;
            // 
            // groupBoxClients
            // 
            this.groupBoxClients.Controls.Add(this.listBoxClients);
            this.groupBoxClients.Controls.Add(this.textBoxSearch);
            this.groupBoxClients.Controls.Add(this.buttonSearch);
            this.groupBoxClients.Controls.Add(this.buttonAddClient);
            this.groupBoxClients.Location = new System.Drawing.Point(12, 12);
            this.groupBoxClients.Name = "groupBoxClients";
            this.groupBoxClients.Size = new System.Drawing.Size(320, 360);
            this.groupBoxClients.TabIndex = 3;
            this.groupBoxClients.TabStop = false;
            this.groupBoxClients.Text = "Clients";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(6, 22);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.PlaceholderText = "Search by name, surname, or passport...";
            this.textBoxSearch.Size = new System.Drawing.Size(200, 23);
            this.textBoxSearch.TabIndex = 3;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(212, 22);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(94, 23);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonAddClient
            // 
            this.buttonAddClient.Location = new System.Drawing.Point(6, 296);
            this.buttonAddClient.Name = "buttonAddClient";
            this.buttonAddClient.Size = new System.Drawing.Size(300, 38);
            this.buttonAddClient.TabIndex = 5;
            this.buttonAddClient.Text = "Add New Client";
            this.buttonAddClient.UseVisualStyleBackColor = true;
            this.buttonAddClient.Click += new System.EventHandler(this.buttonAddClient_Click);
            // 
            // groupBoxPackages
            // 
            this.groupBoxPackages.Controls.Add(this.listBoxPackages);
            this.groupBoxPackages.Controls.Add(this.buttonAddPackage);
            this.groupBoxPackages.Location = new System.Drawing.Point(360, 12);
            this.groupBoxPackages.Name = "groupBoxPackages";
            this.groupBoxPackages.Size = new System.Drawing.Size(360, 360);
            this.groupBoxPackages.TabIndex = 4;
            this.groupBoxPackages.TabStop = false;
            this.groupBoxPackages.Text = "Travel Packages";
            // 
            // buttonAddPackage
            // 
            this.buttonAddPackage.Location = new System.Drawing.Point(6, 296);
            this.buttonAddPackage.Name = "buttonAddPackage";
            this.buttonAddPackage.Size = new System.Drawing.Size(340, 38);
            this.buttonAddPackage.TabIndex = 6;
            this.buttonAddPackage.Text = "Add New Package";
            this.buttonAddPackage.UseVisualStyleBackColor = true;
            this.buttonAddPackage.Click += new System.EventHandler(this.buttonAddPackage_Click);
            // 
            // groupBoxReservations
            // 
            this.groupBoxReservations.Controls.Add(this.listBoxReservations);
            this.groupBoxReservations.Controls.Add(this.buttonReservePackage);
            this.groupBoxReservations.Controls.Add(this.buttonCancelReservation);
            this.groupBoxReservations.Location = new System.Drawing.Point(740, 12);
            this.groupBoxReservations.Name = "groupBoxReservations";
            this.groupBoxReservations.Size = new System.Drawing.Size(360, 360);
            this.groupBoxReservations.TabIndex = 5;
            this.groupBoxReservations.TabStop = false;
            this.groupBoxReservations.Text = "Client Reservations";
            // 
            // buttonReservePackage
            // 
            this.buttonReservePackage.Location = new System.Drawing.Point(6, 296);
            this.buttonReservePackage.Name = "buttonReservePackage";
            this.buttonReservePackage.Size = new System.Drawing.Size(150, 38);
            this.buttonReservePackage.TabIndex = 7;
            this.buttonReservePackage.Text = "Reserve Package";
            this.buttonReservePackage.UseVisualStyleBackColor = true;
            this.buttonReservePackage.Click += new System.EventHandler(this.buttonReservePackage_Click);
            // 
            // buttonCancelReservation
            // 
            this.buttonCancelReservation.Location = new System.Drawing.Point(162, 296);
            this.buttonCancelReservation.Name = "buttonCancelReservation";
            this.buttonCancelReservation.Size = new System.Drawing.Size(150, 38);
            this.buttonCancelReservation.TabIndex = 8;
            this.buttonCancelReservation.Text = "Cancel Reservation";
            this.buttonCancelReservation.UseVisualStyleBackColor = true;
            this.buttonCancelReservation.Click += new System.EventHandler(this.buttonCancelReservation_Click);
            // 
            // groupBoxClientInfo
            // 
            this.groupBoxClientInfo.Controls.Add(this.labelClientPhone);
            this.groupBoxClientInfo.Controls.Add(this.labelClientEmail);
            this.groupBoxClientInfo.Controls.Add(this.labelClientName);
            this.groupBoxClientInfo.Controls.Add(this.textBoxClientPhone);
            this.groupBoxClientInfo.Controls.Add(this.textBoxClientEmail);
            this.groupBoxClientInfo.Controls.Add(this.textBoxClientName);
            this.groupBoxClientInfo.Location = new System.Drawing.Point(12, 420);
            this.groupBoxClientInfo.Name = "groupBoxClientInfo";
            this.groupBoxClientInfo.Size = new System.Drawing.Size(320, 150);
            this.groupBoxClientInfo.TabIndex = 6;
            this.groupBoxClientInfo.TabStop = false;
            this.groupBoxClientInfo.Text = "Selected Client Information";
            this.groupBoxClientInfo.Visible = false;
            // 
            // textBoxClientName
            // 
            this.textBoxClientName.Location = new System.Drawing.Point(100, 25);
            this.textBoxClientName.Name = "textBoxClientName";
            this.textBoxClientName.ReadOnly = true;
            this.textBoxClientName.Size = new System.Drawing.Size(200, 23);
            this.textBoxClientName.TabIndex = 0;
            // 
            // textBoxClientEmail
            // 
            this.textBoxClientEmail.Location = new System.Drawing.Point(100, 60);
            this.textBoxClientEmail.Name = "textBoxClientEmail";
            this.textBoxClientEmail.ReadOnly = true;
            this.textBoxClientEmail.Size = new System.Drawing.Size(200, 23);
            this.textBoxClientEmail.TabIndex = 1;
            // 
            // textBoxClientPhone
            // 
            this.textBoxClientPhone.Location = new System.Drawing.Point(100, 95);
            this.textBoxClientPhone.Name = "textBoxClientPhone";
            this.textBoxClientPhone.ReadOnly = true;
            this.textBoxClientPhone.Size = new System.Drawing.Size(200, 23);
            this.textBoxClientPhone.TabIndex = 2;
            // 
            // labelClientName
            // 
            this.labelClientName.AutoSize = true;
            this.labelClientName.Location = new System.Drawing.Point(20, 28);
            this.labelClientName.Name = "labelClientName";
            this.labelClientName.Size = new System.Drawing.Size(42, 15);
            this.labelClientName.TabIndex = 3;
            this.labelClientName.Text = "Name:";
            // 
            // labelClientEmail
            // 
            this.labelClientEmail.AutoSize = true;
            this.labelClientEmail.Location = new System.Drawing.Point(20, 63);
            this.labelClientEmail.Name = "labelClientEmail";
            this.labelClientEmail.Size = new System.Drawing.Size(44, 15);
            this.labelClientEmail.TabIndex = 4;
            this.labelClientEmail.Text = "Email:";
            // 
            // labelClientPhone
            // 
            this.labelClientPhone.AutoSize = true;
            this.labelClientPhone.Location = new System.Drawing.Point(20, 98);
            this.labelClientPhone.Name = "labelClientPhone";
            this.labelClientPhone.Size = new System.Drawing.Size(47, 15);
            this.labelClientPhone.TabIndex = 5;
            this.labelClientPhone.Text = "Phone:";
            // 
            // groupBoxActions
            // 
            this.groupBoxActions.Controls.Add(this.buttonBackup);
            this.groupBoxActions.Controls.Add(this.buttonViewDestinations);
            this.groupBoxActions.Controls.Add(this.buttonUndo);
            this.groupBoxActions.Controls.Add(this.buttonRedo);

            this.groupBoxActions.Location = new System.Drawing.Point(360, 420);
            this.groupBoxActions.Name = "groupBoxActions";
            this.groupBoxActions.Size = new System.Drawing.Size(320, 240);
            this.groupBoxActions.TabIndex = 7;
            this.groupBoxActions.TabStop = false;
            this.groupBoxActions.Text = "Actions";
            // 
            // buttonViewDestinations
            // 
            this.buttonViewDestinations.Location = new System.Drawing.Point(6, 160);
            this.buttonViewDestinations.Name = "buttonViewDestinations";
            this.buttonViewDestinations.Size = new System.Drawing.Size(300, 35);
            this.buttonViewDestinations.TabIndex = 5;
            this.buttonViewDestinations.Text = "View Destinations";
            this.buttonViewDestinations.UseVisualStyleBackColor = true;
            this.buttonViewDestinations.Click += new System.EventHandler(this.buttonViewDestinations_Click);
            // 
            // buttonUndo
            // 
            this.buttonUndo.Enabled = false;
            this.buttonUndo.Location = new System.Drawing.Point(6, 25);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(145, 35);
            this.buttonUndo.TabIndex = 3;
            this.buttonUndo.Text = "↶ Undo";
            this.buttonUndo.UseVisualStyleBackColor = true;
            this.buttonUndo.Click += new System.EventHandler(this.buttonUndo_Click);
            // 
            // buttonRedo
            // 
            this.buttonRedo.Enabled = false;
            this.buttonRedo.Location = new System.Drawing.Point(161, 25);
            this.buttonRedo.Name = "buttonRedo";
            this.buttonRedo.Size = new System.Drawing.Size(145, 35);
            this.buttonRedo.TabIndex = 4;
            this.buttonRedo.Text = "↷ Redo";
            this.buttonRedo.UseVisualStyleBackColor = true;
            this.buttonRedo.Click += new System.EventHandler(this.buttonRedo_Click);
            // 
            // buttonBackup
            // 
            this.buttonBackup.Location = new System.Drawing.Point(6, 75);
            this.buttonBackup.Name = "buttonBackup";
            this.buttonBackup.Size = new System.Drawing.Size(300, 35);
            this.buttonBackup.TabIndex = 2;
            this.buttonBackup.Text = "Create Database Backup";
            this.buttonBackup.UseVisualStyleBackColor = true;
            this.buttonBackup.Click += new System.EventHandler(this.buttonBackup_Click);
            // 
                         // groupBoxCommandHistory
             // 
             this.groupBoxCommandHistory.Controls.Add(this.listBoxCommandHistory);
             this.groupBoxCommandHistory.Location = new System.Drawing.Point(708, 420);
             this.groupBoxCommandHistory.Name = "groupBoxCommandHistory";
             this.groupBoxCommandHistory.Size = new System.Drawing.Size(320, 150);
             this.groupBoxCommandHistory.TabIndex = 8;
             this.groupBoxCommandHistory.TabStop = false;
             this.groupBoxCommandHistory.Text = "Command History";
            // 
                         // listBoxCommandHistory
             // 
             this.listBoxCommandHistory.FormattingEnabled = true;
             this.listBoxCommandHistory.ItemHeight = 15;
             this.listBoxCommandHistory.Location = new System.Drawing.Point(6, 25);
             this.listBoxCommandHistory.Name = "listBoxCommandHistory";
             this.listBoxCommandHistory.Size = new System.Drawing.Size(308, 119);
             this.listBoxCommandHistory.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 700);
            this.Controls.Add(this.groupBoxCommandHistory);
            this.Controls.Add(this.groupBoxActions);
            this.Controls.Add(this.groupBoxClientInfo);
            this.Controls.Add(this.groupBoxReservations);
            this.Controls.Add(this.groupBoxPackages);
            this.Controls.Add(this.groupBoxClients);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Travel Agency Management System";
            this.groupBoxClients.ResumeLayout(false);
            this.groupBoxClients.PerformLayout();
            this.groupBoxPackages.ResumeLayout(false);
            this.groupBoxReservations.ResumeLayout(false);
            this.groupBoxClientInfo.ResumeLayout(false);
            this.groupBoxClientInfo.PerformLayout();
            this.groupBoxActions.ResumeLayout(false);
            this.groupBoxCommandHistory.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button buttonUndo;
        private System.Windows.Forms.Button buttonRedo;
        private System.Windows.Forms.ListBox listBoxCommandHistory;
        private System.Windows.Forms.GroupBox groupBoxCommandHistory;
        private System.Windows.Forms.Button buttonViewDestinations;
    }
}
