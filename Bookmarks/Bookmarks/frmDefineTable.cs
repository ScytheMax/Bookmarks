using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ms.Bookmarks
{
	public partial class frmDefineTable : Form
	{
        private DataTable m_dt;
        private string m_tableIndex;
        private string m_tableValue;
        private string m_tableDefine;
        private string m_filename;

        public frmDefineTable(string formName)
		{
			InitializeComponent();
            Text = formName;
		}

		public void init(string table, string filename)
		{
            m_tableIndex = table + "_Index";
            m_tableValue = table.Replace("d_", "") + "_Value";
            m_tableDefine = table.Replace("d_", "") + "_Define";
            m_filename = filename;
            prepare_DataTable(table);
            ReadXML.LoadDataTable(m_filename, m_dt);
            prepare_dgv();
            Forms_Enabled();
		}

        private void Forms_Enabled()
        {
            txtValue.Enabled = txtDefine.Enabled = dgv.Rows.Count > 0;
        }

        private void prepare_DataTable(string table)
        {
            try
            {
                m_dt = new DataTable(table);
                var col_BMS = m_dt.Columns;
                col_BMS.Add(new DataColumn(m_tableIndex, typeof(int))
                {
                    AutoIncrement = true,
                    Unique = true,
                });
                col_BMS.Add(new DataColumn(m_tableValue, typeof(int)));
                col_BMS.Add(new DataColumn(m_tableDefine, typeof(string)));

                foreach (DataColumn col in col_BMS)
                    col.AllowDBNull = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }

        private void prepare_dgv()
		{
            try
            {
                dgv.AllowUserToAddRows = false;
                dgv.AllowUserToDeleteRows = false;
                dgv.AllowUserToOrderColumns = false;
                dgv.AllowUserToResizeRows = false;
                dgv.ReadOnly = true;
                dgv.MultiSelect = false;
                dgv.RowHeadersVisible = false;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                dgv.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = m_tableValue,
                    Name = m_tableValue,
                    HeaderText = def.colHeader.Value,
                    Width = 100,
                    ReadOnly = true,
                });
                dgv.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = m_tableDefine,
                    Name = m_tableDefine,
                    HeaderText = def.colHeader.Define,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    ReadOnly = true
                });
                dgv.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = m_tableIndex,
                    Name = m_tableIndex,
                    Visible = false,
                });

			    dgv.CurrentCellChanged += dgv_CurrentCellChanged;
                dgv.DataSource = m_dt;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }

        private void dgv_CurrentCellChanged(object sender, EventArgs e)
		{
            try
            {
                if (dgv.CurrentRow == null)
                {
                    txtValue.Text = string.Empty;
                    txtDefine.Text = string.Empty;
                    return;
                }

                txtValue.Text = dgv.CurrentRow.Cells[m_tableValue].Value.ToString();
                txtDefine.Text = (string)dgv.CurrentRow.Cells[m_tableDefine].Value;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }

		private void txtValue_TextChanged(object sender, EventArgs e)
		{
            try
            {
                if (dgv.CurrentRow == null)
                    return;

                if (int.TryParse(txtValue.Text, out int n))
			    {
                    if (n != (int)dgv.CurrentRow.Cells[m_tableValue].Value)
                        dgv.CurrentRow.Cells[m_tableValue].Value = n;
                }  
                else
			    {
                    txtValue.Text = dgv.CurrentRow.Cells[m_tableValue].Value.ToString();
                    throw new Exception(def.Error.WrongFormat);
                }    
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }

		private void txtDefine_TextChanged(object sender, EventArgs e)
		{
            try
            {
                if (dgv.CurrentRow == null)
                    return;

                if (txtDefine.Text != (string)dgv.CurrentRow.Cells[m_tableDefine].Value)
                    dgv.CurrentRow.Cells[m_tableDefine].Value = txtDefine.Text;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }

		private void btnAdd_Click(object sender, EventArgs e)
		{
            try
            {
                DataRow dr = m_dt.NewRow();
                int index = (int)dr[m_tableIndex];
                dr[m_tableValue] = index;
                dr[m_tableDefine] = string.Empty;
                m_dt.Rows.Add(dr);

                dgv.CurrentCell = dgv.Rows.Cast<DataGridViewRow>().Where(r => (int)r.Cells[m_tableIndex].Value == index).First()
                    .Cells[m_tableValue];

                Forms_Enabled();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                validateFinal();

                if (m_dt.GetChanges() == null)
                    return;

                m_dt.WriteXml(Path.Combine(Config.dir, m_filename), XmlWriteMode.WriteSchema);
                m_dt.AcceptChanges();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }

        private void validateFinal()
        {
            foreach (DataRow dr in m_dt.Rows)
                dr.EndEdit();
        }

        private void btnExit_Click(object sender, EventArgs e)
		{
            try
            {
                Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }
	}
}
