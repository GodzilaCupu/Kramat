using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Player Event Handler", menuName = "ScriptibleObject/Player/Event Handler")]
public class PlayerEventHandlerSO : ScriptableObject
{
    #region Senter
    public UnityAction e_Lighting;

    public void LightingEvent() => e_Lighting?.Invoke();

    #endregion

    #region Grab item
    public UnityAction e_GrabItem;

    public void GrabEvent() => e_GrabItem?.Invoke();

    #endregion
}
