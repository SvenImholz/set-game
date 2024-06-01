# Game

## Create Game request
```http request
POST api/game/create
```
Optional query parameters:
```json
{
  "player": "00000000-0000-0000-0000-000000000000"
}
```

## Create Game response
Success
```http status code
201 Created
```

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "player": "00000000-0000-0000-0000-000000000000",
  "deck": {
    "id": "00000000-0000-0000-0000-000000000000",
    "cards": [
      {
        "id": "00000000-0000-0000-0000-000000000000"
      }
    ]
  },
  "sets": [
    {
      "cards": [
        {
          "id": "00000000-0000-0000-0000-000000000000"
        },
        {
          "id": "00000000-0000-0000-0000-000000000000"
        },
        {
          "id": "00000000-0000-0000-0000-000000000000"
        }
      ]
    }
  ],
  "status": "CREATED",
  "createdAt": "2021-01-01T00:00:00Z",
  "updatedAt": "2021-01-01T00:00:00Z"
}
```
