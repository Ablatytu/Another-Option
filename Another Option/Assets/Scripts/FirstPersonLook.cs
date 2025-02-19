using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    [SerializeField]
    Transform character;
    public float sensitivity = 2;
    public float smoothing = 1.5f;
    private FirstPersonMovement movement;
    public Transform model;

    Vector2 velocity;
    Vector2 frameVelocity;


    void Reset()
    {
        // Get the character from the FirstPersonMovement in parents.
        character = GetComponentInParent<FirstPersonMovement>().transform;
    }

    void Start()
    {
        // Lock the mouse cursor to the game screen.
        Cursor.lockState = CursorLockMode.Locked;
        movement = gameObject.GetComponentInParent<FirstPersonMovement>();
    }

    void Update()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);
        frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
        velocity += frameVelocity;
        velocity.y = Mathf.Clamp(velocity.y, -90, 90);
        if(!movement.Switched)
        {
            transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
            character.localRotation = Quaternion.AngleAxis(-velocity.x, -Vector3.up);
            model.localRotation = Quaternion.LookRotation(Vector3.forward);
        }
        else
        {
            transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
            character.localRotation = Quaternion.AngleAxis(velocity.x, -Vector3.up);
            model.localRotation = Quaternion.LookRotation(-Vector3.forward);
        }
    }
}
