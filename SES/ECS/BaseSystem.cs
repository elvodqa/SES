using System.Reflection;
using SFML.Graphics;
using SFML.System;

namespace SES.ECS;

public class BaseSystem
{
    protected static List<Component> Components = GetAllComponents();
    
    public static void Update(Clock clock)
    {
        foreach (Component component in Components)
        {
            component.Update(clock);
        }
    }

    public static void Draw(RenderWindow window)
    {
        foreach (Component component in Components)
        {
            component.Draw(window);
        }
    }
    
    private static List<Component> GetAllComponents()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        Type componentType = typeof(Component);
        List<Component> components = new List<Component>();

        foreach (Type type in assembly.GetTypes())
        {
            if (type.IsSubclassOf(componentType))
            {
                Console.WriteLine(type.Name);
                Component instance = (Component)Activator.CreateInstance(type);
                components.Add(instance);
            }
        }

        return components;
    }
}