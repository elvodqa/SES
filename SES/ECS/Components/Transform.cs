using Silk.NET.Maths;

namespace SES.ECS.Components;

public class Transform : Component
{
    /// <summary>
    /// The position of the entity
    /// </summary>
    public Vector2D<float> Position;
    
    /// <summary>
    /// Scale in percentage
    /// </summary>
    public Vector2D<float> Scale;
    
    /// <summary>
    /// Rotation in degrees
    /// </summary>
    public Vector2D<float> Rotation; 

    public void Update()
    {
        
    }
}