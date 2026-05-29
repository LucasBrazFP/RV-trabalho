using UnityEngine;
using TMPro;

public class Sala2ExitTrigger : MonoBehaviour
{
    public GameObject TextoQuest2;
    public GameObject FeedbackText;

    private void OnTriggerEnter(Collider other)
    {
        Transform player = other.transform.root;

        if (player.CompareTag("Player"))
        {
            if (TextoQuest2 != null)
            {
                TextoQuest2.SetActive(false);
            }

            if (FeedbackText != null)
            {
                FeedbackText.SetActive(false);
            }
        }
    }
}