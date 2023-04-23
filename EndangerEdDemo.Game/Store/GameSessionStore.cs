﻿using EndangerEdDemo.Game.Screen.Game;
using EndangerEdDemo.Game.Screen.Screenstack;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Logging;
using osu.Framework.Timing;

namespace EndangerEdDemo.Game.Store;

/// <summary>
/// A store that holds the current session state, will start initialized on DI.
/// </summary>
public partial class GameSessionStore : CompositeDrawable
{
    [Resolved]
    private EndangerEdDemoScreenStack screenStack { get; set; }

    public const int MAX_LIFE = 3;

    /// <summary>
    /// Time per microgame in milliseconds.
    /// </summary>
    public const int TIME_PER_GAME = 60000;

    public BindableInt Life = new BindableInt(MAX_LIFE);

    public BindableInt Score = new BindableInt(0);

    public BindableInt GameCount = new BindableInt(0);

    // We need to use StopwatchClock instead of Stopwatch because it's also depend on the frame time on framework too.
    public StopwatchClock StopwatchClock = new StopwatchClock();

    protected override void LoadAsyncComplete()
    {
        base.LoadAsyncComplete();
        GameCount.BindValueChanged(gameCountChangedEvent =>
        {
            Logger.Log($"🏬 Game count changed to {gameCountChangedEvent.NewValue}.");
            osu.Framework.Screens.Screen startScreen = new StartMicrogameScreen();
            screenStack.GameScreenStack.GameSessionScreenStack.MainScreenStack.Push(new StartMicrogameScreen());
            startScreen.FadeInFromZero(1000)
                       .Then(2000)
                       .FadeOut(1000)
                       .MoveToY(-200, 250, Easing.OutQuint);
        });
    }

    /// <summary>
    /// Reset the game session to initial state.
    /// </summary>
    public void Reset()
    {
        Life.Value = MAX_LIFE;
        Score.Value = 0;
        StopwatchClock.Reset();
    }

    public bool IsOverTime()
    {
        return StopwatchClock.ElapsedMilliseconds >= TIME_PER_GAME;
    }
}
