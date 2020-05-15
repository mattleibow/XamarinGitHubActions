# Scripts

Certificates, provisioning profiles, keystores and others are gpg signed and stored as Base64 secrets.

```powershell
$gpgPassword = "password"

.\Scripts\Get-GPG.ps1 "iOSProvisioning.mobileprovision" "$gpgPassword"
.\Scripts\Get-GPG.ps1 "Certificate.p12" "$gpgPassword"

.\Scripts\Get-Base64.ps1 "iOSProvisioning.mobileprovision.gpg"
.\Scripts\Get-Base64.ps1 "Certificate.p12.gpg"
```