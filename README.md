# ST0257: Web Applications Development
The following repository contains the code I submitted for my Web Applications
Development module. The project is a Timesheet Management system for a fictional
dance studio. I built the admin dashboard using Vue.js.

## Requirements
+ .NET Core SDK 2.0+
+ SQL Server
+ Node.js (developed on v8.4.x, although earlier/later versions should work. Let
  me know!)

## Instructions for Ah Tan (and whoever he tells to clone this 😛)

1. Clone the repository.
```sh
$ git clone https://github.com/JingYenLoh/NetCoreVue.git
```

2. Configure your connection strings in `appsettings.json`. It should not be
   necessary to modify `ApplicationDbContext.cs`.
3. Run the following commands to restore packages:
```sh
# Restore .NET packages
$ dotnet restore

# Restore node_modules using npm
$ npm install

# OR, if you prefer yarn over npm
$ yarn
```

Note that windows users may experience an issue with the `node-sass` version. If
so, run `npm upgrade node-sass`.

4. Run the following commands to setup and start the dev server.
```sh
$ npm run install # OR yarn run install
$ npm run build   # OR yarn run build
$ npm run dev     # OR yarn run dev
```

5. Go to `localhost:5000`. The app should be up and running.

## Issues
Apparently the `UserInfo` isn't getting seeded properly. I'll need to
investigate into this, but feel free to file an issue with the details to
motivate my lazy bum to fix this.

**[Solved]**
Since `UserInfo` is a table that is manually created, it is not handled by ASP.NET Core by default, the table have to be seeded just like any other tables. 
