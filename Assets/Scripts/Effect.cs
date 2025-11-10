using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public AudioClip sound;
    public ParticleSystem effect;

    /// <summary>
    /// 在指定位置播放音效和特效（由业务脚本调用）
    /// </summary>
    public void PlayEffect(Vector3 pos)
    {
        if (sound != null)
            AudioSource.PlayClipAtPoint(sound, pos);

        if (effect != null)
        {
            // 实例化并播放特效，自动销毁
            ParticleSystem eff = Instantiate(effect, pos, Quaternion.identity);
            eff.Play();
            Destroy(eff.gameObject, eff.main.duration + eff.main.startLifetime.constantMax);
        }
    }
}
