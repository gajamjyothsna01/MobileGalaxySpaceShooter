using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    #region SINGLETON METHOD
    private static PoolManager instance;
    public static PoolManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<PoolManager>();
                if(instance == null)
                {
                    GameObject container = new GameObject("PoolManager");
                    container.AddComponent<PoolManager>();
                }
            }
            return instance;
        }
    }
    #endregion
    #region PUBLIC VARIABLES
    #endregion
    #region PRIVATE VARIABLES
    #endregion

    #region MONOBEHAVIOUR METHODS
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

    #region PUBLIC METHODS
    #endregion


}
