dotnet pack MTask.Boilerplate.Extensions.sln --include-symbols --include-source --output /nugpk /p:PackageVersion=$PackageVersion
cd /nugpk
ls | while read line ; do dotnet nuget push $line -k $NUGET_KEY -s http://nuget.mtask.ge/nuget/IronManNuget/  ; done 
rm -r /nugpk
