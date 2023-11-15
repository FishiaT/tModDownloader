# tModDownloader
A mod browser/downloader for tModLoader and a dump of inefficient, unoptimized, slow and spagetti code.

tModDownloader is a standalone Steam Workshop mod browser/downloader written in C#. It works by parsing Steam Workshop HTML data and use `steamcmd` to download mods behind the scene.

## Compiling
To compile tModDownloader, you need .NET 6.0 SDK installed. After that just open `tModDownloader.sln` in Visual Studio and build the project. You need to put `steamcmd.exe` into a folder named `steamcmd` in the same directory as `tModDownloader.exe` to be able to download mods.

*Note: tModDownloader is Windows-only at the moment.