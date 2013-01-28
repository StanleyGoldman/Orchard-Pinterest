using System;
using System.Collections.Generic;
using System.Data;
using Contrib.PinterestButtons.Models;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

namespace Contrib.PinterestButtons
{
    public class Migrations : DataMigrationImpl
    {
        public int Create()
        {
            // Creating table PinItButtonRecord
            SchemaBuilder.CreateTable("PinterestPinItButtonRecord", table => table
                .ContentPartRecord()
                .Column("PinCount", DbType.String)
                .Column("AnyImage", DbType.Boolean)
                .Column("Url", DbType.String)
                .Column("Image", DbType.String)
                .Column("Description", DbType.String)
            );

            ContentDefinitionManager.AlterPartDefinition(
                typeof(PinterestPinItButtonPart).Name, cfg => cfg.Attachable());

            // Creating table FollowButtonRecord
            SchemaBuilder.CreateTable("PinterestFollowButtonRecord", table => table
                .ContentPartRecord()
                .Column("Username", DbType.String)
                .Column("Name", DbType.String)
            );

            ContentDefinitionManager.AlterPartDefinition(
                typeof(PinterestFollowButtonPart).Name, cfg => cfg.Attachable());

            return 1;
        }

        public int UpdateFrom1()
        {
            ContentDefinitionManager.AlterTypeDefinition("PinterestPinItButtonWidget", cfg => cfg
                .WithPart("PinterestPinItButtonPart")
                .WithPart("WidgetPart")
                .WithPart("CommonPart")
                .WithSetting("Stereotype", "Widget"));

            ContentDefinitionManager.AlterTypeDefinition("PinterestFollowButtonWidget", cfg => cfg
                .WithPart("PinterestFollowButtonPart")
                .WithPart("WidgetPart")
                .WithPart("CommonPart")
                .WithSetting("Stereotype", "Widget"));

            return 2;
        }
    }
}