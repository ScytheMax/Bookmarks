using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ms.Bookmarks
{
	public partial class frmBookmarks : Form
	{
		public frmBookmarks()
		{
			InitializeComponent();
		}

        public void init()
        {
            prepare_dgvBMS();
        }

        private void prepare_dgvBMS()
        {
            dgvBMS.AllowUserToAddRows = false;
            dgvBMS.AllowUserToDeleteRows = false;
            dgvBMS.AllowUserToOrderColumns = false;
            dgvBMS.AllowUserToResizeRows = false;
            dgvBMS.ReadOnly = true;
            dgvBMS.MultiSelect = false;
            dgvBMS.RowHeadersVisible = false;

          
            dgvBMS.Columns.Add( new DataGridViewTextBoxColumn() {
                DataPropertyName = Name = def.Field.BMS_Description,
                HeaderText = def.colHeader.Description,
                Width = 100,
                ReadOnly = true } );
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
    }
}
