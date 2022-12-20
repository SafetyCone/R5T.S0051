using System;


namespace R5T.S0051
{
	public class ExampleRazorComponentNames : IExampleRazorComponentNames
	{
		#region Infrastructure

	    public static IExampleRazorComponentNames Instance { get; } = new ExampleRazorComponentNames();

	    private ExampleRazorComponentNames()
	    {
        }

	    #endregion
	}
}