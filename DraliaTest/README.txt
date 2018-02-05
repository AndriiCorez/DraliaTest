﻿Use following steps to prepare environment for test, run it and generate test report in HTML format:

I. Make sure DraliaTest.dll is available and internet connection is stable

II. Use NUnit to run the tests:
1. Download Nunit from https://github.com/nunit/nunit-console/releases/tag/3.8 - NUnit.Console-3.8.0.msi
2. Choose 'Typical' while installation
3. Add to system PATH variable this: C:\Program Files (x86)\NUnit.org\nunit-console
4. Open command line
5. Type:
$ nunit3-console unitTestPath.dll

!IMPORTANT! NUnit may be blocked by Firewall, in case you have a failure while running please check your firewall if it is not in proactive mode, 
or add NUnit to trusted executables/Exclusions

III. Generate HTML report from the rest run result
1. Download http://relevantcodes.com/Tools/ReportUnit/ 1.2 is recommended due to stability
2. Add to system PATH a folder with unzipped ReportUnit
3. Open command line
4. Type: 
$ reportunit pathToTestResult.xml
