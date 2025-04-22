using System.Runtime.CompilerServices;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    [SerializeField] private float swipeDeadZone = 50f;
    private Vector2 fingerDownPosition;

    private void Update()
    {
#if UNITY_EDITOR
        KeyboardControls();
#endif
    }

    void KeyboardControls()
    {
        if (Input.GetKeyDown(KeyCode.W)) GravityChange(Vector2.up);
        if (Input.GetKeyDown(KeyCode.A)) GravityChange(Vector2.left);
        if (Input.GetKeyDown(KeyCode.S)) GravityChange(Vector2.down);
        if (Input.GetKeyDown(KeyCode.D)) GravityChange(Vector2.right);
    }

    void GravityChange(Vector2 direction)
    {
        Debug.Log("Gravity is changed");
        Physics2D.gravity = direction * 9.81f;
    }
}
