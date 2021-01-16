# Small repo for volumechanged event handler issue

This repo will:
- Start media playback
- Log every volumechanged event
- Set volume to 100 after playing
- Print the amount of times the event was invoked

The volumechanged event should only fire once, but does so two or three times (this is not reproducable).
