using System;


namespace R5T.S0051
{
	public class ProjectNames : IProjectNames
	{
		#region Infrastructure

	    public static IProjectNames Instance { get; } = new ProjectNames();

	    private ProjectNames()
	    {
        }

	    #endregion
	}
}