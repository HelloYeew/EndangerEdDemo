using EndangerEdDemo.Game.Graphics.Components;
using EndangerEdDemo.Game.Screen.Game;
using EndangerEdDemo.Game.Screen.Game.MicroGame;
using EndangerEdDemo.Game.Screen.Screenstack;
using EndangerEdDemo.Game.Store;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Screens;
using osuTK;

namespace EndangerEdDemo.Game.Screen.Presentation;

public partial class PresentationSlide4 : EndangerEdDemoPresentationScreen
{
    public override EndangerEdDemoGameScreen GameScreen => new MainMenuScreen();

    [Resolved]
    private EndangerEdDemoScreenStack screenStack { get; set; }

    [Resolved]
    private SessionStore sessionStore { get; set; }

    [Resolved]
    private GameSessionStore gameSessionStore { get; set; }

    [BackgroundDependencyLoader]
    private void load()
    {
        InternalChildren = new Drawable[]
        {
            new SpriteText
            {
                Text = "Game screen",
                Font = new FontUsage(size: 50),
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Margin = new MarginPadding(10),
            },
            new SpriteText
            {
                Text = "4",
                Font = new FontUsage(size: 30),
                Anchor = Anchor.BottomRight,
                Origin = Anchor.BottomRight,
                Margin = new MarginPadding(10),
            },
            new SpriteText
            {
                Text = "The game screen is the screen that is shown after the game is started.",
                Font = new FontUsage(size: 25),
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Margin = new MarginPadding()
                {
                    Top = 60,
                    Left = 10,
                }
            },
            new SpriteText
            {
                Text = "It is the screen that contains the microgames.",
                Font = new FontUsage(size: 25),
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Margin = new MarginPadding()
                {
                    Top = 80,
                    Left = 10,
                }
            },
            new EndangerEdDemoButton("Start timer")
            {
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Action = () =>
                {
                    gameSessionStore.StopwatchClock.Start();
                },
                Width = 100,
                Height = 50,
                Margin = new MarginPadding
                {
                    Top = 120,
                    Left = 10,
                },
                Colour = Colour4.Green
            },
            new EndangerEdDemoButton("Stop timer")
            {
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Action = () =>
                {
                    gameSessionStore.StopwatchClock.Stop();
                },
                Width = 100,
                Height = 50,
                Margin = new MarginPadding
                {
                    Top = 180,
                    Left = 10,
                },
                Colour = Colour4.Red
            },
            new EndangerEdDemoButton("Reset timer")
            {
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Action = () =>
                {
                    gameSessionStore.StopwatchClock.Reset();
                },
                Width = 100,
                Height = 50,
                Margin = new MarginPadding
                {
                    Top = 240,
                    Left = 10,
                },
                Colour = Colour4.Blue
            },
            new EndangerEdDemoButton("Clear")
            {
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Action = () =>
                {
                    screenStack.GameScreenStack.GameSessionScreenStack.MainScreenStack.CurrentScreen?.Exit();
                },
                Width = 100,
                Height = 50,
                Margin = new MarginPadding
                {
                    Top = 300,
                    Left = 10,
                },
                Colour = Colour4.Yellow
            },
            new EndangerEdDemoButton("Remove live")
            {
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Action = () =>
                {
                    gameSessionStore.Life.Value--;
                },
                Width = 100,
                Height = 50,
                Margin = new MarginPadding
                {
                    Top = 360,
                    Left = 10,
                },
                Colour = Colour4.DarkRed
            },
            new EndangerEdDemoButton("Reset live")
            {
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Action = () =>
                {
                    gameSessionStore.Life.Value = 3;
                },
                Width = 100,
                Height = 50,
                Margin = new MarginPadding
                {
                    Top = 420,
                    Left = 10,
                },
                Colour = Colour4.DarkOliveGreen
            },
            new EndangerEdDemoButton("Start demo1")
            {
                Anchor = Anchor.TopRight,
                Origin = Anchor.TopRight,
                Action = () =>
                {
                    gameSessionStore.StopwatchClock.Stop();
                    gameSessionStore.StopwatchClock.Reset();
                    StartMicrogameScreen startMicrogameScreen = new StartMicrogameScreen();
                    SelectNameMicroGameScreen selectNameMicroGameScreen = new SelectNameMicroGameScreen();
                    screenStack.GameScreenStack.GameSessionScreenStack.MainScreenStack.Push(startMicrogameScreen);
                    Scheduler.AddDelayed(() =>
                    {
                        screenStack.GameScreenStack.GameSessionScreenStack.MainScreenStack.Push(new SelectNameMicroGameScreen());
                        gameSessionStore.StopwatchClock.Start();
                    }, 2000);
                },
                Width = 100,
                Height = 50,
                Margin = new MarginPadding
                {
                    Top = 120,
                    Right = 10,
                },
                Colour = Colour4.LightGreen
            },
            new EndangerEdDemoButton("Start demo2")
            {
                Anchor = Anchor.TopRight,
                Origin = Anchor.TopRight,
                Action = () =>
                {
                    gameSessionStore.StopwatchClock.Stop();
                    gameSessionStore.StopwatchClock.Reset();
                    StartMicrogameScreen startMicrogameScreen = new StartMicrogameScreen();
                    TypeToAnswerMicroGameScreen typeToAnswerMicroGameScreen = new TypeToAnswerMicroGameScreen();
                    screenStack.GameScreenStack.GameSessionScreenStack.MainScreenStack.Push(startMicrogameScreen);
                    Scheduler.AddDelayed(() =>
                    {
                        screenStack.GameScreenStack.GameSessionScreenStack.MainScreenStack.Push(new TypeToAnswerMicroGameScreen());
                        gameSessionStore.StopwatchClock.Start();
                    }, 2000);
                },
                Width = 100,
                Height = 50,
                Margin = new MarginPadding
                {
                    Top = 180,
                    Right = 10,
                },
                Colour = Colour4.LightGreen
            },
            new FillFlowContainer
            {
                Anchor = Anchor.BottomLeft,
                Origin = Anchor.BottomLeft,
                Direction = FillDirection.Horizontal,
                Margin = new MarginPadding()
                {
                    Bottom = 30,
                    Left = 10,
                },
                Spacing = new Vector2(3),
                Children = new Drawable[]
                {
                    new SpriteIcon
                    {
                        Icon = FontAwesome.Solid.Flask,
                        Size = new Vector2(15),
                    },
                    new SpriteText
                    {
                        Text = "This is a demo version of the EndangerEd project, the final version maybe different.",
                        Font = new FontUsage(size: 15),
                        Margin = new MarginPadding()
                        {
                            Left = 10,
                        }
                    }
                }
            }
        };
    }
}
