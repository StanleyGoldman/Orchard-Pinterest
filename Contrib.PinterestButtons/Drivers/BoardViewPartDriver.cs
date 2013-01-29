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
            base.Exporting(part, context);
        }

        protected override void Importing(PinterestBoardViewPart part, ImportContentContext context)
        {
            base.Importing(part, context);
        }
    }
}