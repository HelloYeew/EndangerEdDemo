using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.IO.Stores;
using osuTK;
using EndangerEdDemo.Resources;
using osu.Framework.Audio;

namespace EndangerEdDemo.Game
{
    public partial class EndangerEdDemoGameBase : osu.Framework.Game
    {
        // Anything in this class is shared between the test browser and the game implementation.
        // It allows for caching global dependencies that should be accessible to tests, or changing
        // the screen scaling for all components including the test browser and framework overlays.

        protected override Container<Drawable> Content { get; }

        private DependencyContainer dependencies;

        private AudioManager audioManager;

        protected EndangerEdDemoGameBase()
        {
            // Ensure game and tests scale with window size and screen DPI.
            base.Content.Add(Content = new DrawSizePreservingFillContainer
            {
                // You may want to change TargetDrawSize to your "default" resolution, which will decide how things scale and position when using absolute coordinates.
                TargetDrawSize = new Vector2(1366, 768)
            });
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            Resources.AddStore(new DllResourceStore(typeof(EndangerEdDemoResources).Assembly));

            AddFont(Resources, @"Fonts/MPlus1p/MPlus1p-Bold");
            AddFont(Resources, @"Fonts/MPlus1p/MPlus1p-Regular");
            AddFont(Resources, @"Fonts/MPlus1p/MPlus1p-BoldItalic");
            AddFont(Resources, @"Fonts/MPlus1p/MPlus1p-Italic");
            AddFont(Resources, @"Fonts/MPlus1p/MPlus1p-Light");
            AddFont(Resources, @"Fonts/MPlus1p/MPlus1p-Medium");

            AddFont(Resources, @"Fonts/Comfortaa/Comfortaa-Regular");
            AddFont(Resources, @"Fonts/Comfortaa/Comfortaa-Bold");
            AddFont(Resources, @"Fonts/Comfortaa/Comfortaa-BoldItalic");
            AddFont(Resources, @"Fonts/Comfortaa/Comfortaa-Italic");
            AddFont(Resources, @"Fonts/Comfortaa/Comfortaa-Light");

            AddFont(Resources, @"Fonts/Kanit/Kanit-Bold");

            AddFont(Resources, @"Fonts/GothicA1/GothicA1-Bold");

            AddFont(Resources, @"Fonts/Noto/Noto-Basic");
            AddFont(Resources, @"Fonts/Noto/Noto-Hangul");
            AddFont(Resources, @"Fonts/Noto/Noto-CJK-Basic");
            AddFont(Resources, @"Fonts/Noto/Noto-CJK-Compatibility");

            ResourceStore<byte[]> trackResourceStore = new ResourceStore<byte[]>();
            trackResourceStore.AddStore(new NamespacedResourceStore<byte[]>(Resources, "Tracks"));

            // dependencies.Cache(audioManager = new AudioManager(Host.AudioThread, new NamespacedResourceStore<byte[]>(Resources, "Tracks"), new NamespacedResourceStore<byte[]>(Resources, "Samples")));
            // dependencies.CacheAs(this);
        }

        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent) => dependencies = new DependencyContainer(base.CreateChildDependencies(parent));
    }
}
