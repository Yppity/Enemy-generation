using UnityEngine;

public class Mage : Enemy
{
    private Color _color = Color.blue;

    protected override Color Color => _color;
}
