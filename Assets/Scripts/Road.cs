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

    private void Start()
    {
        var position = new Vector3(0, 0.7f, 0.5f);
        for (int i = 0; i < roadLength; i++)
        {
            var crystal = Instantiate(_crystal, transform);
            crystal.transform.localPosition = position;
            position.z++;
        }
    }

    private void OnValidate()
    {
        road.localScale = new Vector3(road.localScale.x, road.localScale.y, roadLength);
        road.localPosition = new Vector3(road.localPosition.x, road.localPosition.y, roadLength * 0.5f);
    }
}