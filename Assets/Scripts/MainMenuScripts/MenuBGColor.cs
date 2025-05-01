using UnityEngine;

public class MenuBGColor : MonoBehaviour
{

    [SerializeField] private Camera camRef;
    [SerializeField] private Color[] colors;
    [SerializeField] private float colorChangeSpeed;
    [SerializeField] private float time;
    private float currentTime;
    private int colorIndex;

    private void Awake()
    {
        camRef = Camera.main;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ColorChange();
        ColorChangeTime();
    }

    private void ColorChange()
    {
        camRef.backgroundColor = Color.Lerp(camRef.backgroundColor, colors[colorIndex], colorChangeSpeed * Time.deltaTime);
    }

    private void ColorChangeTime()
    {
        if (currentTime <= 0)
        {
            colorIndex++;
            CheckColorIndex();
            currentTime = time;
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
    }

    private void CheckColorIndex()
    {
        if (colorIndex >= colors.Length)
        {
            colorIndex = 0;
        }
    }

    private void OnDestroy()
    {
        camRef.backgroundColor = colors[0];
    }
}
