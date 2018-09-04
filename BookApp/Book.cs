using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Web.Script.Serialization;

namespace BookApp
{
    public class Book
    {
        private string _Name;
        private string _Author;
        private string _ReleaseDate;
        
        public string Name { get; set; }
        public string Author { get; set; }
        public string ReleaseDate { get; set; }

        public Book() { }
        public Book(string name, string author, string releasedate)
        {
            Name = name;
            Author = author;
            ReleaseDate = releasedate;
        }
        public string ToXML()
        {
            using (StringWriter sw = new StringWriter())
            using (XmlTextWriter tw = new XmlTextWriter(sw))
            {
                XmlSerializer serializer = new XmlSerializer(GetType());
                serializer.Serialize(tw, this);
                return sw.ToString();
            }
        }

        public static Book FromXML(string xmlText)
        {
            using (var stringReader = new StringReader(xmlText))
            {
                var serializer = new XmlSerializer(typeof(Book));
                return serializer.Deserialize(stringReader) as Book;
            }
        }

        public string ToJSON()
        {
            return new JavaScriptSerializer().Serialize(this);
        }

        public static Book FromJSON(string jsondata)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            Book blogObject = js.Deserialize<Book>(jsondata);
            return blogObject;
        }

        public void Show()
        {
            Console.WriteLine("Book Name - {0}, Author - {1}, Release Date - {2}",Name,Author,ReleaseDate);
        }

    }
}
