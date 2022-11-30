using System;
using System.Threading.Tasks;
using R5T.F0052;
using R5T.T0132;


namespace R5T.S0051
{
	[FunctionalityMarker]
	public partial interface IProjectScripts : IFunctionalityMarker
	{
        public async Task CreateWebApplicationProject()
        {
            /// Inputs.
            var projectName =
                ProjectNames.Instance.WebTest
                ;
            var projectDescription = "A first generated web application project.";


			/// Run.
			var projectPathsInformation = await ProjectOperator.Instance.InClearedProjectDirectoryPathInformationContext(
				DirectoryPaths.Instance.TemporaryProjectParent,
				projectName,
				async projectPathInformation =>
				{
					await F0084.ProjectOperations.Instance.CreateNewProject_Console(
						projectPathInformation.ProjectFilePath,
						projectDescription);
				});

			F0034.WindowsExplorerOperator.Instance.OpenDirectoryInExplorer(projectPathsInformation.ProjectDirectoryPath);
			F0033.NotepadPlusPlusOperator.Instance.Open(projectPathsInformation.ProjectFilePath);
		}

		public async Task Create_WebServerForBlazorClient()
		{
			/// Inputs.
			var projectName =
				ProjectNames.Instance.WebTest
				;
			var projectDescription = "A first generated web server for Blazor client project.";


			/// Run.
			var projectPathsInformation = await ProjectOperator.Instance.InClearedProjectDirectoryPathInformationContext(
				DirectoryPaths.Instance.TemporaryProjectParent,
				projectName,
				async projectPathInformation =>
				{
					await F0084.ProjectOperations.Instance.CreateNewProject_WebServerForBlazorClient(
						projectPathInformation.ProjectFilePath,
						projectDescription);
				});

			F0034.WindowsExplorerOperator.Instance.OpenDirectoryInExplorer(projectPathsInformation.ProjectDirectoryPath);
			F0033.NotepadPlusPlusOperator.Instance.Open(projectPathsInformation.ProjectFilePath);
		}

        public async Task Create_WebBlazorClient()
        {
            /// Inputs.
            var projectName =
                ProjectNames.Instance.WebTest
                ;
            var projectDescription = "A first generated web server for Blazor client project.";


            /// Run.
            var projectPathsInformation = await ProjectOperator.Instance.InClearedProjectDirectoryPathInformationContext(
                DirectoryPaths.Instance.TemporaryProjectParent,
                projectName,
                async projectPathInformation =>
                {
                    await F0084.ProjectOperations.Instance.CreateNewProject_WebBlazorClient(
                        projectPathInformation.ProjectFilePath,
                        projectDescription);
                });

            F0034.WindowsExplorerOperator.Instance.OpenDirectoryInExplorer(projectPathsInformation.ProjectDirectoryPath);
            F0033.NotepadPlusPlusOperator.Instance.Open(projectPathsInformation.ProjectFilePath);
        }

        public async Task CreateLibraryProject()
		{
			/// Inputs.
			var projectName =
				"R5T.L1000"
				;
			var projectDescription = "A first generated library project.";


			/// Run.
			var projectPathsInformation = await ProjectOperator.Instance.InClearedProjectDirectoryPathInformationContext(
				DirectoryPaths.Instance.TemporaryProjectParent,
				projectName,
				async projectPathInformation =>
				{
					await F0084.ProjectOperations.Instance.CreateNewProject_Library(
						projectPathInformation.ProjectFilePath,
						projectDescription);
				});

			F0034.WindowsExplorerOperator.Instance.OpenDirectoryInExplorer(projectPathsInformation.ProjectDirectoryPath);
			F0033.NotepadPlusPlusOperator.Instance.Open(projectPathsInformation.ProjectFilePath);
		}

		public async Task CreateConsoleProject()
		{
			/// Inputs.
			var projectName =
				"R5T.W1000"
				;
			var projectDescription = "A first generated web application project.";


            /// Run.
			var projectPathsInformation = await ProjectOperator.Instance.InClearedProjectDirectoryPathInformationContext(
				DirectoryPaths.Instance.TemporaryProjectParent,
				projectName,
				async projectPathInformation =>
				{
					await F0084.ProjectOperations.Instance.CreateNewProject_Console(
						projectPathInformation.ProjectFilePath,
				        projectDescription);
				});

			F0034.WindowsExplorerOperator.Instance.OpenDirectoryInExplorer(projectPathsInformation.ProjectDirectoryPath);
			F0033.NotepadPlusPlusOperator.Instance.Open(projectPathsInformation.ProjectFilePath);
		}

		public async Task CreateStronglyTypedTypeInProject()
        {
            /// Inputs.
            var stronglyTypedTypeTypeName = "TestDouble";
            var stronglyTypedTypeDescription = "A test double";
            Func<string, string, string, string, bool, Task> strongTypeGenerator =
                F0083.CodeFileGenerationOperations.Instance.CreateStronglyTypedDouble
                ;

            var projectName =
                ProjectNames.Instance.Temporary
                ;
            var projectDefaultNamespaceName = Instances.ProjectNamespacesOperator.GetDefaultNamespaceName_FromProjectName(projectName);


            /// Run.
            var stronglyTypedTypeCodeFilePath = await F0084.ProjectOperator.Instance.CreateStronglyTypedType(
                DirectoryPaths.Instance.TemporaryProjectParent,
                projectName,
                stronglyTypedTypeTypeName,
                stronglyTypedTypeDescription,
                strongTypeGenerator);

            F0033.NotepadPlusPlusOperator.Instance.Open(
                stronglyTypedTypeCodeFilePath);
        }

        public async Task CreateStronglyTypedGuidInProject()
        {
            /// Inputs.
            var stronglyTypedGuidTypeName = "TestIdentity";
            var stronglyTypedTypeDescription = "A test identity";

            var projectName =
                ProjectNames.Instance.Temporary
                ;
            var projectDefaultNamespaceName = Instances.ProjectNamespacesOperator.GetDefaultNamespaceName_FromProjectName(projectName);


            /// Run.
            string projectFilePath = default;
            string stronglyTypedGuidCodeFilePath = default;

            await F0084.ProjectOperator.Instance.InProjectPathInformationContext(
                DirectoryPaths.Instance.TemporaryProjectParent,
                projectName,
                async projectPathInformation =>
                {
                    // Create the code file.
                    stronglyTypedGuidCodeFilePath = F0052.ProjectPathsOperator.Instance.GetStrongTypeCodeFilePath(
                        projectPathInformation.ProjectFilePath,
                        stronglyTypedGuidTypeName);

                    await F0083.CodeFileGenerationOperations.Instance.CreateStronglyTypedGuid(
                        stronglyTypedGuidCodeFilePath,
                        projectDefaultNamespaceName,
                        stronglyTypedGuidTypeName,
                        stronglyTypedTypeDescription);

                    // Add the project references.
                    projectFilePath = projectPathInformation.ProjectFilePath;

                    F0020.ProjectFileOperator.Instance.AddProjectReferences_Idempotent_Synchronous(
                        projectPathInformation.ProjectFilePath,
                        Z0018.ProjectFilePaths.Instance.StronglyTypedTypeDependencies);
                });

            F0033.NotepadPlusPlusOperator.Instance.Open(
                projectFilePath,
                stronglyTypedGuidCodeFilePath);
        }

        public async Task CreateLibraryProject_Simple()
		{
			/// Inputs.
			var projectName =
				ProjectNames.Instance.Temporary
				;
			var projectDescription =
				ProjectDescriptions.Instance.Example
				;
			var projectDefaultNamespaceName = Instances.ProjectNamespacesOperator.GetDefaultNamespaceName_FromProjectName(projectName);


			/// Run.
			var projectPathsInformation = await ProjectOperator.Instance.InClearedProjectDirectoryPathInformationContext(
				DirectoryPaths.Instance.TemporaryProjectParent,
				projectName,
				async projectPathInformation =>
				{
                    await F0081.ProjectFileOperations.Instance.Create_OnlyProjectElement(projectPathInformation.ProjectFilePath);

                    F0051.ProjectOperator.Instance.SetupProject_Library(
                        projectPathInformation.ProjectFilePath,
						projectDescription,
						projectName,
						projectDefaultNamespaceName);
                });

            F0034.WindowsExplorerOperator.Instance.OpenDirectoryInExplorer(projectPathsInformation.ProjectDirectoryPath);
            F0033.NotepadPlusPlusOperator.Instance.Open(projectPathsInformation.ProjectFilePath);
        }

		/// <summary>
		/// Creates a project, with only the project file, with only the project element.
		/// </summary>
		public async Task Create_OnlyProjectElement()
		{
            /// Inputs.
            var projectName =
                ProjectNames.Instance.Temporary
                ;

            /// Run.
            await ProjectOperator.Instance.InClearedProjectDirectoryContext(
                DirectoryPaths.Instance.TemporaryProjectParent,
                projectName,
                async projectDirectoryPath =>
                {
					var projectFilePath = F0052.ProjectPathsOperator.Instance.GetProjectFilePath(
						projectDirectoryPath,
						projectName);

					await F0081.ProjectFileOperations.Instance.Create_OnlyProjectElement(projectFilePath);

                    F0034.WindowsExplorerOperator.Instance.OpenDirectoryInExplorer(projectDirectoryPath);
                    F0033.NotepadPlusPlusOperator.Instance.Open(projectFilePath);
                });
        }
	}
}