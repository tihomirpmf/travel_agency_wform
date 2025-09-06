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
            treeViewPackages = new TreeView();
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
            labelClientText = new Label();
            labelClientPhone = new Label();
            labelClientEmail = new Label();
            labelClientName = new Label();
            textBoxClientPhone = new TextBox();
            textBoxClientEmail = new TextBox();
            textBoxClientName = new TextBox();
            labelClientDob = new Label();
            textBoxClientDob = new TextBox();
            groupBoxPackageInfo = new GroupBox();
            labelPackageText = new Label();
            groupBoxActions = new GroupBox();
            buttonBackup = new Button();
            buttonViewDestinations = new Button();
            groupBoxClients.SuspendLayout();
            groupBoxPackages.SuspendLayout();
            groupBoxReservations.SuspendLayout();
            groupBoxClientInfo.SuspendLayout();
            groupBoxPackageInfo.SuspendLayout();
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
            // treeViewPackages
            //
            treeViewPackages.Location = new Point(6, 50);
            treeViewPackages.Name = "treeViewPackages";
            treeViewPackages.Size = new Size(387, 229);
            treeViewPackages.TabIndex = 1;
            treeViewPackages.AfterSelect += treeViewPackages_AfterSelect;
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
            textBoxSearch.PlaceholderText = "Search by name/surname/passport";
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
            groupBoxPackages.Controls.Add(treeViewPackages);
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
            groupBoxClientInfo.Controls.Add(labelClientText);
            groupBoxClientInfo.Location = new Point(12, 364);
            groupBoxClientInfo.Name = "groupBoxClientInfo";
            groupBoxClientInfo.Size = new Size(320, 164);
            groupBoxClientInfo.TabIndex = 6;
            groupBoxClientInfo.TabStop = false;
            groupBoxClientInfo.Text = "Selected Client Information";
            groupBoxClientInfo.Visible = false;
            // 
            // labelClientText
            // 
            labelClientText.Location = new Point(20, 22);
            labelClientText.Name = "labelClientText";
            labelClientText.Size = new Size(280, 132);
            labelClientText.TabIndex = 8;
            // 
            // labelClientPhone
            // 
            labelClientPhone.Location = new Point(0, 0);
            labelClientPhone.Name = "labelClientPhone";
            labelClientPhone.Size = new Size(100, 23);
            labelClientPhone.TabIndex = 0;
            // 
            // labelClientEmail
            // 
            labelClientEmail.Location = new Point(0, 0);
            labelClientEmail.Name = "labelClientEmail";
            labelClientEmail.Size = new Size(100, 23);
            labelClientEmail.TabIndex = 0;
            // 
            // labelClientName
            // 
            labelClientName.Location = new Point(0, 0);
            labelClientName.Name = "labelClientName";
            labelClientName.Size = new Size(100, 23);
            labelClientName.TabIndex = 0;
            // 
            // textBoxClientPhone
            // 
            textBoxClientPhone.Location = new Point(0, 0);
            textBoxClientPhone.Name = "textBoxClientPhone";
            textBoxClientPhone.Size = new Size(100, 23);
            textBoxClientPhone.TabIndex = 0;
            // 
            // textBoxClientEmail
            // 
            textBoxClientEmail.Location = new Point(0, 0);
            textBoxClientEmail.Name = "textBoxClientEmail";
            textBoxClientEmail.Size = new Size(100, 23);
            textBoxClientEmail.TabIndex = 0;
            // 
            // textBoxClientName
            // 
            textBoxClientName.Location = new Point(0, 0);
            textBoxClientName.Name = "textBoxClientName";
            textBoxClientName.Size = new Size(100, 23);
            textBoxClientName.TabIndex = 0;
            // 
            // labelClientDob
            // 
            labelClientDob.Location = new Point(0, 0);
            labelClientDob.Name = "labelClientDob";
            labelClientDob.Size = new Size(100, 23);
            labelClientDob.TabIndex = 0;
            // 
            // textBoxClientDob
            // 
            textBoxClientDob.Location = new Point(0, 0);
            textBoxClientDob.Name = "textBoxClientDob";
            textBoxClientDob.Size = new Size(100, 23);
            textBoxClientDob.TabIndex = 0;
            // 
            // groupBoxPackageInfo
            // 
            groupBoxPackageInfo.Controls.Add(labelPackageText);
            groupBoxPackageInfo.Location = new Point(360, 364);
            groupBoxPackageInfo.Name = "groupBoxPackageInfo";
            groupBoxPackageInfo.Size = new Size(399, 164);
            groupBoxPackageInfo.TabIndex = 8;
            groupBoxPackageInfo.TabStop = false;
            groupBoxPackageInfo.Text = "Selected Package Information";
            groupBoxPackageInfo.Visible = false;
            // 
            // labelPackageText
            // 
            labelPackageText.Location = new Point(20, 22);
            labelPackageText.Name = "labelPackageText";
            labelPackageText.Size = new Size(360, 132);
            labelPackageText.TabIndex = 1;
            // 
            // groupBoxActions
            // 
            groupBoxActions.Controls.Add(buttonBackup);
            groupBoxActions.Controls.Add(buttonViewDestinations);
            groupBoxActions.Location = new Point(765, 364);
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
            Controls.Add(groupBoxPackageInfo);
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
            groupBoxPackageInfo.ResumeLayout(false);
            groupBoxActions.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxClients;
        private System.Windows.Forms.TreeView treeViewPackages;
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
        private System.Windows.Forms.GroupBox groupBoxPackageInfo;
        private System.Windows.Forms.Label labelPackageText;
        private System.Windows.Forms.Label labelClientText;
    }
}
