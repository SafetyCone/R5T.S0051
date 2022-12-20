using System;

using R5T.T0131;


namespace R5T.S0051
{
	[DraftValuesMarker]
	public partial interface IExampleProjectFilePaths : IDraftValuesMarker
	{
		public string Example => @"C:\Temp\Projects\ExampleProject\ExampleProject.csproj";
    }
}