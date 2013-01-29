using Contrib.PinterestButtons.Models;
using Orchard;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;
using Orchard.Environment.Extensions;

namespace Contrib.PinterestButtons.Drivers
{
    [OrchardFeature("Contrib.PinterestButtons")]
    public class FollowButtonPartDriver : ContentPartDriver<PinterestFollowButtonPart>
    {
        protected override DriverResult Display(PinterestFollowButtonPart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_PinterestFollowButton",
                () => shapeHelper.Parts_PinterestFollowButton(
                     Name: part.Name,
                     Username: part.Username
                    ));
        }

        // GET
        protected override DriverResult Editor(PinterestFollowButtonPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_PinterestFollowButton_Edit",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts/PinterestFollowButton",
                    Model: part,
                    Prefix: Prefix));
        }

        // POST
        protected override DriverResult Editor(PinterestFollowButtonPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }

        protected override void Exporting(PinterestFollowButtonPart part, ExportContentContext context)
        {
            context.Element(part.PartDefinition.Name).SetAttributeValue("Username", part.Username);
            context.Element(part.PartDefinition.Name).SetAttributeValue("Name", part.Name);
        }

        protected override void Importing(PinterestFollowButtonPart part, ImportContentContext context)
        {
            part.Username = context.Attribute(part.PartDefinition.Name, "Username");
            part.Name = context.Attribute(part.PartDefinition.Name, "Name");
        }
    }
}