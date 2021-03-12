using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBulletScript : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public GameObject impactEffect;

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
        GameObject effectInstance = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 2f);
        SoundManagerScript.PlaySound("cannon_01");
        EnemiesLeftScript.enemiesLeft--;
        Destroy(target.gameObject);
        Destroy(gameObject);
        GridLayout.GetComponent<GridScript>().money += 25;
    }
}
