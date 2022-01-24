using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Road : MonoBehaviour
{
    [SerializeField]
    [Range(2, 10)]
    private int roadLength = 10;

    [SerializeField]
    private Crystal _crystal;

    [SerializeField]
    private Transform road;

    private readonly Vector3 localStartPosition = new Vector3(0, 0.7f, 0.5f);
    private readonly float roadLengthCoeffitient = 0.5f;

    private void Start()
    {
        var crystalPosition = localStartPosition;
        for (int i = 0; i < roadLength; i++)
        {
            var crystal = Instantiate(_crystal, transform);
            crystal.transform.localPosition = crystalPosition;
            crystalPosition.z++;
        }
    }

    private void OnValidate()
    {
        road.localScale = new Vector3(road.localScale.x, road.localScale.y, roadLength);
        road.localPosition = new Vector3(road.localPosition.x, road.localPosition.y, roadLength * roadLengthCoeffitient);
    }
}