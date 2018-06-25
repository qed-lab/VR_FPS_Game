using UnityEngine;
using UnityEngine.UI;

public class Gun_Xbox : MonoBehaviour
{
    public ParticleSystem MuzzleFlash;
    public Transform endBarrel;
    public GameObject impactEffect;
    public Text shotsFired;
    public AudioSource shoot;
    //public VRTK.VRTK_ControllerEvents controllerEvents;

    public float numberOfShots = 0f;
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 1f;
    public float fireRate = 4f;
    private float nextTimeToFire = 0f;

    // Update is called once per frame
    void Update()
    {




        if ((Input.GetButtonDown("Fire1") || Input.GetButtonDown("FirebuttonXbox")) && Time.time >= nextTimeToFire && Time.timeScale == 1f)
        {
            nextTimeToFire = Time.time + 0.3f;
            Shoot();
        }
    }

    void Shoot()
    {
        shoot.Play();
        MuzzleFlash.Play();
        numberOfShots += 1;
        shotsFired.text = numberOfShots.ToString();
        RaycastHit hit;
        float hAxis = Input.GetAxis("AimJoystickHorizontal");
        float vAxis = Input.GetAxis("AimJoystickVertical");
        Quaternion Rotation = Quaternion.Euler(vAxis * 30, hAxis * 30, 0);

        if (Physics.Raycast(endBarrel.transform.position, Rotation * endBarrel.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }

    }

}
