using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Assertions;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    { get; private set; }

    [System.NonSerialized] public Camera gameCamera;

    [System.NonSerialized] public Test.Player[] activePlayers = new Test.Player[MAX_PLAYERS];
    private int numberOfActivePlayers = 0;

    public const int MAX_PLAYERS = 4;

    /// <summary>
    /// Returns player index,
    /// </summary>
    public int RegisterActivePlayer(Test.Player player)
    {
        Assert.IsFalse(numberOfActivePlayers > activePlayers.Length);
        for (int i = 0; i < activePlayers.Length; i++)
        {
            if (activePlayers[i])
            { continue; }

            activePlayers[i] = player;
            numberOfActivePlayers++;
            return i;
        }
        return -1;
    }

    public void UnregisterActivePlayer(int index)
    {
        activePlayers[index] = null;
        numberOfActivePlayers--;
    }

    public void GetActivePlayers(out Transform[] players)
    {
        players = new Transform[numberOfActivePlayers];
        int k = 0;
        for (int i = 0; i < activePlayers.Length; i++)
        {
            if (activePlayers[i])
            {
                players[k] = activePlayers[i].transform;
                k++;
            }
        }
    }

    #region Unity methods
    private void Awake()
    {
        Debug.Log("awake");
        if (Instance)
        { Destroy(gameObject); }
        else
        { Instance = this; }

        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    #endregion Unity methods

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        gameCamera = Camera.main;
    }
}
