using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;
using Orchard.Environment.Extensions;

namespace Contrib.PinterestButtons.Models {
    
    [OrchardFeature("Contrib.PinterestButtons")]
    public class PinItButtonPartRecord : ContentPartRecord
    {
        public virtual string PinCount { get; set; }
        public virtual bool AnyImage { get; set; }
        public virtual string Url { get; set; }
        public virtual string Image { get; set; }
        public virtual string Description { get; set; }

        public PinItButtonPartRecord()
            : base()
        {
            PinCount = "standard";
            AnyImage = false;
            Url = "like";
            Description = "arial";
            Image = "arial";
        }
    }

    public class PinItButtonPart : ContentPart {}
}