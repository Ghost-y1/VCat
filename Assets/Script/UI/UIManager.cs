using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Stat Bars")]
    [SerializeField]
    private Slider healthSlider;
    [SerializeField]
    private Slider hungerSlider;
    [SerializeField]
    private Slider moodSlider;
    [SerializeField]
    private GameObject statsPanel;
    [SerializeField] 
    private GameObject _petUIBotton;


    private StatsManager statManager;
    public bool STATSPANELACTIVE {get;private set;}
    private void Awake()
    {
        Instance = this;
        statManager = FindObjectOfType<StatsManager>();
    }

    private void Start()
    {
        statsPanel.SetActive(false);
    }
    private void Update()
    {
        UpdateSliders();
    }

    private void UpdateSliders()
    {
        if (statManager != null)
        {
            healthSlider.value = statManager.GetHealth() / 100;
            hungerSlider.value = statManager.GetHunger() / 100;
            moodSlider.value = statManager.GetMood() / 100;
        }
    }
    public void invokeStatsPanel()
    {
        statsPanel.SetActive(true);
        STATSPANELACTIVE = true;
        _petUIBotton.SetActive(false);
    }

    public void closeStatsPanel()
    {
        statsPanel.SetActive(false);
        STATSPANELACTIVE = false;
    }

}
