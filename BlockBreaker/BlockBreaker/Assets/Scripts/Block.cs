using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakAudio;
    [SerializeField] GameObject blockParticleEffects;
    [SerializeField] Sprite[] hitSprites;

    // Cached references
    Level level;

    // States
    [SerializeField] int timeHits;

    void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.BlocksCounter();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (tag == "Breakable")
        {
            PlayDestroyAudio();
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timeHits++;
        int maxHits = hitSprites.Length + 1;
        if (timeHits >= maxHits)
        {
            BlockDestroyer();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timeHits - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void BlockDestroyer()
    {
        level.BlockDestroyed();
        FindObjectOfType<GameSession>().AddToScore();
        // TriggerParticleEffects();
        Destroy(gameObject);
    }

    private void PlayDestroyAudio()
    {
        AudioSource.PlayClipAtPoint(breakAudio, Camera.main.transform.position, 0.2f);
    }

    private void TriggerParticleEffects()
    {
        GameObject particle = Instantiate(blockParticleEffects, transform.position, transform.rotation);
        Destroy(particle, 1f);
    }
}