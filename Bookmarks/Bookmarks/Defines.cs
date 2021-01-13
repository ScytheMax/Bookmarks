namespace ms.Bookmarks
{
	static class def
	{
		public static class FormName
		{
			public const string Origin = "Origin";
			public const string Genre = "Genre";
		}

		public static class Table
		{
			public const string BMS = "BMS";
			public const string d_BMT = "d_BMT";
			public const string d_ORG = "d_ORG";
			public const string d_GNR = "d_GNR";
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

			public const string BMS_ORG_Value = "BMS_ORG_Value";
			public const string BMS_GNR_Value = "BMS_GNR_Value";
			public const string BMS_Title = "BMS_Title";

			public const string d_BMT_Index = "d_BMT_Index";
			public const string BMT_Value = "BMT_Value";
			public const string BMT_Define = "BMT_Define";

			public const string d_ORG_Index = "d_ORG_Index";
			public const string ORG_Value = "ORG_Value";
			public const string ORG_Define = "ORG_Define";

			public const string d_GNR_Index = "d_GNR_Index";
			public const string GNR_Value = "GNR_Value";
			public const string GNR_Define = "GNR_Define";
		}

		public static class BookmarkType
		{
			public const int BMT_Value_General = 1;
			public const int BMT_Value_Song = 2;
			public const int BMT_Value_Album = 3;
			public const int BMT_Value_Movie = 4;

			public const string BMT_Define_General = "General";
			public const string BMT_Define_Song = "Song";
			public const string BMT_Define_Album = "Album";
			public const string BMT_Define_Movie = "Movie";
		}

		public static class colHeader
		{
			public const string Origin = "Origin";
			public const string Genre = "Genre";
			public const string Title = "Title";

			public const string Band = "Band";
			public const string Album = "Album";
			public const string Song = "Song";

			public const string Description = "Description";
			public const string URL = "URL";

			public const string Value = "Value";
			public const string Define = "Define";
		}

		public static class FilePath
		{
			public const string config = "../../../../config/Bookmarks.config";
		}

		public static class FileName
		{
			public const string xml_Bookmarks = "Bookmarks.xml";
			public const string xml_Origin = "Origin.xml";
			public const string xml_Genre = "Genre.xml";
		}


		public static class Config
		{
			public const string dir = "dir";
		}

		public static class Win
		{
			public const string Error = "Error";
		}

		public static class Error
		{
			public const string WrongFormat = "Wrong format!";
		}

		public static class XML
		{
			public const string KEY_DS = "ds";
		}
		
	}
}
