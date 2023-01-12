using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataPersistenceManager : MonoBehaviour 
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    [Header("Menu Buttons")]
    [SerializeField] private Button Save;

    [Header("Debugging")]
    [SerializeField] private bool initializeDataIfNull = false;

    public PlayerData data;
    
    private List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandler dataHandler;
    
    public static DataPersistenceManager instance { get; private set; }
     

    public void Awake() 
    {
        
        if (instance != null) 
        {
            Debug.Log("Found more than one Data Persistence Manager in the scene. Destroying the newest one.");
            
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
    }

    private void OnEnable(){
        SceneManager.sceneLoaded += OnSceneLoaded;
        
    }

    private void OnDisable(){
        SceneManager.sceneLoaded -= OnSceneLoaded;
        
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        NewGame();
        
    }

    public void OnSceneUnloaded(Scene scene){
        SaveGame();
    }

    public void NewGame(){
        
        this.data = new PlayerData();
    }

    public void LoadGame(){
        this.data = dataHandler.Load();
        if (this.data == null && initializeDataIfNull){
            NewGame();
        }

        if(this.data == null){
            Debug.Log("No data was found. Initializing data to defaults");
            NewGame();
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects) 
        {
            dataPersistenceObj.LoadData(data);
        }

    }

    public void SaveGame(){
        if (this.data == null){
            Debug.LogWarning("No data was found. A New Game needs to be started before data can be saved.");
            return;
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects) 
        {
            dataPersistenceObj.SaveData(ref data);
        }
        

        dataHandler.Save(data);
    }

    private void OnApplicationQuit(){
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects(){
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }
    public bool HasGameData(){
        return data != null;
    }
}
