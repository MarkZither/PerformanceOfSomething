using Nuke.Common;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.SonarScanner;
using static System.IO.Path;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Common.Tools.SonarScanner.SonarScannerTasks;
using Nuke.Common.Tools.GitVersion;
using System.Diagnostics;

// originally based on https://github.com/VijayakumarKupusamy/hc12.0.9/blob/87f0be40bb0a60d0ba50901ce8875bfd255608f5/hotchocolate-12.9.0/.build/Build.Sonar.cs
public partial class Build
{
    [Parameter] readonly string SonarToken;
    [Parameter] readonly string SonarServer = "https://sonarcloud.io";

    Target SonarPr => _ => _
        //.Requires(() => GitHubRepository != null)
        //.Requires(() => GitHubHeadRef != null)
        //.Requires(() => GitHubBaseRef != null)
        //.Requires(() => GitHubPRNumber != null)
        .Requires(() =>  !string.IsNullOrEmpty(SonarToken))
        .Executes(() =>
        {
            //Serilog.Log.Information<Build>($"GitHubRepository: {GitHubRepository}");
            //Serilog.Log.Information<Build>($"GitHubHeadRef: {GitHubHeadRef}");
            //Serilog.Log.Information<Build>($"GitHubBaseRef: {GitHubBaseRef}");
            //Serilog.Log.Information<Build>($"GitHubPRNumber: {GitHubPRNumber}");

            //TryDelete(SonarSolutionFile);
            //DotNetBuildSonarSolution(AllSolutionFile);
            //DotNetBuildSonarSolution(SonarSolutionFile, include: IsRelevantForSonar);

            DotNetRestore(c => c
                .SetProjectFile(Solution)
                .SetProcessWorkingDirectory(RootDirectory));

            SonarScannerBegin(SonarBeginPrSettings);
            DotNetBuild(SonarBuildAll);
            try
            {
                //DotNetTest(
                //    c => CoverNoBuildSettingsOnlyNet60(c, CoverProjects),
                //    degreeOfParallelism: DegreeOfParallelism,
                //    completeOnFailure: true);
            }
            catch { }
            SonarScannerEnd(SonarEndSettings);
        });

    Target Sonar => _ => _
        .Executes(() =>
        {
            //TryDelete(SonarSolutionFile);
            //DotNetBuildSonarSolution(Solution);
            //DotNetBuildSonarSolution(SonarSolutionFile, include: IsRelevantForSonar);

            DotNetRestore(c => c
                .SetProjectFile(Solution)
                .SetProcessWorkingDirectory(RootDirectory));

            //Logger.Info("Creating Sonar analysis for version: {0} ...", GitVersion.SemVer);

            SonarScannerBegin(SonarBeginFullSettings);
            DotNetBuild(SonarBuildAll);
            try
            {
                //DotNetTest(
                //    c => CoverNoBuildSettingsOnlyNet60(c, CoverProjects),
                //    degreeOfParallelism: DegreeOfParallelism,
                //    completeOnFailure: true);
            }
            catch { }
            SonarScannerEnd(SonarEndSettings);
        });

    SonarScannerBeginSettings SonarBeginPrSettings(SonarScannerBeginSettings settings) =>
        SonarBeginBaseSettings(settings)
            .SetProcessArgumentConfigurator(t => t
                .Add("/o:{0}", "markzither-github")
                .Add("/d:sonar.pullrequest.provider={0}", "github")
                //.Add("/d:sonar.pullrequest.github.repository={0}", GitHubRepository)
                //.Add("/d:sonar.pullrequest.key={0}", GitHubPRNumber)
                //.Add("/d:sonar.pullrequest.branch={0}", GitHubHeadRef)
                //.Add("/d:sonar.pullrequest.base={0}", GitHubBaseRef)
                .Add("/d:sonar.cs.roslyn.ignoreIssues={0}", "true"))
            .SetFramework(Net50);

    SonarScannerBeginSettings SonarBeginFullSettings(SonarScannerBeginSettings settings) =>
        SonarBeginBaseSettings(settings)
            //.SetVersion(GitVersion.SemVer)
            .SetFramework(Net50);

    SonarScannerBeginSettings SonarBeginBaseSettings(SonarScannerBeginSettings settings) =>
        SonarBaseSettings(settings)
            .SetProjectKey("MarkZither_PerformanceOfSomething")
            .SetName("PerformanceOfSomething")
            .SetServer(SonarServer)
            .SetLogin(SonarToken)
            //.AddOpenCoverPaths(TestResultDirectory / "*.xml")
            //.SetVSTestReports(TestResultDirectory / "*.trx")
            .AddSourceExclusions("**/Generated/**/*.*,**/*.Designer.cs,**/*.generated.cs,**/*.js,**/*.html,**/*.css,**/Sample/**/*.*,**/Samples.*/**/*.*,**/*Tools.*/**/*.*,**/Program.Dev.cs, **/Program.cs,**/*.ts,**/*.tsx,**/*EventSource.cs,**/*EventSources.cs,**/*.Samples.cs,**/*Tests.*/**/*.*,**/*Test.*/**/*.*")
        .SetProcessArgumentConfigurator(t => t
            .Add("/o:{0}", "markzither-github")
            .Add("/d:sonar.cs.roslyn.ignoreIssues={0}", "true"));

    SonarScannerBeginSettings SonarBaseSettings(SonarScannerBeginSettings settings) =>
        settings
            .SetLogin(SonarToken)
            .SetProcessWorkingDirectory(RootDirectory);

    SonarScannerEndSettings SonarEndSettings(SonarScannerEndSettings settings) =>
        settings
            .SetLogin(SonarToken)
            .SetProcessWorkingDirectory(RootDirectory)
            .SetFramework(Net50);

    DotNetBuildSettings SonarBuildAll(DotNetBuildSettings settings) =>
        settings
            .SetProjectFile(Solution)
            .SetNoRestore(true)
            .SetConfiguration(Configuration.Debug)
            .SetProcessWorkingDirectory(RootDirectory)
            .SetFramework(Net70);
}