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
    public static Vector2 FindCoordinate(Vector2 pos, float unit)
    {
        Vector2 result = Vector3.zero;
        result.x = FloatRound(pos.x, unit);
        result.y = FloatRound(pos.y, unit);
        return result;
    }
}
