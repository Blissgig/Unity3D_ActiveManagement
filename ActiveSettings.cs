using UnityEngine;

public class ActiveSettings 
{
    public float minDistance = 500;
    public ObjectType objectType = ActiveSettings.ObjectType.Default; //This is used in unique situations.  Not necessary for basic usage.  

    public Transform activeTransform;
    public Vector3 position;
    
    public enum ObjectType
    {
        Default,
        Building
    }

    public ActiveSettings()
    {
    }

    public ActiveSettings(Transform activeTransform, float minDistance)
    {
        this.activeTransform = activeTransform;
        this.minDistance = minDistance;
        this.position = activeTransform.position;
    }

    public ActiveSettings(Transform activeTransform, float minDistance, Vector3 position)
    {
        this.activeTransform = activeTransform;
        this.minDistance = minDistance;
        this.position = position;
    }

    public ActiveSettings(Transform activeTransform, float minDistance, ObjectType objectType)
    {
        this.activeTransform = activeTransform;
        this.minDistance = minDistance;
        this.objectType = objectType;
        this.position = activeTransform.position;
    }

    public ActiveSettings(Transform activeTransform, Vector3 position, float minDistance, ObjectType objectType)
    {
        this.activeTransform = activeTransform;
        this.minDistance = minDistance;
        this.objectType = objectType;
        this.position = position;
    }
}