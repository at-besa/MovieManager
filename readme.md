This is an old project of myself which aims to rename folders of movies into a readable format.
The point is to index these folders with KODI (https://github.com/xbmc/xbmc) and read the informations about the video files and the movie title from its database and bring it to a readable folder name.

It reads the database of KODI with an generated EF Core Model and extracts information out of it.

As of now i would definetly do a lot of stuff in a different way:
* usage of .NET 6 and some of its new patterns, especially its new Program pattern
* use the ProblemDetails Middleware Nuget
* use of ConnectionStringBuilder for ConnectionStrings
* make paths and other sensible data configurable instead of hard coded
* better handling of models and Dtos
* Automapper or other CodeGens
* Upgrade EF Core
