using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPointer : MonoBehaviour
{
    [SerializeField]
    private Transform arrow;

    public NextMove nextMove;

    private void OnValidate()
    {
        switch (nextMove)
        {
            case NextMove.Left: {
                    arrow.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    break;
                }
            case NextMove.Right: {
                    arrow.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
                    break;
                }
            case NextMove.Forward: {
                    arrow.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
                    break;
                }
            case NextMove.Backward:
                {
                    arrow.localRotation = Quaternion.Euler(new Vector3(0, 270, 0));
                    break;
                }
        }        
    }
}
