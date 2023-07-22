using UnityEngine;
using UnityEngine.UI;

public class TextElementLinker : MonoBehaviour
{
    public Text linkedText; // Reference to the UI Text element

    void Awake()
    {
        // Automatically find the UI Text component on this GameObject if not assigned in the Inspector
        if (linkedText == null)
        {
            linkedText = GetComponent<Text>();
        }
    }
}
