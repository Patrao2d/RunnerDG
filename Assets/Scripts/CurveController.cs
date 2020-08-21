//
// CurveController.cs
//
// Author:
//       Devon O. <devon.o@onebyonedesign.com>
//
// Copyright (c) 2016 Devon O. Wolfgang
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.


using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CurveController : MonoBehaviour
{

    public Transform CurveOrigin;

    [Range(-500f, 500f)]
    [SerializeField]
    float startX = 0f;

    [Range(-500f, 500f)]
    [SerializeField]
    float startY = 0f;

    [Range(0f, 50f)]
    [SerializeField]
    float falloff = 0f;

    public float newX;
    public float newY;
    public float currentX = 0;
    public float currentY = 0;

    float yVelocity = 0.0f;
    float xVelocity = 0.0f;

    private Vector2 bendAmount = Vector2.zero;

    // Global shader property ids
    private int bendAmountId;
    private int bendOriginId;
    private int bendFalloffId;

    void Start()
    {
        bendAmountId = Shader.PropertyToID("_BendAmount");
        bendOriginId = Shader.PropertyToID("_BendOrigin");
        bendFalloffId = Shader.PropertyToID("_BendFalloff");
        currentX = startX;
        currentY = startY;
        InvokeRepeating("NewValues", 1.5f, 10.5f);
    }

    void Update()
    {
        currentX = Mathf.SmoothDamp(currentX, newX, ref xVelocity, 3f);
        currentY = Mathf.SmoothDamp(currentY, newY, ref yVelocity, 1f);

        bendAmount.x = currentX;
        bendAmount.y = currentY;

        Shader.SetGlobalVector(bendAmountId, bendAmount);
        Shader.SetGlobalVector(bendOriginId, CurveOrigin.position);
        Shader.SetGlobalFloat(bendFalloffId, falloff);
    }

    private void NewValues()
    {
        newY = Random.Range(-8f, 0f);
        newX = Random.Range(-11f, 11f);
        //StartCoroutine(ChangeValuesCooldown());
    }

    private IEnumerator ChangeValuesCooldown()
    {
        yield return new WaitForSeconds(7f);
        NewValues();
    }

}