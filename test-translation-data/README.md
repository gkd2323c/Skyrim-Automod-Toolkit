# Translation Studio Status Showcase

This folder contains a small XML + cache bundle for testing the standalone `SpookysAutomod.TranslationStudio` app.

## Files

- `status-showcase_english_chinese.xml`
- `status-showcase_english_chinese.xml.studio-cache.json`

## What You See After Opening

If the app is using the sidecar cache file for the opened XML, the entries map to these states:

| EDID | Expected State | Why |
| --- | --- | --- |
| `StatusShowcase_Pending` | `Pending` | Source and destination are still identical, and no cache entry exists |
| `StatusShowcase_Cached` | `Cached` | High-confidence cached translation is auto-applied on load |
| `StatusShowcase_Review` | `Review` | Low-confidence cached translation is loaded as review-only |
| `StatusShowcase_Edited` | `Edited` | Destination already differs from source and was not AI-applied at runtime |
| `StatusShowcase_AI` | `Pending` -> `AI` | Click `Translate This Entry` or `Translate Pending` to get an AI-applied entry |
| `StatusShowcase_Failed` | `Pending` -> `Failed` | Force a failed translation request to test the failed state |

## How To Exercise All Current States

### 1. Open The XML

Open:

- `[status-showcase_english_chinese.xml](/D:/SteamLibrary/steamapps/common/Skyrim%20Special%20Edition/Data/Skyrim-Automod-Toolkit/test-translation-data/status-showcase_english_chinese.xml)`

### 2. Make Sure The Matching Cache Is Used

For automatic cache loading to work, the app must resolve the sidecar file:

- `[status-showcase_english_chinese.xml.studio-cache.json](/D:/SteamLibrary/steamapps/common/Skyrim%20Special%20Edition/Data/Skyrim-Automod-Toolkit/test-translation-data/status-showcase_english_chinese.xml.studio-cache.json)`

If your `settings.json` uses a fixed global `aiTranslation.cacheFile`, either:

1. temporarily clear that setting so the app uses the sidecar cache next to the XML, or
2. copy the contents of this sidecar cache into your configured global cache file

## How To Trigger The Remaining Runtime States

### `AI`

Select `StatusShowcase_AI` and click `Translate This Entry`.

### `Failed`

Temporarily point the translation endpoint to an invalid URL or stop the local model service, then select `StatusShowcase_Failed` and click `Translate This Entry`.

## Cache Metadata

The cache file was generated against the current local translation context in this repository:

- model: `qwen3.5`
- context key: `21937C2AB5309AFDECED25FC9B6BECE9CBAB57B3B8FA92BD6F4838A0B49F8823`

If you change the model or translation prompts, the app will treat that as a different cache context, which is expected.
