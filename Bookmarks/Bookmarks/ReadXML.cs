using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace ms.Bookmarks
{
	static class ReadXML
	{
		static public void LoadDataTable(string filename, DataTable dt)
		{
            try
            {
                if (!Directory.Exists(Config.dir))
                    Directory.CreateDirectory(Config.dir);

                string filePath = Path.Combine(Config.dir, filename);
                if (!File.Exists(filePath))
                {
                    using (var fs = File.Create(filePath))
                    {
                        dt.WriteXml(fs);
                    }
                }

                DataTable dt_tmp = new DataTable();
                dt_tmp.ReadXml(filePath);
                dt.Merge(dt_tmp);
                dt.AcceptChanges();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }
	}
}
