# MyJohnDeereAPI-OAuth-CS-Client
Sample C# application for My Johndeere API

## System Requirements
 - Microsoft .Net Framework 4.6+ and Microsoft Visual Studio 2017+ (community or higher)
 - Or, Mono 5.0+ and some IDE with NuGet support (tested with MonoDevelop)

## Setup and Run
<ul>
  <li>Update Program.cs with appId and secret from developer.deere.com.</li>
  <li>Run Program.cs file to generate OAuth tokens.</li>
  <li>OAuth tokens are valid for one year. To continue experimenting with the sample code:
     <ul>
      <li>Paste your appId, secret, oAuth token, and token secret into ApiCredentials.cs</li>
      <li>Comment or delete the call to oauthWorkflowExample.Authenticate(clientKey, clientSecret) in Program.cs, so you don't have to repeatedly generate new oAuth tokens.</li>                       
      <li>Add a `var apiCredentials = new ApiCredentials();` line to Program.cs to reuse the credentials you pasted in ApiCredentials.cs</li>
      <li>Note that in the real world you'd want to store these oAuth credentials somewhere (probably a database), and include logic to generate new oAuth credentials once you start getting HTTP 401 (Unauthorized) responses from the Deere API's.</li>
    </ul>
  </li>
</ul>
  
  

