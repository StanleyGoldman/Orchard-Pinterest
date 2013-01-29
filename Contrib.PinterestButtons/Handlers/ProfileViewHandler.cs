using Contrib.PinterestButtons.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Environment.Extensions;

namespace Contrib.PinterestButtons.Handlers
{
    [OrchardFeature("Contrib.PinterestButtons")]
    public class ProfileViewHandler : ContentHandler
    {
        public ProfileViewHandler(IRepository<PinterestProfileViewRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}