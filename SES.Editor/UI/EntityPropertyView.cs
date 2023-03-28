using ImGuiNET;
using SES.ECS;
using SES.ECS.Components;

namespace SES.Editor.UI;

public class EntityPropertyView
{
    public void Draw(Entity entity)
    {
        ImGui.Begin("Entity Properties");
        if (entity == null)
        {
            ImGui.End();
            return;
        }
        ImGui.Text(entity.Name);
        ImGui.Separator();
        
        List<Type> types = new();
        entity.Components.ForEach(component => types.Add(component.GetType()));
        foreach (var componentType in types)
        {
            if (ImGui.CollapsingHeader(componentType.Name))
            {
                // Get all the components of the current type in the entity, Note: It's not necessary
                // to get all the components of the same type, because you can have the same type multiple times but whatever
                var components = entity.Components.Where(component => component.GetType() == componentType).ToList();

                foreach (var component in components)
                {
                    // Draw the component's properties
                    //ImGui.Text(component.GetType().Name);
                    //ImGui.Separator();

                    if (component.GetType() == typeof(Transform))
                    {
                        var transform = (Transform) component;
                        ImGui.Text("Position");
                        ImGui.SameLine();
                        ImGui.InputFloat("##X", ref transform.Position.X);
                        ImGui.SameLine();
                        ImGui.InputFloat("##Y", ref transform.Position.Y);
                        ImGui.Text("Scale");
                        ImGui.SameLine();
                        ImGui.InputFloat("##ScaleX", ref transform.Scale.X);
                        ImGui.SameLine();
                        ImGui.InputFloat("##ScaleY", ref transform.Scale.Y);
                        ImGui.Text("Rotation");
                        ImGui.SameLine();
                        ImGui.InputFloat("##RotationX", ref transform.Rotation.X);
                        ImGui.SameLine();
                        ImGui.InputFloat("##RotationY", ref transform.Rotation.Y);
                    }
                }
            }
        }

        ImGui.End();
    }
}
