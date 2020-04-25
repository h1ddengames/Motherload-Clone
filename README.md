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
8. Create activation.yml in ```.gitignore/workflows``` with the code from the section Acquire Activation File Workflow.
9. Stage all the changes, commit, then push.
10. Go to the github repo then click on the Actions tab.
11. Go the the "Acquire activation file" action then wait for it to finish.
12. On the top right of the "Request manual activation" page click on Artifacts, then download the alf file that was generated.
13. Unzip the alf file that was downloaded then upload it to https://license.unity3d.com/manual
14. Follow the prompts on that page then downloade the ulf file that it generates.
15. Go to the github repo then click on the Settings tab, then the Secrets tab.
16. Click on Add a new secret then name the secret ```UNITY_LICENSE```
17. Copy the contents of the ulf file into the Value input then click on the Add Secret button.
18. Create main.yml in ```.gitignore/workflows``` with the code from the section Main Workflow
19. In the Unity Editor, go to Edit > Project Settings > Editor > Enter Play Mode Settings then enable ```Enter Play Mode Options (Experimental)```
20. While Project Settings window is still open, go to Player then change the Company Name and make sure the API Compatibility Level is .NET 4.x
21. Stage all the changes, commit, then push.

### Acquire Activation File Workflow

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
        unityVersion: 2019.3.9f1

    # Upload artifact (Unity_v20XX.X.XXXX.alf)
    - name: Expose as artifact
      uses: actions/upload-artifact@v1
      with:
        name: ${{ steps.getManualLicenseFile.outputs.filePath }}
        path: ${{ steps.getManualLicenseFile.outputs.filePath }}
```

### Main Workflow

```yml
name: Build project

on: [push]

env:
  UNITY_LICENSE: ${{ secrets.UNITY_LICENSE }}

jobs:
  buildForSomePlatforms:
    name: Build for ${{ matrix.targetPlatform }} on version ${{ matrix.unityVersion }}
    runs-on: ubuntu-latest
    strategy:
      fail-fast: false
      matrix:
        projectPath:
          - path/to/your/project
        unityVersion:
          - 2019.3.9f1
        targetPlatform:
          - StandaloneOSX # Build a macOS standalone (Intel 64-bit).
          - StandaloneWindows64 # Build a Windows 64-bit standalone.
          - StandaloneLinux64 # Build a Linux 64-bit standalone.
          - WebGL # WebGL.

    steps:
      - uses: actions/checkout@v2
        with:
          lfs: true
      - uses: actions/cache@v1.1.0
        with:
          path: ${{ matrix.projectPath }}/Library
          key: Library-${{ matrix.projectPath }}-${{ matrix.targetPlatform }}
          restore-keys: |
            Library-${{ matrix.projectPath }}-
            Library-
      - uses: webbertakken/unity-builder@v0.11
        with:
          projectPath: ${{ matrix.projectPath }}
          unityVersion: ${{ matrix.unityVersion }}
          targetPlatform: ${{ matrix.targetPlatform }}
      - uses: actions/upload-artifact@v1
        with:
          name: Build
          path: build
```
