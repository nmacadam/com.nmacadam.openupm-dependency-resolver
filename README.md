# OpenUPM Dependency Resolver
[![GitHub release](https://img.shields.io/github/package-json/v/nmacadam/com.nmacadam.openupm-dependency-resolver)](https://github.com/nmacadam/com.nmacadam.openupm-dependency-resolver/releases)
[![openupm](https://img.shields.io/npm/v/com.nmacadam.openupm-dependency-resolver?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.nmacadam.openupm-dependency-resolver/)
[![semantic-release: angular](https://img.shields.io/badge/semantic--release-angular-e10079?logo=semantic-release)](https://github.com/semantic-release/semantic-release)
[![License: MIT](https://img.shields.io/badge/License-MIT-brightgreen.svg)](/LICENSE)

This package adds support for resolving packages hosted on OpenUPM as package dependencies.  Inspired by [mob-sakai's](https://github.com/mob-sakai) [Git Dependency Resolver For Unity](https://github.com/mob-sakai/GitDependencyResolverForUnity).

## Usage

### Package User
1. Install [OpenUPM CLI](https://openupm.com/docs/getting-started.html) if you have not already
2. Install this package (see [🪛 Installation](https://github.com/nmacadam/com.nmacadam.openupm-dependency-resolver/blob/main/README.md#-installation))

### Package Developer

```JSON
{
  ...
  "openUpmDependencies": {
    "your.package": "1.0.0",
    ...
  }
}
```

- You must use `openUpmDependencies` instead of `dependencies` to define OpenUPM-based dependencies for the package.
- Package users must install `com.nmacadam.openupm-dependency-resolver`.
- Optionally specify a which package version to retrieve from OpenUPM
  - You may use the version string `default` to download the latest version (though this is not recommended)

## 🪛 Installation
Install [OpenUPM CLI](https://openupm.com/docs/getting-started.html) if you have not already.

<details>
  <summary>Install with <a href="https://openupm.com/packages/com.nmacadam.notate/">OpenUPM</a> via CLI or scoped registry (recommended)</summary>
  
  <br />
  
  &emsp;✨ *To add a package via [openupm-cli](https://github.com/openupm/openupm-cli), run the following command:*
  
  &emsp;`openupm install com.nmacadam.openupm-dependency-resolver`
  
  <br />
  
  &emsp;🗃️ *To add a package via scoped registry:*
  
  - Open `Edit/Project Settings/Package Manager`
  - Add a new Scoped Registry:
    ```
    Name: OpenUPM
    URL:  https://package.openupm.com/
    Scope(s): com.nmacadam
    ```
  - Open `Window/Package Manager`
  - Click <kbd>+</kbd>
  - <kbd>Add from Git URL</kbd>
  - `com.nmacadam.openupm-dependency-resolver` <kbd>Add</kbd>
  
</details>
<details>
  <summary>Install with Git URL</summary>
  
  <br />
  
  - Open `Window/Package Manager`
  - Click <kbd>+</kbd>
  - <kbd>Add from Git URL</kbd>
  - `https://github.com/nmacadam/com.nmacadam.openupm-dependency-resolver.git` <kbd>Add</kbd>
  
  &emsp;Note that you won't be able to receive updates through Package Manager this way, you'll have to update manually.
  
</details>
<details>
  <summary>Install manually</summary>
  
  <br />
  
  - Download the [upm](https://github.com/nmacadam/Notate/tree/upm) branch of this repository as a .zip file and extract it
  - Open `Window/Package Manager`
  - Click <kbd>+</kbd>
  - <kbd>Add package from disk</kbd>
  - Select `package.json` in the extracted folder

  &emsp;Note that you won't be able to receive updates through Package Manager this way, you'll have to update manually.
  
</details>