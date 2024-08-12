using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioPlaying
{
    public static void PlayAudio(this GameObject player, AudioClip audioClip)
    {
        player.GetComponent<AudioSource>().clip = audioClip;
        player.GetComponent<AudioSource>().Play();
    }
}
