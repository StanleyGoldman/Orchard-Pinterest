using Orchard.UI.Resources;

namespace Contrib.PinterestButtons {
    public class ResourceManifest : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();
            manifest.DefineScript("PinItButtonEditor").SetUrl("pinit-button-editor.js").SetDependencies("jQuery");
            manifest.DefineScript("pinit").SetUrl("pinit.js");
        }
    }
}
