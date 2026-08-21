Stop-Process -Name "dotnet" -Force -ErrorAction SilentlyContinue
Start-Sleep -Seconds 2
Start-Process -FilePath "dotnet" -ArgumentList "run","--project","src\Multitrac.Api","--urls","http://localhost:5100" -WorkingDirectory "C:\Users\fabri\Downloads\MultitracV2" -NoNewWindow
Start-Sleep -Seconds 18
Write-Host "=== Testing /api/moneda ==="
try {
    $r = Invoke-WebRequest -Uri "http://localhost:5100/api/moneda" -UseBasicParsing -TimeoutSec 10
    Write-Host "Status: $($r.StatusCode)"
    Write-Host $r.Content
} catch {
    Write-Host "Error: $($_.Exception.Message)"
    if ($_.Exception.Response) {
        $reader = New-Object System.IO.StreamReader($_.Exception.Response.GetResponseStream())
        Write-Host $reader.ReadToEnd()
    }
}
Write-Host "=== Testing /api/banco ==="
try {
    $r = Invoke-WebRequest -Uri "http://localhost:5100/api/banco" -UseBasicParsing -TimeoutSec 10
    Write-Host "Status: $($r.StatusCode)"
    Write-Host $r.Content
} catch {
    Write-Host "Error: $($_.Exception.Message)"
    if ($_.Exception.Response) {
        $reader = New-Object System.IO.StreamReader($_.Exception.Response.GetResponseStream())
        Write-Host $reader.ReadToEnd()
    }
}
