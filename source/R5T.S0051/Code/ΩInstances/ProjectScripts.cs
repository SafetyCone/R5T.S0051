using System;


namespace R5T.S0051
{
	public class ProjectScripts : IProjectScripts
	{
		#region Infrastructure

	    public static IProjectScripts Instance { get; } = new ProjectScripts();

	    private ProjectScripts()
	    {
        }

	    #endregion
	}
}