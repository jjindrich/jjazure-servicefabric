# JJ Azure ServiceFabric sample
This repo contains ServiceFabric samples with several services:

## Encrypted service JJFabric.EncryptedSvcApi
This service implements how to encrypt secrets in ServiceFabric. Api service returns encrypted value from encrypted secret stored in fabric configuration.
ServiceFabric documentation (https://docs.microsoft.com/en-us/azure/service-fabric/service-fabric-application-secret-management)

### Step 1 - Create certificate
Creating self-signed certificate for demo. Check with certmgr.msc certificate has been created.
```PowerShell
.\Scripts\prepare.ps1
```

### Step 2 - Encrypt value "mojeheslo"
```PowerShell
.\Scripts\encrypt.ps1
```

### Step 3 - Add secret into fabric code
Add secret into service settings file, change value with encrypted value
```Xml
  <Section Name="JJConfigSection">
    <Parameter Name="JJHeslo" IsEncrypted="true"  Value="MIIBrwYJKoZIhvcNAQcDoIIBoDCCAZwCAQAxggFHMIIBQwIBADArMBcxFTATBgNVBAMMDGpqZmFicmljY2VydAIQZPR+6QCuwYJF2S0dq0BOfDANBgkqhkiG9w0BAQcwAASCAQBL2/uRa3Roup5ycfURdQHoh3faTjmW/0WID7UK0+NsQTbzEAeO6PGRn+FZ/ZLNSZOv8S2kprznQrNQdnkP18EFo7B0J/SZsHEsLGOxu2qYv061JhnI5DPYU3EwpXXxGSaSMLfAF8j++Ta+68jXejv9V1Cm+0R0Du2PEBZVtDELcb1oHR4Yel3gVxWJTbpUEEmM6iniI1SDUfwGEExP1WOQLnwImnGAG1GOWT3Yd52URkJ6c8hIvGwg3QwGcObeq5Brf05djhuqhZoQf5PgiEDsLuKUY56IAgEEVGyODTqt/fzDJI5INZNygPbU0iaeaQof+unWglZkGMpqFKfbPCvqMEwGCSqGSIb3DQEHATAdBglghkgBZQMEASoEEKuQrcetGQ9S4icdCAXPuK2AINyGXAqSsc22bUMHwDfOKmWW9v/uUMwX7NjHLvjlGIiU" />
  </Section>
```
btw, you can override this value durring application deployment process -> define in ApplicationManifest ConfigOverrides

Next, add thumbprint into ApplicationManifest.xml
```Xml
  <Principals>
    <Users>
      <User Name="EncryptedSvcApi" AccountType="NetworkService" />
    </Users>
  </Principals>
  <Policies>
    <SecurityAccessPolicies>
      <SecurityAccessPolicy GrantRights="Read" PrincipalRef="EncryptedSvcApi" ResourceRef="EncryptedSvcApiCert" ResourceType="Certificate"/>
    </SecurityAccessPolicies>
  </Policies>
  <Certificates>
    <SecretsCertificate Name="EncryptedSvcApiCert" X509FindType="FindByThumbprint" X509FindValue="37B63D21204C52E6F1163C198AE67C055008B6BD"/>
  </Certificates>
```

### Step 4 - Test locally
Open Visual Studio project and deploy into local ServiceFabric.
Check port in ServiceManifest.xml and start browser (http://localhost:8247/api/values/5)