/* AudioManager.cs

		----------------------------------------------------------------------
		Persephone

		Author : Özge Kocaoğlu 
* ------------------------------------------------------------------------ */
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Persephone
{ 
public class AudioManager : SingletonManager<AudioManager>
{
	public AudioMixer audioMixer;
	public bool isAudioPlaying = true;
	public float audioMasterVolume = 1;
	public AudioMixer musicMixer;
	public bool isMusicPlaying = true;
	public float musicMasterVolume = 1;
	public List<Sound> sounds;


	public void AwakeOmegaAudioManager()
	{
		UIInputManager.soundToggle += AudioToggle;
		UIInputManager.musicToggle += MusicToggle;

		for (int i = 0; i < sounds.Count; i++) {
			GameObject soundObject = new GameObject("Sound" + i + "-" + sounds[i].clipName);
			soundObject.transform.SetParent(this.transform);
			sounds[i].SetSource(soundObject.AddComponent<AudioSource>());
		}

	}

	public void StartOmegaAudioManager()
	{
		StartPlayOnAwakeAudios();
		audioMixer.SetFloat("myMasterVol", audioMasterVolume);
		musicMixer.SetFloat("myMusicVol", musicMasterVolume);
	}

	public void PlayAudio(string audioName)
	{
		for (int i = 0; i < sounds.Count; i++) {
			if (sounds[i].clipName == audioName) {
				sounds[i].Play();
				return;
			}
		}
	}

	public void StopAudio(string audioName)
	{
		for (int i = 0; i < sounds.Count; i++) {
			if (sounds[i].clipName == audioName) {
				sounds[i].Stop();
				return;
			}
		}
	}

	public void MuteAudio(string audioName)
	{
		for (int i = 0; i < sounds.Count; i++) {
			if (sounds[i].clipName == audioName) {
				sounds[i].Mute();
				return;
			}
		}
	}

	public void UnMuteAudio(string audioName)
	{
		for (int i = 0; i < sounds.Count; i++) {
			if (sounds[i].clipName == audioName){
				sounds[i].UnMute();
				return;
			}
		}
	}

	public void StartPlayOnAwakeAudios()
	{
		for (int i = 0; i < sounds.Count; i++)
			if (sounds[i].PlayOnAwake)
				PlayAudio(sounds[i].clipName);
	}

	public void PlayAudios()
	{
		audioMixer.SetFloat("myMasterVol", 1f);
		isAudioPlaying = true;
		PlayerPrefsManager.Instance.SaveAudioPlayerPrefs(isAudioPlaying, 1f);
	}

	public void StopAudios()
	{
		audioMixer.SetFloat("myMasterVol", 0f);
		isAudioPlaying = false;
		PlayerPrefsManager.Instance.SaveAudioPlayerPrefs(isAudioPlaying, 0f);
	}

	public void PlayMusics()
	{
		musicMixer.SetFloat("myMusicVol", 1f);
		isMusicPlaying = true;
		PlayerPrefsManager.Instance.SaveMusicPlayerPrefs(isMusicPlaying, 1f);
	}

	public void StopMusics()
	{
		musicMixer.SetFloat("myMusicVol", 0f);
		isMusicPlaying = false;
		PlayerPrefsManager.Instance.SaveMusicPlayerPrefs(isMusicPlaying, 0f);
	}

	void MusicToggle()
	{
		if (isMusicPlaying) StopMusics();
		else PlayMusics();
	}

	void AudioToggle()
	{
		if (isAudioPlaying) StopAudios();
		else PlayAudios();
	}
}
}

