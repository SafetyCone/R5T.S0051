using System;

using R5T.T0131;


namespace R5T.S0051
{
	[DraftValuesMarker]
	public partial interface IExampleClassNames : IDraftValuesMarker
	{
        public string ExampleClass => "ExampleClass";
    }
}