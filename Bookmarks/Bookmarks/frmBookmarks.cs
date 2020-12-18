using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ms.Bookmarks
{
	public partial class frmBookmarks : Form
	{
        private DataTable m_dtBMS;
        private DataTable m_dtBMT;
        private DataSet m_ds = new DataSet(def.XML.KEY_DS);

        private int m_bmt_value;

        public frmBookmarks()
		{
			InitializeComponent();
		}

        public void init()
        {
            prepare_DataTables();
            load();
            prepare_dgvBMS();
            prepare_Form();

        }

        private void prepare_DataTables()
        {
            try
            {
                m_dtBMS = new DataTable(def.Table.BMS);
                var col_BMS = m_dtBMS.Columns;
                col_BMS.Add(new DataColumn(def.Field.BMS_Index, typeof(int))
                {
                    AllowDBNull = false,
                    AutoIncrement = true,
                    Unique = true,
                });
                col_BMS.Add(new DataColumn(def.Field.BMS_Description, typeof(string)));
                col_BMS.Add(new DataColumn(def.Field.BMS_URL, typeof(string)));
                col_BMS.Add(new DataColumn(def.Field.BMS_Band, typeof(string)));
                col_BMS.Add(new DataColumn(def.Field.BMS_Album, typeof(string)));
                col_BMS.Add(new DataColumn(def.Field.BMS_Song, typeof(string)));

                foreach (DataColumn col in col_BMS)
                    col.AllowDBNull = true;

                m_dtBMT = new DataTable(def.Table.d_BMT);
                m_dtBMT.Columns.Add(new DataColumn(def.Field.d_BMT_Index, typeof(int))
                {
                    AllowDBNull = false,
                    Unique = true,
                });
                m_dtBMT.Columns.Add(new DataColumn(def.Field.BMT_Value, typeof(int))
                {
                    AllowDBNull = false,
                });
                m_dtBMT.Columns.Add(new DataColumn(def.Field.BMT_Define, typeof(string))
                {
                    AllowDBNull = false,
                });
                m_dtBMT.Rows.Add(1, 1, def.BookmarkType.BMT_Define_General);
                m_dtBMT.Rows.Add(2, 2, def.BookmarkType.BMT_Define_Music);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }

        private void load()
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

                btnDelete.Enabled = txtDescription.Enabled = txtURL.Enabled = m_dtBMS.Rows.Count > 0;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }

        private void prepare_Form()
		{
            cboBookmarkType.DisplayMember = def.Field.BMT_Define;
            cboBookmarkType.ValueMember = def.Field.BMT_Value;
            cboBookmarkType.DataSource = m_dtBMT;
            cboBookmarkType.SelectedValue = def.BookmarkType.BMT_Value_Music;
            m_bmt_value = def.BookmarkType.BMT_Value_Music;
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
                    Width = 100,
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
                    Width = 100,
                    ReadOnly = true,
                    Visible = false,
                });
                dgvBMS.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = def.Field.BMS_URL,
                    Name = def.Field.BMS_URL,
                    HeaderText = def.colHeader.URL,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    ReadOnly = true
                });
                dgvBMS.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = def.Field.BMS_Index,
                    Name = def.Field.BMS_Index,
                    Width = 100,
                    Visible = false,
                });

                dgvBMS.CurrentCellChanged += dgvBMS_CurrentCellChanged;
                
                dgvBMS.DataSource = m_dtBMS;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }

		private void dgvBMS_CurrentCellChanged(object sender, EventArgs e)
		{
            try
            {
                if (dgvBMS.CurrentRow == null)
				{
                    txtDescription.Text = txtURL.Text = string.Empty;
                    return;
                }

                txtDescription.Text = (string)dgvBMS.CurrentRow.Cells[def.Field.BMS_Description].Value;
                txtURL.Text = (string)dgvBMS.CurrentRow.Cells[def.Field.BMS_URL].Value;
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

        private void btnAdd_Click(object sender, EventArgs e)
		{
            try
			{
                DataRow dr = m_dtBMS.NewRow();
                int bms_index = (int)dr[def.Field.BMS_Index];
                dr[def.Field.BMS_Description] = string.Empty;
                dr[def.Field.BMS_URL] = string.Empty;
                m_dtBMS.Rows.Add(dr);

                dgvBMS.CurrentCell = dgvBMS.Rows.Cast<DataGridViewRow>().Where(r => (int)r.Cells[def.Field.BMS_Index].Value == bms_index).First()
                    .Cells[def.Field.BMS_Description];
                btnDelete.Enabled = txtDescription.Enabled = txtURL.Enabled = true;
                txtDescription.Text = txtURL.Text = string.Empty;
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
                btnDelete.Enabled = txtDescription.Enabled = txtURL.Enabled = dgvBMS.Rows.Count > 0;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }


        private void validateFinal()
		{
            foreach (DataRow dr in m_dtBMS.Rows)
                dr.EndEdit();
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

		private void cboBookmarkType_SelectedValueChanged(object sender, EventArgs e)
		{
            try
            {          
                if ((int)(cboBookmarkType.SelectedValue ?? 0) == m_bmt_value)
                    return;
                else
                    m_bmt_value = (int)cboBookmarkType.SelectedValue;

                if (m_bmt_value == def.BookmarkType.BMT_Value_Music)
				{
                    dgvBMS.Columns[def.Field.BMS_Band].Visible = true;
                    dgvBMS.Columns[def.Field.BMS_Album].Visible = true;
                    dgvBMS.Columns[def.Field.BMS_Song].Visible = true;
                    dgvBMS.Columns[def.Field.BMS_Description].Visible = false;
                    pnlDetailsMusic.Visible = true;
                    pnlDetailsGeneral.Visible = false;
                }
                else
				{
                    dgvBMS.Columns[def.Field.BMS_Band].Visible = false;
                    dgvBMS.Columns[def.Field.BMS_Album].Visible = false;
                    dgvBMS.Columns[def.Field.BMS_Song].Visible = false;
                    dgvBMS.Columns[def.Field.BMS_Description].Visible = true;
                    pnlDetailsMusic.Visible = false;
                    pnlDetailsGeneral.Visible = true;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }
	}
}
