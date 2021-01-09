using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ms.Bookmarks
{
	static class def
	{
		public static class Table
		{
			public const string BMS = "BMS";
			public const string d_BMT = "BMT";
		}

		public static class Field
		{
			public const string BMS_Index = "BMS_Index";
			public const string BMS_BMT_Value = "BMS_BMT_Value";
			public const string BMS_URL = "BMS_URL";
			public const string BMS_Description = "BMS_Description";

			public const string BMS_Band = "BMS_Band";
			public const string BMS_Album = "BMS_Album";
			public const string BMS_Song = "BMS_Song";

			public const string d_BMT_Index = "d_BMT_Index";
			public const string BMT_Value = "BMT_Value";
			public const string BMT_Define = "BMT_Define";
		}

		public static class BookmarkType
		{
			public const int BMT_Value_General = 1;
			public const int BMT_Value_Song = 2;
			public const int BMT_Value_Album = 3;

			public const string BMT_Define_General = "General";
			public const string BMT_Define_Song = "Song";
			public const string BMT_Define_Album = "Album";
		}

		public static class colHeader
		{
			public const string Band = "Band";
			public const string Album = "Album";
			public const string Song = "Song";

			public const string Description = "Description";
			public const string URL = "URL";
		}

		public static class FilePath
		{
			public const string config = "../../../../config/Bookmarks.config";
		}

		public static class FileName
		{
			public const string xml_Bookmarks = "Bookmarks.xml";
		}


		public static class Config
		{
			public const string dir = "dir";
		}

		public static class Win
		{
			public const string Error = "Error";
		}

		public static class XML
		{
			public const string KEY_DS = "ds";
			public const string header = "<?xml version=\"1.0\" standalone=\"yes\"?>";
		}
		
	}
}
