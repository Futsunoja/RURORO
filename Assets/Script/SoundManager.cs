﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource aud;
    public AudioClip soundHitEnter, soundHitCancel, soundAttack, soundBlast, soundBuff, soundThirdSlash, soundNearDeathSlash, soundDrink, soundEnemyAttack;

    private void Awake()
    {
        instance = this;
    }

    public void SoundEnterHit()
    {
        aud.clip = soundHitEnter;
        aud.Play();
    }

    public void SoundHitCancel()
    {
        aud.clip = soundHitCancel;
        aud.Play();
    }

    public void SoundAttack()
    {
        aud.clip = soundAttack;
        aud.Play();
    }

    public void SoundBlast()
    {
        aud.clip = soundBlast;
        aud.Play();
    }

    public void SoundBuff()
    {
        aud.clip = soundBuff;
        aud.Play();
    }

    public void SoundThirdSlash()
    {
        aud.clip = soundThirdSlash;
        aud.Play();
    }

    public void SoundNearDeathSlash()
    {
        aud.clip = soundNearDeathSlash;
        aud.Play();
    }

    public void SoundDrink()
    {
        aud.clip = soundDrink;
        aud.Play();
    }

    public void SoundEnemyAttack()
    {
        aud.clip = soundEnemyAttack;
        aud.Play();
    }
}
