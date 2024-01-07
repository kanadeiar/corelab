[Console]::OutputEncoding = [System.Text.Encoding]::UTF8

Function Build-Failed{
    Write-Host "### Building the solution"
    Invoke-Command "dotnet build TCR.sln"
    return $LASTEXITCODE -eq 1
}
function Tests-Run{
    Write-Host "### Running tests"
    Invoke-Expression -Command: "dotnet test TCR.sln" | Tee-Object -Variable output | Write-Host
    return $output
}
Function Tests-Pass($testOutput){
    return $testOutput -Match "Test Run Successful"
}
Function Single-NotImplementedException($testOutput){
    $count = ([regex]::Matches($testOutput, "System.NotImplementedException: The method or operation is not implemented." )).count
    return $count -eq 1
}
Function Commit{
    Invoke-Command "git add --all"
    Invoke-Command "git commit -m 'tests pass'"
}
Function Revert{
    # Invoke-Command
    Invoke-Command "git reset --hard HEAD"
}

Function Invoke-Command($command){
    Invoke-Expression -Command: $command | Write-Host
}

if(Build-Failed){
    Write-Host "### Build failed. No change."
    return
}
Write-Host "### Build Passed"
$testOutput = Tests-Run
if(Single-NotImplementedException $testOutput){
    Write-Host "### A single NotImplementedException is allowed. No Change."
    return
}
if(Tests-Pass $testOutput){
    Write-Host "### Tests Passed. Commiting Changes."
    Commit
} else {
    Write-Host "### Tests Failed. Reverting..."
    Revert
}