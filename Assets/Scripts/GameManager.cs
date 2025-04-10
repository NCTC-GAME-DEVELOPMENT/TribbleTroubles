using UnityEngine;
using System.Collections.Generic;


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

    private void Awake()
    {
        // Lazy Singleton
        Instance = this;

        LensStates = new List<LensFunction>();
        LensStates.Add(BlankState);
        LensStates.Add(RedState);
        LensStates.Add(YellowState);
        LensStates.Add(BlueState);
    }

    void Start()
    {
        BlankState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CycleLensPlus()
    {
        LensStateIndex++;
        if (LensStateIndex >= LensStates.Count)
        {
            LensStateIndex = 0;
        }

        LensStates[LensStateIndex]?.Invoke();
    }

    public void CycleLensMinus()
    {
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
    }

    public void RedState()
    {
        RedWorld.SetActive(true);
        YellowWorld.SetActive(false);
        BlueWorld.SetActive(false);
        currentLens = EnumWorldColor.Red;
    }

    public void YellowState()
    {
        RedWorld.SetActive(false);
        YellowWorld.SetActive(true);
        BlueWorld.SetActive(false);
        currentLens = EnumWorldColor.Yellow;
    }

    public void BlueState()
    {
        RedWorld.SetActive(false);
        YellowWorld.SetActive(false);
        BlueWorld.SetActive(true);
        currentLens = EnumWorldColor.Blue;
    }
}
