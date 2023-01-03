using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ms.Bookmarks
{
	partial class frmBookmarks
	{
		private int? m_bms_row_index_docu = null;

		private void dgvBMS_Sorted_Docu(object sender, EventArgs e)
		{
			if (m_bmt_value == def.BookmarkType.BMT_Value_Docu)
				set_ORG_Define_Value();
		}
	}
}
