using UnityEngine;

public static class Vector2Extensions 
{
    public static Vector2 SetX(this Vector2 source, float x) 
    { return new Vector2(x, source.y); }
    
    public static Vector2 SetY(this Vector2 source, float y) 
    { return new Vector2(source.x, y); }
    
    public static Vector2 SetX(this Vector3 source, float x) 
    { return new Vector2(x, source.y); }
    
    public static Vector2 SetY(this Vector3 source, float y) 
    { return new Vector2(source.x, y); }
}