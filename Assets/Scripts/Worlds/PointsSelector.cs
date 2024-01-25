using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsSelector : MonoBehaviour
{
    public enum PointAmount {
        _500,
        _750,
        _1000,
        _1500
    }

    public PointAmount points;
}
