**Description**

A c# win form application to save urls for the following topics:

General / Songs / Albums / Movies / Series / Docu

\
![grafik](https://user-images.githubusercontent.com/47299122/210374289-39df5453-2b60-4b77-b737-fd19c74aa11b.png)

\
**Release Build**

You just need a free version of visual studio with the addon ".NET Desktop Development".

-> Open the solution Bookmarks in Visual Studio.

The following libraries are used:

	- System
	- System.Xml
	- System.Windows.Forms
	- System.Collections.Generic
	- System.Linq
	- System.Data
	- System.IO
	- System.Diagnostics

-> The libraries are included in the base libraries of C# or can easily added via
	right click on References and click "Add references".

-> Choose the Configuration "Release" and Platform "Any CPU".

-> Build the solution.

\
**Config**

Go into the file config/Bookmarks.config. Here you can set the save directory.

Default dir is C:\development\data.

\
**Start application first time**

You can start the app easily via Visual Studio or copy for example a reference to the Bookmarks.exe to your desktop.

(Automatically the files Bookmarks.xml and Origin.xml are created in the save dir)


-> Choose in the combobox "Movie" and click the "..." button on the right of "Origin".

-> Add a first origin, for example Value 1 and Define "Netflix" and click "Save". Exit the window.

You are now ready to use the app.

\
**Functionalities**

- Combobox on the top left: Choose the type of bookmark.
- Filter: Search for a string in all bookmarks of one type. It searches in every text column for the string.
- Add/Delete button: Add or delete a row.
- Right area: Set the details: URL, Create Date and so on.
- Save button: Save new rows or update rows. (you can see, that there are changes to save by the '*' symbol in the app title)
- Double Click on a row: Opens the URL in your standard browser.

\
**License**

GNU GENERAL PUBLIC LICENSE
