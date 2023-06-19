using DG.Tweening;

using TMPro;

using UnityEngine;


public class Collisions : MonoBehaviour
{
    private int count;
    public TextMeshProUGUI countText;
    [SerializeField] GameObject canvas;


    [SerializeField] GameObject pickUpEffect;
    [SerializeField] float scaleUpDuration;
    [SerializeField] float increase;
    [SerializeField] Ease ease;
    [SerializeField] Animator anim;


    private void Start()
    {
        count = 0;
        SetCountText();
      

    }
    private void OnTriggerEnter(Collider other)
    {


       
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            GameObject glitterEffect = Instantiate(pickUpEffect, other.transform.position, other.transform.rotation);
            transform.DOScale(transform.lossyScale * increase, scaleUpDuration).SetEase(ease);
            count += 1;
            EventManager.Instance.PlaySFX("PickUpSound");
            SetCountText();
            Destroy(glitterEffect, 2);
        }

      
    }

    public void SetCountText()
    {
        countText.text = (count.ToString());
        anim.SetTrigger("PickedSnowflake");
      
        if (count >= 10)
        {
            canvas.GetComponent<UiManager>().OpenWinMenuPanel();
           
            Time.timeScale = 0;
        }
    }


}
