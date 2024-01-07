[Console]::OutputEncoding = [System.Text.Encoding]::UTF8

Function Invoke-Command($command){
    Invoke-Expression -Command: $command | Write-Host
	Write-Host "### Build failed. No change."
}

Invoke-Command "dotnet test"