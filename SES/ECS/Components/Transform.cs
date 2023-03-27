
using SFML.System;

namespace SES.ECS.Components;

public class Transform : Component
{
    public Vector3f Position;
    public Vector3f Scale;
    public Vector3f Rotation;

    public override void Update(Clock clock)
    {
        base.Update(clock);
    }
}