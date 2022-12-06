using System;


namespace R5T.S0051
{
    public static class Instances
    {
        public static F0089.IProjectContextOperations ProjectContextOperations { get; } = F0089.ProjectContextOperations.Instance;
        public static F0040.F000.IProjectNamespacesOperator ProjectNamespacesOperator { get; } = F0040.F000.ProjectNamespacesOperator.Instance;
    }
}