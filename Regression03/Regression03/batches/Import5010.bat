
set Pathname="C:\AutoImport5010"
pushd %Pathname%
Start AutoImport5010.exe
ROBOCOPY "F:\QAFiles\Regression\Automated\claims5010" \\apexdata\F_Drive_Test\ClaimStaker\Claims\Auto\5010
end