using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.DTOs.ISBNDB
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    /// <summary>
    /// This model is generated purely to perfectly fit the API response from Open Library, to help me filter the information I receive.
    /// Created using https://json2csharp.com/
    /// </summary>
    public class BookEntries
    {
        public string title { get; set; }
        public string image { get; set; }
        public string title_long { get; set; }
        public object date_published { get; set; }
        public string publisher { get; set; }
        public string synopsis { get; set; }
        public List<string> subjects { get; set; }
        public List<string> authors { get; set; }
        public string isbn13 { get; set; }
        public string binding { get; set; }
        public string isbn { get; set; }
        public string isbn10 { get; set; }
        public string language { get; set; }
        public int pages { get; set; }
        public string edition { get; set; }
        public string dimensions { get; set; }
        public DimensionsStructured dimensions_structured { get; set; }
        public double? msrp { get; set; }
    }

    public class DimensionsStructured
    {
        public Length length { get; set; }
        public Width width { get; set; }
        public Weight weight { get; set; }
        public Height height { get; set; }
    }

    public class Height
    {
        public double value { get; set; }
        public string unit { get; set; }
    }

    public class Length
    {
        public double value { get; set; }
        public string unit { get; set; }
    }

    public class ISBNDBBookDTO
    {
        public int total { get; set; }
        public List<BookEntries> books { get; set; }
    }

    public class Weight
    {
        public double value { get; set; }
        public string unit { get; set; }
    }

    public class Width
    {
        public double value { get; set; }
        public string unit { get; set; }
    }


}
