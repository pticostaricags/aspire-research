using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspireResearch
{
    public static class AzureVideoIndexerResourceExtensions
    {
        public static IDistributedApplicationBuilder AddAzureVideoIndexer(
            this IDistributedApplicationBuilder builder,
            string name)
        {
            var storageAccountNameParam = builder.AddParameter("storageAccountName");
            var videoIndexerAccountNameParam = builder.AddParameter("videoIndexerAccountName");
            var videoIndexer = builder.AddBicepTemplate(name, "../infra/azure-video-indexer/videoindexer.bicep")
                .WithParameter("storageAccountName", storageAccountNameParam)
                .WithParameter("videoIndexerAccountName", videoIndexerAccountNameParam);
            return builder;
        }
    }
}
