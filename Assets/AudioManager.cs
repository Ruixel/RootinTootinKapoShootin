using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioClip bigexplode, bump, fire, explode, hitpatrol, deathknoll, switchsound;
    static AudioSource audiosrc;
    // Start is called before the first frame update
    void Start()
    {
        bigexplode = Resources.Load<AudioClip>("bigexplode");
        explode = Resources.Load<AudioClip>("explode");
        fire = Resources.Load<AudioClip>("fire");
        hitpatrol = Resources.Load<AudioClip>("hitpatrol");
        bump = Resources.Load<AudioClip>("bump");
        deathknoll = Resources.Load<AudioClip>("deathknoll");
        switchsound = Resources.Load<AudioClip>("switchsound");

        audiosrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
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
            case "deathknoll":
                audiosrc.PlayOneShot(deathknoll);
                break;
            case "switchsound":
                audiosrc.PlayOneShot(switchsound);
                break;
            default:
                Debug.LogWarning("Sound: " + clip + " not found!");
                break;
        }
    }
}