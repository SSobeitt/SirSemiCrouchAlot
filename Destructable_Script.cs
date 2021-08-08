
using UnityEngine;
using UnityEngine.Audio;

public class Destructable_Script : MonoBehaviour
{
    public float health = 50f;
    public AudioSource Audio;

    public void TakeDamage (float amount)
    {
        health -= amount;
        if(health<- 0f) // when the hp is less than or equal to
        {
            die();
        }
    }

    void die()
    {
        Destroy(gameObject); // when the object "Dies" it destorys the game object and plays an Audio Source
        Audio.Play(); 
    }

    
}
