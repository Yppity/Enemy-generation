using UnityEngine;

public class Archer : Enemy
{
    private Color _color = Color.green;

    protected override Color Color => _color;
}
