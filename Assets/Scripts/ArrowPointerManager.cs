using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPointerManager : MonoBehaviour
{
    
    void Start()
    {
        foreach(Transform child in transform)
        {
            AllMoves.nextMove.Enqueue(child.GetComponent<ArrowPointer>().nextMove);
        }
    }

}
