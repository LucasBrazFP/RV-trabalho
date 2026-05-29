using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    [Header("UI da missão da sala 1")]
    public TextMeshProUGUI questText1;

    [Header("Configuração")]
    public int totalEPIs = 6;

    [Header("Teleport bloqueado no início")]
    public GameObject tp1;

    private int episAnalisados = 0;

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
        if (tp1 != null)
        {
            tp1.SetActive(false);
        }

        AtualizarTexto();
    }

    public void RegistrarEPIAnalisado()
    {
        episAnalisados++;

        if (episAnalisados >= totalEPIs)
        {
            episAnalisados = totalEPIs;

            if (questText1 != null)
            {
                questText1.text = "Vá para a próxima sala";
            }

            if (tp1 != null)
            {
                tp1.SetActive(true);
            }
        }
        else
        {
            AtualizarTexto();
        }
    }

    private void AtualizarTexto()
    {
        if (questText1 != null)
        {
            questText1.text = "Analise os EPIs: " + episAnalisados + "/" + totalEPIs;
        }
    }

    public void EsconderQuest1()
    {
        if (questText1 != null)
        {
            questText1.gameObject.SetActive(false);
        }
    }
}