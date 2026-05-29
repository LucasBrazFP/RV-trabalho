using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerControllerFPS : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 200f;

    public float playerHeight = 2f;   // Altura do Player
    public float cameraHeight = 1.8f; // Altura do olho

    private CharacterController controller;
    private Transform cameraTransform;
    private float xRotation = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cameraTransform = GetComponentInChildren<Camera>().transform;

        // Ajusta CharacterController
        controller.height = playerHeight;
        controller.center = new Vector3(0f, playerHeight / 2f, 0f);

        // Ajusta câmera
        cameraTransform.localPosition = new Vector3(0f, cameraHeight, 0f);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Movimento
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 forward = new Vector3(transform.forward.x, 0f, transform.forward.z).normalized;
        Vector3 right = new Vector3(transform.right.x, 0f, transform.right.z).normalized;

        Vector3 move = right * x + forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }
}