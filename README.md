[![build status](http://teamcity.codebetter.com/app/rest/builds/buildType:id:FluentTc/statusIcon)](http://teamcity.codebetter.com/viewType.html?buildTypeId=FluentTc&guest=1) [![code coverage](https://img.shields.io/teamcity/coverage/FluentTc.svg)](http://teamcity.codebetter.com/viewType.html?buildTypeId=FluentTc&guest=1) [![NuGet version](https://badge.fury.io/nu/FluentTc.svg)](https://badge.fury.io/nu/FluentTc)  [![Chat on gitter](https://img.shields.io/gitter/room/QualiSystems/FluentTc.svg)](https://gitter.im/QualiSystems/FluentTc) [![Stories in Ready](https://badge.waffle.io/QualiSystems/FluentTc.png?label=ready&title=Ready)](https://waffle.io/QualiSystems/FluentTc)

# FluentTc 
Easy-to-use, readable and comprehensive library for consuming TeamCity REST API. Written using real scenarios in mind, enables variuos range of queries and operation on TeamCity

# Getting started 

Install __FluentTc__ nuget package from from Manage Nuget packages

Or from Nuget Package Manager Console:
```PS
install-package FluentTc
```

# Example 

Connects to TeamCity using guest account and retrieves builds from the [FluentTc](http://teamcity.codebetter.com/viewType.html?buildTypeId=FluentTc_FluentTcDevelop) build configuration with all its branches, 
with additional build properties, such as StatusText, StartDate and FinishDate; with paging taking 10 builds starting from the 30th build.

```C#
IList<IBuild> builds =
    new RemoteTc().Connect(h => h.ToHost("teamcity.codebetter.com").AsGuest())
        .GetBuilds(b =>
            b.BuildConfiguration(c =>
                c.Id("FluentTc_FluentTcDevelop"))
                .Branch(r => r.Branched()),
            i => i.IncludeStatusText().IncludeStartDate().IncludeFinishDate(), 
            p => p.Start(30).Count(10));
```

For more examples and documentation read the [Wiki](https://github.com/QualiSystems/FluentTc/wiki)

## Contributors
This project would not be possible with the support of [contributors](CONTRIBUTORS.md)

## Versioning
FluentTc adheres to [Semantic Versioning 2.0.0](http://semver.org/), basically means that there are no breaking changes unless the version is 0.x or major version is promoted. 

## Project State
The project is stable and works in production in a few organizations. It has a growing community of users and contributors.
Although we are happy with its current state, we'd like to hear what you think. We are asking to spend a few minutes and fill this survey:
[FluentTc survey](http://goo.gl/forms/42U7MvVFStoieQaB3)

## License
[Apache License 2.0](https://github.com/QualiSystems/FluentTc/blob/master/LICENSE)

## Credits
[![Continuous Integration powered by TeamCity and CodeBetter](https://resources.jetbrains.com/assets/banners/jetbrains-com/Codebetter.png)](http://codebetter.com/codebetter-ci/)

