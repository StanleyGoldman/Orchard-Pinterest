using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;
using Orchard.Environment.Extensions;

namespace Contrib.PinterestButtons.Models
{
    [OrchardFeature("Contrib.PinterestButtons")]
    public class PinterestProfileViewRecord : ContentPartRecord
    {
        public virtual string Username { get; set; }
        public virtual int ImageWidth { get; set; }
        public virtual int BoardHeight { get; set; }
        public virtual string BoardWidth { get; set; }

        public PinterestProfileViewRecord()
        {
            Username = null;
            ImageWidth = 92;
            BoardHeight = 175;
            BoardWidth = "auto";
        }
    }

    [OrchardFeature("Contrib.PinterestButtons")]
    public class PinterestProfileViewPart : ContentPart<PinterestProfileViewRecord>
    {
        [Required]
        public string Username
        {
            get { return Record.Username; }
            set { Record.Username = value; }
        }

        public int ImageWidth
        {
            get { return Record.ImageWidth; }
            set { Record.ImageWidth = value; }
        }

        public int BoardHeight
        {
            get { return Record.BoardHeight; }
            set { Record.BoardHeight = value; }
        }

        public string BoardWidth
        {
            get { return Record.BoardWidth; }
            set { Record.BoardWidth = value; }
        }
    }
}