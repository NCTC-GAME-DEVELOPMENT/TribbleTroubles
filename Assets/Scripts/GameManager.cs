using UnityEngine;
using System.Collections.Generic;
using static UnityEngine.Rendering.DebugUI;


//Connects all managers to keep game running
public class GameManager : MonoBehaviour
{
    public GameObject WholeWorld;
    public GameObject WhiteWorld;
    public GameObject RedWorld;
    public GameObject YellowWorld;
    public GameObject BlueWorld;

    public EnumWorldColor currentLens = EnumWorldColor.Blank;
    public delegate void LensFunction();
    private List<LensFunction> LensStates;
    int LensStateIndex = 0;

    public static GameManager Instance;

    private Dictionary<string, bool> levelFlags;

    private void Awake()
    {
        // Lazy Singleton
        Instance = this;

        LensStates = new List<LensFunction>();
        LensStates.Add(BlankState);
        LensStates.Add(RedState);
        LensStates.Add(YellowState);
        LensStates.Add(BlueState);

        levelFlags = new Dictionary<string, bool>();
    }

    void Start()
    {
        BlankState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetFlag(string flagname, bool value)
    {
        if(levelFlags.ContainsKey(flagname))
        {
            levelFlags[flagname] = value;
        }
        else
        {
            levelFlags.Add(flagname, value);
        }
    }

    public bool GetFlag(string flagname)
    {
        if (levelFlags.ContainsKey(flagname))
        {
            return levelFlags[flagname];
        }
        return false;
    }

    public void CycleLensPlus()
    {
        Debug.Log("CL PLUS Activated");
        LensStateIndex++;
        if (LensStateIndex >= LensStates.Count)
        {
            LensStateIndex = 0;
        }

        LensStates[LensStateIndex]?.Invoke();
    }

    public void CycleLensMinus()
    {
        Debug.Log("CL MINUS Activated");

        LensStateIndex--;
        if (LensStateIndex < 0)
        {
            LensStateIndex = (LensStates.Count - 1);
        }

        LensStates[LensStateIndex]?.Invoke();
    }

    public void BlankState()
    {
        RedWorld.SetActive(false);
        YellowWorld.SetActive(false);
        BlueWorld.SetActive(false);
        currentLens = EnumWorldColor.Blank;
        Debug.Log("Blank world activated");
    }

    public void RedState()
    {
        RedWorld.SetActive(true);
        YellowWorld.SetActive(false);
        BlueWorld.SetActive(false);
        currentLens = EnumWorldColor.Red;
        Debug.Log("Red world activated");
    }

    public void YellowState()
    {
        RedWorld.SetActive(false);
        YellowWorld.SetActive(true);
        BlueWorld.SetActive(false);
        currentLens = EnumWorldColor.Yellow;
        Debug.Log("Yellow world activated");
    }

    public void BlueState()
    {
        RedWorld.SetActive(false);
        YellowWorld.SetActive(false);
        BlueWorld.SetActive(true);
        currentLens = EnumWorldColor.Blue;
        Debug.Log("Blue world activated");
    }
}
