using UnityEngine;

public class EPIInteractable : MonoBehaviour
{
    [Header("Informações do objeto")]
    public string titulo;

    [TextArea(4, 10)]
    public string descricao;

    [Header("Distância para interação")]
    public float distanciaInteracao = 3f;

    private Transform player;
    private bool jaFoiAnalisado = false;

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

        float distancia = Vector3.Distance(player.position, transform.position);

        if (distancia <= distanciaInteracao && Input.GetKeyDown(KeyCode.E))
        {
            EPIDialogUI.Instance.MostrarDialogo(titulo, descricao);

            if (!jaFoiAnalisado)
            {
                jaFoiAnalisado = true;

                if (QuestManager.Instance != null)
                {
                    QuestManager.Instance.RegistrarEPIAnalisado();
                }
            }
        }
    }
}