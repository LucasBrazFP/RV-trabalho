using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class QuizManager : MonoBehaviour
{
    public static QuizManager Instance;

    [Header("UI")]
    public TextMeshProUGUI feedbackText;

    [Header("Teleport da próxima etapa")]
    public GameObject tp3;

    private HashSet<string> corretosSelecionados = new HashSet<string>();

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
        if (feedbackText != null)
        {
            feedbackText.text = "";
        }

        if (tp3 != null)
        {
            tp3.SetActive(false);
        }
    }

    public void SelecionarManequim(string nome)
    {
        if (nome == "CHAR_A" || nome == "CHAR_D")
        {
            if (!corretosSelecionados.Contains(nome))
            {
                corretosSelecionados.Add(nome);

                if (feedbackText != null)
                {
                    if (corretosSelecionados.Count < 2)
                    {
                        feedbackText.text = "Correto! Falta mais um manequim.";
                    }
                    else
                    {
                        feedbackText.text = "Muito bem! Vá para a próxima sala.";

                        if (tp3 != null)
                        {
                            tp3.SetActive(true);
                        }
                    }
                }
            }
        }
        else
        {
            if (feedbackText != null)
            {
                feedbackText.text = "Esse manequim não está com EPI correto.";
            }
        }
    }
}