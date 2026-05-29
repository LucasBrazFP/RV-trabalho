using TMPro;
using UnityEngine;

public class EPIDialogUI : MonoBehaviour
{
    public static EPIDialogUI Instance;

    [Header("Elementos da interface")]
    public GameObject painelDialogo;
    public TextMeshProUGUI tituloTexto;
    public TextMeshProUGUI descricaoTexto;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        FecharDialogo();
    }

    private void Update()
    {
        if (painelDialogo.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            FecharDialogo();
        }
    }

    public void MostrarDialogo(string titulo, string descricao)
    {
        painelDialogo.SetActive(true);
        tituloTexto.text = titulo;
        descricaoTexto.text = descricao;
    }

    public void FecharDialogo()
    {
        painelDialogo.SetActive(false);
    }
}