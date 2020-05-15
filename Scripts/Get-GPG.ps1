[CmdletBinding()]
param (
    [Parameter()]
    [String]
    $FilePath,
    [Parameter()]
    [String]
    $Passphrase
)

rm -force -erroraction ignore "${FilePath}.gpg"
gpg --batch --passphrase $Passphrase --symmetric --cipher-algo AES256 "$FilePath"
