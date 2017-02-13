using CoreServiceFramework.CoreServiceFramework;
using ElasticDataToTridion.Common;
using ElasticDataToTridion.Common.Model;
using ElasticDataToTridion.TridionObjects;
using Nest;
using System;
using System.Configuration;
using System.Net;

namespace ElasticDataToTridion.Client
{
    class Program
    {
        public static Uri node;
        public static ConnectionSettings settings;
        public static ICoreServiceFrameworkContext coreService = null;
        static void Main(string[] args)
        {
            node = new Uri("http://localhost:9200");

            settings = new ConnectionSettings(node);
            Logger.Logger.WriteLog(Logger.Logger.LogLevel.INFO, "ConnectionSettings");
            settings.DefaultIndex("fromelasticstoweb8");
            var client = new Nest.ElasticClient(settings);
            Logger.Logger.WriteLog(Logger.Logger.LogLevel.INFO, "Elastic Client" + client.ToString());
            Logger.Logger.WriteLog(Logger.Logger.LogLevel.INFO, "Component ");
            //var news = new ESNews
            //{
            //    Title = "About SDL WEB 8",
            //    Description = "SDL recently released the latest version of their web content management SDL WEB 8 an all-in-one global Web Experience Management solution",
            //    shortTitle = "About SDL WEB 8",
            //    authorName = "SDL",
            //    aboutAuthor = "Bring your brand to the world & the world to your brand with the industry leader in Language Translation & Content Management solutions. ",
            //    Category = "WEB 8",
            //    relasedDate = DateTime.Now,
            //    imageUrl = "Images/SDL.png"


            //};
            //var response = client.Index(news);
            var searchResults = client.Search<Esnews>(s => s
                                .Index("fromelasticstoweb8")
                                .Type("esnews")
                                .From(0)
                                .Size(10)
                                .Query(q => q.MatchAll())
                                );
            if (searchResults.Documents.Count > 0)
            {
                coreService = CoreServiceFactory.GetCoreServiceContext(new Uri(ConfigurationManager.AppSettings["CoreServiceURL"].ToString()), new NetworkCredential(ConfigurationManager.AppSettings["UserName"].ToString(), ConfigurationManager.AppSettings["Password"].ToString(), ConfigurationManager.AppSettings["Domain"].ToString()));
            }
            foreach (Esnews hit in searchResults.Documents)
            {
                try
                {
                    string serializeXml = "";
                    bool bln = TransformObjectToXml.Serialize<Esnews>(hit, ref serializeXml);
                    string xml = serializeXml;
                    string tcmuri = TridionComponent.GenerateComponent(coreService, xml, SetPublication.Publication(ConfigurationManager.AppSettings["FolderLocation"].ToString(), ConfigurationManager.AppSettings["SchemaID"].ToString()), EnumType.SchemaType.Component, ConfigurationManager.AppSettings["FolderLocation"].ToString(), hit.Title, hit.Title);
                    
                }
                catch(Exception ex)
                {
                    Logger.Logger.WriteLog(Logger.Logger.LogLevel.ERROR, "Component " +ex.Message);

                }
            }

        }
    }
}

