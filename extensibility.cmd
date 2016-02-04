copy NUnitPlugin\bin\Debug\NUnitPlugin.dll packages\NUnit.Console.3.0.0\tools\addins /Y
copy NUnitPlugin\bin\Debug\JetBrains.TeamCity.ServiceMessages.dll packages\NUnit.Console.3.0.0\tools\addins /Y
copy NUnitPlugin\TeamCity.addins packages\NUnit.Console.3.0.0\tools /Y
packages\NUnit.Console.3.0.0\tools\nunit3-console.exe Tests\bin\Debug\Tests.dll --result=output;format=TeamCityResume --result=output;format=TeamCityStat