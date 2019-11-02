# Biometric API

* BiometricAPI is a WebAPI project to perform various operations to/from registration devices.

[![Build Status](https://dev.azure.com/avvarma/ProgLan/_apis/build/status/BiometricApiCI?branchName=master)](https://dev.azure.com/avvarma/ProgLan/_build/latest?definitionId=7&branchName=master)
[![Deployment Status](https://vsrm.dev.azure.com/avvarma/_apis/public/Release/badge/039cdcf2-f6ec-4d50-b96b-cc57ba5c0f0e/1/1)](https://dev.azure.com/avvarma/ProgLan/_release?_a=analytics&view=mine&definitionId=1)
[![Application Status](https://img.shields.io/website?down_color=lightgrey&down_message=offline&up_color=green&up_message=online&url=https%3A%2F%2Fbiometricapp.azurewebsites.net)](https://biometricapp.azurewebsites.net)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=iAvinashVarma_BiometricApi&metric=alert_status)](https://sonarcloud.io/dashboard?id=iAvinashVarma_BiometricApi)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=iAvinashVarma_BiometricApi&metric=code_smells)](https://sonarcloud.io/dashboard?id=iAvinashVarma_BiometricApi)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=iAvinashVarma_BiometricApi&metric=ncloc)](https://sonarcloud.io/dashboard?id=iAvinashVarma_BiometricApi)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=iAvinashVarma_BiometricApi&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=iAvinashVarma_BiometricApi)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=iAvinashVarma_BiometricApi&metric=security_rating)](https://sonarcloud.io/dashboard?id=iAvinashVarma_BiometricApi)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=iAvinashVarma_BiometricApi&metric=reliability_rating)](https://sonarcloud.io/dashboard?id=iAvinashVarma_BiometricApi)

---

## Technical Stack

Stack | Version |
--- | --- |
.NET Framework | v4.7.2 |
C# Version | 7 |
Visual Studio | 2019 |

---

## Postman

### Collection

[![Run in Postman](https://run.pstmn.io/button.svg)](https://www.getpostman.com/collections/adff3dc0d9dd3e9eb118)

### Runner

```cmd
> npm install newman -g
> newman run BiometricAPI.DDT\Postman\BiometricAPI.postman_collection.json -e BiometricAPI.DDT\Postman\Production.postman_environment.json
> newman run https://raw.githubusercontent.com/iAvinashVarma/BiometricAPI/master/BiometricAPI.DDT/Postman/BiometricAPI.postman_collection.json -e https://raw.githubusercontent.com/iAvinashVarma/BiometricAPI/master/BiometricAPI.DDT/Postman/Production.postman_environment.json
```

### Documentation

* **[BiometricAPI Documentation](https://documenter.getpostman.com/view/1806674/SW132JHm)**

## Quality Check

[![Quality gate](https://sonarcloud.io/api/project_badges/quality_gate?project=iAvinashVarma_BiometricApi)](https://sonarcloud.io/dashboard?id=iAvinashVarma_BiometricApi)
