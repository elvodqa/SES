using System.Drawing;
using ImGuiNET;
using SES.ECS;
using SES.Editor.UI;
using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;
using Silk.NET.OpenGL.Extensions.ImGui;

namespace SES.Editor;

public class Editor
{
    private IWindow window;
    private ImGuiController controller = null;
    private GL gl;
    private IInputContext inputContext = null;
    private List<Entity> entityTree = new();
    private EntityTreeComponent entityTreeComponent = new();
    
    public Editor()
    {
        var options = WindowOptions.Default;
        options.Size = new Vector2D<int>(1280, 720);
        options.Title = "SES Editor";
        window = Window.Create(options);
       

        window.Load += OnLoad;
        window.Update += OnUpdate;
        window.Render += OnRender;
        window.FramebufferResize += WindowOnFramebufferResize;
        window.Closing += OnClosing;
        
        window.Run();
    }
    

    private void OnLoad()
    {
        //Set-up input context.
        IInputContext input = window.CreateInput();
        for (int i = 0; i < input.Keyboards.Count; i++)
        {
            input.Keyboards[i].KeyDown += KeyDown;
        }
        
        controller = new ImGuiController(
            gl = window.CreateOpenGL(), // load OpenGL
            window, // pass in our window
            input // create an input context
        );
        
        Console.WriteLine(ImGui.GetVersion());

        //ImGui.DockSpaceOverViewport(ImGui.GetMainViewport());
        
        Entity entity = new();
        entity.Name = "Root";
        entityTree.Add(entity);
        
        Entity childEntity = new();
        childEntity.Parent = entity;
        childEntity.Name = "Some node";
        entity.Children.Add(childEntity);
        
    }

    
    private void OnUpdate(double delta)
    {
        
    }
    
    private void OnRender(double delta)
    {
        controller.Update((float) delta);
        
        gl.ClearColor(Color.FromArgb(255, 88, 85, 83));
        gl.Clear((uint) (ClearBufferMask.ColorBufferBit));
        
        ImGuiRender();
        entityTreeComponent.Draw(entityTree, window);
        controller.Render();
    }
    
    private void WindowOnFramebufferResize(Vector2D<int> obj)
    {
        gl.Viewport(obj);
    }

    private void KeyDown(IKeyboard arg1, Key arg2, int arg3)
    {
        if (arg2 == Key.Escape)
        {
            window.Close();
        }
    }
    
    private void OnClosing()
    {
        
    }
    
    private void ImGuiRender()
    {
        if (ImGui.BeginMainMenuBar())
        {
            if (ImGui.BeginMenu("File"))
            {
                if (ImGui.MenuItem("New"))
                {
                    
                }
                if (ImGui.MenuItem("Open"))
                {
                    
                }
                if (ImGui.MenuItem("Save"))
                {
                    
                }
                if (ImGui.MenuItem("Save As"))
                {
                    
                }
                ImGui.EndMenu();
            }
            if (ImGui.BeginMenu("Edit"))
            {
                if (ImGui.MenuItem("Undo"))
                {
                    
                }
                if (ImGui.MenuItem("Redo"))
                {
                    
                }
                ImGui.EndMenu();
            }
            if (ImGui.BeginMenu("View"))
            {
                if (ImGui.MenuItem("Scene"))
                {
                    
                }
                if (ImGui.MenuItem("Game"))
                {
                    
                }
                ImGui.EndMenu();
            }
            if (ImGui.BeginMenu("Help"))
            {
                if (ImGui.MenuItem("About"))
                {
                    
                }
                ImGui.EndMenu();
            }
            ImGui.EndMainMenuBar();
        }
    }
}