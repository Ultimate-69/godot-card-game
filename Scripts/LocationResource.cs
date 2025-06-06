using Godot;
using System;

public partial class LocationResource : Node
{
    [Export]
    public string locationName;
    [Export]
    public string locationEffect;
    [Export]
    public Texture2D locationImage;
}
