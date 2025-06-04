using Godot;
using System;

public partial class Location : Control
{
    [Export]
    public LocationResource locationResource;

    [Export]
    public TextureRect image;
    [Export]
    public Label name;
    [Export]
    public Label effect;
    [Export]
    public Label powerTop;
    [Export]
    public Label powerBottom;
    [Export]
    public Button cardButton;

}
