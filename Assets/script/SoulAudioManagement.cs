using UnityEngine;

public class SoulAudioManagement : MonoBehaviour
{
    public AudioSource SoulPickUpSoundSource;
    public AudioClip SoulPickUpSoundClip;
    public AudioSource SoulIdleSoundSource;
    public AudioClip SoulIdleSoundClip;

    private GameObject player;
    private float dist;
    public int soundDistanceDecayFactor = 10;

    private void Start()    // start the looping of the soul idle sound
    {
        player = GameObject.FindGameObjectWithTag("Player");    // lalalalaaaa je m'en fiiiiche
        SoulIdleSoundSource.clip = SoulIdleSoundClip;
        SoulIdleSoundSource.loop = true;
        SoulIdleSoundSource.Play();
    }

    private void FixedUpdate()  // change ambiant volume based on distance with player
    {
        dist = Vector3.Distance(transform.position, player.transform.position);
        SoulIdleSoundSource.volume = (soundDistanceDecayFactor-dist)/soundDistanceDecayFactor;
    }

    public void PlayPickUpSound()
    {
        SoulPickUpSoundSource.PlayOneShot(SoulPickUpSoundClip);
    }
}
