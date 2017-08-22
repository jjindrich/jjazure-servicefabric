# Create new certificate
Import-Module .\New-SelfSignedCertificateEx.ps1
$securePassword = ConvertTo-SecureString -String "azure" -AsPlainText -Force

New-SelfsignedCertificateEx -Subject "CN=jjfabric.westeurope.cloudapp.azure.com" -EKU "Server Authentication", "Client authentication", "Document Encryption" -KeyUsage "KeyEncipherment, DigitalSignature, DataEncipherment" -Path "certdns2.pfx" -Password $securePassword -Exportable

# returns  
	# Thumbprint EA83AEE57808A3DB4EC44F41B628611725971EDC
	# Subject CN=jjfabric.westeurope.cloudapp.azure.com

  