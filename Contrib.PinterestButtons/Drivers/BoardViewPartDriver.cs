using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Contrib.PinterestButtons.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;
using Orchard.Environment.Extensions;

namespace Contrib.PinterestButtons.Drivers
{
    [OrchardFeature("Contrib.PinterestButtons")]
    public class BoardViewPartDriver : ContentPartDriver<PinterestBoardViewPart>
    {
        protected override DriverResult Display(PinterestBoardViewPart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_PinterestBoardView",
                () => shapeHelper.Parts_PinterestBoardView(
                     Username: part.Username,
                     Board: part.Board,
                     ImageWidth: part.ImageWidth,
                     BoardHeight: part.BoardHeight,
                     BoardWidth: part.BoardWidth
                    ));
        }

        // GET
        protected override DriverResult Editor(PinterestBoardViewPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_PinterestBoardView_Edit",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts/PinterestBoardView",
                    Model: part,
                    Prefix: Prefix));
        }

        // POST
        protected override DriverResult Editor(PinterestBoardViewPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }

        protected override void Exporting(PinterestBoardViewPart part, ExportContentContext context)
        {
            context.Element(part.PartDefinition.Name).SetAttributeValue("Username", part.Username);
            context.Element(part.PartDefinition.Name).SetAttributeValue("Board", part.Board);
            context.Element(part.PartDefinition.Name).SetAttributeValue("ImageWidth", part.ImageWidth);
            context.Element(part.PartDefinition.Name).SetAttributeValue("BoardHeight", part.BoardHeight);
            context.Element(part.PartDefinition.Name).SetAttributeValue("BoardWidth", part.BoardWidth);
        }

        protected override void Importing(PinterestBoardViewPart part, ImportContentContext context)
        {
            part.Username = context.Attribute(part.PartDefinition.Name, "Username");
            part.Board = context.Attribute(part.PartDefinition.Name, "Board");
            part.ImageWidth = Convert.ToInt32(context.Attribute(part.PartDefinition.Name, "ImageWidth"));
            part.BoardHeight = Convert.ToInt32(context.Attribute(part.PartDefinition.Name, "BoardHeight"));
            part.BoardWidth = context.Attribute(part.PartDefinition.Name, "BoardWidth");
        }
    }
}