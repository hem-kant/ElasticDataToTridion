using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ElasticDataToTridion.Common.Model
{
    [XmlRoot(ElementName = "esnews", Namespace = "http://www.sdl.com/web/schemas/core")]
    public class Esnews
    {
        [XmlElement(ElementName = "Title", Namespace = "http://www.sdl.com/web/schemas/core")]
        public string Title { get; set; }
        [XmlElement(ElementName = "Description", Namespace = "http://www.sdl.com/web/schemas/core")]
        public string Description { get; set; }
        [XmlElement(ElementName = "shortTitle", Namespace = "http://www.sdl.com/web/schemas/core")]
        public string ShortTitle { get; set; }
        [XmlElement(ElementName = "authorName", Namespace = "http://www.sdl.com/web/schemas/core")]
        public string AuthorName { get; set; }
        [XmlElement(ElementName = "aboutAuthor", Namespace = "http://www.sdl.com/web/schemas/core")]
        public string AboutAuthor { get; set; }
        [XmlElement(ElementName = "Category", Namespace = "http://www.sdl.com/web/schemas/core")]
        public string Category { get; set; }
        [XmlElement(ElementName = "relasedDate", Namespace = "http://www.sdl.com/web/schemas/core")]
        public DateTime? RelasedDate { get; set; }
        [XmlElement(ElementName = "imageUrl", Namespace = "http://www.sdl.com/web/schemas/core")]
        public string ImageUrl { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
    }
}
