using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    private Slider HealthBar;

    private Comp_UnitInfo trainInfo;
    /// <summary>
    /// Sets the health bar value
    /// </summary>
    /// <param name="value">should be between 0 to 1</param>
    public void SetHealthBarValue(float value)
    {
        HealthBar.value = value;
        if (value/HealthBar.maxValue < 0.2)
        {
            SetHealthBarColor(Color.red);
        }
        else if (value / HealthBar.maxValue < 0.4f)
        {
            SetHealthBarColor(Color.yellow);
        }
        else
        {
            SetHealthBarColor(Color.green);
        }
    }

    public float GetHealthBarValue()
    {
        return HealthBar.value;
    }

    /// <summary>
    /// Sets the health bar color
    /// </summary>
    /// <param name="healthColor">Color </param>
    public void SetHealthBarColor(Color healthColor)
    {
        HealthBar.fillRect.GetComponent<Image>().color = healthColor;
    }

    /// <summary>
    /// Initialize the variable
    /// </summary>
    private void Start()
    {
        HealthBar = GetComponent<Slider>();

        trainInfo = GameObject.FindWithTag("Train").GetComponent<Comp_UnitInfo>();
        HealthBar.maxValue = trainInfo.Health;
    }

    private void Update()
    {
        SetHealthBarValue(trainInfo.Health);
    }
}
