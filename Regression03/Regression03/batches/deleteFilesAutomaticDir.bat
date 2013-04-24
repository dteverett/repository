echo off
set Pathname="F:\ClaimStaker\Output\"
set Pathname2="\\Apexdata\F_Drive_Test\ClaimStaker\Claims\TODAY\"
set Pathname3="\\Apexdata\F-Drive_Test\Claimstaker\Claims\Auto\5010\"
pause
pushd %Pathname%
del *.* /Q
pushd %Pathname2%
del *.* /Q
pushd %Pathname3%
del *.* /Q
pause