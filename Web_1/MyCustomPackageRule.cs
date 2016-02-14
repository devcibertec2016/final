using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NuGetPackageExplorer.Types;
using System.ComponentModel.Composition;
using NuGet;

namespace Web_1 
{
    [Export(typeof(IPackageRule))]
    internal class MyCustomPackageRule : IPackageRule 
    {
        public IEnumerable<PackageIssue> Validate(IPackage package, string packageFileName) 
        {
            throw new NotImplementedException();
        }
    }
}