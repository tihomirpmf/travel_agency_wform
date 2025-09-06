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
            this.labelPackage = new System.Windows.Forms.Label();
            this._comboPackages = new System.Windows.Forms.ComboBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this._comboStatus = new System.Windows.Forms.ComboBox();
            this.labelTravelers = new System.Windows.Forms.Label();
            this._numericTravelers = new System.Windows.Forms.NumericUpDown();
            this.labelPrice = new System.Windows.Forms.Label();
            this._numericPrice = new System.Windows.Forms.NumericUpDown();
            this._labelTotal = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._numericTravelers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numericPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPackage
            // 
            this.labelPackage.AutoSize = true;
            this.labelPackage.Location = new System.Drawing.Point(20, 20);
            this.labelPackage.Name = "labelPackage";
            this.labelPackage.Size = new System.Drawing.Size(56, 15);
            this.labelPackage.TabIndex = 0;
            this.labelPackage.Text = "Package:";
            // 
            // _comboPackages
            // 
            this._comboPackages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboPackages.FormattingEnabled = true;
            this._comboPackages.Location = new System.Drawing.Point(180, 18);
            this._comboPackages.Name = "_comboPackages";
            this._comboPackages.Size = new System.Drawing.Size(320, 23);
            this._comboPackages.TabIndex = 1;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(20, 55);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(42, 15);
            this.labelStatus.TabIndex = 2;
            this.labelStatus.Text = "Status:";
            // 
            // _comboStatus
            // 
            this._comboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboStatus.FormattingEnabled = true;
            this._comboStatus.Location = new System.Drawing.Point(180, 53);
            this._comboStatus.Name = "_comboStatus";
            this._comboStatus.Size = new System.Drawing.Size(200, 23);
            this._comboStatus.TabIndex = 3;
            // 
            // labelTravelers
            // 
            this.labelTravelers.AutoSize = true;
            this.labelTravelers.Location = new System.Drawing.Point(20, 90);
            this.labelTravelers.Name = "labelTravelers";
            this.labelTravelers.Size = new System.Drawing.Size(123, 15);
            this.labelTravelers.TabIndex = 4;
            this.labelTravelers.Text = "Number of travelers:";
            // 
            // _numericTravelers
            // 
            this._numericTravelers.Location = new System.Drawing.Point(180, 88);
            this._numericTravelers.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this._numericTravelers.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._numericTravelers.Name = "_numericTravelers";
            this._numericTravelers.Size = new System.Drawing.Size(120, 23);
            this._numericTravelers.TabIndex = 5;
            this._numericTravelers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(20, 125);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(93, 15);
            this.labelPrice.TabIndex = 6;
            this.labelPrice.Text = "Price per person:";
            // 
            // _numericPrice
            // 
            this._numericPrice.DecimalPlaces = 2;
            this._numericPrice.Location = new System.Drawing.Point(180, 123);
            this._numericPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this._numericPrice.Name = "_numericPrice";
            this._numericPrice.Size = new System.Drawing.Size(120, 23);
            this._numericPrice.TabIndex = 7;
            // 
            // _labelTotal
            // 
            this._labelTotal.AutoSize = true;
            this._labelTotal.Location = new System.Drawing.Point(320, 125);
            this._labelTotal.Name = "_labelTotal";
            this._labelTotal.Size = new System.Drawing.Size(49, 15);
            this._labelTotal.TabIndex = 8;
            this._labelTotal.Text = "Total: -";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(380, 210);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(120, 23);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(20, 210);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(120, 23);
            this.buttonDelete.TabIndex = 10;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // ReservationEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 260);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this._labelTotal);
            this.Controls.Add(this._numericPrice);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this._numericTravelers);
            this.Controls.Add(this.labelTravelers);
            this.Controls.Add(this._comboStatus);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this._comboPackages);
            this.Controls.Add(this.labelPackage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReservationEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Reservation";
            ((System.ComponentModel.ISupportInitialize)(this._numericTravelers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numericPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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


