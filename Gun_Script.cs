
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gun_Script : MonoBehaviour
{
    public float damage = 10f; //adjustable damage of raycast
    public float range = 100f; // adjustable effective range of raycast
    public int maxAmmo;
    public int currentAmmo;
    public float reloadTime = 1f;
    private bool Reloading = false;
    public Text AmmoDisplay;
    public Text AmmoDisplay1;

    public Camera fpsCam; // set up where the raycast will be cast from

    public AudioSource reloadAduio;
    public AudioSource gunShot;


    private void Start()
    {
        currentAmmo = maxAmmo; // sets the guns current ammo to its max ammo when the game starts
    }


    // Update is called once per frame
    void Update()
    {
        AmmoDisplay.text = currentAmmo + "/" + maxAmmo.ToString();
        AmmoDisplay1.text = currentAmmo + "/" + maxAmmo.ToString();


        if (Reloading)
            return;
        if (currentAmmo <=0)
        {
            StartCoroutine(reload());
            
            return;
        }   
        if(Input.GetButtonDown("Fire1")) // if fire 1 is hit, in this case left mouse button it calls on the shoot function
        {
            
            shoot();
        }
        if (Input.GetButtonDown("right Control")) // if fire 1 is hit, in this case left mouse button it calls on the shoot function
        {

            shoot();
        }
    }

    IEnumerator reload ()
    {
        Reloading = true; // starts reload function
        

        reloadAduio.Play(); // when reloading plays a reload sound

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo; // resets ammo to the max
        Reloading = false; // stops reload function
    }

    void shoot() // shootfunction fires raycast,
    {
        currentAmmo--;
        gunShot.Play();
       
        RaycastHit hit;
       if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name); // reads out what is hit from raycast


            Destructable_Script target = hit.transform.GetComponent<Destructable_Script>(); // checks if the object that is hit has a target component which allows it to take damage
            if(target != null) // if what is hit has the target component
            {
                target.TakeDamage(damage);
            }
        }
    }
}
