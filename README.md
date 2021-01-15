# Small repo for volumechanged event handler issue

This repo will:
- Start media playback
- Log every volumechanged event
- Set volume to 50 after playing
- Set volume back to 100 after a second

The volumechanged event should only fire twice, but does so six times (three per volume change).
