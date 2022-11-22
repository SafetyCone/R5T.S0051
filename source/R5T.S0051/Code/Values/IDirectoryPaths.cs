using System;

using R5T.T0131;


namespace R5T.S0051
{
	[ValuesMarker]
	public partial interface IDirectoryPaths : IValuesMarker
	{
		public string TemporaryProjectParent => @"C:\Temp\Projects";
	}
}