namespace EyeSoft.Nuget.Publisher.Shell.Nuget
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class PackageWithFramework
	{
		public PackageWithFramework(string id, string version, IEnumerable<Package> frameworkPackages)
		{
			Id = id;
			Version = version;
			FrameworkPackages = frameworkPackages;
		}

		public string Id { get; }

		public string Version { get; }

		public IEnumerable<Package> FrameworkPackages { get; }

		public override string ToString()
		{
			return $"{Id} {Version}";
		}

		public IEnumerable<PackageUpdate> TryUpdateNuspecDependencies(
			IReadOnlyDictionary<string, Func<Version>> packagesVersion)
		{
			var nugetPackageReference = FrameworkPackages.Single(x => x.HasNuget);

			var updatedNuspecDependencies = nugetPackageReference.TryUpdateNuspecDependencies(packagesVersion);

			return updatedNuspecDependencies;
		}

		public void IncrementAssemblyInfo(BuildAndRevision buildAndRevision)
		{
			var newVersion = new Version(Version).Increment(buildAndRevision).ToString();

			foreach (var frameworkPackage in FrameworkPackages)
			{
				frameworkPackage.IncrementAssemblyInfo(newVersion);
			}
		}

		public bool IsLatestVersion(string previousVersion)
		{
			var isLatestVersion = new Version(previousVersion) == new Version(Version);

			return isLatestVersion;
		}
	}
}