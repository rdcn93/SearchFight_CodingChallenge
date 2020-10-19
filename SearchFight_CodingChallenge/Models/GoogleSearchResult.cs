using System;
using System.Collections.Generic;
using System.Text;

namespace SearchFight_CodingChallenge.Models
{
    public class GoogleSearchResult
    {
        public SearchInformation SearchInformation { get; set; }
    }

    public class SearchInformation
    {
        public int TotalResults { get; set; }
        public string FormattedTotalResults { get; set; }
    }
}
