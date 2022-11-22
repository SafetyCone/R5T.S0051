using System;


namespace R5T.S0051
{
	public class ProjectDescriptions : IProjectDescriptions
	{
		#region Infrastructure

	    public static IProjectDescriptions Instance { get; } = new ProjectDescriptions();

	    private ProjectDescriptions()
	    {
        }

	    #endregion
	}
}