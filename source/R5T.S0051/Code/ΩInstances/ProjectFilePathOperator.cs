using System;


namespace R5T.S0051
{
	public class ProjectFilePathOperator : IProjectFilePathOperator
	{
		#region Infrastructure

	    public static IProjectFilePathOperator Instance { get; } = new ProjectFilePathOperator();

	    private ProjectFilePathOperator()
	    {
        }

	    #endregion
	}
}