﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FTG.AudioController;
using UnityEditor;
using UnityEngine;

public class Bee : MonoBehaviour
{
    public Honeycomb originTile; // Where Bee was standing
    public Honeycomb currentTile; // Where Bee is standing
    public Honeycomb targetTile; // Where Bee should go

    [SerializeField] bool moving = false;
    [SerializeField] Coroutine activeNavigation;
    [SerializeField] private int minPathLengthForSound = 3;
        
    public float navTimeStep = 0.5f; // [s]
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetStartTile(Honeycomb startTile)
    {
        transform.position = startTile.transform.position;
        originTile = startTile;
        currentTile = startTile;
    }

    public void Navigate(List<Honeycomb> path)
    {
        if (path.Count == 0) 
            return;

        if (activeNavigation != null)
        {
            StopCoroutine(activeNavigation);
        }

        targetTile = path.Last();
        activeNavigation = StartCoroutine(NavigateAsync(path));
    }

    private IEnumerator NavigateAsync(List<Honeycomb> path)
    {
        moving = true;

        if (path.Count >= minPathLengthForSound)
        {
            AudioController.Instance.PlaySound("BeeLoopSound");
            AudioController.Instance.TransitionToSnapshot("BeeSnapshot", 0.3f);
        }

        var startIndex = path.First() == originTile ? 1 : 0;

        for (int i = startIndex; i < path.Count; i++)
        {
            var current = path[i];
            yield return new WaitForSeconds(navTimeStep);
            // TODO: When smoothly navigating and we stop the coroutine, when should we set the currentTile?
            currentTile = current;
            transform.position = current.transform.position;
        }

        originTile = targetTile;
        targetTile = null;
        moving = false;
        GameController.Instance.BeeFinishedNavigating(originTile);
        
        AudioController.Instance.TransitionToSnapshot("SoundSnapshot", 0.3f);
        yield return new WaitForSeconds(0.3f);
        AudioController.Instance.StopSound("BeeLoopSound");
    }
    
    
    [CustomEditor(typeof(Bee))]
    public class BeeEditor : Editor
    {

        public bool IsAnyOpen = true;
        
        public override void OnInspectorGUI()
        {
            var bee = target as Bee;
            DrawDefaultInspector();
            
            if (GUILayout.Button("Check Connected Tiles"))
            {
                var flood = PathfinderBeemaker.GetAllConnectedTiles(bee.currentTile);
                IsAnyOpen = flood.Any(t => t.HasAnyDoor());

                Debug.Log(string.Join(",",flood.Select(x => x.number)));
                Debug.Log(IsAnyOpen);
            }
        }
    }
}
