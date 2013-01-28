using Contrib.PinterestButtons.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Environment.Extensions;

namespace Contrib.PinterestButtons.Handlers
{
    [OrchardFeature("Contrib.PinterestButtons")]
    public class FollowButtonHandler : ContentHandler
    {
        public FollowButtonHandler(IRepository<PinterestFollowButtonRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}