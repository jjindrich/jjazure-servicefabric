# Create new certificate
New-SelfSignedCertificate -Type DocumentEncryptionCert -KeyUsage DataEncipherment -Subject jjfabriccert -Provider 'Microsoft Enhanced Cryptographic Provider v1.0'

# returns
	# Thumbprint 37B63D21204C52E6F1163C198AE67C055008B6BD
	# Subject CN=jjfabriccert

  