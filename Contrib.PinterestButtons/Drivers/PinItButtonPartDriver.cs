using Contrib.PinterestButtons.Models;
using Orchard;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;
using Orchard.Environment.Extensions;

namespace Contrib.PinterestButtons.Drivers
{
    [OrchardFeature("Contrib.PinterestButtons")]
    public class PinItButtonPartDriver : ContentPartDriver<PinItButtonPart>
    {
        protected override DriverResult Display(PinItButtonPart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_PinItButton",
                () => shapeHelper.Parts_PinItButton(
                     PinCount: part.PinCount,
                     AnyImage: part.AnyImage,
                     Url: part.Url,
                     Image: part.Image,
                     Description: part.Description
                    ));
        }

        // GET
        protected override DriverResult Editor(PinItButtonPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_PinItButton_Edit",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts/PinItButton",
                    Model: part,
                    Prefix: Prefix));
        }

        // POST
        protected override DriverResult Editor(PinItButtonPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }

        protected override void Exporting(PinItButtonPart part, ExportContentContext context)
        {
            base.Exporting(part, context);
        }

        protected override void Importing(PinItButtonPart part, ImportContentContext context)
        {
            base.Importing(part, context);
        }
    }
}