namespace SearchFight_CodingChallenge.Models
{
    public class SearchedWord
    {
        public string name { get; set; }
        public int googleResults { get; set; }
        public int bingResults { get; set; }
        public int total => googleResults + bingResults;
    }
}
