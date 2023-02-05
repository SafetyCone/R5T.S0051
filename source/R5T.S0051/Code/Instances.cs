using System;


namespace R5T.S0051
{
    public static class Instances
    {
        public static F0000.IFileSystemOperator FileSystemOperator => F0000.FileSystemOperator.Instance;
        public static F0033.INotepadPlusPlusOperator NotepadPlusPlusOperator => F0033.NotepadPlusPlusOperator.Instance;
        public static F0089.IProjectContextOperations ProjectContextOperations => F0089.ProjectContextOperations.Instance;
        public static F0040.F000.IProjectNamespacesOperator ProjectNamespacesOperator => F0040.F000.ProjectNamespacesOperator.Instance;
        public static F0084.IProjectOperations ProjectOperations => F0084.ProjectOperations.Instance;
        public static F0034.IWindowsExplorerOperator WindowsExplorerOperator => F0034.WindowsExplorerOperator.Instance;
    }
}