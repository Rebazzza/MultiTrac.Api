Stop-Process -Name "dotnet" -Force -ErrorAction SilentlyContinue
Start-Sleep -Seconds 2
$proc = Start-Process -FilePath "dotnet" -ArgumentList "run --project src\Multitrac.Api" -WorkingDirectory "C:\Users\fabri\Downloads\MultitracV2" -PassThru -NoNewWindow
$proc.Id | Out-File "C:\Users\fabri\Downloads\MultitracV2\api_pid.txt"
Start-Sleep -Seconds 15
try {
    $response = Invoke-WebRequest -Uri "http://localhost:5100/api/moneda" -UseBasicParsing -TimeoutSec 10
    Write-Host "STATUS: $($response.StatusCode)" -ForegroundColor Green
    Write-Host "DATA: $($response.Content)" -ForegroundColor Yellow
} catch {
    Write-Host "ERROR: $($_.Exception.Message)" -ForegroundColor Red
    if ($_.Exception.Response) {
        $reader = New-Object System.IO.StreamReader($_.Exception.Response.GetResponseStream())
        $body = $reader.ReadToEnd()
        Write-Host "BODY: $body" -ForegroundColor Red
    }
}
