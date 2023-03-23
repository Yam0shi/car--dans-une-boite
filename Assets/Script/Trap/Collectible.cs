using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Collectible", menuName = "Data ScriptableObject")]
public class Collectible : ScriptableObject
{
    [SerializeField] float value;
    public GameObject apparence;
    [SerializeField] float Duration;
    [SerializeField] ObjectType type;

    public enum ObjectType {goldForSkin, powerUp, malus};
}
