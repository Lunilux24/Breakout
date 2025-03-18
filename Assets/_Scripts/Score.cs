using System.Collections;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI current;
    [SerializeField] private TextMeshProUGUI toUpdate;
    [SerializeField] private Transform TextContainer;
    [SerializeField] private float duration;
    [SerializeField] private Ease animationCurve;

    private float containerInitPosition;
    private float moveAmount;

    private void Start()
    {
        Canvas.ForceUpdateCanvases();
        current.SetText("0");
        toUpdate.SetText("0");
        containerInitPosition = TextContainer.localPosition.y;
        moveAmount = current.rectTransform.rect.height;
    }

    public void UpdateScore(int score)
    {
        toUpdate.SetText($"{score}");
        TextContainer.DOLocalMoveY(containerInitPosition + moveAmount, duration).SetEase(animationCurve);
        StartCoroutine(ResetCoinContainer(score));
    }

    private IEnumerator ResetCoinContainer(int score)
    {
        yield return new WaitForSeconds(duration);
        current.SetText($"{score}");
        Vector3 localPosition = TextContainer.localPosition;
        TextContainer.localPosition = new Vector3(localPosition.x, containerInitPosition, localPosition.z);
    }
}
