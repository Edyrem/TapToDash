using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "New Player Settings")]
public class PlayerSettings : ScriptableObject
{
    public float speed;
    public float jumpForce;
    public float cameraTurnAngle;
    public float cameraTurnSpeed;
}
