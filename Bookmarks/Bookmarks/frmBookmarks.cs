using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ms.Bookmarks
{
	public partial class frmBookmarks : Form
	{
        private DataTable m_dtBMS;
        private BindingSource m_bsBMS = new BindingSource();

        private DataTable m_dtBMT;
        private DataSet m_ds = new DataSet(def.XML.KEY_DS);

        private DataTable m_dtORG;
        private DataTable m_dtGNR;

        private int m_bmt_value;
        private int? m_bms_row_index_movie = null;
        private int? m_bms_row_index_album = null;
        private int? m_bms_row_index_song = null;
        private int? m_bms_row_index_general = null;

        public frmBookmarks()
		{
			InitializeComponent();
		}

        public void init()
        {
            prepare_DataTables();
            loadDataTable();
            prepare_dgvBMS();
            prepare_Forms();

        }

        private void prepare_DataTables()
        {
            try
            {
                m_dtBMS = new DataTable(def.Table.BMS);
                var col_BMS = m_dtBMS.Columns;
                col_BMS.Add(new DataColumn(def.Field.BMS_Index, typeof(int))
                {
                    AutoIncrement = true,
                    Unique = true,
                });
                col_BMS.Add(new DataColumn(def.Field.BMS_BMT_Value, typeof(int)));
                col_BMS.Add(new DataColumn(def.Field.BMS_Description, typeof(string)));
                col_BMS.Add(new DataColumn(def.Field.BMS_URL, typeof(string)));
                col_BMS.Add(new DataColumn(def.Field.BMS_Band, typeof(string)));
                col_BMS.Add(new DataColumn(def.Field.BMS_Album, typeof(string)));
                col_BMS.Add(new DataColumn(def.Field.BMS_Song, typeof(string)));
                col_BMS.Add(new DataColumn(def.Field.BMS_ORG_Value, typeof(int)));
                col_BMS.Add(new DataColumn(def.Field.BMS_GNR_Value, typeof(int)));
                col_BMS.Add(new DataColumn(def.Field.BMS_Title, typeof(string)));

                foreach (DataColumn col in col_BMS)
                    col.AllowDBNull = true;
                col_BMS[def.Field.BMS_Index].AllowDBNull = false;
                col_BMS[def.Field.BMS_BMT_Value].AllowDBNull = false;

                m_dtBMT = new DataTable(def.Table.d_BMT);
                var col_BMT = m_dtBMT.Columns;
                col_BMT.Add(new DataColumn(def.Field.d_BMT_Index, typeof(int)));
                col_BMT.Add(new DataColumn(def.Field.BMT_Value, typeof(int)));
                col_BMT.Add(new DataColumn(def.Field.BMT_Define, typeof(string)));

                col_BMT[def.Field.d_BMT_Index].Unique = true;
                foreach (DataColumn col in col_BMT)
                    col.AllowDBNull = false;

                m_dtBMT.Rows.Add(1, def.BookmarkType.BMT_Value_General, def.BookmarkType.BMT_Define_General);
                m_dtBMT.Rows.Add(2, def.BookmarkType.BMT_Value_Song, def.BookmarkType.BMT_Define_Song);
                m_dtBMT.Rows.Add(3, def.BookmarkType.BMT_Value_Album, def.BookmarkType.BMT_Define_Album);
                m_dtBMT.Rows.Add(4, def.BookmarkType.BMT_Value_Movie, def.BookmarkType.BMT_Define_Movie);


                m_dtORG = new DataTable(def.Table.d_ORG);
                var col_ORG = m_dtORG.Columns;
                col_ORG.Add(new DataColumn(def.Field.d_ORG_Index, typeof(int))
                {
                    AutoIncrement = true,
                    Unique = true,
                });
                col_ORG.Add(new DataColumn(def.Field.ORG_Value, typeof(int)));
                col_ORG.Add(new DataColumn(def.Field.ORG_Define, typeof(string)));
                foreach (DataColumn col in col_ORG)
                    col.AllowDBNull = false;

                m_dtGNR = new DataTable(def.Table.d_ORG);
                var col_GNR = m_dtGNR.Columns;
                col_GNR.Add(new DataColumn(def.Field.d_GNR_Index, typeof(int))
                {
                    AutoIncrement = true,
                    Unique = true,
                });
                col_GNR.Add(new DataColumn(def.Field.GNR_Value, typeof(int)));
                col_GNR.Add(new DataColumn(def.Field.GNR_Define, typeof(string)));
                foreach (DataColumn col in col_GNR)
                    col.AllowDBNull = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }

        private void loadDataTable()
        {
            ReadXML.LoadDataTable(def.FileName.xml_Bookmarks, m_dtBMS);
            ReadXML.LoadDataTable(def.FileName.xml_Origin, m_dtORG);
            ReadXML.LoadDataTable(def.FileName.xml_Genre, m_dtGNR);
        }

        private void Forms_Enabled()
        {
            if (m_bmt_value == def.BookmarkType.BMT_Value_Movie)
                cboOrigin.Enabled = cboGenre.Enabled = txtTitle.Enabled = dgvBMS.Rows.Count > 0;
            else if (m_bmt_value == def.BookmarkType.BMT_Value_Album)
                txtBand.Enabled = txtAlbum.Enabled = dgvBMS.Rows.Count > 0;
            else if (m_bmt_value == def.BookmarkType.BMT_Value_Song)
                txtBand.Enabled = txtAlbum.Enabled = txtSong.Enabled = dgvBMS.Rows.Count > 0;
            else
                txtDescription.Enabled = dgvBMS.Rows.Count > 0;

            btnDelete.Enabled = txtURL.Enabled = dgvBMS.Rows.Count > 0;
        }

        private void prepare_dgvBMS()
        {
            try
			{
                dgvBMS.AllowUserToAddRows = false;
                dgvBMS.AllowUserToDeleteRows = false;
                dgvBMS.AllowUserToOrderColumns = false;
                dgvBMS.AllowUserToResizeRows = false;
                dgvBMS.ReadOnly = true;
                dgvBMS.MultiSelect = false;
                dgvBMS.RowHeadersVisible = false;
                dgvBMS.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                dgvBMS.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = def.Field.ORG_Define,
                    Name = def.Field.ORG_Define,
                    HeaderText = def.colHeader.Origin,
                    Width = 100,
                    ReadOnly = true,
                });
                dgvBMS.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = def.Field.BMS_ORG_Value,
                    Name = def.Field.BMS_ORG_Value,
                    Visible = false,
                });
                dgvBMS.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = def.Field.GNR_Define,
                    Name = def.Field.GNR_Define,
                    HeaderText = def.colHeader.Genre,
                    Width = 100,
                    ReadOnly = true
                });
                dgvBMS.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = def.Field.BMS_GNR_Value,
                    Name = def.Field.BMS_GNR_Value,
                    Visible = false,
                });
                dgvBMS.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = def.Field.BMS_Title,
                    Name = def.Field.BMS_Title,
                    HeaderText = def.colHeader.Title,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    ReadOnly = true
                });

                dgvBMS.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = def.Field.BMS_Band,
                    Name = def.Field.BMS_Band,
                    HeaderText = def.colHeader.Band,
                    Width = 100,
                    ReadOnly = true,
                });
                dgvBMS.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = def.Field.BMS_Album,
                    Name = def.Field.BMS_Album,
                    HeaderText = def.colHeader.Album,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    ReadOnly = true
                });
                dgvBMS.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = def.Field.BMS_Song,
                    Name = def.Field.BMS_Song,
                    HeaderText = def.colHeader.Song,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    ReadOnly = true
                });

                dgvBMS.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = def.Field.BMS_Description,
                    Name = def.Field.BMS_Description,
                    HeaderText = def.colHeader.Description,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    ReadOnly = true,
                    Visible = false,
                });
                dgvBMS.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = def.Field.BMS_URL,
                    Name = def.Field.BMS_URL,
                    HeaderText = def.colHeader.URL,
                    Visible = false,
                });
                dgvBMS.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = def.Field.BMS_BMT_Value,
                    Name = def.Field.BMS_BMT_Value,
                    Visible = false,
                });
                dgvBMS.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = def.Field.BMS_Index,
                    Name = def.Field.BMS_Index,
                    Visible = false,
                });

                dgvBMS.CurrentCellChanged += dgvBMS_CurrentCellChanged;
				dgvBMS.CellDoubleClick += dgvBMS_CellDoubleClick;

                m_bsBMS.DataSource = m_dtBMS;
                dgvBMS.DataSource = m_bsBMS;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }

		private void prepare_Forms()
		{
            cboBookmarkType.DisplayMember = def.Field.BMT_Define;
            cboBookmarkType.ValueMember = def.Field.BMT_Value;
            cboBookmarkType.DataSource = m_dtBMT; 
            cboBookmarkType.SelectedValueChanged += cboBookmarkType_SelectedValueChanged;
            cboBookmarkType.SelectedValue = def.BookmarkType.BMT_Value_Song;
            m_bmt_value = def.BookmarkType.BMT_Value_Song;

            cboOrigin.DisplayMember = def.Field.ORG_Define;
            cboOrigin.ValueMember = def.Field.ORG_Value;
            cboOrigin.DataSource = m_dtORG;
            cboOrigin.SelectedValue = -1;
            cboOrigin.SelectedValueChanged += cboOrigin_SelectedValueChanged;

            cboGenre.DisplayMember = def.Field.GNR_Define;
            cboGenre.ValueMember = def.Field.GNR_Value;
            cboGenre.DataSource = m_dtGNR;
            cboGenre.SelectedValue = -1;
            cboGenre.SelectedValueChanged += cboGenre_SelectedValueChanged;
        }

		private void dgvBMS_CurrentCellChanged(object sender, EventArgs e)
		{
            try
            {
                if (dgvBMS.CurrentRow == null)
				{
                    cboOrigin.SelectedValue = -1;
                    cboGenre.SelectedValue = -1;
                    txtBand.Text = string.Empty;
                    txtAlbum.Text = string.Empty;
                    txtSong.Text = string.Empty;
                    txtDescription.Text = txtURL.Text = string.Empty;
                    return;
                }

                if (m_bmt_value == def.BookmarkType.BMT_Value_Movie)
				{
                    cboOrigin.SelectedValue = (int)dgvBMS.CurrentRow.Cells[def.Field.BMS_ORG_Value].Value;
                    dgvBMS.CurrentRow.Cells[def.Field.ORG_Define].Value = cboOrigin.Text;
                    cboGenre.SelectedValue = (int)dgvBMS.CurrentRow.Cells[def.Field.BMS_GNR_Value].Value;
                    dgvBMS.CurrentRow.Cells[def.Field.GNR_Define].Value = cboGenre.Text;
                    txtTitle.Text = (string)dgvBMS.CurrentRow.Cells[def.Field.BMS_Title].Value;
                }
                else if (m_bmt_value == def.BookmarkType.BMT_Value_Album)
                {
                    txtBand.Text = (string)dgvBMS.CurrentRow.Cells[def.Field.BMS_Band].Value;
                    txtAlbum.Text = (string)dgvBMS.CurrentRow.Cells[def.Field.BMS_Album].Value;
                }
                else if (m_bmt_value == def.BookmarkType.BMT_Value_Song)
				{
                    txtBand.Text = (string)dgvBMS.CurrentRow.Cells[def.Field.BMS_Band].Value;
                    txtAlbum.Text = (string)dgvBMS.CurrentRow.Cells[def.Field.BMS_Album].Value;
                    txtSong.Text = (string)dgvBMS.CurrentRow.Cells[def.Field.BMS_Song].Value;
                }
                else
				    txtDescription.Text = (string)dgvBMS.CurrentRow.Cells[def.Field.BMS_Description].Value;

                txtURL.Text = (string)dgvBMS.CurrentRow.Cells[def.Field.BMS_URL].Value;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }

        private void dgvBMS_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvBMS.CurrentRow == null)
                    return;

                Process.Start((string)dgvBMS.CurrentRow.Cells[def.Field.BMS_URL].Value);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }

        #region textboxes changed
        private void txtBand_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvBMS.CurrentRow == null)
                    return;

                if (txtBand.Text != (string)dgvBMS.CurrentRow.Cells[def.Field.BMS_Band].Value)
                    dgvBMS.CurrentRow.Cells[def.Field.BMS_Band].Value = txtBand.Text;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }

        private void txtAlbum_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvBMS.CurrentRow == null)
                    return;

                if (txtAlbum.Text != (string)dgvBMS.CurrentRow.Cells[def.Field.BMS_Album].Value)
                    dgvBMS.CurrentRow.Cells[def.Field.BMS_Album].Value = txtAlbum.Text;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }

        private void txtSong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvBMS.CurrentRow == null)
                    return;

                if (txtSong.Text != (string)dgvBMS.CurrentRow.Cells[def.Field.BMS_Song].Value)
                    dgvBMS.CurrentRow.Cells[def.Field.BMS_Song].Value = txtSong.Text;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvBMS.CurrentRow == null)
                    return;

                if (txtDescription.Text != (string)dgvBMS.CurrentRow.Cells[def.Field.BMS_Description].Value)
                    dgvBMS.CurrentRow.Cells[def.Field.BMS_Description].Value = txtDescription.Text;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }

        private void txtURL_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvBMS.CurrentRow == null)
                    return;

                if (txtURL.Text != (string)dgvBMS.CurrentRow.Cells[def.Field.BMS_URL].Value)
                    dgvBMS.CurrentRow.Cells[def.Field.BMS_URL].Value = txtURL.Text;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }

        private void cboOrigin_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvBMS.CurrentRow == null)
                    return;

                if (cboOrigin.SelectedValue != null && (int)cboOrigin.SelectedValue != (int)dgvBMS.CurrentRow.Cells[def.Field.BMS_ORG_Value].Value)
				{
                    dgvBMS.CurrentRow.Cells[def.Field.BMS_ORG_Value].Value = cboOrigin.SelectedValue;
                    dgvBMS.CurrentRow.Cells[def.Field.ORG_Define].Value = cboOrigin.Text;
                }             
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }

		private void cboGenre_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvBMS.CurrentRow == null)
                    return;

                if (cboGenre.SelectedValue != null && (int)cboGenre.SelectedValue != (int)dgvBMS.CurrentRow.Cells[def.Field.BMS_GNR_Value].Value)
                {
                    dgvBMS.CurrentRow.Cells[def.Field.BMS_GNR_Value].Value = cboGenre.SelectedValue;
                    dgvBMS.CurrentRow.Cells[def.Field.GNR_Define].Value = cboGenre.Text;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvBMS.CurrentRow == null)
                    return;

                if (txtTitle.Text != (string)dgvBMS.CurrentRow.Cells[def.Field.BMS_Title].Value)
                    dgvBMS.CurrentRow.Cells[def.Field.BMS_Title].Value = txtTitle.Text;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }
        #endregion

        #region buttons click
        private void btnAdd_Click(object sender, EventArgs e)
		{
            try
			{
                DataRow dr = ((DataTable)(m_bsBMS.DataSource)).NewRow();
                int bms_index = (int)dr[def.Field.BMS_Index];
                string bms_col = def.Field.BMS_Description;

                if (m_bmt_value == def.BookmarkType.BMT_Value_Movie)
                {
                    dr[def.Field.BMS_BMT_Value] = def.BookmarkType.BMT_Value_Movie;
                    dr[def.Field.BMS_ORG_Value] = m_dtORG.Rows[0].Field<int>(def.Field.ORG_Value);
                    dr[def.Field.BMS_GNR_Value] = m_dtGNR.Rows[0].Field<int>(def.Field.GNR_Value);
                    dr[def.Field.BMS_Title] = string.Empty;
                    bms_col = def.Field.BMS_Title;
                }
                else if (m_bmt_value == def.BookmarkType.BMT_Value_Album || m_bmt_value == def.BookmarkType.BMT_Value_Song)
                {
                    dr[def.Field.BMS_BMT_Value] = m_bmt_value == def.BookmarkType.BMT_Value_Album ? def.BookmarkType.BMT_Value_Album : def.BookmarkType.BMT_Value_Song;
                    dr[def.Field.BMS_Band] = string.Empty;
                    dr[def.Field.BMS_Album] = string.Empty;
                    bms_col = def.Field.BMS_Band;

                    if (m_bmt_value == def.BookmarkType.BMT_Value_Song)
                        dr[def.Field.BMS_Song] = string.Empty;
                }
                else
                {
                    dr[def.Field.BMS_BMT_Value] = def.BookmarkType.BMT_Value_General;
                    dr[def.Field.BMS_Description] = string.Empty;    
                }

                dr[def.Field.BMS_URL] = string.Empty;
                ((DataTable)(m_bsBMS.DataSource)).Rows.Add(dr);

                // selects new row, triggers current cell changed; shortcut: song and album has band
                dgvBMS.CurrentCell = dgvBMS.Rows.Cast<DataGridViewRow>().Where(r => (int)r.Cells[def.Field.BMS_Index].Value == bms_index).First()
                    .Cells[bms_col];

                Forms_Enabled();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }


		private void btnDelete_Click(object sender, EventArgs e)
		{
            try
            {
                if (dgvBMS.CurrentRow == null)
                    return;

                int bms_index = (int)dgvBMS.CurrentRow.Cells[def.Field.BMS_Index].Value;
                DataRow dr = m_dtBMS.AsEnumerable().Where(r => r.RowState != DataRowState.Deleted && r.Field<int>(def.Field.BMS_Index) == bms_index).First();
                dr.Delete();

                Forms_Enabled();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                validateFinal();

                if (m_dtBMS.GetChanges() == null)
                    return;

                // TODO check if just changes or updates can be added to the file
                m_dtBMS.WriteXml(Path.Combine(Config.dir, def.FileName.xml_Bookmarks), XmlWriteMode.WriteSchema);
                m_dtBMS.AcceptChanges();

                if (m_bmt_value == def.BookmarkType.BMT_Value_Movie)
                {
                    foreach (DataGridViewRow dgvr in dgvBMS.Rows)
                    {
                        dgvr.Cells[def.Field.ORG_Define].Value = m_dtORG.Select($"{def.Field.ORG_Value}={dgvr.Cells[def.Field.BMS_ORG_Value].Value}")
                            .First().Field<string>(def.Field.ORG_Define);
                        dgvr.Cells[def.Field.GNR_Define].Value = m_dtGNR.Select($"{def.Field.GNR_Value}={dgvr.Cells[def.Field.BMS_GNR_Value].Value}")
                            .First().Field<string>(def.Field.GNR_Define);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }
        #endregion

        private void validateFinal()
		{
            foreach (DataRow dr in m_dtBMS.Rows)
                dr.EndEdit();
		}

		private void cboBookmarkType_SelectedValueChanged(object sender, EventArgs e)
		{
            try
            {
                if (m_bmt_value == def.BookmarkType.BMT_Value_Movie)
                    m_bms_row_index_movie = dgvBMS.CurrentRow?.Index;
                else if (m_bmt_value == def.BookmarkType.BMT_Value_Album)
                    m_bms_row_index_album = dgvBMS.CurrentRow?.Index;
                else if (m_bmt_value == def.BookmarkType.BMT_Value_Song)
                    m_bms_row_index_song = dgvBMS.CurrentRow?.Index;
                else
                    m_bms_row_index_general = dgvBMS.CurrentRow?.Index;

                if ((int)(cboBookmarkType.SelectedValue ?? 0) == m_bmt_value)
                    return;
                else
                    m_bmt_value = (int)cboBookmarkType.SelectedValue;

                m_bsBMS.Filter = $"{def.Field.BMS_BMT_Value} = {m_bmt_value}";

                pnlDetailsMovie.Visible = m_bmt_value == def.BookmarkType.BMT_Value_Movie;
                dgvBMS.Columns[def.Field.ORG_Define].Visible = m_bmt_value == def.BookmarkType.BMT_Value_Movie;
                dgvBMS.Columns[def.Field.GNR_Define].Visible = m_bmt_value == def.BookmarkType.BMT_Value_Movie;
                dgvBMS.Columns[def.Field.BMS_Title].Visible = m_bmt_value == def.BookmarkType.BMT_Value_Movie;

                pnlDetailsMusic.Visible = m_bmt_value == def.BookmarkType.BMT_Value_Song || m_bmt_value == def.BookmarkType.BMT_Value_Album;
                dgvBMS.Columns[def.Field.BMS_Band].Visible = m_bmt_value == def.BookmarkType.BMT_Value_Song || m_bmt_value == def.BookmarkType.BMT_Value_Album;
                dgvBMS.Columns[def.Field.BMS_Album].Visible = m_bmt_value == def.BookmarkType.BMT_Value_Song || m_bmt_value == def.BookmarkType.BMT_Value_Album;
                dgvBMS.Columns[def.Field.BMS_Song].Visible = m_bmt_value == def.BookmarkType.BMT_Value_Song && m_bmt_value != def.BookmarkType.BMT_Value_Album;
                lblSong.Visible = txtSong.Visible = m_bmt_value == def.BookmarkType.BMT_Value_Song && m_bmt_value != def.BookmarkType.BMT_Value_Album;

                pnlDetailsGeneral.Visible = m_bmt_value == def.BookmarkType.BMT_Value_General;
                dgvBMS.Columns[def.Field.BMS_Description].Visible = m_bmt_value == def.BookmarkType.BMT_Value_General;

                int? bms_row_index = m_bms_row_index_general;
                string bms_col = def.Field.BMS_Description;

                if (m_bmt_value == def.BookmarkType.BMT_Value_Movie)
                {
                    bms_row_index = m_bms_row_index_movie;
                    bms_col = def.Field.BMS_Title;

                    foreach (DataGridViewRow dgvr in dgvBMS.Rows)
                    {
                        dgvr.Cells[def.Field.ORG_Define].Value = m_dtORG.Select($"{def.Field.ORG_Value}={dgvr.Cells[def.Field.BMS_ORG_Value].Value}")
                            .First().Field<string>(def.Field.ORG_Define);
                        dgvr.Cells[def.Field.GNR_Define].Value = m_dtGNR.Select($"{def.Field.GNR_Value}={dgvr.Cells[def.Field.BMS_GNR_Value].Value}")
                            .First().Field<string>(def.Field.GNR_Define);
                    }
                }
                else if (m_bmt_value == def.BookmarkType.BMT_Value_Album)
                {
                    bms_row_index = m_bms_row_index_album;
                    bms_col = def.Field.BMS_Band;
                }
                else if (m_bmt_value == def.BookmarkType.BMT_Value_Song)
                {
                    bms_row_index = m_bms_row_index_song;
                    bms_col = def.Field.BMS_Band;
                }

                if (dgvBMS.Rows.Count > 0)
                    dgvBMS.CurrentCell = dgvBMS.Rows[bms_row_index ?? 0].Cells[bms_col];

                Forms_Enabled();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }

        }

		private void btnOrigin_Click(object sender, EventArgs e)
		{
            try
            {
                Form f = new frmDefineTable(def.FormName.Origin);
                ((frmDefineTable)f).init(def.Table.d_ORG, def.FileName.xml_Origin);
                f.ShowDialog();

                DataTable dt = new DataTable();
                dt.ReadXml(Path.Combine(Config.dir, def.FileName.xml_Origin));
                m_dtORG.Rows.Clear();
                m_dtORG.Merge(dt);

                cboOrigin.SelectedValue = dgvBMS.CurrentRow != null ? dgvBMS.CurrentRow.Cells[def.Field.BMS_ORG_Value].Value : -1;

                foreach (DataGridViewRow dgvr in dgvBMS.Rows)
                {
                    dgvr.Cells[def.Field.ORG_Define].Value = m_dtORG.Select($"{def.Field.ORG_Value}={dgvr.Cells[def.Field.BMS_ORG_Value].Value}")
                        .First().Field<string>(def.Field.ORG_Define);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }

		private void btnGenre_Click(object sender, EventArgs e)
		{
            try
            {
                Form f = new frmDefineTable(def.FormName.Genre);
                ((frmDefineTable)f).init(def.Table.d_GNR, def.FileName.xml_Genre);
                f.ShowDialog();

                DataTable dt = new DataTable();
                dt.ReadXml(Path.Combine(Config.dir, def.FileName.xml_Genre));
                m_dtGNR.Rows.Clear();
                m_dtGNR.Merge(dt);

                cboGenre.SelectedValue = dgvBMS.CurrentRow != null ? dgvBMS.CurrentRow.Cells[def.Field.BMS_GNR_Value].Value : -1;

                foreach (DataGridViewRow dgvr in dgvBMS.Rows)
                {
                    dgvr.Cells[def.Field.GNR_Define].Value = m_dtGNR.Select($"{def.Field.GNR_Value}={dgvr.Cells[def.Field.BMS_GNR_Value].Value}")
                        .First().Field<string>(def.Field.GNR_Define);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }
	}
}
