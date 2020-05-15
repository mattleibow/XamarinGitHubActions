# Xamarin + GitHub Actions

![Build App](https://github.com/mattleibow/XamarinGitHubActions/workflows/Build%20App/badge.svg)

The repo for my awesome 🤞🏻 talk...

> **The Pandemic Approach to CI for Xamarin Apps with GitHub Actions**
> 
> Are you wanting to lockdown the CI for your Xamarin apps? Well, I want to show you how you can flatten the curve of learning with a short intro on building and testing Xamarin apps using GitHub Actions. By adding some disinfectant to your workflow, you can quarantine any viruses before they get merged. They are not going to do any social distancing with your code! And, they are certainly not going to self isolate! You will be able to use GitHub Actions to sanitize any code before it infects the rest of the population. By taking a few precautions, users will say "nature is healing" and give you that 5-star review.
>
> https://www.meetup.com/Cape-Town-Ms-Dev-User-Group/events/270420246/

## Utils

Certificates, provisioning profiles, keystores and others are gpg signed and stored as Base64 secrets.


```powershell
# the secure, secret password
$passphrase = "password"

# remove any old items
rm -force -erroraction ignore iOSCertificate.p12.*
rm -force -erroraction ignore iOSProvisioning.mobileprovision.*

# gpg the items
gpg --batch --passphrase $passphrase --symmetric --cipher-algo AES256 iOSCertificate.p12
gpg --batch --passphrase $passphrase --symmetric --cipher-algo AES256 iOSProvisioning.mobileprovision

# get the base64 for storage
[IO.File]::WriteAllText("iOSProvisioning.mobileprovision.base64", [System.Convert]::ToBase64String([IO.File]::ReadAllBytes("iOSProvisioning.mobileprovision.gpg")))
[IO.File]::WriteAllText("iOSCertificate.p12.base64", [System.Convert]::ToBase64String([IO.File]::ReadAllBytes("iOSCertificate.p12.gpg")))
```
