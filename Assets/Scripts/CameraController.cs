using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float velocidadeMovimento = 10f; // Velocidade de movimenta��o da c�mera
    public float sensibilidade = 2f; // Sensibilidade do movimento da c�mera
    public float zoomSpeed = 10f; // Velocidade do zoom
    public float zoomMin = 10f; // Dist�ncia m�nima para o zoom
    public float zoomMax = 100f; // Dist�ncia m�xima para o zoom

    // Posi��es da c�mera
    public Transform posicaoVisaoSuperior, posicaoVisaoSuperior2, posicaoVisaoSuperior3, posicaoVisaoSuperior4;
    public Transform posicaoOriginal, posicaoOriginal2, posicaoOriginal3, posicaoOriginal4;
    private bool emVisaoSuperior = false;
    private int visaoSuperior, visaoTatica = 0;

    private void Start()
    {
        TransformCamera(posicaoOriginal);
    }

    private void Update()
    {
        // Alternar entre a vis�o superior e a posi��o original
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (posicaoVisaoSuperior != null && posicaoOriginal != null)
            {
                if (emVisaoSuperior)
                {
                    visaoSuperior = 0;
                    TransformCamera(posicaoOriginal);
                }
                else
                {
                    visaoTatica = 0;
                    TransformCamera(posicaoVisaoSuperior);
                }
                emVisaoSuperior = !emVisaoSuperior;
            }
            else
            {
                Debug.LogWarning("As refer�ncias para 'Posicao Visao Superior' ou 'Posicao Original' n�o est�o atribu�das.");
            }
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            if (emVisaoSuperior && visaoSuperior == 0)
            {
                visaoSuperior = 1;
                TransformCamera(posicaoVisaoSuperior2);
            }
            else if (emVisaoSuperior && visaoSuperior == 1)
            {
                visaoSuperior = 2;
                TransformCamera(posicaoVisaoSuperior3);
            }
            else if (emVisaoSuperior && visaoSuperior == 2)
            {
                visaoSuperior = 3;
                TransformCamera(posicaoVisaoSuperior4);
            }
            else if (emVisaoSuperior && visaoSuperior == 3)
            {
                visaoSuperior = 0;
                TransformCamera(posicaoVisaoSuperior);
            }

            if (!emVisaoSuperior && visaoTatica == 0)
            {
                visaoTatica = 1;
                TransformCamera(posicaoOriginal2);
            }
            else if (!emVisaoSuperior && visaoTatica == 1)
            {
                visaoTatica = 2;
                TransformCamera(posicaoOriginal3);
            }
            else if (!emVisaoSuperior && visaoTatica == 2)
            {
                visaoTatica = 3;
                TransformCamera(posicaoOriginal4);
            }
            else if (!emVisaoSuperior && visaoTatica == 3)
            {
                visaoTatica = 0;
                TransformCamera(posicaoOriginal);
            }
        }
        /*
        if (!emVisaoSuperior) // Movimento da c�mera apenas na posi��o original
        {
            // Verifica se o bot�o direito do mouse est� pressionado
            if (Input.GetMouseButton(1)) // Bot�o direito do mouse � 1
            {
                // Captura o movimento do mouse
                float movimentoX = Input.GetAxis("Mouse X") * sensibilidade;
                float movimentoY = Input.GetAxis("Mouse Y") * sensibilidade;

                // Rotaciona a c�mera com base no movimento do mouse
                transform.Rotate(Vector3.up * movimentoX);
                transform.Rotate(Vector3.left * movimentoY);

                // Movimenta a c�mera com base nos eixos de entrada
                float movimentoZ = Input.GetAxis("Vertical") * velocidadeMovimento * Time.deltaTime;
                float movimentoX2 = Input.GetAxis("Horizontal") * velocidadeMovimento * Time.deltaTime;

                transform.Translate(Vector3.forward * movimentoZ);
                transform.Translate(Vector3.right * movimentoX2);
            }

            // Zoom com a roda do mouse
            float scroll = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            Vector3 novaPosicao = transform.position + transform.forward * scroll;
            float distancia = Vector3.Distance(novaPosicao, transform.position);

            if (distancia >= zoomMin && distancia <= zoomMax)
            {
                transform.position = novaPosicao;
            }
        }*/
    }

    private void TransformCamera(Transform novaPosicao)
    {
        if (novaPosicao != null)
        {
            // Move a c�mera para a nova posi��o
            transform.position = novaPosicao.position;
            transform.rotation = novaPosicao.rotation;
        }
    }
}
