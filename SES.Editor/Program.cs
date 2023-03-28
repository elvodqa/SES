using System.Reflection;
using SES.ECS;
using SES.Editor;
using Silk.NET.Maths;
using Silk.NET.Windowing;

List<Component> GetAllSESComponents()
{
    //Assembly assembly = Assembly.GetExecutingAssembly();
    Assembly? assembly = Assembly.Load("SES");
    Console.WriteLine(assembly.FullName);

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

// TODO: CUSTOM COMPONENTS
List<Component> GetAllCustomComponents(string userAssemblyName)
{
    Assembly? assembly = Assembly.Load(userAssemblyName);
    Console.WriteLine(assembly.FullName);

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

Editor editor = new();