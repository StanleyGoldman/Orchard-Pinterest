﻿using System;
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
    public class ProfileViewPartDriver : ContentPartDriver<PinterestProfileViewPart>
    {
        protected override DriverResult Display(PinterestProfileViewPart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_PinterestProfileView",
                () => shapeHelper.Parts_PinterestProfileView(
                     Username: part.Username,
                     ImageWidth: part.ImageWidth,
                     BoardHeight: part.BoardHeight,
                     BoardWidth: part.BoardWidth
                    ));
        }

        // GET
        protected override DriverResult Editor(PinterestProfileViewPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_PinterestProfileView_Edit",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts/PinterestProfileView",
                    Model: part,
                    Prefix: Prefix));
        }

        // POST
        protected override DriverResult Editor(PinterestProfileViewPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }

        protected override void Exporting(PinterestProfileViewPart part, ExportContentContext context)
        {
            context.Element(part.PartDefinition.Name).SetAttributeValue("Username", part.Username);
            context.Element(part.PartDefinition.Name).SetAttributeValue("ImageWidth", part.ImageWidth);
            context.Element(part.PartDefinition.Name).SetAttributeValue("BoardHeight", part.BoardHeight);
            context.Element(part.PartDefinition.Name).SetAttributeValue("BoardWidth", part.BoardWidth);
        }

        protected override void Importing(PinterestProfileViewPart part, ImportContentContext context)
        {
            part.Username = context.Attribute(part.PartDefinition.Name, "Username");
            part.ImageWidth = Convert.ToInt32(context.Attribute(part.PartDefinition.Name, "ImageWidth"));
            part.BoardHeight = Convert.ToInt32(context.Attribute(part.PartDefinition.Name, "BoardHeight"));
            part.BoardWidth = context.Attribute(part.PartDefinition.Name, "BoardWidth");
        }
    }
}