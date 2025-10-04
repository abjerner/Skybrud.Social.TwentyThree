@echo off
dotnet build src/Skybrud.Social.TwentyThree --configuration Release /t:rebuild /t:pack -p:PackageOutputPath=../../releases/nuget