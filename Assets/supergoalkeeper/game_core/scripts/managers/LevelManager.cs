using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace game_core
{
    /// <summary>
    /// Level manager class; Deals with level load 
    /// transaction.
    /// </summary>
    public class LevelManager : MonoBehaviour
    {
        protected static LevelManager instance;
        protected static string levelName = "";

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static LevelManager Instance
        {
            get
            {
                if (instance == null)
                {
                    GameObject obj = new GameObject("LevelManager");
                    instance = obj.AddComponent<LevelManager>();

                    if (instance == null)
                    {
                        Debug.LogError("An instance of LevelManager is needed in the scene, but there is none.");
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets or sets the loading level.
        /// </summary>
        /// <value>The loading level.</value>
        public static string loadingLevel
        {
            set { levelName = value; }
            get { return levelName; }
        }

        /// <summary>
        /// Load the specified name.
        /// </summary>
        /// <param name="name">Name.</param>
        public static void Load(string name)
        {
            Object.DontDestroyOnLoad(Instance.gameObject);
            loadingLevel = name;
            SceneManager.LoadScene(name);
        }

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
