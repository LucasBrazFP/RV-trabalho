using UnityEngine;

public class Sala2Trigger : MonoBehaviour
{
    public GameObject perguntaUI;
    public GameObject questTextSala1;
    public GameObject testeQuestSala2;

    private bool jaAtivou = false;

    private void Start()
    {
        if (perguntaUI != null)
            perguntaUI.SetActive(false);

        if (testeQuestSala2 != null)
            testeQuestSala2.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (jaAtivou) return;

        if (other.CompareTag("Player"))
        {
            jaAtivou = true;

            if (questTextSala1 != null)
                questTextSala1.SetActive(false);

            if (testeQuestSala2 != null)
                testeQuestSala2.SetActive(true);

            if (perguntaUI != null)
            {
                perguntaUI.SetActive(true);
                Invoke(nameof(EsconderPergunta), 5f);
            }
        }
    }

    private void EsconderPergunta()
    {
        if (perguntaUI != null)
            perguntaUI.SetActive(false);
    }
}