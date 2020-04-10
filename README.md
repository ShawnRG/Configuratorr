# Configuratorr
![.NET Core](https://github.com/ShawnRG/Configuratorr/workflows/.NET%20Core/badge.svg)
Configuration Tool for a HTPC download box

## Features (so far..)
- Add indexers defined in Jackett to Sonarr and/or Radarr

---

## Usage
```
configuratorr <tool> <arguments>
```

### `migrate-indexers`
This is used for adding the indexers defined in Jackett to Sonarr and/or Radarr

**Arguments**
| Name    | Required | Description                  |
|---------|:--------:|------------------------------|
| apikey  |    Yes   | Your Jackett API key         |
| jackett |    Yes   | Jacket config root directory |
| sonarr  |    No    | Sonarr config root directory |
| radarr  |    No    | Radarr config root directory |
