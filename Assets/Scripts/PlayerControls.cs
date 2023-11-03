using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class PlayerControls : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 offset;

    private float maxLeft;
    private float maxRight;
    private float maxUp;
    private float maxDown;

    void Start()
    {
        // Gán camera chính trong scene vào biến mainCam
        mainCam = Camera.main;

        // Bắt đầu coroutine SetBoundaries()
        StartCoroutine(SetBoundaries());
    }

    void Update()
    {
        // Kiểm tra nếu có ngón tay nào đang chạm vào màn hình
        if (Touch.fingers[0].isActive)
        {
            // Lấy thông tin về cử chỉ cảm ứng từ ngón tay đầu tiên
            Touch myTouch = Touch.activeTouches[0];
            Vector3 touchPos = myTouch.screenPosition;

            // Chuyển đổi tọa độ màn hình thành tọa độ trong thế giới game
            touchPos = mainCam.ScreenToWorldPoint(touchPos);

            // Xử lý khi ngón tay bắt đầu chạm vào màn hình
            if (Touch.activeTouches[0].phase == TouchPhase.Began)
            {
                // Tính offset giữa vị trí ngón tay và vị trí đối tượng
                offset = touchPos - transform.position;
            }

            // Xử lý khi ngón tay di chuyển trên màn hình
            if (Touch.activeTouches[0].phase == TouchPhase.Moved)
            {
                // Cập nhật vị trí của đối tượng theo vị trí ngón tay và offset
                transform.position = new Vector3(touchPos.x - offset.x, touchPos.y - offset.y, 0);
            }

            // Xử lý khi ngón tay không di chuyển
            if (Touch.activeTouches[0].phase == TouchPhase.Stationary)
            {
                // Cập nhật vị trí của đối tượng theo vị trí ngón tay và offset
                transform.position = new Vector3(touchPos.x - offset.x, touchPos.y - offset.y, 0);
            }

            // Giới hạn vị trí của đối tượng trong khoảng maxLeft, maxRight, maxDown, maxUp
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, maxLeft, maxRight),
                                             Mathf.Clamp(transform.position.y, maxDown, maxUp), 0);
        }
    }

    private void OnEnable()
    {
        // Kích hoạt hỗ trợ cảm ứng nâng cao
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        // Tắt hỗ trợ cảm ứng nâng cao
        EnhancedTouchSupport.Disable();
    }

    private IEnumerator SetBoundaries()
    {
        // Đợi 0.4 giây
        yield return new WaitForSeconds(0.4f);

        // Tính toán và gán giá trị maxLeft, maxRight, maxDown, maxUp
        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(0.10f, 0)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.9f, 0)).x;
        maxDown = mainCam.ViewportToWorldPoint(new Vector2(0, 0.05f)).y;
        maxUp = mainCam.ViewportToWorldPoint(new Vector2(0, 0.9f)).y;
    }
}
