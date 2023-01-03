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
			this.dtpDateCreated = new System.Windows.Forms.DateTimePicker();
			this.lblDateCreated = new System.Windows.Forms.Label();
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
			this.pnlDetailsMovie = new System.Windows.Forms.Panel();
			this.cboOrigin = new System.Windows.Forms.ComboBox();
			this.btnOrigin = new System.Windows.Forms.Button();
			this.lblTitle = new System.Windows.Forms.Label();
			this.txtTitle = new System.Windows.Forms.TextBox();
			this.lblOrigin = new System.Windows.Forms.Label();
			this.lblFilter = new System.Windows.Forms.Label();
			this.txtFilter = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dgvBMS)).BeginInit();
			this.pnlDetails.SuspendLayout();
			this.pnlDetailsMusic.SuspendLayout();
			this.pnlDetailsGeneral.SuspendLayout();
			this.pnlDetailsMovie.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgvBMS
			// 
			this.dgvBMS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.dgvBMS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvBMS.Location = new System.Drawing.Point(14, 90);
			this.dgvBMS.Margin = new System.Windows.Forms.Padding(4);
			this.dgvBMS.Name = "dgvBMS";
			this.dgvBMS.RowHeadersWidth = 51;
			this.dgvBMS.Size = new System.Drawing.Size(539, 271);
			this.dgvBMS.TabIndex = 0;
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAdd.Location = new System.Drawing.Point(14, 369);
			this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(94, 29);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// txtURL
			// 
			this.txtURL.Location = new System.Drawing.Point(70, 16);
			this.txtURL.Margin = new System.Windows.Forms.Padding(4);
			this.txtURL.Multiline = true;
			this.txtURL.Name = "txtURL";
			this.txtURL.Size = new System.Drawing.Size(175, 49);
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
			this.pnlDetails.Controls.Add(this.dtpDateCreated);
			this.pnlDetails.Controls.Add(this.lblDateCreated);
			this.pnlDetails.Controls.Add(this.lblURL);
			this.pnlDetails.Controls.Add(this.txtURL);
			this.pnlDetails.Location = new System.Drawing.Point(576, 90);
			this.pnlDetails.Margin = new System.Windows.Forms.Padding(4);
			this.pnlDetails.Name = "pnlDetails";
			this.pnlDetails.Size = new System.Drawing.Size(289, 113);
			this.pnlDetails.TabIndex = 6;
			// 
			// dtpDateCreated
			// 
			this.dtpDateCreated.Checked = false;
			this.dtpDateCreated.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpDateCreated.Location = new System.Drawing.Point(109, 72);
			this.dtpDateCreated.Name = "dtpDateCreated";
			this.dtpDateCreated.Size = new System.Drawing.Size(99, 22);
			this.dtpDateCreated.TabIndex = 15;
			// 
			// lblDateCreated
			// 
			this.lblDateCreated.AutoSize = true;
			this.lblDateCreated.Location = new System.Drawing.Point(26, 77);
			this.lblDateCreated.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblDateCreated.Name = "lblDateCreated";
			this.lblDateCreated.Size = new System.Drawing.Size(58, 17);
			this.lblDateCreated.TabIndex = 16;
			this.lblDateCreated.Text = "Created";
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSave.Location = new System.Drawing.Point(729, 369);
			this.btnSave.Margin = new System.Windows.Forms.Padding(4);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(94, 29);
			this.btnSave.TabIndex = 7;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnDelete.Location = new System.Drawing.Point(115, 369);
			this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
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
			this.cboBookmarkType.Location = new System.Drawing.Point(14, 35);
			this.cboBookmarkType.Margin = new System.Windows.Forms.Padding(4);
			this.cboBookmarkType.Name = "cboBookmarkType";
			this.cboBookmarkType.Size = new System.Drawing.Size(150, 24);
			this.cboBookmarkType.TabIndex = 9;
			// 
			// pnlDetailsMusic
			// 
			this.pnlDetailsMusic.Controls.Add(this.lblSong);
			this.pnlDetailsMusic.Controls.Add(this.txtSong);
			this.pnlDetailsMusic.Controls.Add(this.txtBand);
			this.pnlDetailsMusic.Controls.Add(this.lblAlbum);
			this.pnlDetailsMusic.Controls.Add(this.txtAlbum);
			this.pnlDetailsMusic.Controls.Add(this.lblBand);
			this.pnlDetailsMusic.Location = new System.Drawing.Point(576, 211);
			this.pnlDetailsMusic.Margin = new System.Windows.Forms.Padding(4);
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
			this.txtSong.Location = new System.Drawing.Point(109, 88);
			this.txtSong.Margin = new System.Windows.Forms.Padding(4);
			this.txtSong.Name = "txtSong";
			this.txtSong.Size = new System.Drawing.Size(136, 22);
			this.txtSong.TabIndex = 6;
			this.txtSong.TextChanged += new System.EventHandler(this.txtSong_TextChanged);
			// 
			// txtBand
			// 
			this.txtBand.Location = new System.Drawing.Point(109, 22);
			this.txtBand.Margin = new System.Windows.Forms.Padding(4);
			this.txtBand.Name = "txtBand";
			this.txtBand.Size = new System.Drawing.Size(136, 22);
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
			this.txtAlbum.Location = new System.Drawing.Point(109, 55);
			this.txtAlbum.Margin = new System.Windows.Forms.Padding(4);
			this.txtAlbum.Name = "txtAlbum";
			this.txtAlbum.Size = new System.Drawing.Size(136, 22);
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
			this.pnlDetailsGeneral.Location = new System.Drawing.Point(576, 211);
			this.pnlDetailsGeneral.Margin = new System.Windows.Forms.Padding(4);
			this.pnlDetailsGeneral.Name = "pnlDetailsGeneral";
			this.pnlDetailsGeneral.Size = new System.Drawing.Size(289, 58);
			this.pnlDetailsGeneral.TabIndex = 11;
			// 
			// txtDescription
			// 
			this.txtDescription.Location = new System.Drawing.Point(109, 22);
			this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(136, 22);
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
			// pnlDetailsMovie
			// 
			this.pnlDetailsMovie.Controls.Add(this.cboOrigin);
			this.pnlDetailsMovie.Controls.Add(this.btnOrigin);
			this.pnlDetailsMovie.Controls.Add(this.lblTitle);
			this.pnlDetailsMovie.Controls.Add(this.txtTitle);
			this.pnlDetailsMovie.Controls.Add(this.lblOrigin);
			this.pnlDetailsMovie.Location = new System.Drawing.Point(576, 211);
			this.pnlDetailsMovie.Margin = new System.Windows.Forms.Padding(4);
			this.pnlDetailsMovie.Name = "pnlDetailsMovie";
			this.pnlDetailsMovie.Size = new System.Drawing.Size(289, 138);
			this.pnlDetailsMovie.TabIndex = 12;
			// 
			// cboOrigin
			// 
			this.cboOrigin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboOrigin.FormattingEnabled = true;
			this.cboOrigin.Location = new System.Drawing.Point(109, 54);
			this.cboOrigin.Margin = new System.Windows.Forms.Padding(2);
			this.cboOrigin.Name = "cboOrigin";
			this.cboOrigin.Size = new System.Drawing.Size(99, 24);
			this.cboOrigin.TabIndex = 10;
			// 
			// btnOrigin
			// 
			this.btnOrigin.Location = new System.Drawing.Point(216, 54);
			this.btnOrigin.Margin = new System.Windows.Forms.Padding(4);
			this.btnOrigin.Name = "btnOrigin";
			this.btnOrigin.Size = new System.Drawing.Size(30, 25);
			this.btnOrigin.TabIndex = 8;
			this.btnOrigin.Text = "...";
			this.btnOrigin.UseVisualStyleBackColor = true;
			this.btnOrigin.Click += new System.EventHandler(this.btnOrigin_Click);
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Location = new System.Drawing.Point(26, 21);
			this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(35, 17);
			this.lblTitle.TabIndex = 7;
			this.lblTitle.Text = "Title";
			// 
			// txtTitle
			// 
			this.txtTitle.Location = new System.Drawing.Point(109, 18);
			this.txtTitle.Margin = new System.Windows.Forms.Padding(4);
			this.txtTitle.Name = "txtTitle";
			this.txtTitle.Size = new System.Drawing.Size(136, 22);
			this.txtTitle.TabIndex = 6;
			this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
			// 
			// lblOrigin
			// 
			this.lblOrigin.AutoSize = true;
			this.lblOrigin.Location = new System.Drawing.Point(26, 58);
			this.lblOrigin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblOrigin.Name = "lblOrigin";
			this.lblOrigin.Size = new System.Drawing.Size(46, 17);
			this.lblOrigin.TabIndex = 4;
			this.lblOrigin.Text = "Origin";
			// 
			// lblFilter
			// 
			this.lblFilter.AutoSize = true;
			this.lblFilter.Location = new System.Drawing.Point(298, 38);
			this.lblFilter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblFilter.Name = "lblFilter";
			this.lblFilter.Size = new System.Drawing.Size(39, 17);
			this.lblFilter.TabIndex = 13;
			this.lblFilter.Text = "Filter";
			// 
			// txtFilter
			// 
			this.txtFilter.Location = new System.Drawing.Point(344, 35);
			this.txtFilter.Margin = new System.Windows.Forms.Padding(4);
			this.txtFilter.Name = "txtFilter";
			this.txtFilter.Size = new System.Drawing.Size(209, 22);
			this.txtFilter.TabIndex = 14;
			this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
			// 
			// frmBookmarks
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(889, 429);
			this.Controls.Add(this.txtFilter);
			this.Controls.Add(this.lblFilter);
			this.Controls.Add(this.pnlDetailsMovie);
			this.Controls.Add(this.pnlDetailsGeneral);
			this.Controls.Add(this.pnlDetailsMusic);
			this.Controls.Add(this.cboBookmarkType);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.pnlDetails);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.dgvBMS);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "frmBookmarks";
			this.Text = "Bookmarks";
			((System.ComponentModel.ISupportInitialize)(this.dgvBMS)).EndInit();
			this.pnlDetails.ResumeLayout(false);
			this.pnlDetails.PerformLayout();
			this.pnlDetailsMusic.ResumeLayout(false);
			this.pnlDetailsMusic.PerformLayout();
			this.pnlDetailsGeneral.ResumeLayout(false);
			this.pnlDetailsGeneral.PerformLayout();
			this.pnlDetailsMovie.ResumeLayout(false);
			this.pnlDetailsMovie.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

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
		private System.Windows.Forms.Panel pnlDetailsMovie;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.TextBox txtTitle;
		private System.Windows.Forms.Label lblOrigin;
		private System.Windows.Forms.Button btnOrigin;
		private System.Windows.Forms.ComboBox cboOrigin;
		private System.Windows.Forms.Label lblFilter;
		private System.Windows.Forms.TextBox txtFilter;
		private System.Windows.Forms.DateTimePicker dtpDateCreated;
		private System.Windows.Forms.Label lblDateCreated;
	}
}

