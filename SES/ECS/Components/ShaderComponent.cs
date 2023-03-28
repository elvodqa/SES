namespace SES.ECS.Components;

public class ShaderComponent : Component
{
    public new Type Requires = typeof(RenderableComponent);
}