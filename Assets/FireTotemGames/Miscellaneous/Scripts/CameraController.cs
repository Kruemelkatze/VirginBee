﻿using UnityEngine;

public class CameraController : MonoBehaviour
{
    /* ======================================================================================================================== */
    /* VARIABLE DECLARATIONS                                                                                                    */
    /* ======================================================================================================================== */

    [SerializeField] private float defaultOrthographicSize = 5f;
    [SerializeField] private int defaultScreenWidth = 1920;
    [SerializeField] private int defaultScreenHeight = 1080;
    
    private float defaultRatio = 1920f / 1080f;
    private Camera camera1;

    /* ======================================================================================================================== */
    /* UNITY CALLBACKS                                                                                                          */
    /* ======================================================================================================================== */

    private void Start()
    {
        defaultRatio = (float)defaultScreenWidth / defaultScreenHeight;
        camera1 = GetComponent<Camera>();
        
        UpdateOrthographicSize();
    }

    /* ======================================================================================================================== */
    /* PRIVATE FUNCTIONS                                                                                                        */
    /* ======================================================================================================================== */

    private void UpdateOrthographicSize()
    {
        float multiplier = ((float)Screen.width / Screen.height) / defaultRatio;

        if (multiplier < 1f)
        {
            camera1.orthographicSize = defaultOrthographicSize / multiplier;
        }
        else
        {
            camera1.orthographicSize = defaultOrthographicSize;
        }
    }

    /* ======================================================================================================================== */
    /* PRIVATE FUNCTIONS                                                                                                        */
    /* ======================================================================================================================== */

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