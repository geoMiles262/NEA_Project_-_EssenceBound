using UnityEngine;
using TMPro;

public class UIEssenceDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text essenceText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialize the essence display with the current value
        if (ResourceManager.Instance != null)
            UpdateEssence(ResourceManager.Instance.CurrentEssence);
        else
            Debug.LogError("ResourceManager instance is not found.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        // Subscribe to the event to get notified when essence changes
       if (ResourceManager.Instance != null)
            ResourceManager.Instance.OnEssenceChanged += UpdateEssence;
    }

    private void OnDisable()
    {
        // Unsubscribe from the event to prevent memory leaks
        if (ResourceManager.Instance != null)
            ResourceManager.Instance.OnEssenceChanged -= UpdateEssence;
    }

    private void UpdateEssence(int newValue)
    {
        // Update the UI text to reflect the new essence value
        if (essenceText != null)
            essenceText.text = "Essence:" + newValue;
        else
            Debug.LogError("Essence Text UI element is not assigned.");
    }
}
