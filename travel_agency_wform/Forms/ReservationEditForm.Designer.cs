namespace travel_agency_wform.Forms
{
    partial class ReservationEditForm
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
            labelPackage = new Label();
            _comboPackages = new ComboBox();
            labelStatus = new Label();
            _comboStatus = new ComboBox();
            labelTravelers = new Label();
            _numericTravelers = new NumericUpDown();
            labelPrice = new Label();
            _numericPrice = new NumericUpDown();
            _labelTotal = new Label();
            buttonSave = new Button();
            buttonDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)_numericTravelers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_numericPrice).BeginInit();
            SuspendLayout();
            // 
            // labelPackage
            // 
            labelPackage.AutoSize = true;
            labelPackage.Location = new Point(20, 20);
            labelPackage.Name = "labelPackage";
            labelPackage.Size = new Size(54, 15);
            labelPackage.TabIndex = 0;
            labelPackage.Text = "Package:";
            // 
            // _comboPackages
            // 
            _comboPackages.DropDownStyle = ComboBoxStyle.DropDownList;
            _comboPackages.FormattingEnabled = true;
            _comboPackages.Location = new Point(180, 18);
            _comboPackages.Name = "_comboPackages";
            _comboPackages.Size = new Size(320, 23);
            _comboPackages.TabIndex = 1;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(20, 55);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(42, 15);
            labelStatus.TabIndex = 2;
            labelStatus.Text = "Status:";
            // 
            // _comboStatus
            // 
            _comboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            _comboStatus.FormattingEnabled = true;
            _comboStatus.Location = new Point(180, 53);
            _comboStatus.Name = "_comboStatus";
            _comboStatus.Size = new Size(200, 23);
            _comboStatus.TabIndex = 3;
            // 
            // labelTravelers
            // 
            labelTravelers.AutoSize = true;
            labelTravelers.Location = new Point(20, 90);
            labelTravelers.Name = "labelTravelers";
            labelTravelers.Size = new Size(115, 15);
            labelTravelers.TabIndex = 4;
            labelTravelers.Text = "Number of travelers:";
            // 
            // _numericTravelers
            // 
            _numericTravelers.Location = new Point(180, 88);
            _numericTravelers.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            _numericTravelers.Name = "_numericTravelers";
            _numericTravelers.Size = new Size(120, 23);
            _numericTravelers.TabIndex = 5;
            _numericTravelers.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(20, 125);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(95, 15);
            labelPrice.TabIndex = 6;
            labelPrice.Text = "Price per person:";
            // 
            // _numericPrice
            // 
            _numericPrice.DecimalPlaces = 2;
            _numericPrice.Location = new Point(180, 123);
            _numericPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            _numericPrice.Name = "_numericPrice";
            _numericPrice.Size = new Size(120, 23);
            _numericPrice.TabIndex = 7;
            // 
            // _labelTotal
            // 
            _labelTotal.AutoSize = true;
            _labelTotal.Location = new Point(320, 125);
            _labelTotal.Name = "_labelTotal";
            _labelTotal.Size = new Size(44, 15);
            _labelTotal.TabIndex = 8;
            _labelTotal.Text = "Total: -";
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(380, 210);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(120, 23);
            buttonSave.TabIndex = 9;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(244, 210);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(120, 23);
            buttonDelete.TabIndex = 10;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            // 
            // ReservationEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(514, 244);
            Controls.Add(buttonDelete);
            Controls.Add(buttonSave);
            Controls.Add(_labelTotal);
            Controls.Add(_numericPrice);
            Controls.Add(labelPrice);
            Controls.Add(_numericTravelers);
            Controls.Add(labelTravelers);
            Controls.Add(_comboStatus);
            Controls.Add(labelStatus);
            Controls.Add(_comboPackages);
            Controls.Add(labelPackage);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReservationEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit Reservation";
            ((System.ComponentModel.ISupportInitialize)_numericTravelers).EndInit();
            ((System.ComponentModel.ISupportInitialize)_numericPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelPackage;
        private System.Windows.Forms.ComboBox _comboPackages;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ComboBox _comboStatus;
        private System.Windows.Forms.Label labelTravelers;
        private System.Windows.Forms.NumericUpDown _numericTravelers;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.NumericUpDown _numericPrice;
        private System.Windows.Forms.Label _labelTotal;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDelete;
    }
}


