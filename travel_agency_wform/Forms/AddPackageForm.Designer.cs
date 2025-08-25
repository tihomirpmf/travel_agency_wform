namespace travel_agency_wform.Forms
{
    partial class AddPackageForm
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
            this.comboBoxPackageType = new System.Windows.Forms.ComboBox();
            this.labelPackageType = new System.Windows.Forms.Label();
            this.labelPackageName = new System.Windows.Forms.Label();
            this.textBoxPackageName = new System.Windows.Forms.TextBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.numericUpDownPrice = new System.Windows.Forms.NumericUpDown();
            this.labelDestination = new System.Windows.Forms.Label();
            this.textBoxDestination = new System.Windows.Forms.TextBox();
            this.labelNumberOfDays = new System.Windows.Forms.Label();
            this.numericUpDownNumberOfDays = new System.Windows.Forms.NumericUpDown();
            this.labelNumberOfTravelers = new System.Windows.Forms.Label();
            this.numericUpDownNumberOfTravelers = new System.Windows.Forms.NumericUpDown();
            this.panelSeaside = new System.Windows.Forms.Panel();
            this.labelSeasideAccommodationType = new System.Windows.Forms.Label();
            this.textBoxSeasideAccommodationType = new System.Windows.Forms.TextBox();
            this.labelSeasideTransportationType = new System.Windows.Forms.Label();
            this.textBoxSeasideTransportationType = new System.Windows.Forms.TextBox();
            this.panelMountain = new System.Windows.Forms.Panel();
            this.labelMountainActivities = new System.Windows.Forms.Label();
            this.textBoxMountainActivities = new System.Windows.Forms.TextBox();
            this.labelMountainTransportation = new System.Windows.Forms.Label();
            this.textBoxMountainTransportation = new System.Windows.Forms.TextBox();
            this.labelMountainAccommodationType = new System.Windows.Forms.Label();
            this.textBoxMountainAccommodationType = new System.Windows.Forms.TextBox();
            this.panelExcursion = new System.Windows.Forms.Panel();
            this.labelExcursionGuide = new System.Windows.Forms.Label();
            this.textBoxExcursionGuide = new System.Windows.Forms.TextBox();
            this.labelExcursionTransportation = new System.Windows.Forms.Label();
            this.textBoxExcursionTransportation = new System.Windows.Forms.TextBox();
            this.panelCruise = new System.Windows.Forms.Panel();
            this.labelCruiseShip = new System.Windows.Forms.Label();
            this.textBoxCruiseShip = new System.Windows.Forms.TextBox();
            this.labelCruiseRoute = new System.Windows.Forms.Label();
            this.textBoxCruiseRoute = new System.Windows.Forms.TextBox();
            this.labelCruiseDepartureDate = new System.Windows.Forms.Label();
            this.dateTimePickerCruiseDepartureDate = new System.Windows.Forms.DateTimePicker();
            this.labelCruiseCabinType = new System.Windows.Forms.Label();
            this.textBoxCruiseCabinType = new System.Windows.Forms.TextBox();
            this.labelCruiseTransportation = new System.Windows.Forms.Label();
            this.textBoxCruiseTransportation = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfTravelers)).BeginInit();
            this.panelSeaside.SuspendLayout();
            this.panelMountain.SuspendLayout();
            this.panelExcursion.SuspendLayout();
            this.panelCruise.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxPackageType
            // 
            this.comboBoxPackageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPackageType.FormattingEnabled = true;
            this.comboBoxPackageType.Location = new System.Drawing.Point(120, 20);
            this.comboBoxPackageType.Name = "comboBoxPackageType";
            this.comboBoxPackageType.Size = new System.Drawing.Size(200, 23);
            this.comboBoxPackageType.TabIndex = 0;
            // 
            // labelPackageType
            // 
            this.labelPackageType.AutoSize = true;
            this.labelPackageType.Location = new System.Drawing.Point(20, 23);
            this.labelPackageType.Name = "labelPackageType";
            this.labelPackageType.Size = new System.Drawing.Size(80, 15);
            this.labelPackageType.TabIndex = 1;
            this.labelPackageType.Text = "Package Type:";
            // 
            // labelPackageName
            // 
            this.labelPackageName.AutoSize = true;
            this.labelPackageName.Location = new System.Drawing.Point(20, 60);
            this.labelPackageName.Name = "labelPackageName";
            this.labelPackageName.Size = new System.Drawing.Size(90, 15);
            this.labelPackageName.TabIndex = 2;
            this.labelPackageName.Text = "Package Name:";
            // 
            // textBoxPackageName
            // 
            this.textBoxPackageName.Location = new System.Drawing.Point(120, 57);
            this.textBoxPackageName.Name = "textBoxPackageName";
            this.textBoxPackageName.Size = new System.Drawing.Size(200, 23);
            this.textBoxPackageName.TabIndex = 3;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(20, 100);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(36, 15);
            this.labelPrice.TabIndex = 4;
            this.labelPrice.Text = "Price:";
            // 
            // numericUpDownPrice
            // 
            this.numericUpDownPrice.Location = new System.Drawing.Point(120, 97);
            this.numericUpDownPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownPrice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPrice.Name = "numericUpDownPrice";
            this.numericUpDownPrice.Size = new System.Drawing.Size(200, 23);
            this.numericUpDownPrice.TabIndex = 5;
            this.numericUpDownPrice.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // labelDestination
            // 
            this.labelDestination.AutoSize = true;
            this.labelDestination.Location = new System.Drawing.Point(20, 140);
            this.labelDestination.Name = "labelDestination";
            this.labelDestination.Size = new System.Drawing.Size(70, 15);
            this.labelDestination.TabIndex = 6;
            this.labelDestination.Text = "Destination:";
            // 
            // textBoxDestination
            // 
            this.textBoxDestination.Location = new System.Drawing.Point(120, 137);
            this.textBoxDestination.Name = "textBoxDestination";
            this.textBoxDestination.Size = new System.Drawing.Size(200, 23);
            this.textBoxDestination.TabIndex = 7;
            // 
            // labelNumberOfDays
            // 
            this.labelNumberOfDays.AutoSize = true;
            this.labelNumberOfDays.Location = new System.Drawing.Point(20, 180);
            this.labelNumberOfDays.Name = "labelNumberOfDays";
            this.labelNumberOfDays.Size = new System.Drawing.Size(100, 15);
            this.labelNumberOfDays.TabIndex = 8;
            this.labelNumberOfDays.Text = "Number of Days:";
            // 
            // numericUpDownNumberOfDays
            // 
            this.numericUpDownNumberOfDays.Location = new System.Drawing.Point(120, 177);
            this.numericUpDownNumberOfDays.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.numericUpDownNumberOfDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNumberOfDays.Name = "numericUpDownNumberOfDays";
            this.numericUpDownNumberOfDays.Size = new System.Drawing.Size(200, 23);
            this.numericUpDownNumberOfDays.TabIndex = 9;
            this.numericUpDownNumberOfDays.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // labelNumberOfTravelers
            // 
            this.labelNumberOfTravelers.AutoSize = true;
            this.labelNumberOfTravelers.Location = new System.Drawing.Point(20, 220);
            this.labelNumberOfTravelers.Name = "labelNumberOfTravelers";
            this.labelNumberOfTravelers.Size = new System.Drawing.Size(120, 15);
            this.labelNumberOfTravelers.TabIndex = 10;
            this.labelNumberOfTravelers.Text = "Number of Travelers:";
            // 
            // numericUpDownNumberOfTravelers
            // 
            this.numericUpDownNumberOfTravelers.Location = new System.Drawing.Point(120, 217);
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
            this.numericUpDownNumberOfTravelers.Size = new System.Drawing.Size(200, 23);
            this.numericUpDownNumberOfTravelers.TabIndex = 11;
            this.numericUpDownNumberOfTravelers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // panelSeaside
            // 
            this.panelSeaside.Controls.Add(this.textBoxSeasideTransportationType);
            this.panelSeaside.Controls.Add(this.labelSeasideTransportationType);
            this.panelSeaside.Controls.Add(this.textBoxSeasideAccommodationType);
            this.panelSeaside.Controls.Add(this.labelSeasideAccommodationType);
            this.panelSeaside.Location = new System.Drawing.Point(20, 260);
            this.panelSeaside.Name = "panelSeaside";
            this.panelSeaside.Size = new System.Drawing.Size(400, 100);
            this.panelSeaside.TabIndex = 12;
            this.panelSeaside.Visible = false;
            // 
            // labelSeasideAccommodationType
            // 
            this.labelSeasideAccommodationType.AutoSize = true;
            this.labelSeasideAccommodationType.Location = new System.Drawing.Point(0, 10);
            this.labelSeasideAccommodationType.Name = "labelSeasideAccommodationType";
            this.labelSeasideAccommodationType.Size = new System.Drawing.Size(110, 15);
            this.labelSeasideAccommodationType.TabIndex = 0;
            this.labelSeasideAccommodationType.Text = "Accommodation:";
            // 
            // textBoxSeasideAccommodationType
            // 
            this.textBoxSeasideAccommodationType.Location = new System.Drawing.Point(120, 7);
            this.textBoxSeasideAccommodationType.Name = "textBoxSeasideAccommodationType";
            this.textBoxSeasideAccommodationType.Size = new System.Drawing.Size(200, 23);
            this.textBoxSeasideAccommodationType.TabIndex = 1;
            // 
            // labelSeasideTransportationType
            // 
            this.labelSeasideTransportationType.AutoSize = true;
            this.labelSeasideTransportationType.Location = new System.Drawing.Point(0, 40);
            this.labelSeasideTransportationType.Name = "labelSeasideTransportationType";
            this.labelSeasideTransportationType.Size = new System.Drawing.Size(90, 15);
            this.labelSeasideTransportationType.TabIndex = 2;
            this.labelSeasideTransportationType.Text = "Transportation:";
            // 
            // textBoxSeasideTransportationType
            // 
            this.textBoxSeasideTransportationType.Location = new System.Drawing.Point(120, 37);
            this.textBoxSeasideTransportationType.Name = "textBoxSeasideTransportationType";
            this.textBoxSeasideTransportationType.Size = new System.Drawing.Size(200, 23);
            this.textBoxSeasideTransportationType.TabIndex = 3;
            // 
            // panelMountain
            // 
            this.panelMountain.Controls.Add(this.textBoxMountainActivities);
            this.panelMountain.Controls.Add(this.labelMountainActivities);
            this.panelMountain.Controls.Add(this.textBoxMountainTransportation);
            this.panelMountain.Controls.Add(this.labelMountainTransportation);
            this.panelMountain.Controls.Add(this.textBoxMountainAccommodationType);
            this.panelMountain.Controls.Add(this.labelMountainAccommodationType);
            this.panelMountain.Location = new System.Drawing.Point(20, 260);
            this.panelMountain.Name = "panelMountain";
            this.panelMountain.Size = new System.Drawing.Size(400, 130);
            this.panelMountain.TabIndex = 13;
            this.panelMountain.Visible = false;
            // 
            // labelMountainActivities
            // 
            this.labelMountainActivities.AutoSize = true;
            this.labelMountainActivities.Location = new System.Drawing.Point(0, 10);
            this.labelMountainActivities.Name = "labelMountainActivities";
            this.labelMountainActivities.Size = new System.Drawing.Size(60, 15);
            this.labelMountainActivities.TabIndex = 0;
            this.labelMountainActivities.Text = "Activities:";
            // 
            // textBoxMountainActivities
            // 
            this.textBoxMountainActivities.Location = new System.Drawing.Point(120, 7);
            this.textBoxMountainActivities.Name = "textBoxMountainActivities";
            this.textBoxMountainActivities.Size = new System.Drawing.Size(200, 23);
            this.textBoxMountainActivities.TabIndex = 1;
            // 
            // labelMountainTransportation
            // 
            this.labelMountainTransportation.AutoSize = true;
            this.labelMountainTransportation.Location = new System.Drawing.Point(0, 70);
            this.labelMountainTransportation.Name = "labelMountainTransportation";
            this.labelMountainTransportation.Size = new System.Drawing.Size(90, 15);
            this.labelMountainTransportation.TabIndex = 4;
            this.labelMountainTransportation.Text = "Transportation:";
            // 
            // textBoxMountainTransportation
            // 
            this.textBoxMountainTransportation.Location = new System.Drawing.Point(120, 67);
            this.textBoxMountainTransportation.Name = "textBoxMountainTransportation";
            this.textBoxMountainTransportation.Size = new System.Drawing.Size(200, 23);
            this.textBoxMountainTransportation.TabIndex = 5;
            // 
            // labelMountainAccommodationType
            // 
            this.labelMountainAccommodationType.AutoSize = true;
            this.labelMountainAccommodationType.Location = new System.Drawing.Point(0, 40);
            this.labelMountainAccommodationType.Name = "labelMountainAccommodationType";
            this.labelMountainAccommodationType.Size = new System.Drawing.Size(110, 15);
            this.labelMountainAccommodationType.TabIndex = 2;
            this.labelMountainAccommodationType.Text = "Accommodation:";
            // 
            // textBoxMountainAccommodationType
            // 
            this.textBoxMountainAccommodationType.Location = new System.Drawing.Point(120, 37);
            this.textBoxMountainAccommodationType.Name = "textBoxMountainAccommodationType";
            this.textBoxMountainAccommodationType.Size = new System.Drawing.Size(200, 23);
            this.textBoxMountainAccommodationType.TabIndex = 3;
            // 
            // panelExcursion
            // 
            this.panelExcursion.Controls.Add(this.textBoxExcursionGuide);
            this.panelExcursion.Controls.Add(this.labelExcursionGuide);
            this.panelExcursion.Controls.Add(this.textBoxExcursionTransportation);
            this.panelExcursion.Controls.Add(this.labelExcursionTransportation);
            this.panelExcursion.Location = new System.Drawing.Point(20, 260);
            this.panelExcursion.Name = "panelExcursion";
            this.panelExcursion.Size = new System.Drawing.Size(400, 100);
            this.panelExcursion.TabIndex = 14;
            this.panelExcursion.Visible = false;
            // 
            // labelExcursionGuide
            // 
            this.labelExcursionGuide.AutoSize = true;
            this.labelExcursionGuide.Location = new System.Drawing.Point(0, 10);
            this.labelExcursionGuide.Name = "labelExcursionGuide";
            this.labelExcursionGuide.Size = new System.Drawing.Size(40, 15);
            this.labelExcursionGuide.TabIndex = 0;
            this.labelExcursionGuide.Text = "Guide:";
            // 
            // textBoxExcursionGuide
            // 
            this.textBoxExcursionGuide.Location = new System.Drawing.Point(120, 7);
            this.textBoxExcursionGuide.Name = "textBoxExcursionGuide";
            this.textBoxExcursionGuide.Size = new System.Drawing.Size(200, 23);
            this.textBoxExcursionGuide.TabIndex = 1;
            // 
            // labelExcursionTransportation
            // 
            this.labelExcursionTransportation.AutoSize = true;
            this.labelExcursionTransportation.Location = new System.Drawing.Point(0, 40);
            this.labelExcursionTransportation.Name = "labelExcursionTransportation";
            this.labelExcursionTransportation.Size = new System.Drawing.Size(90, 15);
            this.labelExcursionTransportation.TabIndex = 2;
            this.labelExcursionTransportation.Text = "Transportation:";
            // 
            // textBoxExcursionTransportation
            // 
            this.textBoxExcursionTransportation.Location = new System.Drawing.Point(120, 37);
            this.textBoxExcursionTransportation.Name = "textBoxExcursionTransportation";
            this.textBoxExcursionTransportation.Size = new System.Drawing.Size(200, 23);
            this.textBoxExcursionTransportation.TabIndex = 3;
            // 
            // panelCruise
            // 
            this.panelCruise.Controls.Add(this.textBoxCruiseTransportation);
            this.panelCruise.Controls.Add(this.labelCruiseTransportation);
            this.panelCruise.Controls.Add(this.textBoxCruiseCabinType);
            this.panelCruise.Controls.Add(this.labelCruiseCabinType);
            this.panelCruise.Controls.Add(this.dateTimePickerCruiseDepartureDate);
            this.panelCruise.Controls.Add(this.labelCruiseDepartureDate);
            this.panelCruise.Controls.Add(this.textBoxCruiseRoute);
            this.panelCruise.Controls.Add(this.labelCruiseRoute);
            this.panelCruise.Controls.Add(this.textBoxCruiseShip);
            this.panelCruise.Controls.Add(this.labelCruiseShip);
            this.panelCruise.Location = new System.Drawing.Point(20, 260);
            this.panelCruise.Name = "panelCruise";
            this.panelCruise.Size = new System.Drawing.Size(400, 160);
            this.panelCruise.TabIndex = 15;
            this.panelCruise.Visible = false;
            // 
            // labelCruiseShip
            // 
            this.labelCruiseShip.AutoSize = true;
            this.labelCruiseShip.Location = new System.Drawing.Point(0, 10);
            this.labelCruiseShip.Name = "labelCruiseShip";
            this.labelCruiseShip.Size = new System.Drawing.Size(35, 15);
            this.labelCruiseShip.TabIndex = 0;
            this.labelCruiseShip.Text = "Ship:";
            // 
            // textBoxCruiseShip
            // 
            this.textBoxCruiseShip.Location = new System.Drawing.Point(120, 7);
            this.textBoxCruiseShip.Name = "textBoxCruiseShip";
            this.textBoxCruiseShip.Size = new System.Drawing.Size(200, 23);
            this.textBoxCruiseShip.TabIndex = 1;
            // 
            // labelCruiseRoute
            // 
            this.labelCruiseRoute.AutoSize = true;
            this.labelCruiseRoute.Location = new System.Drawing.Point(0, 40);
            this.labelCruiseRoute.Name = "labelCruiseRoute";
            this.labelCruiseRoute.Size = new System.Drawing.Size(45, 15);
            this.labelCruiseRoute.TabIndex = 2;
            this.labelCruiseRoute.Text = "Route:";
            // 
            // textBoxCruiseRoute
            // 
            this.textBoxCruiseRoute.Location = new System.Drawing.Point(120, 37);
            this.textBoxCruiseRoute.Name = "textBoxCruiseRoute";
            this.textBoxCruiseRoute.Size = new System.Drawing.Size(200, 23);
            this.textBoxCruiseRoute.TabIndex = 3;
            // 
            // labelCruiseDepartureDate
            // 
            this.labelCruiseDepartureDate.AutoSize = true;
            this.labelCruiseDepartureDate.Location = new System.Drawing.Point(0, 70);
            this.labelCruiseDepartureDate.Name = "labelCruiseDepartureDate";
            this.labelCruiseDepartureDate.Size = new System.Drawing.Size(90, 15);
            this.labelCruiseDepartureDate.TabIndex = 4;
            this.labelCruiseDepartureDate.Text = "Departure Date:";
            // 
            // dateTimePickerCruiseDepartureDate
            // 
            this.dateTimePickerCruiseDepartureDate.Location = new System.Drawing.Point(120, 67);
            this.dateTimePickerCruiseDepartureDate.MinDate = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerCruiseDepartureDate.Name = "dateTimePickerCruiseDepartureDate";
            this.dateTimePickerCruiseDepartureDate.Size = new System.Drawing.Size(200, 23);
            this.dateTimePickerCruiseDepartureDate.TabIndex = 5;
            // 
            // labelCruiseCabinType
            // 
            this.labelCruiseCabinType.AutoSize = true;
            this.labelCruiseCabinType.Location = new System.Drawing.Point(0, 100);
            this.labelCruiseCabinType.Name = "labelCruiseCabinType";
            this.labelCruiseCabinType.Size = new System.Drawing.Size(70, 15);
            this.labelCruiseCabinType.TabIndex = 6;
            this.labelCruiseCabinType.Text = "Cabin Type:";
            // 
            // textBoxCruiseCabinType
            // 
            this.textBoxCruiseCabinType.Location = new System.Drawing.Point(120, 97);
            this.textBoxCruiseCabinType.Name = "textBoxCruiseCabinType";
            this.textBoxCruiseCabinType.Size = new System.Drawing.Size(200, 23);
            this.textBoxCruiseCabinType.TabIndex = 7;
            // 
            // labelCruiseTransportation
            // 
            this.labelCruiseTransportation.AutoSize = true;
            this.labelCruiseTransportation.Location = new System.Drawing.Point(0, 130);
            this.labelCruiseTransportation.Name = "labelCruiseTransportation";
            this.labelCruiseTransportation.Size = new System.Drawing.Size(90, 15);
            this.labelCruiseTransportation.TabIndex = 8;
            this.labelCruiseTransportation.Text = "Transportation:";
            // 
            // textBoxCruiseTransportation
            // 
            this.textBoxCruiseTransportation.Location = new System.Drawing.Point(120, 127);
            this.textBoxCruiseTransportation.Name = "textBoxCruiseTransportation";
            this.textBoxCruiseTransportation.Size = new System.Drawing.Size(200, 23);
            this.textBoxCruiseTransportation.TabIndex = 9;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(120, 440);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 16;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(220, 440);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 17;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // AddPackageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 490);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.panelCruise);
            this.Controls.Add(this.panelExcursion);
            this.Controls.Add(this.panelMountain);
            this.Controls.Add(this.panelSeaside);
            this.Controls.Add(this.numericUpDownNumberOfTravelers);
            this.Controls.Add(this.labelNumberOfTravelers);
            this.Controls.Add(this.numericUpDownNumberOfDays);
            this.Controls.Add(this.labelNumberOfDays);
            this.Controls.Add(this.textBoxDestination);
            this.Controls.Add(this.labelDestination);
            this.Controls.Add(this.numericUpDownPrice);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.textBoxPackageName);
            this.Controls.Add(this.labelPackageName);
            this.Controls.Add(this.labelPackageType);
            this.Controls.Add(this.comboBoxPackageType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddPackageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Travel Package";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfTravelers)).EndInit();
            this.panelSeaside.ResumeLayout(false);
            this.panelSeaside.PerformLayout();
            this.panelMountain.ResumeLayout(false);
            this.panelMountain.PerformLayout();
            this.panelExcursion.ResumeLayout(false);
            this.panelExcursion.PerformLayout();
            this.panelCruise.ResumeLayout(false);
            this.panelCruise.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxPackageType;
        private System.Windows.Forms.Label labelPackageType;
        private System.Windows.Forms.Label labelPackageName;
        private System.Windows.Forms.TextBox textBoxPackageName;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.NumericUpDown numericUpDownPrice;
        private System.Windows.Forms.Label labelDestination;
        private System.Windows.Forms.TextBox textBoxDestination;
        private System.Windows.Forms.Label labelNumberOfDays;
        private System.Windows.Forms.NumericUpDown numericUpDownNumberOfDays;
        private System.Windows.Forms.Label labelNumberOfTravelers;
        private System.Windows.Forms.NumericUpDown numericUpDownNumberOfTravelers;
        private System.Windows.Forms.Panel panelSeaside;
        private System.Windows.Forms.Label labelSeasideAccommodationType;
        private System.Windows.Forms.TextBox textBoxSeasideAccommodationType;
        private System.Windows.Forms.Label labelSeasideTransportationType;
        private System.Windows.Forms.TextBox textBoxSeasideTransportationType;
        private System.Windows.Forms.Panel panelMountain;
        private System.Windows.Forms.Label labelMountainActivities;
        private System.Windows.Forms.TextBox textBoxMountainActivities;
        private System.Windows.Forms.Label labelMountainTransportation;
        private System.Windows.Forms.TextBox textBoxMountainTransportation;
        private System.Windows.Forms.Label labelMountainAccommodationType;
        private System.Windows.Forms.TextBox textBoxMountainAccommodationType;
        private System.Windows.Forms.Panel panelExcursion;
        private System.Windows.Forms.Label labelExcursionGuide;
        private System.Windows.Forms.TextBox textBoxExcursionGuide;
        private System.Windows.Forms.Label labelExcursionTransportation;
        private System.Windows.Forms.TextBox textBoxExcursionTransportation;
        private System.Windows.Forms.Panel panelCruise;
        private System.Windows.Forms.Label labelCruiseShip;
        private System.Windows.Forms.TextBox textBoxCruiseShip;
        private System.Windows.Forms.Label labelCruiseRoute;
        private System.Windows.Forms.TextBox textBoxCruiseRoute;
        private System.Windows.Forms.Label labelCruiseDepartureDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerCruiseDepartureDate;
        private System.Windows.Forms.Label labelCruiseCabinType;
        private System.Windows.Forms.TextBox textBoxCruiseTransportation;
        private System.Windows.Forms.TextBox textBoxCruiseCabinType;
        private System.Windows.Forms.Label labelCruiseTransportation;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}
