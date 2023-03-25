using System;
using System.Collections.Generic;
using Godot;

namespace Akko.UI;

public class PanelConst
{
    // Base Node:  VBoxContainer/Layout
    public static Dictionary<EPanelPosition, string> Layout = new()
    {
        { EPanelPosition.Left,  "Left" },
        { EPanelPosition.Right,  "Right/Top" },
    };

    public static Dictionary<EPanel, string> Panel = new()
    {
        { EPanel.Index, "uid://df04fvch3j0d4"},
        { EPanel.Console, "uid://7bac1oyiravx"}
    };

    public static Dictionary<ECommand, Action> Command = new()
    {
        { ECommand.Undo, Commands.Undo },
    };

}