using UnityEngine;
using TMPro;
public class SelectionUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI statusText;
    [SerializeField] private MoveByClicking selector;

    private void OnEnable()
    {
        selector.OnAgentSelected += HandleAgentSelected;
    }

    private void OnDisable()
    {
        selector.OnAgentSelected -= HandleAgentSelected;
    }

    private void HandleAgentSelected(GameObject selected)
    {
        if(selected != null)
        {
            statusText.text =$"Selected: {selected.name}";
        }
        else
        {
            statusText.text = "No agent selected";
        }
    }
}
