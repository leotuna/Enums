# Enums API
An API to get all enums of your app as JSON.

## Docs
```
/swagger
```

## Endpoint
```
/api/enums
```

## Example
### Enums
```
public enum Country
{
    [Description("Brazil")]
    Brazil = 55,

    [Description("United States")]
    UnitedStates = 1,
}

public enum Language
{
    [Description("C#")]
    CSharp = 1,

    [Description("Java")]
    Java = 2,

    [Description("JavaScript")]
    JavaScript = 3,
}
```

### Return
```
[
  {
    "name": "Country",
    "key": "UnitedStates",
    "value": 1,
    "description": "United States"
  },
  {
    "name": "Country",
    "key": "Brazil",
    "value": 55,
    "description": "Brazil"
  },
  {
    "name": "Language",
    "key": "CSharp",
    "value": 1,
    "description": "C#"
  },
  {
    "name": "Language",
    "key": "Java",
    "value": 2,
    "description": "Java"
  },
  {
    "name": "Language",
    "key": "JavaScript",
    "value": 3,
    "description": "JavaScript"
  }
]
```