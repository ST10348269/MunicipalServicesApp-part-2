Municipal Services Application – Part 2
Local Events and Announcements Module

Project Overview
This is the second part of the Municipal Services Application developed for a South African municipality. 
In Part 1 the focus was on reporting issues. In Part 2 the application was extended to include a Local 
Events and Announcements section. Citizens can now view upcoming events, search by category or date, 
and receive simple recommendations based on their searches.

The application was built using C# and Windows Forms (.NET Framework).

System Requirements
- Windows operating system
- Visual Studio 2019 or 2022
- .NET Framework 4.7.2 or later
- .NET desktop development workload installed

How to Open and Run the Application
1. Open Visual Studio.
2. Click “Open a project or solution”.
3. Navigate to the project folder and select the solution file (MunicipalServicesApp.sln).
4. Once the project has loaded, press F5 or click the green Start button to run the application.

How to Use the Application

1. Welcome Screen
   - The application starts on the Welcome screen.
   - Click “Get Started” to continue to the Main Menu.

2. Main Menu
   - Report Issues – opens the reporting form created in Part 1.
   - Local Events and Announcements – opens the new events form.
   - Service Request Status – currently disabled (planned for a later part).

3. Local Events and Announcements
   - When the form opens, a list of upcoming events is displayed automatically.
   - Use the Category dropdown to filter events by type (Community, Utilities, Roads, etc.).
   - Use the Date picker to show events from a selected date onwards.
   - Click the Search button to apply the filters.
   - Recommended events will appear in the “Recommended for You” section based on recent searches.
   - Click “Show All Events” to clear the filters and view the full list again.
   - Click “Back to Main Menu” to return to the main menu.

Data Structures Used
- SortedDictionary – stores events ordered by date
- Dictionary – allows fast searching by category
- HashSet – keeps a list of unique categories
- Queue – tracks recent user searches for the recommendation feature

Notes
- Sample events have been included so the form is not empty when first opened.
- The recommendation feature becomes active after the user performs at least one category search.
- This module builds on the work completed in Part 1 and will be extended further in the final Portfolio of Evidence.


Advanced Development – Part 2
