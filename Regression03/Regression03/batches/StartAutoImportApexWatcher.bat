no echo
set Pathname2="C:\ApexWatcher"
set Pathname3="C:\ClaimStaker"
set Pathname1="C:\ClaimStakerPlus"
pushd %Pathname2%
start ApexWatcher.exe
popd
pushd %Pathname3%
start C:\ClaimStaker\RunClaimStaker.exe C:\Claimstaker 1
popd
pushd %Pathname1%
start RunClaimStakerUI.exe
popd