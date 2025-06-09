using Godot;
using System;

public partial class LocationResource : Resource
{
    [Export]
    public string locationName;
    [Export(PropertyHint.MultilineText)]
    public string locationEffect;
    [Export]
    public Texture2D locationImage;
}
