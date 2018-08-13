using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]                           // wird benötigt damit das mit monobehaviour entfernung funktioniert
public class HousePrefabAndCost
{                                                   //  : MonoBehaviour wurde entfenrt weil wir es nicht als komponeten in unity haben wollen

    public GameObject prefab;
    public int cost;

}
