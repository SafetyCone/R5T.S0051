using System;
using System.Threading.Tasks;

using R5T.F0084.T001;
using R5T.T0132;


namespace R5T.S0051
{
	[FunctionalityMarker]
	public partial interface IProjectOperator : IFunctionalityMarker
	{
		public async Task InClearedProjectDirectoryContext(
			string parentDirectoryPath,
			string projectName,
			Func<string, Task> projectDirectoryPathAction)
		{
			var projectDirectoryName = F0052.ProjectDirectoryNameOperator.Instance.GetProjectDirectoryName_FromProjectName(projectName);

			var projectDirectoryPath = F0002.PathOperator.Instance.GetDirectoryPath(
				parentDirectoryPath,
				projectDirectoryName);

			await F0000.FileSystemOperator.Instance.InClearedDirectoryContext(
				projectDirectoryPath,
                projectDirectoryPathAction);
		}

        public async Task<ProjectPathInformation> InClearedProjectDirectoryPathInformationContext(
            string parentDirectoryPath,
            string projectName,
            Func<ProjectPathInformation, Task> projectDirectoryPathAction)
        {
            var projectDirectoryName = F0052.ProjectDirectoryNameOperator.Instance.GetProjectDirectoryName_FromProjectName(projectName);

            var projectDirectoryPath = F0002.PathOperator.Instance.GetDirectoryPath(
                parentDirectoryPath,
                projectDirectoryName);

            ProjectPathInformation projectPathInformation = default;

            async Task Internal(string projectDirectoryPath)
            {
                var projectFilePath = F0052.ProjectPathsOperator.Instance.GetProjectFilePath(
                    projectDirectoryPath,
                    projectName);

                projectPathInformation = new ProjectPathInformation
                {
                    ProjectDirectoryPath = projectDirectoryPath,
                    ProjectFilePath = projectFilePath,
                };

                await projectDirectoryPathAction(projectPathInformation);
            }

            await F0000.FileSystemOperator.Instance.InClearedDirectoryContext(
                projectDirectoryPath,
                Internal);

            return projectPathInformation;
        }
    }
}