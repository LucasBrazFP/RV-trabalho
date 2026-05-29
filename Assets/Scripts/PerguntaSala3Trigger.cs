using UnityEngine;

public class PerguntaSala3Trigger : MonoBehaviour
{
    public GameObject perguntaUI;
    public float tempoNaTela = 5f;

    private bool jaAtivou = false;

    private void Start()
    {
        if (perguntaUI != null)
        {
            perguntaUI.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entrou no trigger: " + other.name);

        if (jaAtivou) return;

        if (other.CompareTag("Player") || other.transform.root.CompareTag("Player"))
        {
            Debug.Log("Player detectado!");

            jaAtivou = true;

            if (perguntaUI != null)
            {
                perguntaUI.SetActive(true);
                Invoke(nameof(EsconderPergunta), tempoNaTela);
            }
            else
            {
                Debug.LogWarning("Pergunta UI está vazia no Inspector!");
            }
        }
    }

    private void EsconderPergunta()
    {
        if (perguntaUI != null)
        {
            perguntaUI.SetActive(false);
        }
    }
}