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

        public frmBookmarks()
		{
			InitializeComponent();
		}

        public void init()
        {
            prepare_dtBMS();
            load();
            prepare_dgvBMS();

        }

        private void prepare_dtBMS()
        {
            try
            {
                m_dtBMS = new DataTable(def.Table.BMS);

                m_dtBMS.Columns.Add(new DataColumn(def.Field.BMS_Index, typeof(int))
                {
                    AllowDBNull = false,
                    AutoIncrement = true,
                    Unique = true,
                });
                m_dtBMS.Columns.Add(new DataColumn(def.Field.BMS_Description, typeof(string))
                {
                    AllowDBNull = false,
                });
                m_dtBMS.Columns.Add(new DataColumn(def.Field.BMS_URL, typeof(string))
                {
                    AllowDBNull = false,
                });
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }

        private void load()
        {
            try
            {
                if (!Directory.Exists(Config.dir))
                    Directory.CreateDirectory(Config.dir);

                var ds = new DataSet("ds");

                string filePath = Path.Combine(Config.dir, def.FileName.xml_Bookmarks);
                if (!File.Exists(filePath))
                {
                    using (var fs = File.Create(filePath))
                    {
                        ds.WriteXml(fs);
                    }
                }

                ds.ReadXml(filePath);
                if (ds.Tables.Contains(def.Table.BMS))
                    m_dtBMS = ds.Tables[def.Table.BMS];
                m_dtBMS.AcceptChanges();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
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
                    DataPropertyName = def.Field.BMS_Description,
                    Name = def.Field.BMS_Description,
                    HeaderText = def.colHeader.Description,
                    Width = 150,
                    ReadOnly = true
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
                    Visible = false
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
                    return;

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
                txtDescription.Text = txtURL.Text = string.Empty;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }
	}
}
