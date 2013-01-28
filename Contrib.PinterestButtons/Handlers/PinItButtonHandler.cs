using Contrib.PinterestButtons.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Environment.Extensions;

namespace Contrib.PinterestButtons.Handlers
{
    [OrchardFeature("Contrib.PinterestButtons")]
    public class PinItButtonHandler : ContentHandler
    {
        public PinItButtonHandler(IRepository<PinItButtonRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}