using System;
using System.Data;
using System.IO;
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
            prepare_dgvBMS();
            prepare_dtBMS();
            load();
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

                dgvBMS.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = Name = def.Field.BMS_Description,
                    HeaderText = def.colHeader.Description,
                    Width = 100,
                    ReadOnly = true
                });
                dgvBMS.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = Name = def.Field.BMS_URL,
                    HeaderText = def.colHeader.URL,
                    Width = 100,
                    ReadOnly = true
                });
                dgvBMS.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = Name = def.Field.BMS_Index,
                    Width = 100,
                    Visible = false
                });
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
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
                    AllowDBNull = true,
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
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }
    }
}
