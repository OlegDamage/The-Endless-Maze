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
#else
        TouchControls();
#endif
    }

    void TouchControls()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                fingerDownPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                Vector2 swipeDelta = touch.position - fingerDownPosition;

                if (swipeDelta.magnitude > swipeDeadZone)
                {
                    if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
                    {
                        ChangeGravity(swipeDelta.x > 0 ? Vector2.right : Vector2.left);
                    }
                    else
                    {
                        ChangeGravity(swipeDelta.y > 0 ? Vector2.up : Vector2.down);
                    }
                }
            }
        }
    }

    void KeyboardControls()
    {
        if (Input.GetKeyDown(KeyCode.W)) ChangeGravity(Vector2.up);
        if (Input.GetKeyDown(KeyCode.A)) ChangeGravity(Vector2.left);
        if (Input.GetKeyDown(KeyCode.S)) ChangeGravity(Vector2.down);
        if (Input.GetKeyDown(KeyCode.D)) ChangeGravity(Vector2.right);
    }

    void ChangeGravity(Vector2 direction)
    {
        Debug.Log("Gravity is changed");
        Physics2D.gravity = direction * 9.81f;
    }
}
