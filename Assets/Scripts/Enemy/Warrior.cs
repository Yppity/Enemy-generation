using UnityEngine;

public class Warrior : Enemy
{
    private Color _color = Color.red;

    protected override Color Color => _color;
}