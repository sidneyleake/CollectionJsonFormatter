# collection+json formatter
When creating RESTful services, hypermedia is one of those things you are just supposed to do. 
[Mike Amundsen](https://twitter.com/mamund)'s [collection+json](http://amundsen.com/media-types/collection/) 
mediatype provides a standard way to add hypermedia to your services. Since collection+json is a standard, 
it is possible to provide a formatter to create what is necessary with minimal work by the developer, 
similar to the currently available JsonMediaTypeFormatter and XmlMediaTypeFormatter. This library has 
a CollectionJsonMediaTypeFormatter which provides support for mediatype in ASP.NET Web API.

## features
* A model set representing the properties defined for a collection+json document
* A mediatype formatter that formats data to collection+json when requested
* A set of attributes that can be used to decorate models allowing for an automatic conversion to collection+json
* A configuration model that can be used to customize the collection+json representations created
* A fluid interface for defining necessary data to automaticall convert models to collection+json

## in progress
* A sample web api which allows for collection+json requests
* More settings to be configured
* A lot of code clean-up
* Hanlding error responses
* Allowing for manual creation of collection+json documents

## features to be
* A mediatype formatter that converts a collection+json representation to a model
* A sample web application consuming an api and requesting data in collection+json format
* Functionality to ignore properties when building items
* Funtiionality to ignore properties when building template
* Regex and Required properties on items for templates

I would love help from anyone who is interested :)

[@alm0stk00l](https://twitter.com/alm0stk00l)
