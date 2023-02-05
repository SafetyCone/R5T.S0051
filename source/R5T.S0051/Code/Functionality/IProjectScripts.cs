using System;
using System.Linq;
using System.Threading.Tasks;

using R5T.F0000;
using R5T.F0083;
using R5T.F0084;
using R5T.F0089;
using R5T.L0026;
using R5T.T0132;


namespace R5T.S0051
{
	[FunctionalityMarker]
	public partial interface IProjectScripts : IFunctionalityMarker
	{
        public async Task CreateWinFormInProject()
        {
            /// Inputs.
            bool clearFilesDuringConstruction = true;
            var winFormName =
                "ExampleWinForm"
                ;
            var projectFilePath =
                ExampleProjectFilePaths.Instance.Example
                ;


            /// Run
            var winFormContext = WinFormContextOperations.Instance.GetWinFormContext(
                projectFilePath,
                winFormName);

            if (clearFilesDuringConstruction)
            {
                FileSystemOperator.Instance.DeleteFile_OkIfNotExists(winFormContext.CodeFilePath);
                FileSystemOperator.Instance.DeleteFile_OkIfNotExists(winFormContext.DesignerFilePath);
            }

            await ProjectOperations.Instance.CreateWinFormInProject(winFormContext);

            // Show outputps.
            F0033.NotepadPlusPlusOperator.Instance.Open(
                winFormContext.CodeFilePath,
                winFormContext.DesignerFilePath,
                winFormContext.ResxFilePath);
        }

        public async Task CreateInstancesInProject()
        {
            /// Inputs.
            var clearFilesDuringConstruction = true;
            var projectFilePath =
                ExampleProjectFilePaths.Instance.Example
                ;
            var instanceType =
                InstanceTypes.Instance.Functionality
                ;
            var instanceTypeNameStems = new[]
            {
                "ExampleInstance"
            };


            /// Run.
            var instanceTypeContexts = instanceTypeNameStems
                .Select(instanceTypeNameStem => InstanceTypeContextOperations.Instance.GetInstanceTypeContext(
                    projectFilePath,
                    instanceTypeNameStem,
                    instanceType))
                .Now();

            // Clear any overwrite-safety-checked files, if we are in construction.
            if(clearFilesDuringConstruction)
            {
                var filePathsToClear = instanceTypeContexts
                    .Select(context => context.InterfaceCodeFilePath)
                    .Now();

                filePathsToClear.ForEach(filePath => FileSystemOperator.Instance.DeleteFile_OkIfNotExists(
                    filePath));
            }

            foreach (var context in instanceTypeContexts)
            {
                await ProjectOperations.Instance.CreateInstanceInProject(
                    context);
            }
            
            // Show output.
            var filePathsToOpen = instanceTypeContexts
                .SelectMany(context => new[]
                {
                    context.InterfaceCodeFilePath,
                    context.ClassCodeFilePath,
                })
                ;

            F0033.NotepadPlusPlusOperator.Instance.Open(
                filePathsToOpen);
        }

        public async Task CreateRazorComponentInProject()
        {
            /// Inputs.
            var clearForConstruction = true;
            var componentName =
                ExampleRazorComponentNames.Instance.ExampleComponent
                ;
            var projectFilePath =
                ExampleProjectFilePaths.Instance.Example
                ;


            /// Run.
            var razorComponentContext = F0089.CodeFileContextOperations.Instance.GetRazorComponentContext(
                projectFilePath,
                componentName);

            if(clearForConstruction)
            {
                FileSystemOperator.Instance.DeleteFile_OkIfNotExists(
                    razorComponentContext.RazorFilePath);

                FileSystemOperator.Instance.DeleteFile_OkIfNotExists(
                    razorComponentContext.CodeBehindFilePath);
            }

            await CodeFileGenerationOperations.Instance.CreateRazorComponentMarkupFile(
                razorComponentContext.RazorFilePath,
                razorComponentContext.NamespaceName);

            await CodeFileGenerationOperations.Instance.CreateRazorComponentCodeBehindFile(
                razorComponentContext.CodeBehindFilePath,
                razorComponentContext.NamespaceName,
                razorComponentContext.Name);

            // Show outputs.
            F0033.NotepadPlusPlusOperator.Instance.Open(
                razorComponentContext.RazorFilePath,
                razorComponentContext.CodeBehindFilePath);
        }

        public async Task CreateClassInProject()
        {
            /// Inputs.
            var clearForConstruction = true;
            var className =
                ExampleClassNames.Instance.ExampleClass
                ;
            var projectFilePath =
                ExampleProjectFilePaths.Instance.Example
                ;


            /// Run.
            var classContext = CodeFileContextOperations.Instance.GetClassTypeContext(
                projectFilePath,
                className);

            if(clearForConstruction)
            {
                FileSystemOperator.Instance.DeleteFile_OkIfNotExists(
                    classContext.CodeFilePath);
            }

            await ProjectOperations.Instance.CreateClassInProject(
                classContext);

            F0033.NotepadPlusPlusOperator.Instance.Open(
                classContext.CodeFilePath);
        }

        public async Task New_RazorClassLibrary()
        {
            /// Inputs.
            var deleteSolutionDirectoryForConstruction = false;
            var projectName =
                //ProjectNames.Instance.Example_RazorClassLibrary
                "D8S.W0003.R000"
                ;
            var projectDescription =
                //"A first generated Razor class library project."
                "Razor class library for the D8S.W0003 project."
                ;
            var solutionDirectoryPath =
                //DirectoryPaths.Instance.TemporaryProjectParent
                @"C:\Code\DEV\Git\GitHub\davidcoats\D8S.W0003.Private\source\"
                ;


            /// Run.
            var projectContext = Instances.ProjectContextOperations.GetProjectContext(
                projectName,
                projectDescription,
                solutionDirectoryPath);

            if(deleteSolutionDirectoryForConstruction)
            {
                await Instances.FileSystemOperator.ClearDirectory(projectContext.ProjectDirectoryPath);
            }

            await Instances.ProjectOperations.NewProject_RazorClassLibrary(
                projectContext.ProjectFilePath,
                projectContext.ProjectDescription);

            Instances.WindowsExplorerOperator.OpenDirectoryInExplorer(projectContext.ProjectDirectoryPath);
            Instances.NotepadPlusPlusOperator.Open(projectContext.ProjectFilePath);
        }

        public async Task New_WebApplicationProject()
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
					await F0084.ProjectOperations.Instance.NewProject_Console(
						projectPathInformation.ProjectFilePath,
						projectDescription);
				});

			F0034.WindowsExplorerOperator.Instance.OpenDirectoryInExplorer(projectPathsInformation.ProjectDirectoryPath);
			F0033.NotepadPlusPlusOperator.Instance.Open(projectPathsInformation.ProjectFilePath);
		}

		public async Task New_WebServerForBlazorClient()
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
					await F0084.ProjectOperations.Instance.NewProject_WebServerForBlazorClient(
						projectPathInformation.ProjectFilePath,
						projectDescription);
				});

			F0034.WindowsExplorerOperator.Instance.OpenDirectoryInExplorer(projectPathsInformation.ProjectDirectoryPath);
			F0033.NotepadPlusPlusOperator.Instance.Open(projectPathsInformation.ProjectFilePath);
		}

        public async Task New_WebBlazorClient()
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
                    await F0084.ProjectOperations.Instance.NewProject_WebBlazorClient(
                        projectPathInformation.ProjectFilePath,
                        projectDescription);
                });

            F0034.WindowsExplorerOperator.Instance.OpenDirectoryInExplorer(projectPathsInformation.ProjectDirectoryPath);
            F0033.NotepadPlusPlusOperator.Instance.Open(projectPathsInformation.ProjectFilePath);
        }

        public async Task New_Library()
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
					await F0084.ProjectOperations.Instance.NewProject_Library(
						projectPathInformation.ProjectFilePath,
						projectDescription);
				});

			F0034.WindowsExplorerOperator.Instance.OpenDirectoryInExplorer(projectPathsInformation.ProjectDirectoryPath);
			F0033.NotepadPlusPlusOperator.Instance.Open(projectPathsInformation.ProjectFilePath);
		}

		public async Task New_Console()
		{
			/// Inputs.
			var projectName =
				"R5T.W1000"
				;
			var projectDescription = "A first generated web application project.";
            var projectParentDirectoryPath = DirectoryPaths.Instance.TemporaryProjectParent;


            /// Run.
			var projectPathsInformation = await ProjectOperator.Instance.InClearedProjectDirectoryPathInformationContext(
				projectParentDirectoryPath,
				projectName,
				async projectPathInformation =>
				{
					await F0084.ProjectOperations.Instance.NewProject_Console(
						projectPathInformation.ProjectFilePath,
				        projectDescription);
				});

			F0034.WindowsExplorerOperator.Instance.OpenDirectoryInExplorer(projectPathsInformation.ProjectDirectoryPath);
			F0033.NotepadPlusPlusOperator.Instance.Open(projectPathsInformation.ProjectFilePath);
		}

        public async Task New_DeployScripts()
        {
            /// Inputs.
            var projectName =
                "R5T.W1000.Deploy"
                ;
            var targetProjectName = "R5T.W1000";
            var projectDescription = "A first generated deploy scripts application project.";
            var projectParentDirectoryPath = DirectoryPaths.Instance.TemporaryProjectParent;


            /// Run.
			var projectPathsInformation = await ProjectOperator.Instance.InClearedProjectDirectoryPathInformationContext(
                projectParentDirectoryPath,
                projectName,
                async projectPathInformation =>
                {
                    await ProjectOperations.Instance.NewProject_DeployScripts(
                        projectPathInformation.ProjectFilePath,
                        projectDescription,
                        targetProjectName);
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

        public async Task New_Library_Simple()
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
                    await F0081.ProjectFileOperations.Instance.NewProjectFile_OnlyProjectElement(projectPathInformation.ProjectFilePath);

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
		public async Task New_OnlyProjectElement()
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

					await F0081.ProjectFileOperations.Instance.NewProjectFile_OnlyProjectElement(projectFilePath);

                    F0034.WindowsExplorerOperator.Instance.OpenDirectoryInExplorer(projectDirectoryPath);
                    F0033.NotepadPlusPlusOperator.Instance.Open(projectFilePath);
                });
        }
	}
}