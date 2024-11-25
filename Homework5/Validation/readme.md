# ArsenalFans

## Validation

### FeedbackViewModel
Data in the `FeedbackViewModel` model is validated using the FluentValidation library.

### PlayerViewModel
Data validation in the `PlayerViewModel` model is done using built-in validation attributes.
Additionally, a custom attribute `FootballPositionAttribute` has been created to ensure that the specified player position matches one of the four valid football positions: Goalkeeper, Defender, Midfielder, Forward.

The new custom attribute and FluentValidation validator can be found in the `Validation` folder of the `ArsenalFansWebApp` project.