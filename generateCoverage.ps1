param(
    [Parameter(Mandatory=$true)]
    [string]$testProjectPath,
    [Parameter(Mandatory=$true)]
    [string]$testResultsFolder
)

<#
echo "Test Project Path" $testProjectPath
echo "Test Results Folder" $testResultsFolder
#>

try {

    if (-not (Test-Path $testProjectPath)) 
    {
        throw [System.IO.FileNotFoundException] "$testProjectPath not found."
    }

    if (-not (Test-Path $testResultsFolder)) 
    {
        throw [System.IO.FileNotFoundException] "$testResultsFolder not found."
    }

    dotnet test $testProjectPath 
    $recentCoverageFile = Get-ChildItem -File -Filter *.coverage -Path $testResultsFolder -Name -Recurse | Select-Object -First 1;
    write-host 'Test Completed'  -ForegroundColor Green

    C:\Users\Justin\.nuget\packages\microsoft.codecoverage\16.8.0\build\netstandard1.0\CodeCoverage\CodeCoverage.exe analyze  /output:$testResultsFolder\MyTestOutput.coveragexml  $testResultsFolder'\'$recentCoverageFile
    write-host 'CoverageXML Generated'  -ForegroundColor Green

    dotnet C:\Users\Justin\.nuget\packages\reportgenerator\4.8.1\tools\netcoreapp3.0\ReportGenerator.dll "-reports:$testResultsFolder\MyTestOutput.coveragexml" "-targetdir:$testResultsFolder\coveragereport"
    write-host 'CoverageReport Published'  -ForegroundColor Green

}
catch {

    write-host "Caught an exception:" -ForegroundColor Red
    write-host "Exception Type: $($_.Exception.GetType().FullName)" -ForegroundColor Red
    write-host "Exception Message: $($_.Exception.Message)" -ForegroundColor Red

}