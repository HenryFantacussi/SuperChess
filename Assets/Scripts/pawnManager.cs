using UnityEngine;
using System.Collections; // Certifique-se de incluir este namespace

public class PawnManager : MonoBehaviour
{
    private bool mouseOver = false;
    public Color hoverColor;
    private Renderer rend;
    private Color startColor;

    public float moveSpeed = 2f; // Velocidade de movimenta��o
    private Vector3 targetPosition; // Posi��o alvo para movimenta��o
    private bool isMoving = false; // Flag para verificar se a pe�a est� se movendo

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
        mouseOver = true;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
        mouseOver = false;
    }

    private void OnMouseDown()
    {
        // Se a pe�a est� sob o cursor e � clicada, marca como selecionada
        if (mouseOver)
        {
            SelectPawn();
        }
    }

    private void Update()
    {
        // Mova a pe�a em dire��o ao alvo
        if (isMoving)
        {
            if (Vector3.Distance(transform.position, targetPosition) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = targetPosition;
                isMoving = false; // Interrompe o movimento quando chega ao alvo
            }
        }
    }

    // Seleciona a pe�a e define a posi��o alvo
    private void SelectPawn()
    {
        // Se j� houver outra pe�a se movendo, n�o faz nada
        if (isMoving)
            return;

        // Inicia o processo de sele��o e movimenta��o
        StartCoroutine(WaitForClick());
    }

    //  aguarda um clique em uma posi��o do tabuleiro
    private IEnumerator WaitForClick()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    // Verifica se o clique foi sobre uma casa do tabuleiro
                    if (hit.collider.CompareTag("Casa"))
                    {
                        targetPosition = hit.point;
                        isMoving = true;
                        yield break; // move quando a posi��o alvo � definida
                    }
                }
            }
            yield return null; // Espera para verificar novamente
        }
    }
}
