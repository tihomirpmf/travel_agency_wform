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
            comboBoxPackageType = new ComboBox();
            labelPackageType = new Label();
            labelPackageName = new Label();
            textBoxPackageName = new TextBox();
            labelPrice = new Label();
            numericUpDownPrice = new NumericUpDown();
            labelDestination = new Label();
            textBoxDestination = new TextBox();
            labelNumberOfDays = new Label();
            numericUpDownNumberOfDays = new NumericUpDown();
            labelNumberOfTravelers = new Label();
            numericUpDownNumberOfTravelers = new NumericUpDown();
            panelSeaside = new Panel();
            textBoxSeasideTransportationType = new TextBox();
            labelSeasideTransportationType = new Label();
            textBoxSeasideAccommodationType = new TextBox();
            labelSeasideAccommodationType = new Label();
            panelMountain = new Panel();
            textBoxMountainActivities = new TextBox();
            labelMountainActivities = new Label();
            textBoxMountainTransportation = new TextBox();
            labelMountainTransportation = new Label();
            textBoxMountainAccommodationType = new TextBox();
            labelMountainAccommodationType = new Label();
            panelExcursion = new Panel();
            textBoxExcursionGuide = new TextBox();
            labelExcursionGuide = new Label();
            textBoxExcursionTransportation = new TextBox();
            labelExcursionTransportation = new Label();
            panelCruise = new Panel();
            textBoxCruiseCabinType = new TextBox();
            labelCruiseCabinType = new Label();
            dateTimePickerCruiseDepartureDate = new DateTimePicker();
            labelCruiseDepartureDate = new Label();
            textBoxCruiseRoute = new TextBox();
            labelCruiseRoute = new Label();
            textBoxCruiseShip = new TextBox();
            labelCruiseShip = new Label();
            buttonSave = new Button();
            buttonCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownNumberOfDays).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownNumberOfTravelers).BeginInit();
            panelSeaside.SuspendLayout();
            panelMountain.SuspendLayout();
            panelExcursion.SuspendLayout();
            panelCruise.SuspendLayout();
            SuspendLayout();
            // 
            // comboBoxPackageType
            // 
            comboBoxPackageType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPackageType.FormattingEnabled = true;
            comboBoxPackageType.Location = new Point(140, 20);
            comboBoxPackageType.Name = "comboBoxPackageType";
            comboBoxPackageType.Size = new Size(200, 23);
            comboBoxPackageType.TabIndex = 0;
            // 
            // labelPackageType
            // 
            labelPackageType.AutoSize = true;
            labelPackageType.Location = new Point(20, 23);
            labelPackageType.Name = "labelPackageType";
            labelPackageType.Size = new Size(82, 15);
            labelPackageType.TabIndex = 1;
            labelPackageType.Text = "Package Type:";
            // 
            // labelPackageName
            // 
            labelPackageName.AutoSize = true;
            labelPackageName.Location = new Point(20, 60);
            labelPackageName.Name = "labelPackageName";
            labelPackageName.Size = new Size(89, 15);
            labelPackageName.TabIndex = 2;
            labelPackageName.Text = "Package Name:";
            // 
            // textBoxPackageName
            // 
            textBoxPackageName.Location = new Point(140, 57);
            textBoxPackageName.Name = "textBoxPackageName";
            textBoxPackageName.Size = new Size(200, 23);
            textBoxPackageName.TabIndex = 3;
            textBoxPackageName.TextChanged += textBoxPackageName_TextChanged;
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(20, 100);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(36, 15);
            labelPrice.TabIndex = 4;
            labelPrice.Text = "Price:";
            // 
            // numericUpDownPrice
            // 
            numericUpDownPrice.Location = new Point(140, 98);
            numericUpDownPrice.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownPrice.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownPrice.Name = "numericUpDownPrice";
            numericUpDownPrice.Size = new Size(200, 23);
            numericUpDownPrice.TabIndex = 5;
            numericUpDownPrice.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // labelDestination
            // 
            labelDestination.AutoSize = true;
            labelDestination.Location = new Point(20, 140);
            labelDestination.Name = "labelDestination";
            labelDestination.Size = new Size(70, 15);
            labelDestination.TabIndex = 6;
            labelDestination.Text = "Destination:";
            // 
            // textBoxDestination
            // 
            textBoxDestination.Location = new Point(140, 137);
            textBoxDestination.Name = "textBoxDestination";
            textBoxDestination.Size = new Size(200, 23);
            textBoxDestination.TabIndex = 7;
            // 
            // labelNumberOfDays
            // 
            labelNumberOfDays.AutoSize = true;
            labelNumberOfDays.Location = new Point(20, 180);
            labelNumberOfDays.Name = "labelNumberOfDays";
            labelNumberOfDays.Size = new Size(96, 15);
            labelNumberOfDays.TabIndex = 8;
            labelNumberOfDays.Text = "Number of Days:";
            // 
            // numericUpDownNumberOfDays
            // 
            numericUpDownNumberOfDays.Location = new Point(140, 178);
            numericUpDownNumberOfDays.Maximum = new decimal(new int[] { 365, 0, 0, 0 });
            numericUpDownNumberOfDays.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownNumberOfDays.Name = "numericUpDownNumberOfDays";
            numericUpDownNumberOfDays.Size = new Size(200, 23);
            numericUpDownNumberOfDays.TabIndex = 9;
            numericUpDownNumberOfDays.Value = new decimal(new int[] { 7, 0, 0, 0 });
            // 
            // labelNumberOfTravelers
            // 
            labelNumberOfTravelers.AutoSize = true;
            labelNumberOfTravelers.Location = new Point(20, 220);
            labelNumberOfTravelers.Name = "labelNumberOfTravelers";
            labelNumberOfTravelers.Size = new Size(117, 15);
            labelNumberOfTravelers.TabIndex = 10;
            labelNumberOfTravelers.Text = "Number of Travelers:";
            // 
            // numericUpDownNumberOfTravelers
            // 
            numericUpDownNumberOfTravelers.Location = new Point(140, 218);
            numericUpDownNumberOfTravelers.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownNumberOfTravelers.Name = "numericUpDownNumberOfTravelers";
            numericUpDownNumberOfTravelers.Size = new Size(200, 23);
            numericUpDownNumberOfTravelers.TabIndex = 11;
            numericUpDownNumberOfTravelers.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // panelSeaside
            // 
            panelSeaside.Controls.Add(textBoxSeasideTransportationType);
            panelSeaside.Controls.Add(labelSeasideTransportationType);
            panelSeaside.Controls.Add(textBoxSeasideAccommodationType);
            panelSeaside.Controls.Add(labelSeasideAccommodationType);
            panelSeaside.Location = new Point(20, 260);
            panelSeaside.Name = "panelSeaside";
            panelSeaside.Size = new Size(336, 100);
            panelSeaside.TabIndex = 12;
            panelSeaside.Visible = false;
            // 
            // textBoxSeasideTransportationType
            // 
            textBoxSeasideTransportationType.Location = new Point(120, 37);
            textBoxSeasideTransportationType.Name = "textBoxSeasideTransportationType";
            textBoxSeasideTransportationType.Size = new Size(200, 23);
            textBoxSeasideTransportationType.TabIndex = 3;
            // 
            // labelSeasideTransportationType
            // 
            labelSeasideTransportationType.AutoSize = true;
            labelSeasideTransportationType.Location = new Point(0, 40);
            labelSeasideTransportationType.Name = "labelSeasideTransportationType";
            labelSeasideTransportationType.Size = new Size(87, 15);
            labelSeasideTransportationType.TabIndex = 2;
            labelSeasideTransportationType.Text = "Transportation:";
            // 
            // textBoxSeasideAccommodationType
            // 
            textBoxSeasideAccommodationType.Location = new Point(120, 7);
            textBoxSeasideAccommodationType.Name = "textBoxSeasideAccommodationType";
            textBoxSeasideAccommodationType.Size = new Size(200, 23);
            textBoxSeasideAccommodationType.TabIndex = 1;
            // 
            // labelSeasideAccommodationType
            // 
            labelSeasideAccommodationType.AutoSize = true;
            labelSeasideAccommodationType.Location = new Point(0, 10);
            labelSeasideAccommodationType.Name = "labelSeasideAccommodationType";
            labelSeasideAccommodationType.Size = new Size(100, 15);
            labelSeasideAccommodationType.TabIndex = 0;
            labelSeasideAccommodationType.Text = "Accommodation:";
            // 
            // panelMountain
            // 
            panelMountain.Controls.Add(textBoxMountainActivities);
            panelMountain.Controls.Add(labelMountainActivities);
            panelMountain.Controls.Add(textBoxMountainTransportation);
            panelMountain.Controls.Add(labelMountainTransportation);
            panelMountain.Controls.Add(textBoxMountainAccommodationType);
            panelMountain.Controls.Add(labelMountainAccommodationType);
            panelMountain.Location = new Point(20, 260);
            panelMountain.Name = "panelMountain";
            panelMountain.Size = new Size(336, 130);
            panelMountain.TabIndex = 13;
            panelMountain.Visible = false;
            // 
            // textBoxMountainActivities
            // 
            textBoxMountainActivities.Location = new Point(120, 7);
            textBoxMountainActivities.Name = "textBoxMountainActivities";
            textBoxMountainActivities.Size = new Size(200, 23);
            textBoxMountainActivities.TabIndex = 1;
            // 
            // labelMountainActivities
            // 
            labelMountainActivities.AutoSize = true;
            labelMountainActivities.Location = new Point(0, 10);
            labelMountainActivities.Name = "labelMountainActivities";
            labelMountainActivities.Size = new Size(58, 15);
            labelMountainActivities.TabIndex = 0;
            labelMountainActivities.Text = "Activities:";
            // 
            // textBoxMountainTransportation
            // 
            textBoxMountainTransportation.Location = new Point(120, 67);
            textBoxMountainTransportation.Name = "textBoxMountainTransportation";
            textBoxMountainTransportation.Size = new Size(200, 23);
            textBoxMountainTransportation.TabIndex = 5;
            // 
            // labelMountainTransportation
            // 
            labelMountainTransportation.AutoSize = true;
            labelMountainTransportation.Location = new Point(0, 70);
            labelMountainTransportation.Name = "labelMountainTransportation";
            labelMountainTransportation.Size = new Size(87, 15);
            labelMountainTransportation.TabIndex = 4;
            labelMountainTransportation.Text = "Transportation:";
            // 
            // textBoxMountainAccommodationType
            // 
            textBoxMountainAccommodationType.Location = new Point(120, 37);
            textBoxMountainAccommodationType.Name = "textBoxMountainAccommodationType";
            textBoxMountainAccommodationType.Size = new Size(200, 23);
            textBoxMountainAccommodationType.TabIndex = 3;
            // 
            // labelMountainAccommodationType
            // 
            labelMountainAccommodationType.AutoSize = true;
            labelMountainAccommodationType.Location = new Point(0, 40);
            labelMountainAccommodationType.Name = "labelMountainAccommodationType";
            labelMountainAccommodationType.Size = new Size(100, 15);
            labelMountainAccommodationType.TabIndex = 2;
            labelMountainAccommodationType.Text = "Accommodation:";
            // 
            // panelExcursion
            // 
            panelExcursion.Controls.Add(textBoxExcursionGuide);
            panelExcursion.Controls.Add(labelExcursionGuide);
            panelExcursion.Controls.Add(textBoxExcursionTransportation);
            panelExcursion.Controls.Add(labelExcursionTransportation);
            panelExcursion.Location = new Point(20, 260);
            panelExcursion.Name = "panelExcursion";
            panelExcursion.Size = new Size(336, 100);
            panelExcursion.TabIndex = 14;
            panelExcursion.Visible = false;
            // 
            // textBoxExcursionGuide
            // 
            textBoxExcursionGuide.Location = new Point(120, 7);
            textBoxExcursionGuide.Name = "textBoxExcursionGuide";
            textBoxExcursionGuide.Size = new Size(200, 23);
            textBoxExcursionGuide.TabIndex = 1;
            // 
            // labelExcursionGuide
            // 
            labelExcursionGuide.AutoSize = true;
            labelExcursionGuide.Location = new Point(0, 10);
            labelExcursionGuide.Name = "labelExcursionGuide";
            labelExcursionGuide.Size = new Size(41, 15);
            labelExcursionGuide.TabIndex = 0;
            labelExcursionGuide.Text = "Guide:";
            // 
            // textBoxExcursionTransportation
            // 
            textBoxExcursionTransportation.Location = new Point(120, 37);
            textBoxExcursionTransportation.Name = "textBoxExcursionTransportation";
            textBoxExcursionTransportation.Size = new Size(200, 23);
            textBoxExcursionTransportation.TabIndex = 3;
            // 
            // labelExcursionTransportation
            // 
            labelExcursionTransportation.AutoSize = true;
            labelExcursionTransportation.Location = new Point(0, 40);
            labelExcursionTransportation.Name = "labelExcursionTransportation";
            labelExcursionTransportation.Size = new Size(87, 15);
            labelExcursionTransportation.TabIndex = 2;
            labelExcursionTransportation.Text = "Transportation:";
            // 
            // panelCruise
            // 
            panelCruise.Controls.Add(textBoxCruiseCabinType);
            panelCruise.Controls.Add(labelCruiseCabinType);
            panelCruise.Controls.Add(dateTimePickerCruiseDepartureDate);
            panelCruise.Controls.Add(labelCruiseDepartureDate);
            panelCruise.Controls.Add(textBoxCruiseRoute);
            panelCruise.Controls.Add(labelCruiseRoute);
            panelCruise.Controls.Add(textBoxCruiseShip);
            panelCruise.Controls.Add(labelCruiseShip);
            panelCruise.Location = new Point(20, 260);
            panelCruise.Name = "panelCruise";
            panelCruise.Size = new Size(336, 160);
            panelCruise.TabIndex = 15;
            panelCruise.Visible = false;
            // 
            // textBoxCruiseCabinType
            // 
            textBoxCruiseCabinType.Location = new Point(120, 97);
            textBoxCruiseCabinType.Name = "textBoxCruiseCabinType";
            textBoxCruiseCabinType.Size = new Size(200, 23);
            textBoxCruiseCabinType.TabIndex = 7;
            // 
            // labelCruiseCabinType
            // 
            labelCruiseCabinType.AutoSize = true;
            labelCruiseCabinType.Location = new Point(0, 100);
            labelCruiseCabinType.Name = "labelCruiseCabinType";
            labelCruiseCabinType.Size = new Size(69, 15);
            labelCruiseCabinType.TabIndex = 6;
            labelCruiseCabinType.Text = "Cabin Type:";
            // 
            // dateTimePickerCruiseDepartureDate
            // 
            dateTimePickerCruiseDepartureDate.Location = new Point(120, 67);
            dateTimePickerCruiseDepartureDate.MinDate = new DateTime(2024, 1, 1, 0, 0, 0, 0);
            dateTimePickerCruiseDepartureDate.Name = "dateTimePickerCruiseDepartureDate";
            dateTimePickerCruiseDepartureDate.Size = new Size(200, 23);
            dateTimePickerCruiseDepartureDate.TabIndex = 5;
            // 
            // labelCruiseDepartureDate
            // 
            labelCruiseDepartureDate.AutoSize = true;
            labelCruiseDepartureDate.Location = new Point(0, 70);
            labelCruiseDepartureDate.Name = "labelCruiseDepartureDate";
            labelCruiseDepartureDate.Size = new Size(89, 15);
            labelCruiseDepartureDate.TabIndex = 4;
            labelCruiseDepartureDate.Text = "Departure Date:";
            // 
            // textBoxCruiseRoute
            // 
            textBoxCruiseRoute.Location = new Point(120, 37);
            textBoxCruiseRoute.Name = "textBoxCruiseRoute";
            textBoxCruiseRoute.Size = new Size(200, 23);
            textBoxCruiseRoute.TabIndex = 3;
            // 
            // labelCruiseRoute
            // 
            labelCruiseRoute.AutoSize = true;
            labelCruiseRoute.Location = new Point(0, 40);
            labelCruiseRoute.Name = "labelCruiseRoute";
            labelCruiseRoute.Size = new Size(41, 15);
            labelCruiseRoute.TabIndex = 2;
            labelCruiseRoute.Text = "Route:";
            // 
            // textBoxCruiseShip
            // 
            textBoxCruiseShip.Location = new Point(120, 7);
            textBoxCruiseShip.Name = "textBoxCruiseShip";
            textBoxCruiseShip.Size = new Size(200, 23);
            textBoxCruiseShip.TabIndex = 1;
            // 
            // labelCruiseShip
            // 
            labelCruiseShip.AutoSize = true;
            labelCruiseShip.Location = new Point(0, 10);
            labelCruiseShip.Name = "labelCruiseShip";
            labelCruiseShip.Size = new Size(33, 15);
            labelCruiseShip.TabIndex = 0;
            labelCruiseShip.Text = "Ship:";
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(187, 439);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 16;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(281, 439);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 17;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // AddPackageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(366, 474);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(panelCruise);
            Controls.Add(panelExcursion);
            Controls.Add(panelMountain);
            Controls.Add(panelSeaside);
            Controls.Add(numericUpDownNumberOfTravelers);
            Controls.Add(labelNumberOfTravelers);
            Controls.Add(numericUpDownNumberOfDays);
            Controls.Add(labelNumberOfDays);
            Controls.Add(textBoxDestination);
            Controls.Add(labelDestination);
            Controls.Add(numericUpDownPrice);
            Controls.Add(labelPrice);
            Controls.Add(textBoxPackageName);
            Controls.Add(labelPackageName);
            Controls.Add(labelPackageType);
            Controls.Add(comboBoxPackageType);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddPackageForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Travel Package";
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownNumberOfDays).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownNumberOfTravelers).EndInit();
            panelSeaside.ResumeLayout(false);
            panelSeaside.PerformLayout();
            panelMountain.ResumeLayout(false);
            panelMountain.PerformLayout();
            panelExcursion.ResumeLayout(false);
            panelExcursion.PerformLayout();
            panelCruise.ResumeLayout(false);
            panelCruise.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.TextBox textBoxCruiseCabinType;
        
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}
