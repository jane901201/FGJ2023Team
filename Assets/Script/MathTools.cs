using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathTools
{
    public static float FloatRound(float value, float roundUnit)
    {
        int valueUnit = (int)(value / roundUnit + 0.5f + 10000) - 10000;
        return roundUnit * valueUnit;
    }
    public static Vector3 FindCoordinate(Vector3 pos, float unit)
    {
        Vector3 result = Vector3.zero;
        result.x = FloatRound(pos.x, unit);
        result.y = FloatRound(pos.y, unit);
        result.z = FloatRound(pos.z, unit);
        return result;
    }
}
