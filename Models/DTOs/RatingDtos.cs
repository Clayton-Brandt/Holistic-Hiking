namespace Holistic_Hiking.Models.DTOs;

public class RateTrailDto
{
    public int TrailId { get; set; }
    public int Value { get; set; }  // 1–5
}

public class TrailRatingSummaryDto
{
    public int TrailId { get; set; }
    public double Average { get; set; }   // 0 if no ratings
    public int Count { get; set; }
    public int? MyRating { get; set; }    // null if not logged in or hasn't rated
}