using System;
using System.Xml;
using System.Windows.Forms;

namespace ms.Bookmarks
{
	static class Config
	{
		private static string _dir = String.Empty;
		public static string dir
		{
            private set { _dir = value; }
			get { return _dir; }
		}

		public static void LoadConfig()
		{
			try
			{
				using (XmlReader xmlr = XmlReader.Create(def.FilePath.config))
				{
					while (xmlr.Read())
					{
						if (xmlr.NodeType == XmlNodeType.Element && xmlr.Name == def.Config.dir)
						{
							xmlr.Read();
							dir = xmlr.Value;
						}
					}
				}
			}
			catch(Exception ex) { MessageBox.Show(ex.Message, def.Win.Error); }
        }
	}
}
