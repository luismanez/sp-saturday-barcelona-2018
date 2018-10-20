# Demo snippets

# Demo 1
```cs
var graphClient = new GraphServiceClient("https://graph.microsoft.com/v1.0", delegateAuthProvider);
```

```cs
var delegateAuthProvider = new DelegateAuthenticationProvider((requestMessage) =>
            {
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", token);

                return Task.FromResult(0);
            });
```

```cs
var groups = await graphClient.Groups.Request()
                .Top(10)
                .OrderBy("displayName")
                .Select("id, visibility, createdDateTime, displayName")
                .GetAsync();
```

```cs
groups = await graphClient.Groups.Request()
                .Filter("startsWith('yam', displayName)")                
                .Select("id, visibility, createdDateTime, displayName")                
                .GetAsync();
```

# Demo 2

```cs
var httpClient = new HttpClient();
httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
```

```cs
var response = await httpClient.GetAsync("https://graph.microsoft.com/v1.0/me?$select=Id,DisplayName,JobTitle,GivenName,Surname,Mail");
```