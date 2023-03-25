using Godot;

namespace Akko.UI
{
    public enum ECommand
    {
        Undo,
        Redo
    }
    
    
    public static class Commands
    {
        public static void Undo()
        {
            GD.Print("Undo!");
        }
    
    }
}