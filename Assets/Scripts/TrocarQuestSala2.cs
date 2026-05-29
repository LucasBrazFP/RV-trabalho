using TMPro;
using UnityEngine;

public class TrocarQuestSala2 : MonoBehaviour
{
    public GameObject textoQuest2;
    private bool jaAtivou = false;

    private void Start()
    {
        if (textoQuest2 != null)
        {
            textoQuest2.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (jaAtivou) return;

        if (other.CompareTag("Player"))
        {
            jaAtivou = true;

            if (QuestManager.Instance != null)
            {
                QuestManager.Instance.EsconderQuest1();
            }

            if (textoQuest2 != null)
            {
                textoQuest2.SetActive(true);
            }
        }
    }
}