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
			this.txtBand = new System.Windows.Forms.TextBox();
			this.lblAlbum = new System.Windows.Forms.Label();
			this.txtAlbum = new System.Windows.Forms.TextBox();
			this.lblBand = new System.Windows.Forms.Label();
			this.lblSong = new System.Windows.Forms.Label();
			this.txtSong = new System.Windows.Forms.TextBox();
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
			this.dgvBMS.Location = new System.Drawing.Point(80, 72);
			this.dgvBMS.Name = "dgvBMS";
			this.dgvBMS.Size = new System.Drawing.Size(390, 217);
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
			// txtURL
			// 
			this.txtURL.Location = new System.Drawing.Point(97, 13);
			this.txtURL.Name = "txtURL";
			this.txtURL.Size = new System.Drawing.Size(100, 20);
			this.txtURL.TabIndex = 3;
			this.txtURL.TextChanged += new System.EventHandler(this.txtURL_TextChanged);
			// 
			// lblURL
			// 
			this.lblURL.AutoSize = true;
			this.lblURL.Location = new System.Drawing.Point(21, 16);
			this.lblURL.Name = "lblURL";
			this.lblURL.Size = new System.Drawing.Size(29, 13);
			this.lblURL.TabIndex = 5;
			this.lblURL.Text = "URL";
			// 
			// pnlDetails
			// 
			this.pnlDetails.Controls.Add(this.lblURL);
			this.pnlDetails.Controls.Add(this.txtURL);
			this.pnlDetails.Location = new System.Drawing.Point(476, 72);
			this.pnlDetails.Name = "pnlDetails";
			this.pnlDetails.Size = new System.Drawing.Size(231, 46);
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
			this.cboBookmarkType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboBookmarkType.Location = new System.Drawing.Point(80, 23);
			this.cboBookmarkType.Name = "cboBookmarkType";
			this.cboBookmarkType.Size = new System.Drawing.Size(121, 21);
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
			this.pnlDetailsMusic.Location = new System.Drawing.Point(476, 124);
			this.pnlDetailsMusic.Name = "pnlDetailsMusic";
			this.pnlDetailsMusic.Size = new System.Drawing.Size(231, 110);
			this.pnlDetailsMusic.TabIndex = 10;
			// 
			// txtBand
			// 
			this.txtBand.Location = new System.Drawing.Point(97, 18);
			this.txtBand.Name = "txtBand";
			this.txtBand.Size = new System.Drawing.Size(100, 20);
			this.txtBand.TabIndex = 2;
			// 
			// lblAlbum
			// 
			this.lblAlbum.AutoSize = true;
			this.lblAlbum.Location = new System.Drawing.Point(21, 47);
			this.lblAlbum.Name = "lblAlbum";
			this.lblAlbum.Size = new System.Drawing.Size(36, 13);
			this.lblAlbum.TabIndex = 5;
			this.lblAlbum.Text = "Album";
			// 
			// txtAlbum
			// 
			this.txtAlbum.Location = new System.Drawing.Point(97, 44);
			this.txtAlbum.Name = "txtAlbum";
			this.txtAlbum.Size = new System.Drawing.Size(100, 20);
			this.txtAlbum.TabIndex = 3;
			// 
			// lblBand
			// 
			this.lblBand.AutoSize = true;
			this.lblBand.Location = new System.Drawing.Point(21, 21);
			this.lblBand.Name = "lblBand";
			this.lblBand.Size = new System.Drawing.Size(32, 13);
			this.lblBand.TabIndex = 4;
			this.lblBand.Text = "Band";
			// 
			// lblSong
			// 
			this.lblSong.AutoSize = true;
			this.lblSong.Location = new System.Drawing.Point(21, 73);
			this.lblSong.Name = "lblSong";
			this.lblSong.Size = new System.Drawing.Size(32, 13);
			this.lblSong.TabIndex = 7;
			this.lblSong.Text = "Song";
			// 
			// txtSong
			// 
			this.txtSong.Location = new System.Drawing.Point(97, 70);
			this.txtSong.Name = "txtSong";
			this.txtSong.Size = new System.Drawing.Size(100, 20);
			this.txtSong.TabIndex = 6;
			// 
			// pnlDetailsGeneral
			// 
			this.pnlDetailsGeneral.Controls.Add(this.txtDescription);
			this.pnlDetailsGeneral.Controls.Add(this.lblDescription);
			this.pnlDetailsGeneral.Location = new System.Drawing.Point(476, 124);
			this.pnlDetailsGeneral.Name = "pnlDetailsGeneral";
			this.pnlDetailsGeneral.Size = new System.Drawing.Size(231, 46);
			this.pnlDetailsGeneral.TabIndex = 11;
			// 
			// txtDescription
			// 
			this.txtDescription.Location = new System.Drawing.Point(97, 18);
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(100, 20);
			this.txtDescription.TabIndex = 2;
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
			// frmBookmarks
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.pnlDetailsGeneral);
			this.Controls.Add(this.pnlDetailsMusic);
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

