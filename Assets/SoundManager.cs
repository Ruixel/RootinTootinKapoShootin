using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip bigexplode, bump, fire, explode, hitpatrol;
    static AudioSource audiosrc;
    // Start is called before the first frame update
    void Start()
    {
        bigexplode = Resources.Load<AudioClip>("bigexplode");
        explode = Resources.Load<AudioClip>("explode");
        fire = Resources.Load<AudioClip>("fire");
        hitpatrol = Resources.Load<AudioClip>("hitpatrol");
        bump = Resources.Load<AudioClip>("bump");

        audiosrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip){
        switch (clip)
        {
            case "fire":
                audiosrc.PlayOneShot(fire);
                break;
            case "bump":
                audiosrc.PlayOneShot(bump);
                break;
            case "explode":
                audiosrc.PlayOneShot(explode);
                break;
            case "hitpatrol":
                audiosrc.PlayOneShot(hitpatrol);
                break;
            case "bigexplode":
                audiosrc.PlayOneShot(bigexplode);
                break;
            default:
                Debug.LogWarning("Sound: " + clip + " not found!");
                break;
        }
    }
}
