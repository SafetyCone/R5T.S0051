using System;
using System.Threading.Tasks;


namespace R5T.S0051
{
    class Program
    {
        static async Task Main()
        {
            //await ProjectScripts.Instance.Create_OnlyProjectElement();
            //await ProjectScripts.Instance.CreateLibraryProject_Simple();
            //await ProjectScripts.Instance.CreateStronglyTypedGuidInProject();
            //await ProjectScripts.Instance.CreateStronglyTypedTypeInProject();

            //await ProjectScripts.Instance.CreateConsoleProject();
            //await ProjectScripts.Instance.CreateLibraryProject();
            //await ProjectScripts.Instance.Create_WebServerForBlazorClient();
            await ProjectScripts.Instance.Create_WebBlazorClient();
        }
    }
}