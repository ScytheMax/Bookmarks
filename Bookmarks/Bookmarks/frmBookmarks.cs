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

        private int m_bmt_value;
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
            loadXML();
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
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }

        private void loadXML()
        {
            try
            {
                if (!Directory.Exists(Config.dir))
                    Directory.CreateDirectory(Config.dir);

                string filePath = Path.Combine(Config.dir, def.FileName.xml_Bookmarks);
                if (!File.Exists(filePath))
                {
                    using (var fs = File.Create(filePath))
                    {
                        m_ds.WriteXml(fs);
                    }
                }

                m_ds.ReadXml(filePath);
                if (m_ds.Tables.Contains(def.Table.BMS))
                    m_dtBMS.Merge(m_ds.Tables[def.Table.BMS]);
                m_dtBMS.AcceptChanges();
                m_bsBMS.DataSource = m_dtBMS;

                Forms_Enabled();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }

        private void Forms_Enabled()
        {
            if (m_bmt_value == def.BookmarkType.BMT_Value_Album)
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
                
                dgvBMS.DataSource = m_bsBMS;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }

		private void prepare_Forms()
		{
            cboBookmarkType.DisplayMember = def.Field.BMT_Define;
            cboBookmarkType.ValueMember = def.Field.BMT_Value;
            cboBookmarkType.DataSource = m_dtBMT;
            cboBookmarkType.SelectedValue = def.BookmarkType.BMT_Value_Song;
            m_bmt_value = def.BookmarkType.BMT_Value_Song;
        }

		private void dgvBMS_CurrentCellChanged(object sender, EventArgs e)
		{
            try
            {
                if (dgvBMS.CurrentRow == null)
				{
                    txtBand.Text = string.Empty;
                    txtAlbum.Text = string.Empty;
                    txtSong.Text = string.Empty;
                    txtDescription.Text = txtURL.Text = string.Empty;
                    return;
                }

                if (m_bmt_value == def.BookmarkType.BMT_Value_Album)
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
		#endregion

		#region buttons click
		private void btnAdd_Click(object sender, EventArgs e)
		{
            try
			{
                DataRow dr = ((DataTable)(m_bsBMS.DataSource)).NewRow();
                int bms_index = (int)dr[def.Field.BMS_Index];

                if (m_bmt_value == def.BookmarkType.BMT_Value_Album)
                {
                    dr[def.Field.BMS_BMT_Value] = def.BookmarkType.BMT_Value_Album;
                    dr[def.Field.BMS_Band] = string.Empty;
                    dr[def.Field.BMS_Album] = string.Empty;
                }
                else if (m_bmt_value == def.BookmarkType.BMT_Value_Song)
                {
                    dr[def.Field.BMS_BMT_Value] = def.BookmarkType.BMT_Value_Song;
                    dr[def.Field.BMS_Band] = string.Empty;
                    dr[def.Field.BMS_Album] = string.Empty;
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
                    .Cells[m_bmt_value == def.BookmarkType.BMT_Value_General ? def.Field.BMS_Description : def.Field.BMS_Band];

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
                if (m_ds.Tables.Contains(def.Table.BMS))
                    m_ds.Tables.Remove(def.Table.BMS);
                m_ds.Tables.Add(m_dtBMS);
                
                m_ds.WriteXml(Path.Combine(Config.dir, def.FileName.xml_Bookmarks), XmlWriteMode.WriteSchema);
                m_dtBMS.AcceptChanges();
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
                if (m_bmt_value == def.BookmarkType.BMT_Value_Album)
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

                bool visible = m_bmt_value != def.BookmarkType.BMT_Value_General;
                dgvBMS.Columns[def.Field.BMS_Band].Visible = visible;
                dgvBMS.Columns[def.Field.BMS_Album].Visible = visible;
                dgvBMS.Columns[def.Field.BMS_Song].Visible = visible && m_bmt_value != def.BookmarkType.BMT_Value_Album;
                dgvBMS.Columns[def.Field.BMS_Description].Visible = !visible;
                pnlDetailsMusic.Visible = visible;
                lblSong.Visible = txtSong.Visible = visible && m_bmt_value != def.BookmarkType.BMT_Value_Album;
                pnlDetailsGeneral.Visible = !visible;

                int? m_bms_row_index_music = null;
                if (m_bmt_value == def.BookmarkType.BMT_Value_Album)
                    m_bms_row_index_music = m_bms_row_index_album;
                else if (m_bmt_value == def.BookmarkType.BMT_Value_Song)
                    m_bms_row_index_music = m_bms_row_index_song;

                if (dgvBMS.Rows.Count > 0)
                    dgvBMS.CurrentCell = dgvBMS.Rows[(m_bmt_value != def.BookmarkType.BMT_Value_General ? m_bms_row_index_music : m_bms_row_index_general) ?? 0]
                        .Cells[m_bmt_value != def.BookmarkType.BMT_Value_General ? def.Field.BMS_Band : def.Field.BMS_Description];

                Forms_Enabled();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }
	}
}
