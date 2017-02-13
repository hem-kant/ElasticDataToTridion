using ElasticDataToTridion.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticDataToTridion.Common.Interface
{
    public interface ISearchService<T>
    {
        SearchResult<T> Search(string query, int page, int pageSize);

        SearchResult<Person> SearchByCategory(string query, IEnumerable<string> tags, int page, int pageSize);

        IEnumerable<string> Autocomplete(string query, int count);
    }
}
