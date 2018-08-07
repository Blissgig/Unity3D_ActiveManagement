using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ActiveMgmt : MonoBehaviour
{
    public List<ActiveProperties> activeProperties = new List<ActiveProperties>();
    public float timerInterval = 1.5f;
    public float timerStart = 0.5f;
    private List<ActiveSettings> activeItems = new List<ActiveSettings>();


    private void Start()
    {
        try
        {
            foreach(ActiveProperties activeProperty in activeProperties)
            {
                var activeObjects = GameObject.FindGameObjectsWithTag(activeProperty.objectTag);

                foreach (var activeObject in activeObjects)
                {
                    //The developer can simply tag items, and those tags will be affected in the DistanceByTag() function
                    //However, if desired specific game objects can have an attached ActiveSettings script with it's own specific values
					//Also be aware that if you are going to use ActiveSettings in this manner then that class will need to inherit from MonoBehaviour
                    //var activeSetting = activeObject.GetComponent<ActiveSettings>();

                    //if (activeSetting == null)
                    //{
                        var activeSetting = new ActiveSettings(activeObject.transform, activeProperty.minDistance);
                    //}

                    //Example of how the Object Type is used.
                    //if (activeProperty.objectTag == "HBCBuilding")
                    //{
                    //    activeSetting.objectType = ActiveSettings.ObjectType.Building;
                    //}

                    activeItems.Add(activeSetting);
                }
            }

            InvokeRepeating("ActivateObjects", timerStart, timerInterval);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("ActiveMgmt Start Ex: " + ex.Message);
        }
    }

    private void ActivateObjects()
    {
        try
        {
            foreach (ActiveSettings activeItem in activeItems)
            {
                float distance = Vector3.Distance(activeItem.position, transform.position);

                if (distance < activeItem.minDistance)
                {
                    activeItem.activeTransform.gameObject.SetActive(true);
                }
                else
                {
                    activeItem.activeTransform.gameObject.SetActive(false);
                }
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("ActivateObjects ex:" + ex.Message);
        }
    }
    
    public void AddItem(ActiveSettings activeSetting)
    {
        activeItems.Add(activeSetting);
    }
}
