using System.Numerics;
using SES.ECS;

namespace SES.Editor.UI;

using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.Windowing;
using ImGuiNET;

public class EntityTreeComponent
{
    public Entity Selected;
    public Entity Hovered;    
    
    public void Draw(List<Entity> entityList, IWindow window)
    {
        //ImGui.SetNextWindowDockID(ImGui.GetID("EntityTree"));
        ImGui.Begin("EntityTree");
        
        if (ImGui.BeginPopupContextWindow("Add Entity"))
        {
            if (ImGui.MenuItem("Add Child Entity"))
            {
                // Add a child entity to the currently selected entity
                if (Hovered != null)
                {
                    Entity e = new();
                    e.Name = "Child Entity";
                    e.Parent = Hovered;
                    Hovered.Children.Add(e);
                }
            }

            if (ImGui.MenuItem("Add Sibling Entity"))
            {
                // Add a sibling entity to the currently selected entity's parent
                if (Hovered != null && Hovered.Parent != null)
                {
                    Entity e = new();
                    e.Name = "Sibling Entity";
                    e.Parent = Hovered.Parent;
                    Hovered.Parent.Children.Add(e);
                }
            }

            ImGui.EndPopup();
        }
        
        foreach (Entity entity in entityList)
        {
            ImGui.SetNextItemOpen(true); // TODO: FIX THIS SO IT ONLY OPENS THE FIRST ENTITY
            DrawEntity(entity);
        }

        ImGui.End();
    }

    private void DrawEntity(Entity entity)
    {
        /*
        if (Selected == entity)
        {
            ImGui.PushStyleColor(ImGuiCol.Text, new Vector4(1, 1, 0, 1));
        }
        */
        
        //bool isNodeOpen = ImGui.TreeNodeEx(entity.Name, ImGuiTreeNodeFlags.Leaf | ImGuiTreeNodeFlags.AllowItemOverlap);
        bool isNodeOpen = ImGui.TreeNodeEx(entity.Name);
        
        if (ImGui.IsItemClicked())
        {
            Selected = entity;
        }
        
        bool isHovered = ImGui.IsItemHovered();
        if (isHovered)
        {
            ImGui.BeginTooltip();
            ImGui.Text("Entity ID: " + entity.ID);
            ImGui.EndTooltip();
        }

        if (ImGui.IsMouseReleased(ImGuiMouseButton.Right) && isHovered)
        {
            // Set the hovered entity to the entity that was right-clicked on
            Hovered = entity;
        }

        if (isNodeOpen)
        {
            foreach (Entity childEntity in entity.Children)
            {
                DrawEntity(childEntity);
            }
            ImGui.TreePop();
        }
        /*
        if (entity == Selected)
        {
            ImGui.PopStyleColor();
        }
        */
        
    }
}
