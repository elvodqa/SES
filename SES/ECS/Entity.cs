using SES.ECS.Components;

namespace SES.ECS;

public class Entity
{
    public string Name = "";
    public int ID { get; set; }
    public Entity Parent;
    public List<Entity> Children = new();
    public readonly List<Component> Components = new();
    
    public Entity AddComponent<T>() where T : Component
    {
        if (!Components.OfType<T>().Any())
        {
            T component = Activator.CreateInstance<T>();
            component.Entity = this;
            Components.Add(component);
            return this;
        }
        throw new Exception("Component already exists.");
    }

    public T GetComponent<T>() where T : Component
    {
        return Components.OfType<T>().FirstOrDefault()!;
    } 
}