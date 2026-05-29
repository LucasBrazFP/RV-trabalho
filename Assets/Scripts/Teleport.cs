using UnityEngine;
using TMPro;

public class Teleport : MonoBehaviour
{
    public Transform destino;

    [Header("UI para esconder ao sair da sala")]
    public GameObject questSala2;
    public TextMeshProUGUI feedbackText;

    private void OnTriggerEnter(Collider other)
    {
        if (destino == null) return;

        Transform player = other.transform.root;

        if (player.CompareTag("Player"))
        {
            // TELEPORTA
            player.position = destino.position;

            // ESCONDE A QUEST DA SALA 2
            if (questSala2 != null)
            {
                questSala2.SetActive(false);
            }

            // LIMPA E ESCONDE O FEEDBACK
            if (feedbackText != null)
            {
                feedbackText.text = "";
                feedbackText.gameObject.SetActive(false);
            }
        }
    }
}