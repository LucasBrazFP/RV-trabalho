using UnityEngine;

public class FakeVRPlayerController : MonoBehaviour
{
    [Header("Movimento")]
    public float velocidade = 4f;
    public float sensibilidadeMouse = 2f;

    [Header("Cameras VR")]
    public Camera leftEyeCamera;
    public Camera rightEyeCamera;

    [Header("Distancia entre olhos")]
    public float distanciaOlhos = 0.065f;

    private float rotacaoX = 0f;
    private float rotacaoY = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        ConfigurarCameras();
    }

    void Update()
    {
        Mover();
        OlharComMouse();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void Mover()
    {
        float horizontal = Input.GetAxis("Horizontal"); // A/D
        float vertical = Input.GetAxis("Vertical");     // W/S

        Vector3 direcao = transform.forward * vertical + transform.right * horizontal;
        direcao.y = 0;

        transform.position += direcao.normalized * velocidade * Time.deltaTime;
    }

    void OlharComMouse()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadeMouse;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadeMouse;

        rotacaoY += mouseX;
        rotacaoX -= mouseY;

        rotacaoX = Mathf.Clamp(rotacaoX, -80f, 80f);

        transform.rotation = Quaternion.Euler(rotacaoX, rotacaoY, 0f);
    }

    void ConfigurarCameras()
    {
        leftEyeCamera.rect = new Rect(0f, 0f, 0.5f, 1f);
        rightEyeCamera.rect = new Rect(0.5f, 0f, 0.5f, 1f);

        leftEyeCamera.transform.localPosition = new Vector3(-distanciaOlhos / 2f, 0f, 0f);
        rightEyeCamera.transform.localPosition = new Vector3(distanciaOlhos / 2f, 0f, 0f);

        leftEyeCamera.transform.localRotation = Quaternion.identity;
        rightEyeCamera.transform.localRotation = Quaternion.identity;
    }
}