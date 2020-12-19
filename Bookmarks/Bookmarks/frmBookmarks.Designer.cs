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
			this.txtURL = new System.Windows.Forms.TextBox();
			this.lblURL = new System.Windows.Forms.Label();
			this.pnlDetails = new System.Windows.Forms.Panel();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.cboBookmarkType = new System.Windows.Forms.ComboBox();
			this.pnlDetailsMusic = new System.Windows.Forms.Panel();
			this.lblSong = new System.Windows.Forms.Label();
			this.txtSong = new System.Windows.Forms.TextBox();
			this.txtBand = new System.Windows.Forms.TextBox();
			this.lblAlbum = new System.Windows.Forms.Label();
			this.txtAlbum = new System.Windows.Forms.TextBox();
			this.lblBand = new System.Windows.Forms.Label();
			this.pnlDetailsGeneral = new System.Windows.Forms.Panel();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.lblDescription = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgvBMS)).BeginInit();
			this.pnlDetails.SuspendLayout();
			this.pnlDetailsMusic.SuspendLayout();
			this.pnlDetailsGeneral.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgvBMS
			// 
			this.dgvBMS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvBMS.Location = new System.Drawing.Point(100, 90);
			this.dgvBMS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.dgvBMS.Name = "dgvBMS";
			this.dgvBMS.RowHeadersWidth = 51;
			this.dgvBMS.Size = new System.Drawing.Size(488, 271);
			this.dgvBMS.TabIndex = 0;
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(100, 369);
			this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(94, 29);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// txtURL
			// 
			this.txtURL.Location = new System.Drawing.Point(121, 16);
			this.txtURL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtURL.Name = "txtURL";
			this.txtURL.Size = new System.Drawing.Size(124, 22);
			this.txtURL.TabIndex = 3;
			this.txtURL.TextChanged += new System.EventHandler(this.txtURL_TextChanged);
			// 
			// lblURL
			// 
			this.lblURL.AutoSize = true;
			this.lblURL.Location = new System.Drawing.Point(26, 20);
			this.lblURL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblURL.Name = "lblURL";
			this.lblURL.Size = new System.Drawing.Size(36, 17);
			this.lblURL.TabIndex = 5;
			this.lblURL.Text = "URL";
			// 
			// pnlDetails
			// 
			this.pnlDetails.Controls.Add(this.lblURL);
			this.pnlDetails.Controls.Add(this.txtURL);
			this.pnlDetails.Location = new System.Drawing.Point(595, 90);
			this.pnlDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.pnlDetails.Name = "pnlDetails";
			this.pnlDetails.Size = new System.Drawing.Size(289, 58);
			this.pnlDetails.TabIndex = 6;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(891, 519);
			this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(94, 29);
			this.btnSave.TabIndex = 7;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(201, 369);
			this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(94, 29);
			this.btnDelete.TabIndex = 8;
			this.btnDelete.Text = "Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// cboBookmarkType
			// 
			this.cboBookmarkType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboBookmarkType.Location = new System.Drawing.Point(100, 29);
			this.cboBookmarkType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.cboBookmarkType.Name = "cboBookmarkType";
			this.cboBookmarkType.Size = new System.Drawing.Size(150, 24);
			this.cboBookmarkType.TabIndex = 9;
			this.cboBookmarkType.SelectedValueChanged += new System.EventHandler(this.cboBookmarkType_SelectedValueChanged);
			// 
			// pnlDetailsMusic
			// 
			this.pnlDetailsMusic.Controls.Add(this.lblSong);
			this.pnlDetailsMusic.Controls.Add(this.txtSong);
			this.pnlDetailsMusic.Controls.Add(this.txtBand);
			this.pnlDetailsMusic.Controls.Add(this.lblAlbum);
			this.pnlDetailsMusic.Controls.Add(this.txtAlbum);
			this.pnlDetailsMusic.Controls.Add(this.lblBand);
			this.pnlDetailsMusic.Location = new System.Drawing.Point(595, 155);
			this.pnlDetailsMusic.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.pnlDetailsMusic.Name = "pnlDetailsMusic";
			this.pnlDetailsMusic.Size = new System.Drawing.Size(289, 138);
			this.pnlDetailsMusic.TabIndex = 10;
			// 
			// lblSong
			// 
			this.lblSong.AutoSize = true;
			this.lblSong.Location = new System.Drawing.Point(26, 91);
			this.lblSong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblSong.Name = "lblSong";
			this.lblSong.Size = new System.Drawing.Size(41, 17);
			this.lblSong.TabIndex = 7;
			this.lblSong.Text = "Song";
			// 
			// txtSong
			// 
			this.txtSong.Location = new System.Drawing.Point(121, 88);
			this.txtSong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtSong.Name = "txtSong";
			this.txtSong.Size = new System.Drawing.Size(124, 22);
			this.txtSong.TabIndex = 6;
			this.txtSong.TextChanged += new System.EventHandler(this.txtSong_TextChanged);
			// 
			// txtBand
			// 
			this.txtBand.Location = new System.Drawing.Point(121, 22);
			this.txtBand.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtBand.Name = "txtBand";
			this.txtBand.Size = new System.Drawing.Size(124, 22);
			this.txtBand.TabIndex = 2;
			this.txtBand.TextChanged += new System.EventHandler(this.txtBand_TextChanged);
			// 
			// lblAlbum
			// 
			this.lblAlbum.AutoSize = true;
			this.lblAlbum.Location = new System.Drawing.Point(26, 59);
			this.lblAlbum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblAlbum.Name = "lblAlbum";
			this.lblAlbum.Size = new System.Drawing.Size(47, 17);
			this.lblAlbum.TabIndex = 5;
			this.lblAlbum.Text = "Album";
			// 
			// txtAlbum
			// 
			this.txtAlbum.Location = new System.Drawing.Point(121, 55);
			this.txtAlbum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtAlbum.Name = "txtAlbum";
			this.txtAlbum.Size = new System.Drawing.Size(124, 22);
			this.txtAlbum.TabIndex = 3;
			this.txtAlbum.TextChanged += new System.EventHandler(this.txtAlbum_TextChanged);
			// 
			// lblBand
			// 
			this.lblBand.AutoSize = true;
			this.lblBand.Location = new System.Drawing.Point(26, 26);
			this.lblBand.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblBand.Name = "lblBand";
			this.lblBand.Size = new System.Drawing.Size(41, 17);
			this.lblBand.TabIndex = 4;
			this.lblBand.Text = "Band";
			// 
			// pnlDetailsGeneral
			// 
			this.pnlDetailsGeneral.Controls.Add(this.txtDescription);
			this.pnlDetailsGeneral.Controls.Add(this.lblDescription);
			this.pnlDetailsGeneral.Location = new System.Drawing.Point(595, 155);
			this.pnlDetailsGeneral.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.pnlDetailsGeneral.Name = "pnlDetailsGeneral";
			this.pnlDetailsGeneral.Size = new System.Drawing.Size(289, 58);
			this.pnlDetailsGeneral.TabIndex = 11;
			// 
			// txtDescription
			// 
			this.txtDescription.Location = new System.Drawing.Point(121, 22);
			this.txtDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(124, 22);
			this.txtDescription.TabIndex = 2;
			this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
			// 
			// lblDescription
			// 
			this.lblDescription.AutoSize = true;
			this.lblDescription.Location = new System.Drawing.Point(26, 26);
			this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(79, 17);
			this.lblDescription.TabIndex = 4;
			this.lblDescription.Text = "Description";
			// 
			// frmBookmarks
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(1000, 562);
			this.Controls.Add(this.pnlDetailsGeneral);
			this.Controls.Add(this.pnlDetailsMusic);
			this.Controls.Add(this.cboBookmarkType);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.pnlDetails);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.dgvBMS);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "frmBookmarks";
			this.Text = "frmBookmarks";
			((System.ComponentModel.ISupportInitialize)(this.dgvBMS)).EndInit();
			this.pnlDetails.ResumeLayout(false);
			this.pnlDetails.PerformLayout();
			this.pnlDetailsMusic.ResumeLayout(false);
			this.pnlDetailsMusic.PerformLayout();
			this.pnlDetailsGeneral.ResumeLayout(false);
			this.pnlDetailsGeneral.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvBMS;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.TextBox txtURL;
		private System.Windows.Forms.Label lblURL;
		private System.Windows.Forms.Panel pnlDetails;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.ComboBox cboBookmarkType;
		private System.Windows.Forms.Panel pnlDetailsMusic;
		private System.Windows.Forms.Label lblSong;
		private System.Windows.Forms.TextBox txtSong;
		private System.Windows.Forms.TextBox txtBand;
		private System.Windows.Forms.Label lblAlbum;
		private System.Windows.Forms.TextBox txtAlbum;
		private System.Windows.Forms.Label lblBand;
		private System.Windows.Forms.Panel pnlDetailsGeneral;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.Label lblDescription;
	}
}

