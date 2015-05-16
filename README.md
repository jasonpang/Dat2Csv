# Dat2Csv
Hello Striiv!

If you'd like to clone and compile the project, it was created in the following environment:

- Microsoft Visual Studio 2013
- 3rd-party Libraries: NUnit (for a testing framework)
- Languages: Only C#

Feel free to browse the commit history as well.

## Project Files Explanation

- `Dataset.cs` is a simple object to represent each of input.dat's data sets
- `DatasetReader.cs` extends from `BinaryReader` and provides methods to read a set in one call
- `Extensions\IntegerBitExtensions.cs` contains the bitwise operations code that powers most of the app
- `Program.cs` glues the rest of the app together, does sequence number checking, reads from input.dat and writes to input.csv

The `Dat2Csv.Tests` classes contain tests for their respective class. `IntegerBitExtensionTests.cs` is the only major test class, and tests the bitwise operation functions. `DatasetReaderTests.cs` ensures the beginning of my output matches the beginning of the sample output.

## Running the Code

Without compiling, you can run the code on an x86 / x86-64 (little-endian) Windows machine.

1. Navigate to `Dat2Csv\bin\Debug`.
2. Call `Dat2Csv.exe input.dat`.

The output CSV file should be created in the same directory as `input.csv`.
