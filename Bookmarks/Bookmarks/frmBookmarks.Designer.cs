namespace ms.Bookmarks
{
	partial class frmBookmarks
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
			this.dgvBMS = new System.Windows.Forms.DataGridView();
			this.btnAdd = new System.Windows.Forms.Button();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.txtURL = new System.Windows.Forms.TextBox();
			this.lblDescription = new System.Windows.Forms.Label();
			this.lblURL = new System.Windows.Forms.Label();
			this.pnlDetails = new System.Windows.Forms.Panel();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.cboBookmarkType = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.dgvBMS)).BeginInit();
			this.pnlDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgvBMS
			// 
			this.dgvBMS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvBMS.Location = new System.Drawing.Point(80, 72);
			this.dgvBMS.Name = "dgvBMS";
			this.dgvBMS.Size = new System.Drawing.Size(333, 217);
			this.dgvBMS.TabIndex = 0;
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(80, 295);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 23);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// txtDescription
			// 
			this.txtDescription.Location = new System.Drawing.Point(97, 18);
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(100, 20);
			this.txtDescription.TabIndex = 2;
			this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
			// 
			// txtURL
			// 
			this.txtURL.Location = new System.Drawing.Point(97, 44);
			this.txtURL.Name = "txtURL";
			this.txtURL.Size = new System.Drawing.Size(100, 20);
			this.txtURL.TabIndex = 3;
			this.txtURL.TextChanged += new System.EventHandler(this.txtURL_TextChanged);
			// 
			// lblDescription
			// 
			this.lblDescription.AutoSize = true;
			this.lblDescription.Location = new System.Drawing.Point(21, 21);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(60, 13);
			this.lblDescription.TabIndex = 4;
			this.lblDescription.Text = "Description";
			// 
			// lblURL
			// 
			this.lblURL.AutoSize = true;
			this.lblURL.Location = new System.Drawing.Point(21, 47);
			this.lblURL.Name = "lblURL";
			this.lblURL.Size = new System.Drawing.Size(29, 13);
			this.lblURL.TabIndex = 5;
			this.lblURL.Text = "URL";
			// 
			// pnlDetails
			// 
			this.pnlDetails.Controls.Add(this.txtDescription);
			this.pnlDetails.Controls.Add(this.lblURL);
			this.pnlDetails.Controls.Add(this.txtURL);
			this.pnlDetails.Controls.Add(this.lblDescription);
			this.pnlDetails.Location = new System.Drawing.Point(476, 72);
			this.pnlDetails.Name = "pnlDetails";
			this.pnlDetails.Size = new System.Drawing.Size(231, 83);
			this.pnlDetails.TabIndex = 6;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(713, 415);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 7;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(161, 295);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 8;
			this.btnDelete.Text = "Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// cboBookmarkType
			// 
			this.cboBookmarkType.FormattingEnabled = true;
			this.cboBookmarkType.Location = new System.Drawing.Point(80, 23);
			this.cboBookmarkType.Name = "cboBookmarkType";
			this.cboBookmarkType.Size = new System.Drawing.Size(121, 21);
			this.cboBookmarkType.TabIndex = 9;
			// 
			// frmBookmarks
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.cboBookmarkType);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.pnlDetails);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.dgvBMS);
			this.Name = "frmBookmarks";
			this.Text = "frmBookmarks";
			((System.ComponentModel.ISupportInitialize)(this.dgvBMS)).EndInit();
			this.pnlDetails.ResumeLayout(false);
			this.pnlDetails.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvBMS;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.TextBox txtURL;
		private System.Windows.Forms.Label lblDescription;
		private System.Windows.Forms.Label lblURL;
		private System.Windows.Forms.Panel pnlDetails;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.ComboBox cboBookmarkType;
	}
}

