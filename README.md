# Landmark Remark WebApp
Angular/.NetCore application for placing location marker notes on google maps


## Overview
### Application functions
1. Unregistered users cannot access or add notes 
2. User can register for an account
3. User can login with their login credentials
4. User can see their current location on map
5. User can add a new note at current location
6. User can view notes they have saved previously on the map
7. User can view notes saved by others on the map
8. User can search for notes by username & note content (partial match)
9. User can click on search result notes to view on map
10. User can logout.

### Development Approach
1. Wrote **Scenarios/acceptance criteria** to elicit implicit requirements
2. **.NetCore Webapi** to persist user and note data.
3. **XUnit** for api unit/integration testing
4. **Angular 8** to serve up front-end application
5. **Karma & Jasmine** for unit/integration testing _angular_ application
6. Utilised the following third party libraries for UI & styling:
   * [Boostrap](https://getbootstrap.com) & [ngx-bootstrap](https://valor-software.com/ngx-bootstrap/
)
   * [Bootswatch](https://bootswatch.com)
   * [AlertifyJS](https://alertifyjs.com)
   * [Font-Awesome](https://fontawesome.com)
   * [Angular Google Maps(Agm)](https://angular-maps.com)

#### Implicit requirements identified
1. Unregistered users cannot access or add notes 
2. User can register for an account
3. User can login with their login credentials
4. User can logout.
5. User can click on search result notes to view on map

#### Time spent
* Requirement analysis and solution design: 1h
* Login and registration API design, test and implementation: 4h
* Login and registration Front-end design, test and implementation: 2h
* Map integration: 1h
* Note frontend features - design & implementation: 2h
* Notes api - design & implementation: 1h
* Search Functionality frontend & API: 2h

#### Known limitations
1. User can add multiple notes at the same location but cannot edit them once saved
2. All saved notes are retrieved from database and rendered on map. This would be not scalable for a real-world application and would affect application performance as user base grows. Some form of lazy loading & retrieving only notes in map view may reduce impact on performance.
3. Owing to time contraints, did not achieve a high level of code coverage with testing.

## Running the application

### Dependencies
The following dependencies will be required to run the application locally:

1. Install [Node.js](https://nodejs.org/en/download) v10+
2. Install [AngularCLi ](https://cli.angular.io/) (v8+) `npm install -g @angular/cli`
3. Install [Dotnet-sdk](https://dotnet.microsoft.com/download)  (v2.2+)
### Restore/Run --via npm (quick)
1. Install dependencies
2. Clone repo.  `git clone https://github.com/lenzoburger/landmark-remark-webApp.git`
3. Change directory `cd landmark-remark-webApp`
4. Run setup process `npm run setup`
5. Start the application `npm start`
6. Browser will launch at http://localhost:4200 ..._if not, launch browser and go to [URL](http://localhost:4200)._ (****running in an updated modern broswer is recommended\*\*\**).
### Restore/Run (alternative method ...for debugging)
1. Install dependencies
2. Clone repo.  `git clone https://github.com/lenzoburger/landmark-remark-webApp.git`
3. Change directory `cd landmark-remark-webApp`
4. Launch an additional _terminal/cmd_ window in current directory  `landmark-remark-webApp`
5. **Run Web API (Terminal 1)**
   * Change directory `cd API\landmark-remark-API`
   * Restore project dependencies `dotnet restore`
   * Build Project `dotnet build`
   * Run WebAPI via `dotnet run` command
   * API will be running at `http://localhost:5000`
6. **Angular App (Terminal 2)**
   *  Change directory `cd landmark-remark-SPA`
   *  Install/restore packages `npm install`
   *  Run app `ng serve --open`
   *  Browser should automatically launch at url  `http://localhost:4200`
### Testing

Run from root directory `landmark-remark-webApp`:
* **API** tests: `npm run dotnet-test` or with [_.NET Core Test Explorer_](https://marketplace.visualstudio.com/items?itemName=formulahendry.dotnet-test-explorer) extension in vscode
* **Frontend** _angular/karma_ tests: `npm ng test`
* Run both **API** and **Angular** tests: `npm test`

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
