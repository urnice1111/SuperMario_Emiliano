using UnityEngine;

public class AnimarPersonaje : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private EstadoPersonaje estadoPersonaje;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        estadoPersonaje = GetComponentInChildren<EstadoPersonaje>();
    }

    void Update()
    {
        // sync animator params with physics state
        animator.SetFloat("velocidad", Mathf.Abs(rb.linearVelocityX));
        animator.SetBool("enPIso", estadoPersonaje.estaEnSuelo);
        // flip sprite when moving left
        spriteRenderer.flipX = rb.linearVelocityX < 0;
    }
}
