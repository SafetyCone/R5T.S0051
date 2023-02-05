using System;
using System.Threading.Tasks;


namespace R5T.S0051
{
    class Program
    {
        static async Task Main()
        {
            //await ProjectScripts.Instance.New_OnlyProjectElement();
            //await ProjectScripts.Instance.New_Library_Simple();

            //await ProjectScripts.Instance.New_Console();
            //await ProjectScripts.Instance.New_DeployScripts();
            //await ProjectScripts.Instance.New_Library();
            //await ProjectScripts.Instance.New_WebServerForBlazorClient();
            //await ProjectScripts.Instance.New_WebBlazorClient();
            await ProjectScripts.Instance.New_RazorClassLibrary();

            //await ProjectScripts.Instance.CreateClassInProject();
            //await ProjectScripts.Instance.CreateInstancesInProject();
            //await ProjectScripts.Instance.CreateRazorComponentInProject();
            //await ProjectScripts.Instance.CreateStronglyTypedGuidInProject();
            //await ProjectScripts.Instance.CreateStronglyTypedTypeInProject();
            //await ProjectScripts.Instance.CreateWinFormInProject();
        }
    }
}