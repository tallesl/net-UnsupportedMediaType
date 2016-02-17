# UnsupportedMediaType

[![][build-img]][build]
[![][nuget-img]][nuget]

A [DelegatingHandler] to return 415 status code.

Have you ever got a "*No MediaTypeFormatter is available to read an object of type 'foo' from content with media type
'bar'*" on your Web API application?

And that error is usually because some <del>dumbass</del> folk forgot to put the proper `Content-Type` on the request.
It's their fault, not mine.
It's supposed to be an error of the [400 family]&nbsp;([415] to be more precise) and not a [500].

[build]:             https://ci.appveyor.com/project/TallesL/net-unsupportedmediatype
[build-img]:         https://ci.appveyor.com/api/projects/status/github/tallesl/net-unsupportedmediatype?svg=true
[nuget]:             https://www.nuget.org/packages/UnsupportedMediaType
[nuget-img]:         https://badge.fury.io/nu/UnsupportedMediaType.svg
[DelegatingHandler]: https://msdn.microsoft.com/library/System.Net.Http.DelegatingHandler
[400 family]:        http://tools.ietf.org/html/rfc7231#section-6.5
[415]:               http://tools.ietf.org/html/rfc7231#section-6.5.13
[500]:               http://tools.ietf.org/html/rfc7231#section-6.6.1

## Usage

```cs
using UnsupportedMediaTypeLibrary;

GlobalConfiguration.Configuration.MessageHandlers.Add(new UnsupportedMediaTypeHandler());
```