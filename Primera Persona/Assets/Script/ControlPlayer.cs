using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    public float rapidezDesplazamiento = 10.0f;
    public Camera camaraPrimeraPersona;
    public GameObject proyectil;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float movimientoAdelanteAtras = Input.GetAxis("Vertical") * rapidezDesplazamiento;
        float movimientoCostados = Input.GetAxis("Horizontal") * rapidezDesplazamiento;

        movimientoAdelanteAtras *= Time.deltaTime;
        movimientoCostados *= Time.deltaTime;

        transform.Translate(movimientoCostados, 0, movimientoAdelanteAtras);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camaraPrimeraPersona.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            GameObject pro;
            pro = Instantiate(proyectil, ray.origin, transform.rotation);

            Rigidbody rb = pro.GetComponent<Rigidbody>();
            rb.AddForce(camaraPrimeraPersona.transform.forward * 15, ForceMode.Impulse);

            Destroy(pro, 5);

            if ((Physics.Raycast(ray, out hit) == true) && hit.distance < 5)
            {
                Debug.Log("El rayo tocó al objeto: " + hit.collider.name);

                if (hit.collider.name.Substring(0, 3) == "Lia")
                {
                    GameObject objetoTocado = GameObject.Find(hit.transform.name);
                    ControlLiana scriptObjetoTocado = (ControlLiana)objetoTocado.GetComponent(typeof(ControlLiana));

                    if (scriptObjetoTocado != null)
                    {
                        scriptObjetoTocado.recibirDaño();
                    }
                }
            }
        }


    }
}
