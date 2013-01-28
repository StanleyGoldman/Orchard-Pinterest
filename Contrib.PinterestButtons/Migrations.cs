using System.Data;
using Contrib.PinterestButtons.Models;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

namespace Contrib.PinterestButtons {
    public class Migrations : DataMigrationImpl {

        public int Create() {
			// Creating table PinItButtonRecord
			SchemaBuilder.CreateTable("PinItButtonRecord", table => table
				.ContentPartRecord()
				.Column("PinCount", DbType.String)
				.Column("AnyImage", DbType.Boolean)
				.Column("Url", DbType.String)
				.Column("Image", DbType.String)
				.Column("Description", DbType.String)
			);

            ContentDefinitionManager.AlterPartDefinition(
                typeof(PinItButtonPart).Name, cfg => cfg.Attachable());

            return 1;
        }
    }
}