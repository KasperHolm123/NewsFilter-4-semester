# NewsFilter-4-semester
A .NET Maui news app. This application uses the relatively new .NET based Maui framework to create multi-platform application that runs on both windows, and android.
# Why was it built?
This application was part of a .NET Maui course taught as part of the Datamatiker education in Denmark (March 2023). It is built with the MVVM design pattern, which makes decreases coupling between parts of the system, and creates a low-coupled application, making it easier to maintain and test.
# Preview & Features (Emulated on Visual Studio 2022's built-in android emulator, android 13 API 33)
### Front page (feed)
![image](https://user-images.githubusercontent.com/95678763/232396576-01fd6a7f-2af6-48b3-b6cc-70a88305d2ed.png)

This is the applications main functionality. A news feed that displays a total of 20 articles (DR's RSS feed only returns 20 articles).
### Filter page
![image](https://user-images.githubusercontent.com/95678763/232397669-95923a82-5dce-4502-adc7-4bd448257694.png)

This page is used to customize the filter.
### Settings page
![image](https://user-images.githubusercontent.com/95678763/232397822-5018bf36-a06d-480f-820e-1f9edcb5a293.png)

Using .NET Maui's built-in coloring system, we can create a light/dark theme. The app will also choose which theme to pick depending on the system theme on the device that it's run on.
