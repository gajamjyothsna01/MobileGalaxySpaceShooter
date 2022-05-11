using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //need to create a pool manager and prefab Manager

    #region SINGLETON REGION
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<GameManager>();
                if(instance == null)
                {
                    GameObject container = new GameObject("GameManager");
                    instance = container.AddComponent<GameManager>();
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
