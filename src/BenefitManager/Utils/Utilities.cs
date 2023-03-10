namespace PBM {
  public static class Utils {

    public static DateOnly TodaysDateOnly => DateOnly.FromDateTime(DateTime.Now);

    public static DateTime DateOnlyToDateTime(DateOnly date) => date.ToDateTime(TimeOnly.MinValue);

    public static void Write(string? msg = null) => System.Diagnostics.Debug.WriteLine(msg ?? "");
  }
}
