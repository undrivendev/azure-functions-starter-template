# Azure Functions starter template
I was unsatisfied with the default Azure Functions template and I was constantly finding myself doing the same stuff again and again to bootstrap a new project.

This repo can be used as a starting point for new Azure Functions solutions: just rename some folders, project files, namespaces and you should be good to go.

## Features
- Dependency Injection: configured as per [documentation](https://docs.microsoft.com/en-us/azure/azure-functions/functions-dotnet-dependency-injection). Just register your services in the `Configure` method in the [Startup](src/AzureFunctionsStarterTemplate.FunctionHost/Startup.cs) class and they will be available for constructor injection.
- Logging: added to the services collection and configured to use the standard `ILogger<T>` logging provider. There is also some logging configuration already in the [host.json](src/AzureFunctionsStarterTemplate.FunctionHost/host.json)
- Configuration: every parameter in the input trigger and output binding is obtained via configuration.
- Latest runtime version(v3) and SDK

## Project structure
The solution is composed by the *host* project (responsible for bootstrapping the runtime) and the *Logic Layer* (BLL) project.

## Quickstart
If you want to test the sample implementation: 
1. make sure you have already created an Azure Storage account with 2 Azure Storage Queues you can use
2. modify `InputAzureStorageConnectionString`, `InputAzureStorageQueueName`, `OutputAzureStorageConnectionString`, `OutputAzureStorageQueueName` configuration values in [local.settings.json](src/AzureFunctionsStarterTemplate.FunctionHost/local.settings.json) to point at these queues.
3. start the project with `func start` (or with Visual Studio).
4. Put a message in the input queue (see below)

### Sample implementation
When the project is run, by default, the function will do three things:
1. Start listening for input messages from an Azure Storage Queue (defined via configuration). The messages must be JSON and must follow this structure:
```
{
    "Id": "48563f31-a98c-4d7f-9777-6b101c870fd8",
    "Value": "123456789"
}
```
2. Perform some *sample* work on the message in memory (just reverses the order of the string characters contained in the `Value` field of the object)
3. Save the result using the output binding on another Azure Storage Queue (defined in configuration) 

  


