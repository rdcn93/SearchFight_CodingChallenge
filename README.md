# SearchFight - Coding Challenge

To determine the popularity of programming languages on the internet we want to you to write an application that queries search engines and compares how many results they return.

### Example
* C:\> searchfight.exe .net java
* .net: Google: 4450000000 MSN Search: 12354420
* java: Google: 966000000 MSN Search: 94381485
* Google winner: .net
* MSN Search winner: java
* Total winner: .net

| Considerations |
| ------ |
| The application should be able to receive a variable amount of words |
| The application should support quotation marks to allow searching for terms with spaces (e.g. searchfight.exe “java script”) |
| The application should support at least two search engines |

### Test from Visual Studio

1. Right click to the Project "SearchFight_CodingChallenge"


![alt text](https://i.ibb.co/ZGTszL1/2020-10-19-07-38-40.png)


2. Click to Properties option


![alt text](https://i.ibb.co/rvRsyq6/2020-10-19-07-46-14.png)


3. Click to Debug


![alt text](https://i.ibb.co/gwr2mwB/2020-10-19-07-32-53.png)


4. Add arguments to Command Line Arguments textbox

![alt text](https://i.ibb.co/HTKMVVF/2020-10-19-07-43-57.png)


5. Click in Run button

![alt text](https://i.ibb.co/R4pJtKR/2020-10-19-07-45-05.png)

### Console App Result

![alt text](https://i.ibb.co/Ws7FDy0/2020-10-19-07-47-53.png)


### References
* https://developers.google.com/custom-search/v1/using_rest
* https://developers.google.com/custom-search/v1/introduction#identify_your_application_to_google_with_api_key
* https://developers.google.com/custom-search/v1/reference/rest/v1/cse/list
* https://azure.microsoft.com/en-us/try/cognitive-services/my-apis/?apiSlug=search-api-v7
* https://docs.microsoft.com/en-us/azure/cognitive-services/bing-custom-search/call-endpoint-csharp
* https://blogs.bing.com/search-quality-insights/2017-11/Start-exploring-Bing-Search-APIs-in-under-5-minutes
