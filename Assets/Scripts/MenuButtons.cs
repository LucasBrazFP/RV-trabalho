using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [Header("UI Menu")]
    public GameObject menuImage;
    public GameObject instrucoesImage;

    public GameObject playButton;
    public GameObject instrucaoButton;
    public GameObject quitButton;

    private bool estaNasInstrucoes = false;

    void Start()
    {
        if (instrucoesImage != null)
            instrucoesImage.SetActive(false);
    }

    void Update()
    {
        if (estaNasInstrucoes && Input.GetKeyDown(KeyCode.Escape))
        {
            VoltarMenu();
        }
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player Said I quit");
    }

    public void AbrirInstrucoes()
    {
        estaNasInstrucoes = true;

        if (instrucoesImage != null)
            instrucoesImage.SetActive(true);

        if (menuImage != null)
            menuImage.SetActive(false);

        playButton.SetActive(false);
        instrucaoButton.SetActive(false);
        quitButton.SetActive(false);
    }

    public void VoltarMenu()
    {
        estaNasInstrucoes = false;

        if (instrucoesImage != null)
            instrucoesImage.SetActive(false);

        if (menuImage != null)
            menuImage.SetActive(true);

        playButton.SetActive(true);
        instrucaoButton.SetActive(true);
        quitButton.SetActive(true);
    }
}