﻿using System;
using System.Collections;
using System.Collections.Generic;
using FTG.AudioController;
using UnityEngine;
using Random = UnityEngine.Random;

public class Otter : MonoBehaviour
{
    /* ======================================================================================================================== */
    /* VARIABLE DECLARATIONS                                                                                                    */
    /* ======================================================================================================================== */

    private bool canPlaySound;
    
    /* ======================================================================================================================== */
    /* UNITY CALLBACKS                                                                                                          */
    /* ======================================================================================================================== */

    private void Start()
    {
        canPlaySound = true;
    }

    private void Update()
    {
    }

    private void OnMouseDown()
    {
        if (canPlaySound == true)
        {
            StartCoroutine(PlayOtterSoundCoroutine());
        }
    }

    /* ======================================================================================================================== */
    /* PRIVATE FUNCTIONS                                                                                                        */
    /* ======================================================================================================================== */

    private IEnumerator PlayOtterSoundCoroutine()
    {
        canPlaySound = false;
        string[] otterSounds =
        {
            "OtterSound1",
            "OtterSound2",
            "OtterSound3"
        };

        AudioController.Instance.PlaySoundOneShot(otterSounds[Random.Range(0, otterSounds.Length)]);

        yield return new WaitForSeconds(5f);
        canPlaySound = true;
    }

    /* ======================================================================================================================== */
    /* PUBLIC FUNCTIONS                                                                                                         */
    /* ======================================================================================================================== */

    /* ======================================================================================================================== */
    /* EVENT CALLERS                                                                                                            */
    /* ======================================================================================================================== */

    /* ======================================================================================================================== */
    /* EVENT LISTENERS                                                                                                          */
    /* ======================================================================================================================== */
}