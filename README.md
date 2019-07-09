# Landmark Remark Web App
Angular/.NetCore application for placing location marker notes on google maps

## Running the application

### Dependencies
1. The following dependencies will be required to run locally
2. Install [Node.js](https://nodejs.org/en/download) v10+
3. Install [AngularCLi ](https://cli.angular.io/) (v8+) `npm install -g @angular/cli`
4. Install [Dotnet-sdk](https://dotnet.microsoft.com/download)  (v2.2+)

### Restore/Run --via cli
1. Install dependencies
2. Clone repo.  `git clone https://github.com/lenzoburger/landmark-remark-webApp.git`
3. Change directory `cd landmark-remark-webApp`
4. Launch an additional _terminal/cmd_ window in current directory  `landmark-remark-webApp`
5. **Run Web API (Terminal 1)**
   * Change directory `cd landmark-remark-API\landmark-remark-API`
   * Restore project dependencies `dotnet restore`
   * Build Project `dotnet build`
   * Run WebAPI via `dotnet run` command
   * API will be running at `http://localhost:5000`
6. **Angular App (Terminal 2)**
   *  Change directory `cd landmark-remark-SPA`
   *  Install/restore packages `npm install`
   *  Run app `ng serve --open`
   *  Browser should automatically launch at url  `http://localhost:4200`


## Development approach overview

### Tools
1. [Postman](https://www.getpostman.com/downloads)
2. [SQLLite.DB.Browser](https://sqlitebrowser.org/dl)
3. [Git](https://git-scm.com/downloads)
4. [Visual Studio 2017](https://visualstudio.microsoft.com/vs/older-downloads/)
5. [Visual Studio Code](https://code.visualstudio.com/download) & **Extensions:**
   * [_.NET Core Test Explorer_](https://marketplace.visualstudio.com/items?itemName=formulahendry.dotnet-test-explorer)
   * [_Angular Files_](https://marketplace.visualstudio.com/items?itemName=alexiv.vscode-angular2-files)
   * [_Angular Language Service_](https://marketplace.visualstudio.com/items?itemName=Angular.ng-template)
   * [_Angular Snippets_](https://marketplace.visualstudio.com/items?itemName=johnpapa.Angular2)
   * [_angular2-switcher_](https://marketplace.visualstudio.com/items?itemName=infinity1207.angular2-switcher)
   * [_Auto Rename Tag_](https://marketplace.visualstudio.com/items?itemName=formulahendry.auto-rename-tag)
   * [_Bracket Pair Colorizer 2_](https://marketplace.visualstudio.com/items?itemName=CoenraadS.bracket-pair-colorizer-2)
   * [_C#_](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp)
   * [_C# Extensions_](https://marketplace.visualstudio.com/items?itemName=jchannon.csharpextensions)
   * [_Debugger for chrome_](https://marketplace.visualstudio.com/items?itemName=msjsdiag.debugger-for-chrome)
   * [_Markdown All in One_](https://marketplace.visualstudio.com/items?itemName=yzhang.markdown-all-in-one)
   * [_Markdown Preview Enhanced_](https://marketplace.visualstudio.com/items?itemName=shd101wyy.markdown-preview-enhanced)
   * [_Meterial Icon Theme_](https://marketplace.visualstudio.com/items?itemName=PKief.material-icon-theme)
   * [_Nuget Package Manger_](https://marketplace.visualstudio.com/items?itemName=jmrog.vscode-nuget-package-manager)
   * [_Path Intellisense_](https://marketplace.visualstudio.com/items?itemName=christian-kohler.path-intellisense)
   * [_Prettier - Code Formatter_](https://marketplace.visualstudio.com/items?itemName=esbenp.prettier-vscode)
   * [_TSLint_](https://marketplace.visualstudio.com/items?itemName=ms-vscode.vscode-typescript-tslint-plugin)
