using SES.ECS;
using SES.ECS.Components;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Transform = SES.ECS.Components.Transform;

namespace SES;

public class Game : IDisposable
{ 
    private RenderWindow? _renderWindow;
    private Clock? _deltaClock;
    private uint _width;
    private uint _height;
    public uint Width
    {
        get
        {
            return _renderWindow!.Size.X;
        }
        set
        {
            var renderWindowSize = _renderWindow.Size;
            renderWindowSize.X = value;
            _renderWindow.Size = renderWindowSize;
        }
    }

    public uint Height
    {
        get
        {
            return _renderWindow!.Size.Y;
        }
        set
        {
            var renderWindowSize = _renderWindow.Size;
            renderWindowSize.Y = value;
            _renderWindow.Size = renderWindowSize;
        }
    }
    public readonly string Title;

    protected Game(uint width, uint height, string title)
    {
        Title = title;
        _width = width;
        _height = height;
    }

    private void Init()
    {
        _deltaClock = new();
        _renderWindow = new(new VideoMode(_width, _height), Title);
        _renderWindow.Closed += (sender, args) =>
        {
            _renderWindow.Close();
        };
    }

    public virtual void Load()
    {
        var foo = new Entity().AddComponent<Transform>();
        foo.AddComponent<ImageRenderer>();
        foo.GetComponent<ImageRenderer>().Texture = new("./data/img/dummy.png");
        foo.GetComponent<ImageRenderer>().Sprite = new(foo.GetComponent<ImageRenderer>().Texture);
    }
    
    public virtual void Update(Clock? clock)
    {
        BaseSystem.Update(clock!);
    }

    private void Draw(RenderWindow window)
    {
        BaseSystem.Draw(window);
    }

    public void Run()
    {
        Init();
        Load(); 
        while (_renderWindow!.IsOpen)
        {
            _renderWindow.DispatchEvents();
            Update(_deltaClock);
            Draw(_renderWindow);
            _renderWindow.Display();
            _deltaClock?.Restart();
        }
    }

    public void Dispose()
    {
        _renderWindow?.Dispose();
        _deltaClock?.Dispose();
    }
}