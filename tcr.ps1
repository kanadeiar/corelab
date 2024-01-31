[Console]::OutputEncoding = [System.Text.Encoding]::UTF8

Function Build-Failed{
    Write-Host "### Building the solution"
    Invoke-Command "dotnet build"
    return $LASTEXITCODE -eq 1
}
function Tests-Run{
    Write-Host "### Running tests"
    Invoke-Expression -Command: "dotnet test" | Tee-Object -Variable output | Write-Host
    return $output
}
Function Tests-Pass($testOutput){
    return $testOutput -Match "Пройден!"
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
    Write-Host "### TCR Build failed. No change."
    return
}
Write-Host "### TCR Build Passed"
$testOutput = Tests-Run
if(Single-NotImplementedException $testOutput){
    Write-Host "### A single NotImplementedException is allowed. No Change."
    return
}
Write-Host "result $lastexitcode" 
if ($lastexitcode -eq 0){
#if(Tests-Pass $testOutput){
    Write-Host "### TCR Tests Passed. Commiting Changes."
    Commit
} else {
    Write-Host "### TCR Tests Failed. Reverting..."
    Revert
}