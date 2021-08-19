using UnityEngine;

public class AudioController : MonoBehaviour
{
    public void MuteMusic()
    {
        AudioManager.instance.MuteMusic(AudioManager.BGMUSIC);
    }

    public void MuteSound()
    {
        AudioManager.instance.MuteSound(AudioManager.ACTIVATION_SOUND ,AudioManager.JUMP_SOUND);
    }
}