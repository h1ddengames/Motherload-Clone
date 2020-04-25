# Motherload-Clone

A clone of the game Motherload by xgenstudios.

## Setting up the project

1. Create a new Github Repo with GNU General Public License v3.0 and a Unity .gitignore file.
2. Create a new Unity Project.
3. Copy the clone url from Github repo page (Something like: https://github.com/h1ddengames/Motherload-Clone.git)
4. Go into the main Unity Project folder, then open a terminal. (The main folder being where you can see the Asset, Library, Logs and other folders)
5. Type ```git clone https://github.com/h1ddengames/Motherload-Clone.git``` where the link is the url you copied from step 3.
6. Move the .git folder, .gitignore and LICENSE file into the main Unity Project folder.
7. Create these folders in the main Unity Project folder ```.gitignore/workflows```
8. Create activation.yml in ```.gitignore/workflows``` with the following info

```yml
name: Acquire activation file
on: [push]
jobs:
  activation:
    name: Request manual activation file 🔑
    runs-on: ubuntu-latest
    steps:
    # Request manual activation file
    - name: Request manual activation file
    id: getManualLicenseFile
    uses: webbertakken/unity-request-manual-activation-file@v1.1
    with:
        unityVersion: 2019.3.11f1

    # Upload artifact (Unity_v20XX.X.XXXX.alf)
    - name: Expose as artifact
    uses: actions/upload-artifact@v1
    with:
        name: ${{ steps.getManualLicenseFile.outputs.filePath }}
        path: ${{ steps.getManualLicenseFile.outputs.filePath }}
```

9. 
