using System;
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
            context.Element(part.PartDefinition.Name).SetAttributeValue("AnyImage", part.AnyImage);
            context.Element(part.PartDefinition.Name).SetAttributeValue("Description", part.Description);
            context.Element(part.PartDefinition.Name).SetAttributeValue("Image", part.Image);
            context.Element(part.PartDefinition.Name).SetAttributeValue("PinCount", part.PinCount);
            context.Element(part.PartDefinition.Name).SetAttributeValue("Url", part.Url);
        }

        protected override void Importing(PinterestPinItButtonPart part, ImportContentContext context)
        {
            part.AnyImage = Convert.ToBoolean(context.Attribute(part.PartDefinition.Name, "AnyImage"));
            part.Description = context.Attribute(part.PartDefinition.Name, "Description");
            part.Image = context.Attribute(part.PartDefinition.Name, "Image");
            part.PinCount = context.Attribute(part.PartDefinition.Name, "PinCount");
            part.Url = context.Attribute(part.PartDefinition.Name, "Url");
        }
    }
}