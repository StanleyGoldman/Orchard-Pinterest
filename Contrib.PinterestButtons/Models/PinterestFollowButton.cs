using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;
using Orchard.Environment.Extensions;

namespace Contrib.PinterestButtons.Models
{
    [OrchardFeature("Contrib.PinterestButtons")]
    public class PinterestFollowButtonRecord : ContentPartRecord
    {
        public virtual string Username { get; set; }
        public virtual string Name { get; set; }

        public PinterestFollowButtonRecord()
        {
            Username = null;
            Name = null;
        }
    }

    [OrchardFeature("Contrib.PinterestButtons")]
    public class PinterestFollowButtonPart : ContentPart<PinterestFollowButtonRecord>
    {
        [Required]
        public string Username
        {
            get { return Record.Username; }
            set { Record.Username = value; }
        }

        [Required]
        public string Name
        {
            get { return Record.Name; }
            set { Record.Name = value; }
        }
    }
}