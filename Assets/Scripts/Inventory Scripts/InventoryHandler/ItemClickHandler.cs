using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemClickHandler : MonoBehaviour
{
    public Inventory _Inventory;

    public KeyCode _Key;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_Key))
        {
            FadeToColor(_button.colors.pressedColor);

            _button.onClick.Invoke();
        }
        else if (Input.GetKeyUp(_Key))
        {
            FadeToColor(_button.colors.normalColor);
        }
    }

    void FadeToColor(Color color)
    {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color, _button.colors.fadeDuration, true, true);
    }

    public void OnItemClicked()
    {
        ItemDragHandler dragHandler = gameObject.transform.Find("Image").GetComponent<ItemDragHandler>();

        IInventoryItem item = dragHandler.Item;

        Debug.Log(item.Name);

        _Inventory.UseItem(item);

        item.OnUse();
    }
}
