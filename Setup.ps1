$AppName = "Company.Application"
$TemplateName = "Zestware"

function Remove-Directory 
{
    Param(
        [string]$Directory
    )

    Get-ChildItem $Directory -Recurse | Remove-Item -force -recurse
    Remove-Item $Directory -Force
}

function Replace_TextInFile
{
    Param(
        [string]$FilePath,
        [string]$Pattern,
        [string]$Replacement
    )

    [System.IO.File]::WriteAllText(
        $FilePath,
        ([System.IO.File]::ReadAllText($FilePath) -CReplace $Pattern, $Replacement),
        [System.Text.Encoding]::UTF8
    )
}

#------------------------------------------------
# Copy to new directory with new name
#------------------------------------------------

Get-ChildItem .\*  | Copy-Item  -Destination ..\$AppName  -Recurse -Force

#------------------------------------------------
# Move context to the new directory
#------------------------------------------------

Set-Location ..\$AppName

#------------------------------------------------
# Delete unwanted stuff
#------------------------------------------------

$dirsToDelete=@("*bin*", "*obj*", "*Albums*", "*Artists*", "*Album*.cs", "*Artist*.cs")

get-childitem -Include ($dirsToDelete) -Recurse -force | Remove-Item -Force -Recurse

#------------------------------------------------
# Change file names
#------------------------------------------------

Get-ChildItem -Include Zestware* -Recurse | Rename-Item -NewName { $_.Name -replace $TemplateName, $AppName }
Get-ChildItem -Include *Zestware* -Recurse | Rename-Item -NewName { $_.Name -replace $TemplateName, $AppName }

#------------------------------------------------
# Change instances of app name in code files
#------------------------------------------------

Get-ChildItem -File -Exclude *Setup.ps1 -Recurse | ForEach-Object { 
   Write-Host $_.FullName
   Replace_TextInFile -FilePath $_.FullName -Pattern $TemplateName -Replacement $AppName
   Replace_TextInFile -FilePath $_.FullName -Pattern $TemplateName.ToLower() -Replacement $AppName.ToLower()
}

#------------------------------------------------
# Final clean-up
#------------------------------------------------
Remove-Item .\Setup.ps1
    