# Basic

This is a very basic [Dolittle](http://www.dolittle.io) sample.

## Prerequisites

You will need to have [.NET Core](https://www.microsoft.com/net/download/core) and [NodeJS](http://nodejs.org/).

## Getting started

The sample is configured to run against a [MongoDB](https://www.mongodb.com) instance running locally, it is assuming a non-secured
instance for this. Its also assuming the default port of `27017` to connect to.

To run MongoDB as a docker image, just do:

```shell
$ docker run -p 27017:27017 mongo
```

This will give you a stateless MongoDB instance - meaning that it won't keep state around between restarts.
You can of course mount a volume for state. Read more on [MongoDBs official Docker image](https://hub.docker.com/_/mongo/).

If you're running Windows, you can also run MongoDB using [Chocolatey](https://chocolatey.org).

```shell
c:\> choco install mongodb
```

To run MongoDB on Windows after installing it with `Chocolatey` you need to create a data directory, the default is `c:\data\db`.
Once this is done you can simply run the MongoDB daemon, which should be located in `c:\Program Files\MongoDB\Server\X.X\bin\mongod.exe`,
where X.X is the version e.g. **3.6**.

Once the database server is running you can use tools like [MongoDB Compass](https://www.mongodb.com/products/compass) or [Studio 3T](https://studio3t.com)
to connect to the server and verify everything is running.

Read more about the package [here](https://chocolatey.org/packages/mongodb).

## The Sample

Open the project in [Visual Studio Code](http://code.visualstudio.com/) by opening the root folder or [Visual Studio 2017](https://www.visualstudio.com/vs/) for Windows or Mac using the `TodoTracking.sln` sitting in the root.
The `Core` project is the starting point - which hosts ASP.NET and serves as the HTTP entrypoint for the application. However, all the static Web parts representing the Single Page Application, sits inside the Web folder.
Its built using [Aurelia](https://aurelia.io) using [WebPack](https://webpack.js.org) to compile and pack the files. Aurelia is not a pre-requisite, as you can use any frontend framework to build using Dolittle.
Proxy generation is done by our [build tool](https://dolittle.io/dotnet-sdk/tooling/build_tool/) that will generate proxies for the Dolittle building blocks relevant for the frontend. These are framework agnostic JavaScript
files. Interacting with Commands and Queries is done through the NPM packages provided; [Commands](https://www.npmjs.com/package/@dolittle/commands), [Queries](https://www.npmjs.com/package/@dolittle/queries).

The simplest way to run this is to navigate to the folder containing the `bounded-context.json` (TodoTracking) and run `dolittle run`. If you have docker and are on mac or linux it should start a mongo docker, but on Windows you will have to make sure docker is running yourself (we recommend [Kitematic](https://kitematic.com/)).

To run it manually you will need to restore packages for both .NET and Node, do the following from the `./Source/Core` folder:

```shell
$ dotnet restore
```

Then navigate to the `./Source/Web` folder and run either

```shell
$ npm install
```

or

```shell
$ yarn
```

Depending on wether or not you're using NPM or YARN.


From a terminal from the root of the project do the following from the `./Source/Web` folder:

```shell
$ ./run.js
```

on Windows:

```shell
c:> node run.js
```

This will run all the tasks and get you up and running, any editing can now be done and just saved and it will recompile / transpile / copy.
Once it is running you can navigate to `http://localhost:5000` with your favorite browser.

You can play with the commands and queries directly through Swagger by going to `http://localhost:5000/swagger`.