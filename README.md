# Azure Functions starter template
I was unhappy with the default Azure Functions template and I was constantly finding myself doing the same stuff again again to bootstrap a new project.

This repo can be used as a starting point for new Azure Functions solution: just rename some folders, project files, namespaces and you should be good to go.

## Features
- Dependency Injection: configured as per [documentation](https://docs.microsoft.com/en-us/azure/azure-functions/functions-dotnet-dependency-injection). Just register your services in the `ConfigureServices` method in the [Startup](src/AzureFunctionStarterTemplate.FunctionHost/Startup.cs) class.
- Logging: added to the services collection and configured to use the standard .NET Core logging provider.
- Configuration: every parameter in the input trigger and output binding is received using the configuration provider.


## Sample implementation
The project structure is composed by the *host* project and the *Domain Layer* (BLL).

When the project is started, by default, the function will do three things:
1. Receive a message from an Azure Storage Queue (defined via configuration). The message must be a JSON following this structure:
```
{
    "Id": "48563f31-a98c-4d7f-9777-6b101c870fd8",
    "Value": "123456789"
}
```
2. Performs some *sample* work on the message (just reverses the order of the string contained in the `Value` field of the object)
3. Saves the result using the output binding on another Azure Storage Queue (defined in configuration) 

  

