using UnityEngine;

public class ResourceManager : MonoBehaviour 
{
    public static ResourceManager Instance { get; private set; }

    [SerializeField] private int essence = 0;

    private void Awake() 
    {
        if (Instance == null) 
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } 
        else 
        {
            Destroy(gameObject);
        }
    }

    public int CurrentEssence => essence;

    public void AddEssence(int amount) 
    {
        essence += amount;
        Debug.Log($"Essence added: {amount}. Total essence: {essence}");
    }

    public bool SpendEssence(int amount) 
    {
        if (essence >= amount) 
        {
            essence -= amount;
            Debug.Log($"Essence spent: {amount}. Remaining essence: {essence}");
            return true;
        } 
        else 
        {
            Debug.Log("Not enough essence to spend.");
            return false;
        }
    }
}
