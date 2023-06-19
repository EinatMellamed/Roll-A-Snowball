using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 0f;
    private Rigidbody rb;
    private Vector2 touchStartPos;
    [SerializeField] GameObject canvas;

    private float movementX;
    private float movementY;


    bool IsNotOnSurface;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    private void Update()
    {


        if (transform.position.y < -13f || transform.position.x< -38f || transform.position.x> 74f || transform.position.z < -58f || transform.position.z >300f  )
        {
            IsNotOnSurface = false;
            canvas.GetComponent<UiManager>().OpenGameOverPanel();
        }

       



    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);

        // Check for touch input
        if (Touchscreen.current == null || Touchscreen.current.touches.Count == 0)
        {
            return;
        }

        TouchControl touch = Touchscreen.current.touches[0];

        if (touch.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Began)
        {
            touchStartPos = touch.position.ReadValue();
        }
        else if (touch.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Moved || touch.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Stationary)
        {
            Vector2 touchDelta = touch.position.ReadValue() - touchStartPos;
            float moveHorizontal = touchDelta.x / Screen.width;
            float moveVertical = touchDelta.y / Screen.height;

            Vector3 movement2 = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.AddForce(movement2 * speed);
        }

    }

  
   
  
}


