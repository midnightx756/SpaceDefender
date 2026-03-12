using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip ShootingClip;
    [SerializeField][Range(0f, 1f)] float ShootingVolume = 1f;

    [Header("Damaging")]
    [SerializeField] AudioClip DamageClip;
    [SerializeField][Range(0f, 1f)] float DamageVolume = 1f;

    static AudioPlayer instance;

    public AudioPlayer GetInstance(){
            return instance;
    }

    void Awake(){
        ManageSingleton();
    }

    void ManageSingleton(){
       // int instanceCount = FindObjectsOfType(GetType()).Length;
        //if(instanceCount > 1)
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else{
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingCLip()
    {
        PlayClip(ShootingClip, ShootingVolume);
    }

    public void PlayDamageCLip()
    {
        PlayClip(DamageClip, DamageVolume);
    }

    void PlayClip(AudioClip Clip, float volume)
    {
       if (Clip != null)
        {
            AudioSource.PlayClipAtPoint(Clip,
                                        Camera.main.transform.position,
                                        volume);
        } 
    }
}
