using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float inputH;
    private float inputV;
    private bool moviendo;
    private Vector3 puntoDestino;
    private Vector3 ultimoInput;
    private Vector3 puntoInteraccion;
    private Collider2D colliderDelante; //Collider que tenemos delante
    private SpriteRenderer spriteRenderer;
    private Animator anim;

    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float radioInteraccion;
    [SerializeField] private LayerMask queEsColisionable;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        LecturaInputs();

        MovimientoYAnimaciones();

    }

    private void MovimientoYAnimaciones()
    {
        // Voltear el sprite cuando se mueve hacia la derecha
        if (inputH > 0)
        {
            spriteRenderer.flipX = true; // Voltear cuando va a la derecha
        }
        else if (inputH < 0)
        {
            spriteRenderer.flipX = false; // Mantener normal cuando va a la izquierda
        }

        //Ejecución de movimiento solo si se está en una casilla y solo si hay input
        if (!moviendo && (inputH != 0 || inputV != 0))
        {
            anim.SetBool("andando", true);
            anim.SetFloat("inputH", inputH);
            anim.SetFloat("inputV", inputV);


            ultimoInput = new Vector3(inputH, inputV, 0);
            puntoDestino = transform.position + ultimoInput;
            puntoInteraccion = puntoDestino;

            colliderDelante = LanzarCheck();

            if (colliderDelante == false)
            {
                StartCoroutine(Mover());
            }

        }
        else if (inputH == 0 && inputV == 0)
        {
            anim.SetBool("andando", false);
        }
    }

    private void LecturaInputs()
    {
        if (inputV == 0)
        {
            inputH = Input.GetAxisRaw("Horizontal");
        }
        if (inputH == 0)
        {
            inputV = Input.GetAxisRaw("Vertical");
        }
    }

    IEnumerator Mover()
    {
        moviendo = true;
        puntoDestino = transform.position + new Vector3(inputH, inputV, 0);
        while (transform.position != puntoDestino)
        {
            transform.position = Vector3.MoveTowards(transform.position, puntoDestino, velocidadMovimiento * Time.deltaTime);
            yield return null;
        }
        //Ante nuevo destino, necesito refrescar de nuevo puntoInteraccion
        puntoInteraccion = transform.position + ultimoInput;
        moviendo= false;
    }

    private Collider2D LanzarCheck()
    {
        return Physics2D.OverlapCircle(puntoInteraccion, radioInteraccion, queEsColisionable);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(puntoInteraccion, radioInteraccion);

    }
}
