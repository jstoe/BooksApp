using Newtonsoft.Json;
using System.Collections.Generic;

namespace BooksApp.Data
{
    // Query

    public class ImageLinks
    {
        [JsonProperty("smallThumbnail")]
        public string SmallThumbnail { get; set; }
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }
    }

    public class BookInfo
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("authors")]
        public List<string> Authors { get; set; }
        public string AuthorInfo {
            get
            {
                if (Authors == null || Authors.Count == 0) return "n.n.";
                return string.Join(", ", Authors);
            }
        }
        [JsonProperty("imageLinks")]
        public ImageLinks ImageLinks { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class Book
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("volumeInfo")]
        public BookInfo Info { get; set; }
    }

    public class BookQuery
    {
        [JsonProperty("totalItems")]
        public int Count { get; set; }
        [JsonProperty("items")]
        public List<Book> Books { get; set; }
    }


}
