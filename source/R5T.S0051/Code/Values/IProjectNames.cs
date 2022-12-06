using System;

using R5T.T0131;


namespace R5T.S0051
{
	[ValuesMarker]
	public partial interface IProjectNames : IValuesMarker
	{
		public string Temporary => "Temporary";
        public string Example_RazorClassLibrary => "R5T.R9999";
        public string WebTest => "R5T.W1000";
	}
}