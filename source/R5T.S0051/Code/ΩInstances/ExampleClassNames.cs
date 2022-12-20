using System;


namespace R5T.S0051
{
	public class ExampleClassNames : IExampleClassNames
	{
		#region Infrastructure

	    public static IExampleClassNames Instance { get; } = new ExampleClassNames();

	    private ExampleClassNames()
	    {
        }

	    #endregion
	}
}