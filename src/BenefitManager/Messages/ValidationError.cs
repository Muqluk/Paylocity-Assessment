/*
  TODO:  Not entirely convinced this is as useful as I'd first considered.
         Likely going to remove it - but for now it can stay.
*/

namespace PBM.Messages {
  public static class ValidationError {

    #region Person

    #region First & Last Names



    #endregion

    #region Date of Birth

    public static string MinAgeNotMet => "The date of birth provided is invalid as it is less than 0.";
    public static string MaxAgeExceeded => $"The date of birth provided is invalid as it exceeds the configured Maximum Age value of {Constants.MaxPersonAge}";

    #endregion

    #endregion

  }
}
