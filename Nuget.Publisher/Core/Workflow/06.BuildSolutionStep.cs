namespace EyeSoft.Nuget.Publisher.Shell.Workflow
{

	using EyeSoft.Nuget.Publisher.Shell.Build;
	using EyeSoft.Nuget.Publisher.Shell.Core;
	using EyeSoft.Nuget.Publisher.Shell.Nuget;

	public class BuildSolutionStep : FluentWorkflowStep
	{
		private readonly SolutionSystemInfo solutionSystemInfo;

		private readonly NugetPackageResultCollection nugetPackageResultCollection;

		private readonly BuildAndRevision buildAndRevision;

		public BuildSolutionStep(
			BuildAndRevision buildAndRevision,
			SolutionSystemInfo solutionSystemInfo,
			NugetPackageResultCollection nugetPackageResultCollection)
		{
			this.buildAndRevision = buildAndRevision;

			this.solutionSystemInfo = solutionSystemInfo;

			this.nugetPackageResultCollection = nugetPackageResultCollection;
		}

		public CompileNugetPackagesStep BuildSolution(bool logEnabled)
		{
			////new MsBuild(solutionSystemInfo.FilePath, new FileInfo(solutionSystemInfo.FilePath).Directory.FullName, logEnabled).Build();

			return new CompileNugetPackagesStep(buildAndRevision, solutionSystemInfo, nugetPackageResultCollection);
		}
	}
}