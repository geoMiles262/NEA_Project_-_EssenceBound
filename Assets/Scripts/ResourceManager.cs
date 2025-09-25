using UnityEngine;

public class ResourceManager : MonoBehaviour 
{
    public static ResourceManager Instance { get; private set; }

    [SerializeField] public int essence = 0;

    public event System.Action<int> OnEssenceChanged;
    public int CurrentEssence => essence;

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

    

    public void AddEssence(int amount) 
    {
        essence += amount;
        Debug.Log($"Essence added: {amount}. Total essence: {essence}");
        OnEssenceChanged?.Invoke(essence);
    }

    public bool SpendEssence(int amount) 
    {
        if (essence >= amount) 
        {
            essence -= amount;
            Debug.Log($"Essence spent: {amount}. Remaining essence: {essence}");
            OnEssenceChanged?.Invoke(essence);
            return true;
        } 
        else 
        {
            Debug.Log("Not enough essence to spend.");
            return false;
        }
    }
}
