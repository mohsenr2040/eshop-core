using System;
using System.Collections.Generic;
using System.Text;

namespace eshop.Application.Services.MongoDb
{
    public interface IeshopCommentsSettings
    {
        string CommentsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }

    public class eshopCommentsSettings : IeshopCommentsSettings
    {
        public string CommentsCollectionName { get ; set; }
        public string ConnectionString { get ; set; }
        public string DatabaseName { get; set ; }
    }
}
