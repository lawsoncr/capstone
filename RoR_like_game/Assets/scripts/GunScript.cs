
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float damage = 15f;
    public float range = 100f;
    public Camera tpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impact;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }
    void Shoot(){
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(tpsCam.transform.position, tpsCam.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);
        }

        GameObject impactGo = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactGo, 1f);
    }
}
