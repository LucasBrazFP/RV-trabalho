using UnityEngine;

public class HUDController : MonoBehaviour
{
    public GameObject textoEPI;

    void Start()
    {
        textoEPI.SetActive(true);
        Invoke("EsconderTexto", 5f);
    }

    void EsconderTexto()
    {
        textoEPI.SetActive(false);
    }
}