
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction
{
    const int ONEACTIONTOP = 0;
    const int ONEACTIONSIDE = 1;
    const int TWOACTIONTOP = 2;
    const int TWOACTIONSIDE = 3;
    const int ONEACTIONTOPONEACTIONSIDE = 4;

    // enum Actions
    // {
    //     ONEACTIONTOP,
    //     ONEACTIONSIDE,
    //     TWOACTIONTOP,
    //     TWOACTIONSIDE,
    //     ONETOPONESIDE
    // }

    private int action;
    private float timing;

    public Instruction(int a, float t)
    {
        action = a;
        timing = t;
    }

    public int getAction()
    {
        return action;
    }

    public float getTime()
    {
        return timing;
    }
}
