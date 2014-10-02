
namespace CompanyHierarchy.Hierarchy
{
    using System.Collections.Generic;

    public interface IDeveloper : IRegularEmployee
    {
        List<Project> ProjectsList { get; set; }
    }
}
