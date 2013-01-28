using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;
using Orchard.Environment.Extensions;

namespace Contrib.PinterestButtons.Models
{
    [OrchardFeature("Contrib.PinterestButtons")]
    public class PinItButtonRecord : ContentPartRecord
    {
        public virtual string PinCount { get; set; }
        public virtual bool AnyImage { get; set; }
        public virtual string Url { get; set; }
        public virtual string Image { get; set; }
        public virtual string Description { get; set; }

        public PinItButtonRecord()
        {
            PinCount = "standard";
            AnyImage = false;
            Url = "like";
            Description = "arial";
            Image = "arial";
        }
    }

    [OrchardFeature("Contrib.PinterestButtons")]
    public class PinItButtonPart : ContentPart<PinItButtonRecord>
    {
        [Required]
        public string PinCount
        {
            get { return Record.PinCount; }
            set { Record.PinCount = value; }
        }

        public bool AnyImage
        {
            get { return Record.AnyImage; }
            set { Record.AnyImage = value; }
        }

        public string Url
        {
            get { return Record.Url; }
            set { Record.Url = value; }
        }

        public string Image
        {
            get { return Record.Image; }
            set { Record.Image = value; }
        }

        public string Description
        {
            get { return Record.Description; }
            set { Record.Description = value; }
        }
    }
}