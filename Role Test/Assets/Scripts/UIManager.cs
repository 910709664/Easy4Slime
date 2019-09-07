using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{


    //开始游戏
    public void OnStartGame()
    {
        SceneManager.LoadScene(1);
    }
    //结束游戏
    public void OnExitGame()
    {
        Application.Quit();
    }

    //private Transform origionalSlot;
    //private GameObject itemParent;
    //private GameObject item;
    //private float item_x;
    //private float item_y;
    //private Vector2 itemSize;
    //private bool isDragging = false; //默认false,否则OnPointEnter会一直调用产生BUG

    /// <summary>
    /// 添加CanvasGroup组件，在物品拖动时blocksRaycasts设置为false;
    /// 让鼠标的Pointer射线穿过Item物体检测到UI下层的物体信息
    /// </summary>

    //private CanvasGroup itemCanvasGroup;

    //public string goTag = null;

    //private void Awake()
    //{
    //    itemCanvasGroup = this.GetComponent<CanvasGroup>();
    //    item = this.transform.gameObject;
    //    item_x = item.GetComponent<Image>().GetPixelAdjustedRect().width;
    //    item_y = item.GetComponent<Image>().GetPixelAdjustedRect().height;
    //    itemParent = GameObject.Find("Item");
    //}

    //public void OnPointerEnter(PointerEventData eventData)
    //{   //当鼠标在面板外(Canvas)
    //    if (eventData.pointerCurrentRaycast.depth == 0 && isDragging == true)
    //    {
    //        SetOrigionalPos(this.gameObject);
    //        return;
    //    }

    //    goTag = eventData.pointerCurrentRaycast.gameObject.tag;
    //    Debug.Log("Tag:" + goTag);

    //    if (goTag != null && isDragging == true)
    //    {
    //        if (goTag == "Grid")//如果为空格子则放到空格子
    //        {
    //            SetCurrentSlot(eventData);
    //        }

    //        else if (goTag == "Item")//如果为道具则交换
    //        {
    //            SwapItem(eventData);
    //        }
    //        else
    //        {
    //            SetOrigionalPos(this.gameObject);//若都不是则返回原位
    //        }
    //    }

    //}

    //public void OnBeginDrag(PointerEventData eventData)
    //{   //开始拖拽时记录当前的位置
    //    origionalSlot = this.GetComponent<Transform>().parent;
    //    isDragging = true;
    //    itemCanvasGroup.blocksRaycasts = true;
    //    item.transform.SetParent(itemParent.transform, false);
    //    放到最底层防止被挡住
    //    item.transform.SetAsLastSibling();
    //    可以不用关心当前及父对象的中心点及锚点的情况而直接设置宽高
    //    item.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, item_x);
    //    item.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, item_y);
    //}

    //public void OnDrag(PointerEventData eventData)
    //{
    //    itemCanvasGroup.blocksRaycasts = false;
    //    DragPos(eventData);

    //}

    //public void OnEndDrag(PointerEventData eventData)
    //{
    //    OnPointerEnter(eventData);
    //    itemCanvasGroup.blocksRaycasts = true;
    //    isDragging = false;
    //}


    //item复位
    //public void SetOrigionalPos(GameObject go)
    //{
    //    go.transform.SetParent(origionalSlot);
    //    大小一致
    //    go.GetComponent<RectTransform>().anchoredPosition =
    //        origionalSlot.GetComponent<RectTransform>().anchoredPosition;
    //    itemCanvasGroup.blocksRaycasts = true;
    //}
    //设置item到当前鼠标的Slot
    //public void SetCurrentSlot(PointerEventData eventData)
    //{
    //    if (eventData.pointerCurrentRaycast.gameObject.tag == "Grid")
    //    {
    //        Transform CurrentSlot = eventData.pointerCurrentRaycast.gameObject.transform;
    //        this.transform.SetParent(CurrentSlot);
    //        填充格子
    //        this.GetComponent<RectTransform>().anchoredPosition =
    //            CurrentSlot.GetComponent<RectTransform>().anchoredPosition;

    //    }
    //    else if (eventData.pointerCurrentRaycast.gameObject.tag == "Item")
    //    {
    //        找到物体的父亲
    //        Transform CurrentSlot = eventData.pointerCurrentRaycast.gameObject.transform.parent;
    //        this.transform.SetParent(CurrentSlot);
    //        this.GetComponent<RectTransform>().anchoredPosition =
    //            CurrentSlot.GetComponent<RectTransform>().anchoredPosition;
    //    }
    //}
    //交换item
    //交换两个物体
    //     由于拖放中，正被拖放的物体没有Block RayCast
    //     具体思路：
    //         1.记录当前射线照射到的物体（Item2）
    //         2.获取Item2的parent的位置信息，并把item1放过去
    //         3.把Item2放到Item1所在的位置
    //public void SwapItem(PointerEventData eventData)
    //{
    //    GameObject targetItem = eventData.pointerCurrentRaycast.gameObject;
    //    SetCurrentSlot(eventData);
    //    SetOrigionalPos(targetItem);
    //}
    //将鼠标位置赋给item
    //public void DragPos(PointerEventData eventData)
    //{
    //    RectTransform RectItem = item.GetComponent<RectTransform>();
    //    Vector3 globalMousePos;
    //    将屏幕空间上的点转换为位于给定RectTransform平面上的世界空间中的位置。cam参数应该是与屏幕点相关的相机。
    //    对于Canvas设置为“Screen Space -Overlay mode”模式的情况，cam参数应该为null。
    //    if (RectTransformUtility.ScreenPointToWorldPointInRectangle(item.transform as RectTransform, eventData.position, eventData.pressEventCamera, out globalMousePos))
    //    {
    //        RectItem.position = globalMousePos;
    //    }
    //}
   
}


