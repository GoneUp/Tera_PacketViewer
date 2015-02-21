namespace Data.Enums
{
    public enum CheckNameResult
    {
        Ok = 0,

        UnavaliableLatter = 1,
        MaximumLengthIs16 = 2,
        MinimumLengthIs2 = 3,

        CharacterNameMustBeAlphaNumericWithAMaximumLengthOfMax = 4,
        YouCantUseThatWordInCharacterName = 5,
        YouCantUseSpacesInCharacterName = 6,
        YouCantUseBannedWordsInCharacterName = 7,
        ThisSsNotAcceptableCharacterName = 8,

        //9 You cant use incompleted Korean in CHaracter name.
        //10 You cant use axpanded Korean in Character name.
        
        CharacterNameContainsAnUnavailableWord = 11,

        //12 You cant use Chinese characters in Character name.

        //...
    }
}