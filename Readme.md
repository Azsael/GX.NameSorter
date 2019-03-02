# GX.NameSorter
[![Build Status](https://travis-ci.com/Azsael/GX.NameSorter.svg?branch=master)](https://travis-ci.com/Azsael/GX.NameSorter)

Implemented as per spec.pdf


## To Run Console App

dotnet restore
dotnet build
dotnet run --project GX.NameSorter.Runner ./GX.NameSorter.Runner/unsorted-names-list.txt

Or run it from cmd line from bin directory :)

## To Test

dotnet restore
dotnet build
dotnet test

## Assumptions

- Person may have 1-3 given names but last name is not mandatory.
- If between 2-4 are on a given line, we assume last one will be the name. 
- If more than 4 names in a line, assume other names are part of a multi last name.
- Ordering is done by Ordinial Ignore Case string compare. 
- No Logging / No Error handling around file IO expected.
