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
        private DataTable m_dtORG;
        
        private int m_bmt_value;   
        private int? m_bms_row_index_series = null;
        private int? m_bms_row_index_movie = null;
        private int? m_bms_row_index_album = null;
        private int? m_bms_row_index_song = null;
        private int? m_bms_row_index_general = null;

        private bool m_changesforsave = false;

        public frmBookmarks()
		{
			InitializeComponent();
            dgvBMS.Sorted += dgvBMS_Sorted_Docu;

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
                col_BMS.Add(new DataColumn(def.Field.BMS_Date__Created, typeof(DateTime)));
                col_BMS.Add(new DataColumn(def.Field.BMS_Band, typeof(string)));
                col_BMS.Add(new DataColumn(def.Field.BMS_Album, typeof(string)));
                col_BMS.Add(new DataColumn(def.Field.BMS_Song, typeof(string)));
                col_BMS.Add(new DataColumn(def.Field.BMS_ORG_Value, typeof(int)));
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
                m_dtBMT.Rows.Add(5, def.BookmarkType.BMT_Value_Series, def.BookmarkType.BMT_Define_Series);
                m_dtBMT.Rows.Add(6, def.BookmarkType.BMT_Value_Docu, def.BookmarkType.BMT_Define_Docu);


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
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }

        private void loadDataTable()
        {
            ReadXML.LoadDataTable(def.FileName.xml_Bookmarks, m_dtBMS);
            ReadXML.LoadDataTable(def.FileName.xml_Origin, m_dtORG);
        }

        private void Forms_Enabled(bool filtering = false)
        {
            bool enable = dgvBMS.Rows.Count > 0 && !filtering;

            if (m_bmt_value == def.BookmarkType.BMT_Value_Movie || m_bmt_value == def.BookmarkType.BMT_Value_Series || m_bmt_value == def.BookmarkType.BMT_Value_Docu)
                cboOrigin.Enabled = txtTitle.Enabled = enable;
            else if (m_bmt_value == def.BookmarkType.BMT_Value_Album)
                txtBand.Enabled = txtAlbum.Enabled = enable;
            else if (m_bmt_value == def.BookmarkType.BMT_Value_Song)
                txtBand.Enabled = txtAlbum.Enabled = txtSong.Enabled = enable;
            else
                txtDescription.Enabled = enable;

            btnDelete.Enabled = txtURL.Enabled = dtpDateCreated.Enabled = enable;
            cboBookmarkType.Enabled = btnAdd.Enabled = btnSave.Enabled = !filtering;
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
                    DataPropertyName = def.Field.BMS_Date__Created,
                    Name = def.Field.BMS_Date__Created,
                    HeaderText = def.colHeader.Date__Created,
                    Width = 70,
                    ReadOnly = true,
                });
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
				dgvBMS.Sorted += dgvBMS_Sorted;

                m_bsBMS.DataSource = m_dtBMS;
                dgvBMS.DataSource = m_bsBMS;      
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }

		private void dgvBMS_Sorted(object sender, EventArgs e)
		{
            if (m_bmt_value == def.BookmarkType.BMT_Value_Movie || m_bmt_value == def.BookmarkType.BMT_Value_Series || m_bmt_value == def.BookmarkType.BMT_Value_Docu)
                set_ORG_Define_Value();
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

            dtpDateCreated.Value = DateTime.Today;
            dtpDateCreated.ValueChanged += dtpDateCreated_ValueChanged;
        }

		private void dgvBMS_CurrentCellChanged(object sender, EventArgs e)
		{
            try
            {
                if (dgvBMS.CurrentRow == null)
				{
                    cboOrigin.SelectedValue = -1;
                    txtBand.Text = string.Empty;
                    txtAlbum.Text = string.Empty;
                    txtSong.Text = string.Empty;
                    txtDescription.Text = txtURL.Text = string.Empty;
                    return;
                }

                DataGridViewCellCollection cells = dgvBMS.CurrentRow.Cells;

                if (m_bmt_value == def.BookmarkType.BMT_Value_Movie || m_bmt_value == def.BookmarkType.BMT_Value_Series || m_bmt_value == def.BookmarkType.BMT_Value_Docu)
				{
                    cboOrigin.SelectedValue = (int)cells[def.Field.BMS_ORG_Value].Value;
                    cells[def.Field.ORG_Define].Value = cboOrigin.Text;
                    txtTitle.Text = (string)cells[def.Field.BMS_Title].Value;
                }
                else if (m_bmt_value == def.BookmarkType.BMT_Value_Album)
                {
                    txtBand.Text = (string)cells[def.Field.BMS_Band].Value;
                    txtAlbum.Text = (string)cells[def.Field.BMS_Album].Value;
                }
                else if (m_bmt_value == def.BookmarkType.BMT_Value_Song)
				{
                    txtBand.Text = (string)cells[def.Field.BMS_Band].Value;
                    txtAlbum.Text = (string)cells[def.Field.BMS_Album].Value;
                    txtSong.Text = (string)cells[def.Field.BMS_Song].Value;
                }
                else
				    txtDescription.Text = (string)cells[def.Field.BMS_Description].Value;

                txtURL.Text = (string)cells[def.Field.BMS_URL].Value;
                var date = cells[def.Field.BMS_Date__Created].Value;
                dtpDateCreated.Value = date == DBNull.Value ? DateTime.Today : (DateTime)date;
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

        #region value forms changed
        private void txtBand_TextChanged(object sender, EventArgs e)
        {
            txtBox_TextChanged(sender, def.Field.BMS_Band);
        }

        private void txtAlbum_TextChanged(object sender, EventArgs e)
        {
            txtBox_TextChanged(sender, def.Field.BMS_Album);
        }

        private void txtSong_TextChanged(object sender, EventArgs e)
        {
            txtBox_TextChanged(sender, def.Field.BMS_Song);
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            txtBox_TextChanged(sender, def.Field.BMS_Description);
        }

        private void txtURL_TextChanged(object sender, EventArgs e)
        {
            txtBox_TextChanged(sender, def.Field.BMS_URL);
        }

        private void cboOrigin_SelectedValueChanged(object sender, EventArgs e)
        {
            cbo_SelectedValueChanged(sender, def.Field.BMS_ORG_Value, def.Field.ORG_Define);
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            txtBox_TextChanged(sender, def.Field.BMS_Title);
        }

        private void txtBox_TextChanged(object sender, string fieldname)
        {
            try
            {
                if (dgvBMS.CurrentRow == null)
                    return;

                if (((TextBox)sender).Text != (string)dgvBMS.CurrentRow.Cells[fieldname].Value)
				{
                    dgvBMS.CurrentRow.Cells[fieldname].Value = ((TextBox)sender).Text;
                    changesforsave();
                }
                    
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }

        private void cbo_SelectedValueChanged(object sender, string value, string define)
		{
            try
            {
                if (dgvBMS.CurrentRow == null)
                    return;

                if (((ComboBox)sender).SelectedValue != null && (int)((ComboBox)sender).SelectedValue != (int)dgvBMS.CurrentRow.Cells[value].Value)
                {
                    dgvBMS.CurrentRow.Cells[value].Value = ((ComboBox)sender).SelectedValue;
                    dgvBMS.CurrentRow.Cells[define].Value = ((ComboBox)sender).Text;
                    changesforsave();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }

        private void dtpDateCreated_ValueChanged(object sender, EventArgs e)
        {
            if (dgvBMS.CurrentRow == null)
                return;

            var date = dgvBMS.CurrentRow.Cells[def.Field.BMS_Date__Created].Value;

            if (date == DBNull.Value || ((DateTimePicker)sender).Value != ((DateTime)date).Date)
			{
                dgvBMS.CurrentRow.Cells[def.Field.BMS_Date__Created].Value = ((DateTimePicker)sender).Value.Date;
                changesforsave();
            }
                
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

                if (m_bmt_value == def.BookmarkType.BMT_Value_Movie || m_bmt_value == def.BookmarkType.BMT_Value_Series || m_bmt_value == def.BookmarkType.BMT_Value_Docu)
                {
                    dr[def.Field.BMS_BMT_Value] = m_bmt_value;
                    dr[def.Field.BMS_ORG_Value] = m_dtORG.Rows[0].Field<int>(def.Field.ORG_Value);
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
                dr[def.Field.BMS_Date__Created] = DateTime.Today;
                ((DataTable)(m_bsBMS.DataSource)).Rows.Add(dr);

                // selects new row, triggers current cell changed; shortcut: song and album has band
                dgvBMS.CurrentCell = dgvBMS.Rows.Cast<DataGridViewRow>().Where(r => (int)r.Cells[def.Field.BMS_Index].Value == bms_index).First()
                    .Cells[bms_col];

                Forms_Enabled();
                changesforsave();
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
                changesforsave();
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

                m_dtBMS.WriteXml(Path.Combine(Config.dir, def.FileName.xml_Bookmarks), XmlWriteMode.WriteSchema);
                m_dtBMS.AcceptChanges();
                this.Text = def.FormName.Bookmarks;
                m_changesforsave = false;

                if (m_bmt_value == def.BookmarkType.BMT_Value_Movie || m_bmt_value == def.BookmarkType.BMT_Value_Series || m_bmt_value == def.BookmarkType.BMT_Value_Docu)
                    set_ORG_Define_Value();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }

        private void validateFinal()
		{
            foreach (DataRow dr in m_dtBMS.Rows)
                dr.EndEdit();
		}

        private void changesforsave()
		{
            if (!m_changesforsave)
			{
                validateFinal();
                if (m_dtBMS.GetChanges() != null)
				{
                    this.Text += " *";
                    m_changesforsave = true;
				}           
            }
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

                set_ORG_Define_Value();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }
        #endregion

        private void cboBookmarkType_SelectedValueChanged(object sender, EventArgs e)
		{
            try
            {
                switch(m_bmt_value)
				{
                    case def.BookmarkType.BMT_Value_Docu:   m_bms_row_index_docu = dgvBMS.CurrentRow?.Index;    break;
                    case def.BookmarkType.BMT_Value_Series: m_bms_row_index_series = dgvBMS.CurrentRow?.Index;  break;
                    case def.BookmarkType.BMT_Value_Movie:  m_bms_row_index_movie = dgvBMS.CurrentRow?.Index;   break;
                    case def.BookmarkType.BMT_Value_Album:  m_bms_row_index_album = dgvBMS.CurrentRow?.Index;   break;
                    case def.BookmarkType.BMT_Value_Song:   m_bms_row_index_song = dgvBMS.CurrentRow?.Index;    break;
                    default:                                m_bms_row_index_general = dgvBMS.CurrentRow?.Index; break;
                }

                if ((int)(cboBookmarkType.SelectedValue ?? 0) == m_bmt_value)
                    return;

                m_bmt_value = (int)cboBookmarkType.SelectedValue;
                m_bsBMS.Filter = $"{def.Field.BMS_BMT_Value} = {m_bmt_value}";
                m_bsBMS.Sort = def.Field.BMS_Date__Created + " ASC";
               
                bool movie_visible = m_bmt_value == def.BookmarkType.BMT_Value_Movie || m_bmt_value == def.BookmarkType.BMT_Value_Series || m_bmt_value == def.BookmarkType.BMT_Value_Docu;
                pnlDetailsMovie.Visible = movie_visible;
                dgvBMS.Columns[def.Field.ORG_Define].Visible = movie_visible;
                dgvBMS.Columns[def.Field.BMS_Title].Visible = movie_visible;

                bool music_visible = m_bmt_value == def.BookmarkType.BMT_Value_Song || m_bmt_value == def.BookmarkType.BMT_Value_Album;
                pnlDetailsMusic.Visible = music_visible;
                dgvBMS.Columns[def.Field.BMS_Band].Visible = music_visible;
                dgvBMS.Columns[def.Field.BMS_Album].Visible = music_visible;
                
                bool song_visible = m_bmt_value == def.BookmarkType.BMT_Value_Song && m_bmt_value != def.BookmarkType.BMT_Value_Album;
                dgvBMS.Columns[def.Field.BMS_Song].Visible = song_visible;
                lblSong.Visible = txtSong.Visible = song_visible;

                pnlDetailsGeneral.Visible = dgvBMS.Columns[def.Field.BMS_Description].Visible = m_bmt_value == def.BookmarkType.BMT_Value_General;

                int? bms_row_index = m_bms_row_index_general;

                switch (m_bmt_value)
                {
                    case def.BookmarkType.BMT_Value_Movie:
                    case def.BookmarkType.BMT_Value_Series:
                    case def.BookmarkType.BMT_Value_Docu:
                        bms_row_index = m_bmt_value == def.BookmarkType.BMT_Value_Movie ? m_bms_row_index_movie : m_bms_row_index_series;
                        if (m_bmt_value == def.BookmarkType.BMT_Value_Docu)
                            bms_row_index = m_bms_row_index_docu;

                        set_ORG_Define_Value();

                        break;
                    case def.BookmarkType.BMT_Value_Album:
                        bms_row_index = m_bms_row_index_album;
                        break;
                    case def.BookmarkType.BMT_Value_Song:
                        bms_row_index = m_bms_row_index_song;
                        break;
                }

                if (dgvBMS.Rows.Count > 0)
                    dgvBMS.CurrentCell = dgvBMS.Rows[bms_row_index ?? 0].Cells[def.Field.BMS_Date__Created];

                Forms_Enabled();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }

		private void txtFilter_TextChanged(object sender, EventArgs e)
		{
            try
            {
                Forms_Enabled(txtFilter.Text != string.Empty);

                string filter = $"{def.Field.BMS_BMT_Value} = {m_bmt_value} and (";
                
                if (m_bmt_value == def.BookmarkType.BMT_Value_Movie || m_bmt_value == def.BookmarkType.BMT_Value_Series || m_bmt_value == def.BookmarkType.BMT_Value_Docu)
                    filter +=
                              $" {def.Field.BMS_Title} like '%{txtFilter.Text}%'";
                else if (m_bmt_value == def.BookmarkType.BMT_Value_Song)
                    filter += $" {def.Field.BMS_Band} like '%{txtFilter.Text}%' or" +
                              $" {def.Field.BMS_Album} like '%{txtFilter.Text}%' or" +
                              $" {def.Field.BMS_Song} like '%{txtFilter.Text}%'";
                else if (m_bmt_value == def.BookmarkType.BMT_Value_Album)
                    filter += $" {def.Field.BMS_Band} like '%{txtFilter.Text}%' or" +
                              $" {def.Field.BMS_Album} like '%{txtFilter.Text}%'";
                else
                    filter += $" {def.Field.BMS_Description} like '%{txtFilter.Text}%'";

                filter += ")";
                m_bsBMS.Filter = filter;

                if (m_bmt_value == def.BookmarkType.BMT_Value_Movie || m_bmt_value == def.BookmarkType.BMT_Value_Series || m_bmt_value == def.BookmarkType.BMT_Value_Docu)
                    set_ORG_Define_Value();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }

        private void set_ORG_Define_Value()
		{
            foreach (DataGridViewRow dgvr in dgvBMS.Rows)
            {
                dgvr.Cells[def.Field.ORG_Define].Value = m_dtORG.Select($"{def.Field.ORG_Value}={dgvr.Cells[def.Field.BMS_ORG_Value].Value}")
                    .First().Field<string>(def.Field.ORG_Define);
            }
        }
	}
}
