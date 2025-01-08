using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.DTOs.OpenLibrary
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class OLAuthor
    {
        public string key { get; set; }
    }

    public class Classifications
    {
    }

    public class Contributor
    {
        public string role { get; set; }
        public string name { get; set; }
    }

    public class Created
    {
        public string type { get; set; }
        public DateTime value { get; set; }
    }

    public class Entry
    {
        public Type type { get; set; }
        public List<OLAuthor> authors { get; set; }
        public List<string> dewey_decimal_class { get; set; }
        public List<string> isbn_13 { get; set; }
        public List<Language> languages { get; set; }
        public int number_of_pages { get; set; }
        public string publish_date { get; set; }
        public List<string> publishers { get; set; }
        public List<string> source_records { get; set; }
        public string title { get; set; }
        public string weight { get; set; }
        public string full_title { get; set; }
        public List<Work> works { get; set; }
        public string key { get; set; }
        public int latest_revision { get; set; }
        public int revision { get; set; }
        public Created created { get; set; }
        public LastModified last_modified { get; set; }
        public Identifiers identifiers { get; set; }
        public Classifications classifications { get; set; }
        public List<string> publish_places { get; set; }
        public string copyright_date { get; set; }
        public string edition_name { get; set; }
        public string pagination { get; set; }
        public List<int> covers { get; set; }
        public List<string> lccn { get; set; }
        public List<string> lc_classifications { get; set; }
        public List<string> oclc_numbers { get; set; }
        public object description { get; set; }
        public List<string> isbn_10 { get; set; }
        public List<string> local_id { get; set; }
        public List<string> subjects { get; set; }
        public string physical_format { get; set; }
        public object notes { get; set; }
        public List<Contributor> contributors { get; set; }
        public List<TranslatedFrom> translated_from { get; set; }
        public string translation_of { get; set; }
        public FirstSentence first_sentence { get; set; }
        public string ocaid { get; set; }
        public string publish_country { get; set; }
        public List<string> work_titles { get; set; }
        public List<string> other_titles { get; set; }
        public List<string> series { get; set; }
        public List<string> contributions { get; set; }
        public List<string> subject_people { get; set; }
        public List<string> subject_places { get; set; }
        public string by_statement { get; set; }
        public string physical_dimensions { get; set; }
        public List<TableOfContent> table_of_contents { get; set; }
        public string subtitle { get; set; }
    }

    public class FirstSentence
    {
        public string type { get; set; }
        public string value { get; set; }
    }

    public class Identifiers
    {
        public List<string> amazon { get; set; }
        public List<string> better_world_books { get; set; }
        public List<string> annas_archive { get; set; }
    }

    public class Language
    {
        public string key { get; set; }
    }

    public class LastModified
    {
        public string type { get; set; }
        public DateTime value { get; set; }
    }

    public class Links
    {
        public string self { get; set; }
        public string work { get; set; }
        public string next { get; set; }
    }

    public class TableOfContent
    {
        public int level { get; set; }
        public string label { get; set; }
        public string title { get; set; }
        public string pagenum { get; set; }
    }

    public class TranslatedFrom
    {
        public string key { get; set; }
    }

    public class Type
    {
        public string key { get; set; }
    }

    public class Work
    {
        public string key { get; set; }
    }


}
