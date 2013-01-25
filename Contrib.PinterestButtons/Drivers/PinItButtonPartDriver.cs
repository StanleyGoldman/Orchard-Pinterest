using Contrib.PinterestButtons.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;
using Orchard.Environment.Extensions;

namespace Contrib.PinterestButtons.Drivers
{
    [OrchardFeature("Contrib.PinterestButtons")]
    public class PinItButtonPartDriver : ContentPartDriver<PinItButtonPart>
    {
        protected override string Prefix
        {
            get { return "PinItButton"; }
        }

        protected override DriverResult Display(PinItButtonPart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_PinItButton",
                () => shapeHelper.Parts_FacebookLikeButton());
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
//            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }

        protected override void Exporting(PinItButtonPart part, ExportContentContext context)
        {
            base.Exporting(part, context);
//
//            context.Element(part.PartDefinition.Name).SetAttributeValue("EnableSendButton", part.EnableSendButton);
//            context.Element(part.PartDefinition.Name).SetAttributeValue("LayoutStyle", part.LayoutStyle);
//            context.Element(part.PartDefinition.Name).SetAttributeValue("ShowFaces", part.ShowFaces);
//            context.Element(part.PartDefinition.Name).SetAttributeValue("VerbToDisplay", part.VerbToDisplay);
//            context.Element(part.PartDefinition.Name).SetAttributeValue("Font", part.Font);
        }

        protected override void Importing(PinItButtonPart part, ImportContentContext context)
        {
            base.Importing(part, context);
//
//            var partName = part.PartDefinition.Name;
//            
//            context.ImportAttribute(partName, "EnableSendButton", value => part.EnableSendButton = bool.Parse(value));
//            context.ImportAttribute(partName, "LayoutStyle", value => part.LayoutStyle = value);
//            context.ImportAttribute(partName, "ShowFaces", value => part.ShowFaces = bool.Parse(value));
//            context.ImportAttribute(partName, "VerbToDisplay", value => part.VerbToDisplay = value);
//            context.ImportAttribute(partName, "Font", value => part.Font = value);
        }
    }
}