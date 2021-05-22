using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : Singleton<ShopManager>
{
    [SerializeField] private List<Material> CharacterMaterials = new List<Material>();
    [SerializeField] private List<Renderer> CharacterObjects = new List<Renderer>();
    [SerializeField] private List<Image> ColorHighlights = new List<Image>();
   
    public void Instantiate()
    {
        ChangeCharacterColor(SaveManager.Instance.CurrentSave.selectedColor);
    }
    
    
    public void ChangeCharacterColor(int ColorIndex)
    {
        ActivateSelectedColorUI(ColorIndex);
        foreach(Renderer bodyPart in CharacterObjects)
        {
            bodyPart.material = CharacterMaterials[ColorIndex];
        }
        SaveManager.Instance.CurrentSave.selectedColor = ColorIndex;
        SaveManager.Instance.Save();
    }
    public void ActivateSelectedColorUI(int colorIndex)
    {
        foreach (var colorhighlight in ColorHighlights)
        {
            colorhighlight.enabled = false;
        }
        ColorHighlights[colorIndex].enabled = true;
    }
}
