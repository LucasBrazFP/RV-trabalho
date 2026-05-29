using UnityEngine;

public class ManequimInteract : MonoBehaviour
{
    public string nomeManequim;
    public float distancia = 3f;

    private Transform player;
    private bool jaSelecionado = false;

    private void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    private void Update()
    {
        if (player == null) return;

        if (Vector3.Distance(player.position, transform.position) <= distancia)
        {
            if (Input.GetKeyDown(KeyCode.E) && !jaSelecionado)
            {
                jaSelecionado = true;

                if (QuizManager.Instance != null)
                {
                    QuizManager.Instance.SelecionarManequim(nomeManequim);
                }
            }
        }
    }
}