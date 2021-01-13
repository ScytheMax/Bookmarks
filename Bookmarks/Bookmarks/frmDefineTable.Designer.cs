namespace ms.Bookmarks
{
	partial class frmDefineTable
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
			this.dgv = new System.Windows.Forms.DataGridView();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.pnlDetails = new System.Windows.Forms.Panel();
			this.txtValue = new System.Windows.Forms.TextBox();
			this.lblDefine = new System.Windows.Forms.Label();
			this.txtDefine = new System.Windows.Forms.TextBox();
			this.lblValue = new System.Windows.Forms.Label();
			this.btnExit = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.pnlDetails.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgv
			// 
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Location = new System.Drawing.Point(21, 26);
			this.dgv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.dgv.Name = "dgv";
			this.dgv.RowHeadersWidth = 51;
			this.dgv.Size = new System.Drawing.Size(380, 209);
			this.dgv.TabIndex = 1;
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(21, 242);
			this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(100, 28);
			this.btnAdd.TabIndex = 9;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(301, 242);
			this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(100, 28);
			this.btnSave.TabIndex = 11;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// pnlDetails
			// 
			this.pnlDetails.Controls.Add(this.txtValue);
			this.pnlDetails.Controls.Add(this.lblDefine);
			this.pnlDetails.Controls.Add(this.txtDefine);
			this.pnlDetails.Controls.Add(this.lblValue);
			this.pnlDetails.Location = new System.Drawing.Point(429, 26);
			this.pnlDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.pnlDetails.Name = "pnlDetails";
			this.pnlDetails.Size = new System.Drawing.Size(308, 102);
			this.pnlDetails.TabIndex = 13;
			// 
			// txtValue
			// 
			this.txtValue.Location = new System.Drawing.Point(116, 22);
			this.txtValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtValue.Name = "txtValue";
			this.txtValue.Size = new System.Drawing.Size(145, 22);
			this.txtValue.TabIndex = 2;
			this.txtValue.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
			// 
			// lblDefine
			// 
			this.lblDefine.AutoSize = true;
			this.lblDefine.Location = new System.Drawing.Point(28, 58);
			this.lblDefine.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblDefine.Name = "lblDefine";
			this.lblDefine.Size = new System.Drawing.Size(49, 17);
			this.lblDefine.TabIndex = 5;
			this.lblDefine.Text = "Define";
			// 
			// txtDefine
			// 
			this.txtDefine.Location = new System.Drawing.Point(116, 54);
			this.txtDefine.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtDefine.Name = "txtDefine";
			this.txtDefine.Size = new System.Drawing.Size(145, 22);
			this.txtDefine.TabIndex = 3;
			this.txtDefine.TextChanged += new System.EventHandler(this.txtDefine_TextChanged);
			// 
			// lblValue
			// 
			this.lblValue.AutoSize = true;
			this.lblValue.Location = new System.Drawing.Point(28, 26);
			this.lblValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblValue.Name = "lblValue";
			this.lblValue.Size = new System.Drawing.Size(44, 17);
			this.lblValue.TabIndex = 4;
			this.lblValue.Text = "Value";
			// 
			// btnExit
			// 
			this.btnExit.Location = new System.Drawing.Point(637, 242);
			this.btnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(100, 28);
			this.btnExit.TabIndex = 14;
			this.btnExit.Text = "Exit";
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// frmDefineTable
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(759, 286);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.pnlDetails);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.dgv);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "frmDefineTable";
			this.Text = "frmDefineTable";
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.pnlDetails.ResumeLayout(false);
			this.pnlDetails.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Panel pnlDetails;
		private System.Windows.Forms.TextBox txtValue;
		private System.Windows.Forms.Label lblDefine;
		private System.Windows.Forms.TextBox txtDefine;
		private System.Windows.Forms.Label lblValue;
		private System.Windows.Forms.Button btnExit;
	}
}