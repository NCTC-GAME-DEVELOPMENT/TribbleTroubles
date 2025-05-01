using UnityEngine;
using System.Collections.Generic;


//Connects all managers to keep game running
public class GameManager : MonoBehaviour
{
    public Camera cam;


    public GameObject WholeWorld;
    public GameObject WhiteWorld;
    public GameObject RedWorld;
    public GameObject YellowWorld;
    public GameObject BlueWorld;

    public Color BlankBackgroundColor = Color.gray; 
    public Color RedBackgroundColor = Color.red;
    public Color YellowBackgroundColor = Color.yellow;
    public Color BlueBackgroundColor = Color.blue;

    public GameObject currentCheckPoint;

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
        if (levelFlags.ContainsKey(flagname))
        {
            //Debug.Log("SET: DIC Contains " + flagname);
            levelFlags[flagname] = value;
        }
        else
        {
            //  Debug.Log("SET: DIC adds " + flagname);
            levelFlags.Add(flagname, value);
        }
    }

    public bool GetFlag(string flagname)
    {


        if (levelFlags.ContainsKey(flagname))
        {
            //Debug.Log("GET: DIC Contains " + flagname);
            return levelFlags[flagname];
        }

        // Debug.Log("SET: DIC Missing " + flagname);
        return false;
    }

    public void CycleLensPlus()
    {
        // Debug.Log("CL PLUS Activated");
        LensStateIndex++;
        if (LensStateIndex >= LensStates.Count)
        {
            LensStateIndex = 0;
        }

        LensStates[LensStateIndex]?.Invoke();
    }

    public void CycleLensMinus()
    {
        // Debug.Log("CL MINUS Activated");

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
        cam.backgroundColor = BlankBackgroundColor;
        PlayerManager.Instance.SetPlayerMaterial(PlayerManager.Instance.BlankMat);
    }

    public void RedState()
    {
        RedWorld.SetActive(true);
        YellowWorld.SetActive(false);
        BlueWorld.SetActive(false);
        currentLens = EnumWorldColor.Red;
        Debug.Log("Red world activated");
        cam.backgroundColor = RedBackgroundColor;
        PlayerManager.Instance.SetPlayerMaterial(PlayerManager.Instance.RedMat);
    }

    public void YellowState()
    {
        RedWorld.SetActive(false);
        YellowWorld.SetActive(true);
        BlueWorld.SetActive(false);
        currentLens = EnumWorldColor.Yellow;
        Debug.Log("Yellow world activated");
        cam.backgroundColor = YellowBackgroundColor;
        PlayerManager.Instance.SetPlayerMaterial(PlayerManager.Instance.YellowMat);
    }

    public void BlueState()
    {
        RedWorld.SetActive(false);
        YellowWorld.SetActive(false);
        BlueWorld.SetActive(true);
        currentLens = EnumWorldColor.Blue;
        Debug.Log("Blue world activated");
        cam.backgroundColor = BlueBackgroundColor;
        PlayerManager.Instance.SetPlayerMaterial(PlayerManager.Instance.BlueMat);
    }

    public void SetCheckPoint(GameObject newCheckPoint)
    {
        currentCheckPoint = newCheckPoint;
    }

    public GameObject GetCheckPoint()
    {
        return currentCheckPoint;
    }
}