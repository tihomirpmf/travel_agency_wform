namespace travel_agency_wform.Forms
{
    partial class DestinationsForm
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
            listBoxDestinations = new ListBox();
            buttonClose = new Button();
            SuspendLayout();
            // 
            // listBoxDestinations
            // 
            listBoxDestinations.FormattingEnabled = true;
            listBoxDestinations.ItemHeight = 15;
            listBoxDestinations.Location = new Point(10, 10);
            listBoxDestinations.Name = "listBoxDestinations";
            listBoxDestinations.Size = new Size(380, 379);
            listBoxDestinations.TabIndex = 0;
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(264, 405);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(120, 23);
            buttonClose.TabIndex = 1;
            buttonClose.Text = "Close";
            buttonClose.UseVisualStyleBackColor = true;
            // 
            // DestinationsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(396, 440);
            Controls.Add(buttonClose);
            Controls.Add(listBoxDestinations);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DestinationsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Available Destinations";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ListBox listBoxDestinations;
        private System.Windows.Forms.Button buttonClose;
    }
}


