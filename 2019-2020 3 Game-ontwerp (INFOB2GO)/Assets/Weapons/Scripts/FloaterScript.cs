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
            HealthController otherController = FindParentWithHealth(others[i].gameObject);

            if (otherController != null)
            {
                otherController.getHit(damage);
                GameObject arcRenderer = Instantiate(ArcRenderer, transform.position, transform.rotation) as GameObject;
                arcRenderer.GetComponent<ArcRendererScript>().createArc(others[i].gameObject.transform.position);
            }
        }
    }

    public HealthController FindParentWithHealth(GameObject childObject)
    {
        Transform t = childObject.transform;
        int i = 0;
        if (t.gameObject.GetComponent<HealthController>())
        {
            return t.gameObject.GetComponent<HealthController>();
        }
        while (t.parent != null)
        {
            if (t.parent.gameObject.GetComponent<HealthController>())
            {
                Debug.Log(t.parent.name);
                return t.parent.gameObject.GetComponent<HealthController>();
            }
            t = t.parent.transform;
        }
        return null; // Could not find a parent with given tag.
    }
}