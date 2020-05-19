using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    [SerializeField] Waypoint startPoint;
    [SerializeField] Waypoint endPoint;
    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        SetTopColor();
    }

    private void SetTopColor()
    {
        startPoint.SetColor(Color.cyan);
        endPoint.SetColor(Color.red);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            if (grid.ContainsKey(waypoint.GetGridPos()))
            {
                Debug.LogWarning("Skipping Block " + waypoint);
            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
                
            }
        }
        //print("Added: " + grid.Count + " Waypoints");
    }
}
