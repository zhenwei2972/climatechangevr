using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float food = 100;
    public float water = 100;

    public float Food
    {
        get { return food; }
        set { food = value; }
    }

    public float Water
    {
        get { return water; }
        set { water = value; }
    }
}
