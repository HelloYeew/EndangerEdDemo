using EndangerEdDemo.Game.Store;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;

namespace EndangerEdDemo.Game.Graphics.Components;

public partial class ScoreDisplay : CompositeDrawable
{
    [Resolved]
    private GameSessionStore gameSessionStore { get; set; }

    private SpriteText scoreText;

    [BackgroundDependencyLoader]
    private void load()
    {
        InternalChildren = new Drawable[]
        {
            new SpriteText
            {
                Text = "Score",
                Font = new FontUsage(size: 30),
                Anchor = Anchor.TopCentre,
                Origin = Anchor.TopCentre,
                Margin = new MarginPadding(10),
            },
            scoreText = new SpriteText
            {
                Anchor = Anchor.TopCentre,
                Origin = Anchor.TopCentre,
                Text = gameSessionStore.Score.Value.ToString(),
                Font = new FontUsage(size:30),
                Margin = new MarginPadding
                {
                    Top = 40,
                    Left = 10,
                },
            },
            new Timer
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both
            }
        };
    }

    protected override void LoadComplete()
    {
        base.LoadComplete();
        gameSessionStore.Score.BindValueChanged(score =>
        {
            // Add comma separator
            scoreText.Text = score.NewValue.ToString("N0");
        });
    }
}
