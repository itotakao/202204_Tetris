using UnityEngine;

abstract class TetoriminoBase
{
    public Color color;
    public int[,] data;

    public abstract void rotationRight();
    public abstract void rotationLeft();
}
