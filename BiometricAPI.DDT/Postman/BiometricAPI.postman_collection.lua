local BiometricApiUrl = "https://biometricapp.azurewebsites.net"
local PersonId = ""

if response.status_code ~= 200 then
log.error("Status code is 200")
    -- or
result.custom_metric("Status code is 200", 1)
end