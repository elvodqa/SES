using SFML.Graphics;
using SFML.System;

namespace SES.ECS;

public class Component
{
    public Entity Entity;
    public virtual void Update(Clock clock) {}
    public virtual void Draw(RenderWindow window) {}
}