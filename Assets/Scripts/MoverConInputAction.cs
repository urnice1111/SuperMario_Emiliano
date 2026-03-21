using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoverConInputAction : MonoBehaviour
{
    [SerializeField] private InputAction accionMover;

    [SerializeField] private InputAction accionSalto;

    private Rigidbody2D rb;
    private EstadoPersonaje estado;


    [SerializeField] private float XVelocity = 4f;

    [SerializeField] private float YVelocity = 4.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        accionMover.Enable();

        rb = GetComponent<Rigidbody2D>();
        estado = GetComponentInChildren<EstadoPersonaje>();

        
    }

    void OnEnable()
    {
        accionSalto.Enable();
        accionSalto.performed += Saltar;
    }

    void OnDisable()
    {
        accionSalto.Disable();
        accionSalto.performed -= Saltar;
    }

    public void Saltar(InputAction.CallbackContext context)
    {
        if (estado.estaEnSuelo)
        {
            rb.linearVelocityY = YVelocity;
        }
        // rb.linearVelocityY = YVelocity;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movimiento = accionMover.ReadValue<Vector2>();
        // transform.position = (Vector2)transform.position + Time.deltaTime * XVelocity * movimiento;
        rb.linearVelocityX = XVelocity * movimiento.x;

    }
}
