@echo off
dotnet build src/Skybrud.Social.TwentyThree --configuration Debug /t:rebuild /t:pack -p:PackageOutputPath=c:\nuget