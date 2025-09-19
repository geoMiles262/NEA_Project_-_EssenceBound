using UnityEngine;

public class EssenceTester : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResourceManager.Instance.AddEssence(100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
