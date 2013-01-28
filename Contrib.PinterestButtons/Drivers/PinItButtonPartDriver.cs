using Contrib.PinterestButtons.Models;
using Orchard;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;
using Orchard.Environment.Extensions;

namespace Contrib.PinterestButtons.Drivers
{
    [OrchardFeature("Contrib.PinterestButtons")]
    public class PinItButtonPartDriver : ContentPartDriver<PinterestPinItButtonPart>
    {
        protected override DriverResult Display(PinterestPinItButtonPart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_PinterestPinItButton",
                () => shapeHelper.Parts_PinterestPinItButton(
                     PinCount: part.PinCount,
                     AnyImage: part.AnyImage,
                     Url: part.Url,
                     Image: part.Image,
                     Description: part.Description
                    ));
        }

        // GET
        protected override DriverResult Editor(PinterestPinItButtonPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_PinterestPinItButton_Edit",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts/PinterestPinItButton",
                    Model: part,
                    Prefix: Prefix));
        }

        // POST
        protected override DriverResult Editor(PinterestPinItButtonPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }

        protected override void Exporting(PinterestPinItButtonPart part, ExportContentContext context)
        {
            base.Exporting(part, context);
        }

        protected override void Importing(PinterestPinItButtonPart part, ImportContentContext context)
        {
            base.Importing(part, context);
        }
    }
}