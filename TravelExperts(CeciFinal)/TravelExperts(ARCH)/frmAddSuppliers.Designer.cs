namespace TravelExperts_fileVersion_
{
    partial class frmAddSuppliers
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
            this.txtNewSupplier = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddOne = new System.Windows.Forms.Button();
            this.lstNewSuppliers = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNewSupplier
            // 
            this.txtNewSupplier.Location = new System.Drawing.Point(68, 44);
            this.txtNewSupplier.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNewSupplier.Name = "txtNewSupplier";
            this.txtNewSupplier.Size = new System.Drawing.Size(159, 22);
            this.txtNewSupplier.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.DimGray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(173, 252);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DimGray;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(36, 252);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddOne
            // 
            this.btnAddOne.BackColor = System.Drawing.Color.DimGray;
            this.btnAddOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddOne.ForeColor = System.Drawing.Color.White;
            this.btnAddOne.Location = new System.Drawing.Point(243, 41);
            this.btnAddOne.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddOne.Name = "btnAddOne";
            this.btnAddOne.Size = new System.Drawing.Size(100, 28);
            this.btnAddOne.TabIndex = 6;
            this.btnAddOne.Text = "&Add to List";
            this.btnAddOne.UseVisualStyleBackColor = false;
            this.btnAddOne.Click += new System.EventHandler(this.btnAddOne_Click);
            // 
            // lstNewSuppliers
            // 
            this.lstNewSuppliers.FormattingEnabled = true;
            this.lstNewSuppliers.ItemHeight = 16;
            this.lstNewSuppliers.Location = new System.Drawing.Point(68, 100);
            this.lstNewSuppliers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstNewSuppliers.Name = "lstNewSuppliers";
            this.lstNewSuppliers.Size = new System.Drawing.Size(159, 116);
            this.lstNewSuppliers.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "New Supplier:";
            // 
            // frmAddSuppliers
            // 
            this.AcceptButton = this.btnAddOne;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 321);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNewSupplier);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddOne);
            this.Controls.Add(this.lstNewSuppliers);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmAddSuppliers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddSuppliers";
            this.Load += new System.EventHandler(this.AddSuppliers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNewSupplier;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAddOne;
        private System.Windows.Forms.ListBox lstNewSuppliers;
        private System.Windows.Forms.Label label1;
    }
}