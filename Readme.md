# Event Bus Example Using MicrosoftChannels and MediatR
This project shows a working example of the MicrosoftChannels package to allow for asynchronous communication via an in-memory event bus.

# Getting Started
Open the solution in Visual Studio and run the WebApi project.  
This will open up a SwaggerUI where you can add a new user which will trigger the message sending (the ID is a guid, generate one [here](https://guidgenerator.com/)).  
Have the console open while debugging and you will see the async messages from the handlers coming through to help understand the flow.


### Credit
Thanks for the inspiration and knowledge into the topic Milan! - https://www.milanjovanovic.tech/blog/lightweight-in-memory-message-bus-using-dotnet-channels
