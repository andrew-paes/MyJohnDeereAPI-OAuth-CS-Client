# MyJohnDeereAPI-OAuth-CS-Client
Sample C# application for My Johndeere API

## System Requirments
Microsoft .Net Framework 4.6.2(Last tested) and Microsoft Visual Studio C# (community or higher)

## Setup and Run
<ul>
  <li>Update ApiCredentials.cs with appId and secret from developer.deere.com.</li>
  <li>Run Program.cs file to generate OAuth tokens. Update the generated tokens in ApiCredentials.cs "TOKEN" variable</li>
  <li> To test file download comment the below lines: 
     <ul>
      <li>of.retrieveApiCatalogToEstablishOAuthProviderDetails();</li>
      <li>of.getRequestToken();</li>                       
      <li>of.authorizeRequestToken();</li>                          
      <li>of.exchangeRequestTokenForAccessToken();</li>       
    </ul>
  </li>
  <li>Then uncomment these lines and run the Program.cs file to download a file.
  <ul>
    <li>Download dn = new Download();</li>
    <li>dn.retrieveApiCatalog();</li>
    </ul>
  </li>
</ul>
  
  

