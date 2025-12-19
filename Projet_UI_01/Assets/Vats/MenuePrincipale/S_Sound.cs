using UnityEngine;
using UnityEngine.Audio;

public class S_Sound : MonoBehaviour
{
    [SerializeField] AudioClip List_ClipSound;
    public AudioSource audioSource_GameObject;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        audioSource_GameObject = GetComponent<AudioSource>();
        audioSource_GameObject.clip = List_ClipSound;
        playsound(true);
    }

    public void playsound(bool play)
    {
        
        if (audioSource_GameObject != null)
        {
            if (play)
            {
                audioSource_GameObject.Play();
            }
            else
            {
                audioSource_GameObject.Stop();
            }
        }
    }
    public void ChangeVolume(float value)
    {
        audioSource_GameObject.volume = value;
    }
}
