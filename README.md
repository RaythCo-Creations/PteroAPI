# PteroAPI

A DLL with functionality for using the pterodactyl server management software within a .NET application.

### Inclusion
Be sure to add project reference to the DLL file, then have `using PteroAPI;` at the top of your project.

### Declaring
Declare your API connection with:
`Pterodactyl varName = new(Url, Key);`

Url is the url to the console as described in the Pterodactyl API Documentation: https://dashflo.net/docs/api/pterodactyl/v1/ (example: https://pterodactyl.app)

### Functions
# ConsoleCmdAsync(string server, string command)
server is the server ID
command is the command to sent to the console.

# ServerPowerAsync(string server, string power)
server is the server ID
power is the state (Start, Stop, Restart, Kill)

# ServerResourcesAsync(string server)
server is the server ID. 
Returns a string which can be accessed by `PteroVar.ServerResponseMessage`. It is a JSON string so you will need to handle the JSON however you wish.

# GetFileContents(string server, string file)
server is the server ID
file is the file required.
Returns full contents of the message through `PteroVar.ServerResponseMessage`

# WriteFile(string server, string file, string contents)
server is the server ID
file is the file required
contents is the contents to be put into the file in question. Will overwrite existing content.

# ReinstallServer(string server)
server is the server ID.
Issues the command to reinstall the server.

# CreateBackup(string server)
server is the server ID
Tells the server to create a backup.

# GetWebSocketURI(string server)
server is the server ID
Requests the URI for use with a web-socket to communicate with the server. See Pterodactyl API for WS usage. URI can be accessed via `PteroVar.ServerResponseMessage`
