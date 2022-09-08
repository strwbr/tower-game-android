using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] private int score = 0;

    private List<Vector3> allPlatformsPos = new List<Vector3>() { Vector3.zero };


    private void Start()
    {
        PlatformToPlace.ActionPlatformAdded += AddPlatformPosToList;
        PlatformToPlace.ActionPlatformAdded += CheckPositionsOfTwoUpperPlatforms;
    }

    private void AddPlatformPosToList(Vector3 pos)
    {
        allPlatformsPos.Add(pos);
        //Debug.Log("New platform position was added to list");
    }

    private void CheckPositionsOfTwoUpperPlatforms(Vector3 addedPos)
    {
        Vector3 lastPos = allPlatformsPos[allPlatformsPos.Count - 2]; // на этом моменте новая платформа уже в листе

        if (ComparePlatfromPositions(lastPos, addedPos))
        {
            score++;
            //Debug.Log("They matched!!!");
        }
        else
        {
            //Debug.Log($"Diff = {CalculateDifferenceBetweenPositions(lastPos, addedPos)}");
        }
    }

    private bool ComparePlatfromPositions(Vector3 pos1, Vector3 pos2)
    {
        return CalculateDifferenceBetweenPositions(pos1, pos2) <= 0.001;
    }

    private float CalculateDifferenceBetweenPositions(Vector3 pos1, Vector3 pos2)
    {
        return Mathf.Abs(pos1.x - pos2.x);
    }
}
