using Newtonsoft.Json;
using SearchFight_CodingChallenge.Models;
using System.Configuration;
using System.IO;
using System.Net;

namespace SearchFight_CodingChallenge.Services
{
    public class SearchService : ISearchService
    {
        public SearchedWord SearchWord(string word)
        {
            SearchedWord sWord = new SearchedWord();
            sWord.name = word;
            sWord.googleResults = SearchGoogle(word);
            sWord.bingResults = SearchBing(word);

            return sWord;
        }

        public int SearchGoogle(string word)
        {
            int total = 0;

            string googleUrl = ConfigurationManager.AppSettings[Constants.GOOGLE_SEARCH_URL];
            string googleSearchEngine = ConfigurationManager.AppSettings[Constants.GOOGLE_SEARCH_ENGINE];
            string googleApiKey = ConfigurationManager.AppSettings[Constants.GOOGLE_SEARCH_KEY];

            string fullUrl = string.Format(googleUrl, googleApiKey, googleSearchEngine, word);

            using (var httpWebResponse = (HttpWebResponse)WebRequest.Create(fullUrl).GetResponse())
            {
                GoogleSearchResult searchResult = DeserializedObject<GoogleSearchResult>(httpWebResponse);
                total = searchResult.SearchInformation.TotalResults != 0 ? searchResult.SearchInformation.TotalResults : total;
            }

            return total;
        }

        public int SearchBing(string word)
        {
            int total = 0;

            string bingWebSearchApiKeyUrl = ConfigurationManager.AppSettings[Constants.BING_API_URL];
            string bingWebSearchApiKey = ConfigurationManager.AppSettings[Constants.BING_SEARCH_KEY];
            string bingWebSearchApiKeyHeaderName = ConfigurationManager.AppSettings[Constants.BING_SEARCH_KEY_HEADER_NAME];

            var webRequest = WebRequest.Create(string.Format(bingWebSearchApiKeyUrl, word));
            webRequest.Headers[bingWebSearchApiKeyHeaderName] = bingWebSearchApiKey;

            using (var httpWebResponse = (HttpWebResponse)webRequest.GetResponse())
            {
                BingSearchResult searchResult = DeserializedObject<BingSearchResult>(httpWebResponse);
                total = searchResult.webPages.totalEstimatedMatches != 0 ? searchResult.webPages.totalEstimatedMatches : total;
            }

            return total;
        }

        public static T DeserializedObject<T>(HttpWebResponse httpWebResponse) where T : class
        {
            T deserializedObject = null;

            using (var streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                string jsonResult = streamReader.ReadToEnd();
                deserializedObject = JsonConvert.DeserializeObject<T>(jsonResult);
            }

            return deserializedObject;
        }
    }
}
