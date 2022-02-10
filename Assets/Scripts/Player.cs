using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int food = 100;
    public int water = 100;

    public int Food
    {
        get { return food; }
        set { food = value; }
    }

    public int Water
    {
        get { return water; }
        set { water = value; }
    }
}
