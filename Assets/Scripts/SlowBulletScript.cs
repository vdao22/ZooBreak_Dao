using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBulletScript : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;

    public GameObject GridLayout;

    public void Seek(Transform _target)
    {
        target = _target;

        GridLayout = GameObject.Find("GridLayout");
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        SoundManagerScript.PlaySound("magic_02");
        Destroy(gameObject);
        GridLayout.GetComponent<GridScript>().money += 10;
    }
}
