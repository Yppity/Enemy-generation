using UnityEngine;

[RequireComponent(typeof(ColorSetter))]

public class EnemyBody : MonoBehaviour
{
    private ColorSetter _colorSetter;

    private void Awake()
    {
        _colorSetter = GetComponent<ColorSetter>();
    }

    public void SetColor(Color color)
    {
        _colorSetter.SetColor(color);
    }
}
