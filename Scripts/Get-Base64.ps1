[CmdletBinding()]
param (
    [Parameter()]
    [String]
    $FilePath
)

rm -force -erroraction ignore "${FilePath}.base64"

$bytes = [IO.File]::ReadAllBytes("${FilePath}")
$str = [System.Convert]::ToBase64String($bytes)
[IO.File]::WriteAllText("${FilePath}.base64", $str)
