using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloaterScript : MonoBehaviour
{
    public GameObject ArcRenderer;
    public float movementSpeed;
    public int damage;
    public LayerMask ignorelayer;

    void Start()
    {
        Destroy(gameObject, 10);
    }

    public void setDamage(int i)
    {
        damage = i;
    }

    void Update()
    {
        transform.Translate(0, 0, movementSpeed * Time.deltaTime);

        Collider[] others = Physics.OverlapSphere(this.transform.position, 5, ~ignorelayer);
        for (int i = 0; i < others.Length; i++)
        {
            HealthController otherController = others[i].gameObject.transform.root.GetComponent<HealthController>();

            if (otherController != null)
            {
                otherController.getHit(damage);
                GameObject arcRenderer = Instantiate(ArcRenderer, transform.position, transform.rotation) as GameObject;
                arcRenderer.GetComponent<ArcRendererScript>().createArc(others[i].gameObject.transform.position);
            }
        }
    }
}