using SFML.Graphics;
using SFML.System;

namespace SES.ECS.Components;

public class ImageRenderer : Component
{
    public Texture Texture;
    public Sprite Sprite;

    public override void Draw(RenderWindow window)
    {
        base.Draw(window);
        Sprite.Position = new Vector2f(
            Entity.GetComponent<Transform>().Position.X,
            Entity.GetComponent<Transform>().Position.Y
        );
        window.Draw(Sprite);
    }
}